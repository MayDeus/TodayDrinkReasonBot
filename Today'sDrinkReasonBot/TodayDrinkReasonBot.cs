using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using TodayDrinkReasonBot.Models;

namespace TodayDrinkReasonBot
{
    public class TodayDrinkReasonBot
    {
        private static ITelegramBotClient bot = new TelegramBotClient("5410794636:AAGbsEqho2Abi5GmgPZ8uCERA7yn6nmET8s");

        private KeyboardButton[] buttons = new KeyboardButton[] { "Повод на сегодня", "Повод на завтра" };

        private HolidaysPage holidayPage = new HolidaysPage();

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (DateTime.Now.Date != holidayPage.LoadDate.Date)
                holidayPage = new HolidaysPage();

            // Кнопочки 
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            ReplyKeyboardMarkup replyButtons = new ReplyKeyboardMarkup(buttons);
            replyButtons.ResizeKeyboard = true;
            replyButtons.OneTimeKeyboard = true;

            // Действия бота

            if (update.Type == UpdateType.Message)
            {
                var message = update.Message;
                if (string.IsNullOrEmpty(message.Text))
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Выбери на когда тебе нужен повод из панели!");
                    return;
                }

                if (message.Text.ToLower() == "/start")
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Привет! Думаешь, что пить без повода это алкоголизм? Спокойно, ведь это особый день!");
                    Message sentMessage = await botClient.SendTextMessageAsync(message.Chat, "Ну как, готов узнать повод для пьянки?", replyMarkup: replyButtons);
                    return;
                }

                if (message.Text.ToLower() == "повод на сегодня")
                {
                    await botClient.SendTextMessageAsync(message.Chat, holidayPage.TodayHolidayText);
                    await botClient.SendPhotoAsync(message.Chat, photo: Resources.GetRandomPicture());
                    return;
                }

                if (message.Text.ToLower() == "повод на завтра")
                {
                    await botClient.SendTextMessageAsync(message.Chat, holidayPage.TommorowHolidayText);
                    await botClient.SendPhotoAsync(message.Chat, photo: Resources.GetRandomPicture());
                    return;
                }

                await botClient.SendTextMessageAsync(message.Chat, "Выбери на когда тебе нужен повод из панели!");
            }
        }

        public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }

    }
}
