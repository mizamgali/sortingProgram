using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sort
{
    public static class Sort
    {
        /// <summary>
        /// Запуск
        /// </summary>
        public static void StartSort(string dirPath)
        {
            CheckFiles(dirPath);

        }

        /// <summary>
        /// Проверка Файлов
        /// </summary>
        /// <param name="dirPath">Путь Директории</param>
        private static void CheckFiles(string dirPath)
        {
            string[] files = Directory.GetFiles(dirPath);

            foreach (string file in files)
            {
                int extIndex = file.LastIndexOf('.');
                int nameIndex = file.LastIndexOf('\\');

                int extLenght = file.Length - extIndex;
                int nameLenght = file.Length - nameIndex - extLenght;

                string fileExt = file.Substring(extIndex);
                string fileName = file.Substring(nameIndex + 1, nameLenght - 1);

                string newDirPath = CreateDirectory(fileExt, dirPath);
                string newFilePath = newDirPath + "\\" + fileName + fileExt;

                File.Move(file, newFilePath);
            }

            MessageBox.Show("Сортировка успешно завершена!");
        }


        private static string CreateDirectory(string fileExt, string dirPath)
        {
            string newDirName;

            switch (fileExt)
            {
                case ".mp3": newDirName = "Музыка"; break;
                case ".mp4": newDirName = "Видео"; break;
                case ".txt": newDirName = "Документы"; break;
                case ".doc": newDirName = "Документы"; break;
                case ".pdf": newDirName = "ПДФ Файлы"; break;
                case ".bat": newDirName = "Исполняемые файлы"; break;
                case ".png": newDirName = "Картинки"; break;
                case ".jpg": newDirName = "Картинки"; break;
                case ".exe": newDirName = "Исполняемые файлы"; break;
                default: newDirName = "Другое"; break;

            }

            string newDirPath = dirPath + "\\" + newDirName;

            Directory.CreateDirectory(newDirPath);

            return newDirPath;
        }
    }
}
