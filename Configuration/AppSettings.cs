﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_VoiceTexterBot.Configuration
{
    public class AppSettings
    {
        /// <summary>
        /// Токен Telegram API
        /// </summary>
        public string BotToken { get; set; }

        /// <summary>
        /// Папка загрузки аудио файлов
        /// </summary>
        public string DownloadsFolder { get; set; }
        /// <summary>
        /// Имя файла при загрузке
        /// </summary>
        public string AudioFileName { get; set; }
        /// <summary>S
        /// Формат аудио при загрузке
        /// </summary>
        public string InputAudioFormat { get; set; }
        /// <summary>
        /// Формат аудио при загрузке
        /// </summary>
        public string OutputAudioFormat { get; set; }
        public int InputAudioBitrate { get; set; }
    }
}