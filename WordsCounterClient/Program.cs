using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using WordsCounterClient.ServiceCount;

namespace WordsCounterClient
  {
  public class ProgramServiceCount : IServiceCountCallback
    {
    static void Main()
      {
      try
        {
        Console.WriteLine("Укажите путь до файла с текстом и нажмите Enter");
        string inputPath = Console.ReadLine();
        if (inputPath == null) throw new Exception("Неверный путь");
        string fullText = File.ReadAllText(inputPath);

        ServiceCountClient client = new ServiceCountClient(
        new System.ServiceModel.InstanceContext(new ProgramServiceCount())
        );

        client.CountWords(fullText);
        Thread.Sleep(10000); // Для того чтобы главный поток дожидался Callback, а не сразу заканчивал свою работу

        }
      catch (Exception ex)
        {
        Console.WriteLine(ex);
        }
      }

    public void CountWordsCallback(Dictionary<string, int> output)
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
          sw.WriteLine(keyValuePair.Key + " " + keyValuePair.Value.ToString());
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
