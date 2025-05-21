# Crypto Tracker

Проєкт для відстеження цін на криптовалюти (BTC) з бекендом на .NET та фронтендом на Angular.

 Опис проекту

CryptoTracker— це система з мікросервісною архітектурою, яка складається з:

- **PriceFetcherService** — сервіс, який періодично отримує актуальні ціни на BTC через API.
- **PriceApiService** — API для отримання збережених цін з бази даних.
- **Frontend** — Angular SPA, що показує графік цін, максимальну та середню ціну за період.

## Структура репозиторію

```
CryptoTrackerSolution/
│
├── services/
│ ├── PriceFetcherService/
│ ├── PriceApiService/
│
├── frontend/
│ └── crypto-tracker-frontend/
│
├── Shared/
│ └── CryptoTracker.Shared.Domain/
│ └── CryptoTracker.Shared.Infrastructure/
│
├── .gitignore
└── README.md      
```

## Встановлення та запуск

### Передумови

- [.NET SDK 8.0+](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Node.js 18+ та npm](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli) (для локального запуску фронтенду)
- SQL Server 

### Запуск бекенду

Перейти у каталог сервісу, наприклад:
```
cd services/PriceFetcherService
```

Відновити залежності та зібрати проект:
```
dotnet restore
dotnet build
```

Запустити сервіс:
```
dotnet run
```

Повторити аналогічно для PriceApiService.

## Запуск фронтенду

Перейти у каталог фронтенду:
```
cd frontend/crypto-tracker-frontend
```

Встановити залежності:
```
npm install
```

Запустити dev-сервер Angular:
```
ng serve
```

Відкрити браузер і перейти за адресою:
```
http://localhost:4200
```

## Конфігурація
Конфігурації зберігаються у appsettings.json в кожному сервісі.

Рядок підключення до бази даних має бути правильно вказаний у appsettings.json.

### Міграції бази даних
Для роботи з міграціями використовується проект Fetcher.Infrastructure.
Відкрийте Package Manager Console у Visual Studio і виконайте:
1 Створення нової міграції:
```
Add-Migration <Ім'яМіграції>
```

2 Застосування міграцій до бази даних:
```
Update-Database 
```
