using System;
using System.Collections.Generic;

namespace TodayDrinkReasonBot.Models
{
    public static class Resources
    {
        private static readonly Dictionary<int, string> SaltPhrases = new Dictionary<int, string>
        {
            { 0, "Отличный повод собраться с друзьми, правда?" },
            { 1, "Не ну тут грех не выпить!" },
            { 2, "Сегодня определенно стоит взять побольше выпивки..." },
            { 3, "Ну такое нельзя пропускать, скорей зови друзей выпить!" },
            { 4, "В такой день и не пить? Тебе не стыдно?" }
        };

        private static readonly Dictionary<int, string> PicturePaths = new Dictionary<int, string>
        {
            { 0, "https://resizer.mail.ru/p/7855035a-ddb8-5d6a-a17d-39f18345dabd/AQAC9aqFv8PttNCJw7KTFRetHUairgdxdei2ETmLiH-wsgZ147tE5vP62JrjNQeTwycz7WSpD8JEAlg5MVvudEoe87c.jpg" },
            { 1, "https://s00.yaplakal.com/pics/pics_original/1/8/2/14751281.jpg" },
            { 2, "https://www.film.ru/sites/default/files/filefield_paths/jnzcrazjlvc2lcbf25p63cf2eu.jpg" },
            { 3, "https://memepedia.ru/wp-content/uploads/2017/08/игорь-николаев-с-пивом-оригинал.jpg" },
            { 4, "https://cs13.pikabu.ru/images/big_size_comm/2021-04_2/1617970005103037.jpg" }
        };

        public static string GetRandomPicture()
        {
            var rnd = new Random();
            var id = rnd.Next(PicturePaths.Count);

            return PicturePaths[id];
        }

        public static string GetRandomPhrase()
        {
            var rnd = new Random();
            var id = rnd.Next(SaltPhrases.Count);

            return SaltPhrases[id];
        }

    }
}
