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

    }
}
