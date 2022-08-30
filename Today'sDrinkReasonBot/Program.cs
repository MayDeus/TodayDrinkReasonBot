using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.ReplyMarkups;
using TodayDrinkReasonBot.Models;

namespace TodayDrinkReasonBot
{

    public class TelegramBot
    {
        private static ITelegramBotClient bot = new TelegramBotClient("5410794636:AAGbsEqho2Abi5GmgPZ8uCERA7yn6nmET8s");

        private KeyboardButton[] buttons = new KeyboardButton[] { "Повод на сегодня", "Повод на завтра" };

        private HolidaysPage holidayPage;

        //public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        //{
            
        //    // Кнопочки 
        //    Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
        //    ReplyKeyboardMarkup replyButtons = new ReplyKeyboardMarkup(buttons);
        //    replyButtons.ResizeKeyboard = true;
        //    replyButtons.OneTimeKeyboard = true;

        //    HolidaysPage test = new HolidaysPage();

        //}

        //public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        //{
        //    // Некоторые действия
        //    Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        //}


        static void Main(string[] args)
        {
            
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);
            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };

            var tdrBot = new TodayDrinkReasonBot();

            bot.StartReceiving(
                tdrBot.HandleUpdateAsync,
                tdrBot.HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }
    }
}