using ezDictionary.Services.Services;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = "I treat you right";

            var key = "trnsl.1.1.20180420T093654Z.f08eef8abc092cf0.c6d723d0624aed5f2c7083659c70ff0c761bd403";
            var url = "https://translate.yandex.net/api/v1.5/tr.json/translate?lang=ru-en";


            ITranslationService translate = new TranslateService(key, url);

            url = "https://microsoft-translator-text.p.rapidapi.com/translate?to=ru&api-version=3.0&from=en&profanityAction=NoAction&textType=plain";

            ITranslationService translate1 = new TranslateService(key, url);

            Console.WriteLine("Пробуй перевести слово " + word);

            var translation = translate1.Translate(word).ContinueWith(x =>
            {
                Console.WriteLine("Перевод" + x.Result);
            });

            ToVoiceService vs = new ToVoiceService();

            vs.GetFile(word).ContinueWith(x =>
            {

            });

            Console.ReadKey();
        }
    }
}
