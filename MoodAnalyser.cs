using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyser
    {
        public string message { get; set; }
        public MoodAnalyser()
        {
        }

        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        public string AnalyseMood(string message = null)
        {
            var messageCopy = message ?? this.message;
            
            try
            {
                if (messageCopy == null)
                    throw new MoodAnalysisException(messageCopy);
                if (messageCopy == "")
                    throw new MoodAnalysisException(messageCopy);
                messageCopy = messageCopy.ToLower();
                if (messageCopy == "i am in sad mood")
                    return "SAD";
                else
                    return "HAPPY";
            }
            catch (MoodAnalysisException ex)
            {
                return ex.message;
            }
            
        }
    }
}
