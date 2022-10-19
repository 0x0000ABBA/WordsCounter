using System;
using System.ServiceModel;

namespace CounterHost
  {
  internal class Host
    {
    static void Main()
      {
      using (var host = new ServiceHost(typeof(WordsCounterService.ServiceCount)))
        {
        host.Open();
        Console.WriteLine("Host started");
        Console.ReadLine();
        }
      }
    }
  }
