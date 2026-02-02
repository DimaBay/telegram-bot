# Простой Telegram-бот (C#, .NET 8)

## Как работает

1. Бот создаётся из токена (переменная `TELEGRAM_BOT_TOKEN`).
2. Запускается long polling: бот запрашивает у Telegram обновления в цикле.
3. Для каждого входящего сообщения вызывается обработчик:
   - **Команда /start** — ответ «Привет! Отправь любое сообщение — я отвечу.»
   - **Любой другой текст** — ответ «Ты написал: {текст}» (эхо).
4. Работает пока не нажать Ctrl+C.

## Запуск

```bash
# 1. Перейти в папку проекта
cd "c:\Users\telegram-bot"

# 2. Восстановить пакеты
dotnet restore

# 3. Задать токен и запустить (PowerShell)
$env:TELEGRAM_BOT_TOKEN = "ВАШ_ТОКЕН_ОТ_@BotFather"
dotnet run

# Либо в одной строке (cmd):
# set TELEGRAM_BOT_TOKEN=ВАШ_ТОКЕН_ОТ_@BotFather && dotnet run
```

Токен получите у [@BotFather](https://t.me/BotFather) в Telegram (команда `/newbot`).
