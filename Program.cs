// Урок 8. Потоки и буферизация
// Объедините две предыдущих работы (практические работы 2 и 3): поиск файла и поиск текста в файле написав утилиту.
// которая ищет файлы определенного расширения с указанным текстом. 
// Рекурсивно. Пример вызова утилиты: utility.exe txt текст.

using System;
using System.IO;

class SearchUtility
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: utility.exe [extension] [text]");
            return;
        }

        string extension = args[0];
        string searchText = args[1];

        string currentDirectory = Directory.GetCurrentDirectory();
        SearchFiles(currentDirectory, extension, searchText);
    }

    static void SearchFiles(string directory, string extension, string searchText)
    {
        try
        {
            string[] files = Directory.GetFiles(directory, $"*.{extension}");

            foreach (string file in files)
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    string fileContent = reader.ReadToEnd();
                    if (fileContent.Contains(searchText))
                    {
                        Console.WriteLine($"Found text '{searchText}' in file: {file}");
                    }
                }
            }

            string[] subdirectories = Directory.GetDirectories(directory);
            foreach (string subdirectory in subdirectories)
            {
                SearchFiles(subdirectory, extension, searchText);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }
    }
}


// Этот код представляет утилиту поиска файлов конкретного расширения с указанным текстом в них.
// Код проходит через все файлы в указанном каталоге и его подкаталогах, ищет файлы с заданным расширением,
// и затем осуществляет поиск текста в каждом найденном файле. 
// Если указанный текст найден в файле, утилита выводит сообщение о нахождении этого текста в файле.