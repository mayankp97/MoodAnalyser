using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyserReflector
    {
        public static string Invoke(string methodName, string message = null,MoodAnalyser moodAnalyser = null)
        {
            

            try
            {
                var methodInfo = typeof(MoodAnalyser).GetMethod(methodName);
                var result = (string)methodInfo.Invoke(moodAnalyser ?? MoodAnalyserFactory.Initialize("MoodAnalyser"),
                    new object[] { message });
                return result;

            }
            catch (Exception)
            {

                throw new MoodAnalysisException("No Such Method Exists", MoodAnalysisException.error.No_Such_Method);
            }

        }

        public static void SetField(MoodAnalyser moodAnalyser, string FieldName,string message)
        {
            try
            {
                var m = moodAnalyser.GetType().GetProperty(FieldName);

                m.SetValue(moodAnalyser, message);

                if (moodAnalyser.message == null)
                    throw new Exception();
            }
            catch (Exception)
            {
                if (message == null)
                    throw new MoodAnalysisException("Cannot set null as field value", MoodAnalysisException.error.Null_Field);
                throw new MoodAnalysisException("No Such Field Exists", MoodAnalysisException.error.No_Such_Field);
            }
            
        }
    }

    
}
