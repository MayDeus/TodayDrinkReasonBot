using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using TodayDrinkReasonBot.Models;

namespace TodayDrinkReasonBot.Models
{
    public class HolidaysPage
    {
        private const string TODAY_HOLIDAY_PATH = "https://nationaltoday.com/what-is-today/";
        private const string TOMMOROW_HOLIDAY_PATH = "https://nationaltoday.com/what-is-tomorrow/";

        public readonly DateTime LoadDate;

        private readonly HtmlDocument todayHolidayPage = new HtmlDocument();
        private readonly HtmlDocument tommorowHolidayPage = new HtmlDocument();

        public Holiday TodayHoliday { get; private set; }
        public Holiday TommorowHoliday { get; private set; }

        public string TodayHolidayText 
        {
            get 
            {
                return Translator.TranslateEngToRus($"{TodayHoliday.Title} - {TodayHoliday.Description}") + $" {Resources.GetRandomPhrase()}";
            }
        }

        public string TommorowHolidayText
        {
            get
            {
                return Translator.TranslateEngToRus($"{TommorowHoliday.Title} - {TommorowHoliday.Description}") + $" {Resources.GetRandomPhrase()}";
            }
        }

        public HolidaysPage()
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;

            var todayPageHtml = wc.DownloadString(TODAY_HOLIDAY_PATH);
            var tommorowPageHtml = wc.DownloadString(TOMMOROW_HOLIDAY_PATH);

            todayHolidayPage.LoadHtml(todayPageHtml);
            tommorowHolidayPage.LoadHtml(tommorowPageHtml);

            InitializeTodayHoliday();
            InitializeTommorowHoliday();

            LoadDate = DateTime.Now;
        }

        private void InitializeTodayHoliday()
        {
            HtmlNode link = todayHolidayPage.DocumentNode.SelectSingleNode("//div[@class='card-content']");
            var title = link.SelectSingleNode("//h3[@class='holiday-title']").InnerText;
            var description = link.SelectSingleNode("//p[@class='excerpt']").InnerText;
            TodayHoliday = new Holiday(title, description);
        }

        private void InitializeTommorowHoliday()
        {
            HtmlNode link = tommorowHolidayPage.DocumentNode.SelectSingleNode("//div[@class='card-content']");
            var title = link.SelectSingleNode("//h3[@class='holiday-title']").InnerText;
            var description = link.SelectSingleNode("//p[@class='excerpt']").InnerText;
            TommorowHoliday = new Holiday(title, description);
        }
        
    }
}
