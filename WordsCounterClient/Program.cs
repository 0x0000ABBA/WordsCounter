using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace WordsCounterClient
  {
  public class ProgramServiceCount 
    {
    static void Main()
      {
        try
        {
            Console.WriteLine("Укажите путь до файла с текстом и нажмите Enter");
            string inputPath = Console.ReadLine();
            if (inputPath == null) throw new Exception("Неверный путь");
            string fullText = File.ReadAllText(inputPath);

            using (var client = new ServiceReference1.ServiceCountClient())
            {
                Dictionary<string, int> a = client.CountWords(fullText);
                Write(a);
            };
        }
      catch (Exception ex)
        {
        Console.WriteLine(ex);
        }
      }

    private static async void Write(Dictionary<string, int> output)
      {
      try
        {
        if (output == null) throw new Exception("Слова не найдены");

        Console.WriteLine("Укажите путь до файла вывода и нажмите Enter");
        string outputPath = Console.ReadLine();

        if (outputPath == null) throw new Exception("Неверный путь");

        StreamWriter sw = new StreamWriter(outputPath);

        foreach (KeyValuePair<string, int> keyValuePair in output)
          {
          await sw.WriteLineAsync(keyValuePair.Key + " " + keyValuePair.Value.ToString());
          }
        sw.Close();

        }
      catch (Exception ex)
        {
        Console.WriteLine(ex);
        }
      }
    }
  }
