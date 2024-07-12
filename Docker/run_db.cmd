docker-compose -f ./docker-compose_db.yml -p docker_pm_db --env-file .env up --no-deps --build -d --remove-orphans
pause