using ezDictionary.Services.Models;
using ezDictionary.Services.Services;
using System;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = "I hate you bitch";

            var key = "trnsl.1.1.20180420T093654Z.f08eef8abc092cf0.c6d723d0624aed5f2c7083659c70ff0c761bd403";
            var url = "https://translate.yandex.net/api/v1.5/tr.json/translate?lang=ru-en";


            var wordTranslator = new TranslateService(key, url);

            url = "https://microsoft-translator-text.p.rapidapi.com/translate?to=ru&api-version=3.0&from=en&profanityAction=NoAction&textType=plain";

            var textTranslator = new TranslateService(key, url);

            Console.WriteLine("Пробуй перевести слово " + word);

            //wordTranslator.Translate(word).ContinueWith(x =>
            // {
            //     Console.WriteLine(x.Result?.Translations?.FirstOrDefault()?.Text);
            // });


            textTranslator.Translate(word).ContinueWith(x =>
            {
                Console.WriteLine("Перевод" + x.Result.Translations.FirstOrDefault().Text);
            });

            ToVoiceService vs = new ToVoiceService();

            ParametersBuilder parameters = new VoiceParametersBuilder();
            parameters.SetUrl("https://translate.google.com.vn/translate_tts");
            parameters.SetOriginLanguage(Lang.en);

            vs.SetParameters(parameters);

            vs.GetFile(word).ContinueWith(x =>
            {
                byte[] ms = x.Result;

                using (FileStream fs = new FileStream(word + ".mp3", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    fs.Write(ms, 0, ms.Length);
                }
            });

            Console.ReadKey();
        }
    }
}
