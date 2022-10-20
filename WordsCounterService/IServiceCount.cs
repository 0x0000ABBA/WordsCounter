using System.Collections.Generic;
using System.ServiceModel;

namespace WordsCounterService
  {
  [ServiceContract/*(CallbackContract = typeof(IServiceCountCallback))*/]
  public interface IServiceCount
    {
    [OperationContract]
        Dictionary<string, int> CountWords(string fullText);
    }
  public interface IServiceCountCallback
    {
    [OperationContract(IsOneWay = true)]
    void CountWordsCallback(Dictionary<string, int> output);
    }
  }

