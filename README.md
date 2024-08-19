# SimpleMessenger

Это руководство поможет вам настроить и запустить приложение SimpleMessenger с использованием Docker. Приложение состоит из базы данных PostgreSQL и API-сервиса на .NET Core. Ниже приведены шаги, чтобы запустить приложение.

## Предварительные требования

Перед началом убедитесь, что у вас установлены следующие инструменты:

- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

## Начало работы

### Шаг 1: Клонирование репозитория

Начните с клонирования репозитория на ваш локальный компьютер:

```bash
git clone https://github.com/Mu4lka/SimpleMessenger.Backend.git
```

### Шаг 2: Доступ к фронтенду
![SimpleMessenger Frontend](https://github.com/Mu4lka/SimpleMessanger.Frontend/blob/main/simpleMessangerFront.png)

Приложение также содержит в себе frontend часть, поэтому выполните следующую команду:

```bash
git clone https://github.com/Mu4lka/SimpleMessanger.Frontend.git
```

### Шаг 3: Сборка и запуск приложения

Чтобы собрать и запустить приложение, выполните следующую команду в корневом каталоге вашего проекта:

```bash
cd SimpleMessenger.Backend\deploy
docker-compose up --build
```

Эта команда соберет образ `simplemessengerapi` и запустит оба сервиса: базу данных и API.

### Шаг 4: Проверьте, что приложение работает

Когда контейнеры будут запущены, вы можете убедиться, что приложение работает.

- База данных PostgreSQL будет доступна по адресу `localhost:5432`.
- API будет доступно на порту, указанном в `Dockerfile`.
- 
## Сервисы

### База данных (`db`)

- **Образ**: `postgres:15.3`
- **Переменные окружения**:
  - `POSTGRES_USER`: postgres
  - `POSTGRES_PASSWORD`: simpleMessenger
  - `POSTGRES_DB`: simpleMessenger
- **Порты**: `5432:5432`
- **Тома**: `./pgdata:/var/lib/postgresql/data`

### API (`simplemessenger.api`)

- **Образ**: `simplemessengerapi`
- **Контекст сборки**: `scr/SimpleMessenger.Api/Dockerfile`

## Остановка приложения

Чтобы остановить приложение, выполните команду:

```bash
docker-compose down
```

Эта команда остановит все работающие контейнеры.
