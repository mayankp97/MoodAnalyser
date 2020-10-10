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
                    throw new MoodAnalysisException("You passed Null as mood",messageCopy);
                if (messageCopy == "")
                    throw new MoodAnalysisException("You passed Empty as mood", messageCopy);
                messageCopy = messageCopy.ToLower();
                if (messageCopy.Contains("sad"))
                    return "SAD";
                else
                    return "HAPPY";
            }
            catch (MoodAnalysisException exception)
            {
                throw exception;
            }

        }

        public override bool Equals(object obj1)
        {
            var copy = (MoodAnalyser)obj1;
            if (copy.message == this.message)
                return true;
            else
                return false;
        }
    }
        
}
