using System.Collections.Generic;
using System.ServiceModel;


namespace WordsCounterService
  {

  [ServiceBehavior]

  public class ServiceCount : IServiceCount
    {
    public Dictionary<string, int> CountWords(string fullText)
      {

      ServerUser user = new ServerUser() {
        operationContext = OperationContext.Current
        };

      Dictionary<string, int> output = WordsCounterLib.WordsCounter.MTCount(fullText);
            return output;
     // user.operationContext.GetCallbackChannel<IServiceCountCallback>().CountWordsCallback(output);

      }
    }
  }
