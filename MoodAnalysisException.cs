using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MoodAnalyser
{
    public class MoodAnalysisException : Exception
    {
        public enum error { Empty_Mood, Null_Mood, No_Such_Method, No_Such_Class, Null_Field, No_Such_Field };

        public error errorIs;

        public string message;

        public MoodAnalysisException(string message,error error) : base(message)
        {
            errorIs = error;
        }
    }
}
