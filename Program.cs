using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

var token = Environment.GetEnvironmentVariable("TELEGRAM_BOT_TOKEN")
    ?? throw new InvalidOperationException("Задайте переменную окружения TELEGRAM_BOT_TOKEN");

using var cts = new CancellationTokenSource();
var bot = new TelegramBotClient(token, cancellationToken: cts.Token);

bot.OnError += (ex, _) => { Console.WriteLine($"Ошибка: {ex.Message}"); return Task.CompletedTask; };

bot.OnMessage += async (message, _) =>
{
    var text = message.Text;
    if (string.IsNullOrEmpty(text)) return;

    if (text == "/start")
    {
        await bot.SendMessage(message.Chat.Id, "Привет! Отправь любое сообщение — я отвечу.");
        return;
    }
    await bot.SendMessage(message.Chat.Id, $"Ты написал: {text}");
};

var me = await bot.GetMe();
Console.WriteLine($"Бот @{me.Username} запущен. Нажми Ctrl+C для выхода.");
Console.ReadKey();
