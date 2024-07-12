docker-compose -f ./docker-compose_wo_back.yml -p docker_pm_wo_back --env-file .env up --no-deps --build -d --remove-orphans
pause