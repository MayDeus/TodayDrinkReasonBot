using System;
using System.Net;
using System.Text;
using System.Web;

namespace TodayDrinkReasonBot.Models
{
    public static class Translator
    {
        public const string RUSSIAN_LANGUAGE_SIGN = "ru";
        public const string ENGLISH_LANGUAGE_SIGN = "en";

        public const string URL_PATTERN = "https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}";

        public static string TranslateEngToRus(string text)
        {
            var url = string.Format(URL_PATTERN, ENGLISH_LANGUAGE_SIGN, RUSSIAN_LANGUAGE_SIGN, HttpUtility.UrlEncode(text));
            var webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;

            var result = webClient.DownloadString(url);
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return result;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
