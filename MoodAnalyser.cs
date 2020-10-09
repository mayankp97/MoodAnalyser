using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyser
    {
        public string AnalyseMood(string message)
        {
            message = message.ToLower();
            if (message == "i am in sad mood")
                return "SAD";
            else
                return "HAPPY";
        }
    }
}
