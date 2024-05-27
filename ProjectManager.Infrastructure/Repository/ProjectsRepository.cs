using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Abstractions;
using ProjectManager.Domain.Models;
using ProjectManager.Infrastructure.Entities;
using System.Diagnostics;

namespace ProjectManager.Infrastructure.Repository;

public class ProjectsRepository : IProjectsRepository
{
    private readonly ProjectManagerDbContext _context;

    public ProjectsRepository(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Project>> Get()
    {
        var projectEntities = await _context.Projects
         .AsNoTracking()
         .Include(a => a.DesignObjects)
         .ToListAsync();
        var projects = projectEntities
            .Select(b => new Project(b.Id, b.Cipher, b.Name))
            .ToList();
        return projects;
    }

    public async Task<int> Create(Project project)
    {
        var projectEntity = new ProjectEntity
        {
            Id = project.Id,
            Cipher = project.Cipher,
            Name = project.Name
        };
        await _context.Projects.AddAsync(projectEntity);
        await _context.SaveChangesAsync();

        return projectEntity.Id;
    }

    public async Task<int> Update(int id, string cipher, string name)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project is null)
        {
            throw new Exception("Project not found");
        }

        project.Id = id;
        project.Cipher = cipher;
        project.Name = name;

        await _context.SaveChangesAsync();

        return project.Id;
    }

    public async Task<int> Delete(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project is null)
        {
            throw new Exception("Project not found");
        }

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();

        return id;
    }
}
