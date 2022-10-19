using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordsCounterLib
  {

  public class WordsCounter
    {

    static public Dictionary<string, int> MTCount(string fullText)
      {

      ConcurrentDictionary<string, int> output = new ConcurrentDictionary<string, int>();

      try
        {
        Regex regex = new Regex(@"\w+");
        MatchCollection matches = regex.Matches(fullText);
        if (matches.Count > 0)
          {
          Parallel.ForEach(matches.OfType<Match>(), match =>
          {
            string formattedMatch = match.Value.ToString();
            output.AddOrUpdate(formattedMatch, 1, (key, oldValue) => oldValue + 1);
          });
          }
        }
      catch (Exception ex)
        {

        Console.WriteLine(ex);

        }

      return output.OrderByDescending(item => item.Value).ToDictionary(key => key.Key, value => value.Value);

      }
    }
  }