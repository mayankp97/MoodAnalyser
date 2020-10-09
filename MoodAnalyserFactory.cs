using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyserFactory
    {
        public static MoodAnalyser Initialize(string ClassName, object parameter = null)
        {
            var className = ClassName +"."+ClassName;
            var assembly = typeof(MoodAnalyser).Assembly;
            try
            {
                Object obj;
                if(parameter == null)
                    obj = (MoodAnalyser)assembly.CreateInstance(className, false, BindingFlags.ExactBinding, null,null, null, null);
                else
                    obj = assembly.CreateInstance(className, false, BindingFlags.Default, null, new object[] { parameter }, null, null);
                if (obj == null)
                    throw new Exception();
                return (MoodAnalyser)obj;

            }
            catch (Exception)
            {

                if (ClassName != "MoodAnalyser")
                    throw new MoodAnalysisException("No such Class Exists");
                throw new MoodAnalysisException("No such method exists!");
            }



            /*
            if (ClassName != "MoodAnalyser")
                throw new MoodAnalysisException(null,"Error : No Such Class");
            try
            {
                var obj = new MoodAnalyser();
                var result = (MoodAnalyser)Activator.CreateInstance(typeof(MoodAnalyser), parameter);
                return result;

            }
            catch (Exception)
            {

                throw new MoodAnalysisException("No Such method");
            }
            */
        }
    }
}
