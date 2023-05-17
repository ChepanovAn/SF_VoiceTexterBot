using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using SF_VoiceTexterBot;
using SF_VoiceTexterBot.Configuration;
using SF_VoiceTexterBot.Services;

namespace SF_VoiceTexterBot
{
    class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            // Объект, отвечающий за постоянный жизненный цикл приложения
            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => ConfigureServices(services)) // Задаем конфигурацию
                .UseConsoleLifetime() // Позволяет поддерживать приложение активным в консоли
                .Build(); // Собираем

            Console.WriteLine("Сервис запущен");
            // Запускаем сервис
            await host.RunAsync();
            Console.WriteLine("Сервис остановлен");
        }

        //static void ConfigureServices(IServiceCollection services)
        //{
        //    // Регистрируем объект TelegramBotClient c токеном подключения
        //    services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient("5916278027:AAFGEw31HrTigGvfe1jsQP09ruPqgjbz-Ek"));
        //    // Регистрируем постоянно активный сервис бота
        //    services.AddHostedService<Bot>();
        //}


        static void ConfigureServices(IServiceCollection services)
        {
            AppSettings appSettings = BuildAppSettings();
            services.AddSingleton(BuildAppSettings());

            services.AddSingleton<IStorage, MemoryStorage>();

            // Подключаем контроллеры сообщений и кнопок
            services.AddTransient<DefaultMessageController>();
            services.AddTransient<VoiceMessageController>();
            services.AddTransient<TextMessageController>();
            services.AddTransient<InlineKeyboardController>();

            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient("5916278027:AAFGEw31HrTigGvfe1jsQP09ruPqgjbz-Ek"));
            services.AddHostedService<Bot>();
            services.AddSingleton<IFileHandler, AudioFileHandler>();
        }

        static AppSettings BuildAppSettings()
        {
            return new AppSettings()
            {
                DownloadsFolder = "C:\\Users\\Анатолий\\source\\SF_VoiceTexterBot\\repos",
                BotToken = "5916278027:AAFGEw31HrTigGvfe1jsQP09ruPqgjbz-Ek",
                AudioFileName = "audio",
                InputAudioFormat = "ogg",
                OutputAudioFormat = "wav",
                InputAudioBitrate = 48000,
            };
        }

    }
}
