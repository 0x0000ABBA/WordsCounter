using System.Collections.Generic;
using System.ServiceModel;

namespace WordsCounterService
  {
  [ServiceContract(CallbackContract = typeof(IServiceCountCallback))]
  public interface IServiceCount
    {
    [OperationContract(IsOneWay = true)]
    void CountWords(string fullText);
    }
  public interface IServiceCountCallback
    {
    [OperationContract(IsOneWay = true)]
    void CountWordsCallback(Dictionary<string, int> output);
    }
  }

