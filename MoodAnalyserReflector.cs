using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyserReflector
    {
        public static string Invoke(string methodName, string message = null)
        {
            

            try
            {
                var methodInfo = typeof(MoodAnalyser).GetMethod(methodName);
                var result = (string)methodInfo.Invoke(MoodAnalyserFactory.Initialize("MoodAnalyser"),
                    new object[] { message });
                return result;

            }
            catch (Exception)
            {

                throw new MoodAnalysisException("No Such Method Exists");
            }

        }
    }
}
