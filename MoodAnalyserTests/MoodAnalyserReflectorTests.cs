using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using MoodAnalyser;

namespace MoodAnalyserTests
{
    [TestFixture]
    class MoodAnalyserReflectorTests
    {
        [Test]
        public void Invoke_WhenPassedProperMethodName_ReturnsHappyMood()
        {
            //Arrange
            var message = "I am in Happy Mood";
            var methodName = "AnalyseMood";

            //Act
            var result = MoodAnalyserReflector.Invoke(methodName, message);

            //Assert
            Assert.That(result, Is.EqualTo("HAPPY"));
        }

        [Test]
        public void Invoke_WhenPassedInvalidMethodName_ThrowsMoodAnalysisException()
        {
            //Arrange
            var message = "I am in Happy Mood";
            var methodName = "AnalyseMoods";

            

            //Assert
            Assert.That(() => MoodAnalyserReflector.Invoke(methodName, message), Throws.Exception.InstanceOf<MoodAnalysisException>());
            Assert.That(() => MoodAnalyserReflector.Invoke(methodName, message), Throws.Exception.Message.Contains("No Such Method").IgnoreCase);

        }

        [Test]
        public void SetField_WhenPassedProperFieldName_ReturnsHappy()
        {
            //Arrange
            var fieldName = "message";
            var methodName = "AnalyseMood";
            var moodAnalyser = new MoodAnalyser.MoodAnalyser();
            var message = "I am in Happy Mood";

            //Act
            MoodAnalyserReflector.SetField(moodAnalyser, fieldName, message);
            var result = MoodAnalyserReflector.Invoke(methodName, null, moodAnalyser);

            //Assert
            Assert.That(result, Is.EqualTo("HAPPY").IgnoreCase);
        }

        [Test]
        public void SetField_WhenPassedInvalidFieldName_ThrowsMoodAnalysisException()
        {
            //Arrange
            var fieldName = "messagess";
            var methodName = "AnalyseMood";
            var moodAnalyser = new MoodAnalyser.MoodAnalyser();
            var message = "I am in Happy Mood";


            //Assert
            Assert.That(() => MoodAnalyserReflector.SetField(moodAnalyser,fieldName,message),Throws.Exception.InstanceOf<MoodAnalysisException>());
            Assert.That(() => MoodAnalyserReflector.SetField(moodAnalyser, fieldName, message), Throws.Exception.Message.Contains("No Such Field").IgnoreCase);

        }

        [Test]
        public void SetField_WhenPassedNullValue_ThrowsMoodAnalysisException()
        {
            //Arrange
            var fieldName = "messages";
            var methodName = "AnalyseMood";
            var moodAnalyser = new MoodAnalyser.MoodAnalyser();
            string message = null;


            //Assert
            Assert.That(() => MoodAnalyserReflector.SetField(moodAnalyser, fieldName, message), Throws.Exception.InstanceOf<MoodAnalysisException>());
            Assert.That(() => MoodAnalyserReflector.SetField(moodAnalyser, fieldName, message), Throws.Exception.Message.Contains("cannot set null").IgnoreCase);

        }
    }
}
