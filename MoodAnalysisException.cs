using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MoodAnalyser
{
    public class MoodAnalysisException : Exception
    {
        public enum error { Empty, Null, Unknown};

        public error errorIs;

        public string message;

        public MoodAnalysisException(string message,string mood = null) : base(message)
        {
            errorIs = mood == null ? error.Null : (mood == "" ? error.Empty : error.Unknown) ;
        }
    }
}
