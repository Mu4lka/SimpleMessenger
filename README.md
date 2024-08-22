# SimpleMessenger

Это руководство поможет вам настроить и запустить приложение SimpleMessenger с использованием Docker. Приложение состоит из базы данных PostgreSQL и API-сервиса на .NET Core. Ниже приведены шаги, чтобы запустить приложение.

![SimpleMessenger Frontend](https://github.com/Mu4lka/SimpleMessenger/blob/main/simpleMessangerFront.png)

## Предварительные требования

Перед началом убедитесь, что у вас установлены следующие инструменты:

- [Git](https://git-scm.com/downloads)
- [Docker](https://www.docker.com/)

## Начало работы

### Шаг 1: Клонирование репозитория

- Создайте корневую папку и откройте в ней Git Bash

- Склонируйте репозиторий на ваш локальный компьютер:

```bash
git clone https://github.com/Mu4lka/SimpleMessenger.git
```

### Шаг 2: Сборка и запуск приложения

- Перейдите в каталог deploy:
  
```bash
cd deploy
```

- Запустите контейнеры:

```bash
docker-compose up --build
```

## Остановка приложения

- Чтобы остановить приложение, выполните команду:

```bash
docker-compose down
```
