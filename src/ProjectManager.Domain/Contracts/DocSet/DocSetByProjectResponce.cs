namespace ProjectManager.Domain.Contracts.DocSet;

public record DocSetByProjectResponce(string? ProjectCipher,
                                      string? DesignObjectCode,
                                      string Mark,
                                      string Number,
                                      string FullComplectCipher);
