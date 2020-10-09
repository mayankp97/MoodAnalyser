using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MoodAnalyser
{
    class MoodAnalysisException : Exception
    {
        public enum error { Empty, Null, Unknown};

        public error errorIs;

        public string message;

        public MoodAnalysisException(string mood)
        {
            errorIs = mood == null ? error.Null : (mood == "" ? error.Empty : error.Unknown) ;
            message = errorIs == error.Null ? "Mood passed is Null" : 
                (errorIs == error.Empty ? "Mood Passed is Empty" : "Unknown Error");
        }
    }
}
