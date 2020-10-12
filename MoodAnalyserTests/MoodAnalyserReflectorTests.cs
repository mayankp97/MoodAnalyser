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
        private string _correctFieldName;
        private string _incorrectFieldName;
        private string _correctMethodName;
        private string _incorrectMethodName;
        private MoodAnalyser.MoodAnalyser _moodAnalyser;

        [SetUp]
        public void SetUp()
        {
            _correctFieldName = "message";
            _incorrectFieldName = "messagess";
            _correctMethodName = "AnalyseMood";
            _incorrectMethodName = "AnalyseMoods";
            _moodAnalyser = new MoodAnalyser.MoodAnalyser();
        }



        [Test]
        public void Invoke_WhenPassedProperMethodName_ReturnsHappyMood()
        {
            //Arrange
            var message = "I am in Happy Mood";

            //Act
            var result = MoodAnalyserReflector.Invoke(_correctMethodName, message);

            //Assert
            Assert.That(result, Is.EqualTo("HAPPY"));
        }

        [Test]
        public void Invoke_WhenPassedInvalidMethodName_ThrowsMoodAnalysisException()
        {
            //Arrange
            var message = "I am in Happy Mood";
            //Act
            Func<string> method = () => MoodAnalyserReflector.Invoke(_incorrectMethodName, message);
            //Assert
            Assert.That(method, Throws.Exception.InstanceOf<MoodAnalysisException>());
            Assert.That(method, Throws.Exception.Message.Contains("No Such Method").IgnoreCase);

        }

        [Test]
        public void SetField_WhenPassedProperFieldName_ReturnsHappy()
        {
            //Arrange
            var message = "I am in Happy Mood";

            //Act
            MoodAnalyserReflector.SetField(_moodAnalyser, _correctFieldName, message);
            var result = MoodAnalyserReflector.Invoke(_correctMethodName, null, _moodAnalyser);

            //Assert
            Assert.That(result, Is.EqualTo("HAPPY").IgnoreCase);
        }

        [Test]
        public void SetField_WhenPassedInvalidFieldName_ThrowsMoodAnalysisException()
        {
            //Arrange
            var message = "I am in Happy Mood";


            //Assert
            Assert.That(() => MoodAnalyserReflector.SetField(_moodAnalyser,_incorrectFieldName,message),Throws.Exception.InstanceOf<MoodAnalysisException>());
            Assert.That(() => MoodAnalyserReflector.SetField(_moodAnalyser, _incorrectFieldName, message), Throws.Exception.Message.Contains("No Such Field").IgnoreCase);

        }

        [Test]
        public void SetField_WhenPassedNullValue_ThrowsMoodAnalysisException()
        {
            //Arrange
            string message = null;


            //Assert
            Assert.That(() => MoodAnalyserReflector.SetField(_moodAnalyser, _correctFieldName, message), Throws.Exception.InstanceOf<MoodAnalysisException>());
            Assert.That(() => MoodAnalyserReflector.SetField(_moodAnalyser, _correctFieldName, message), Throws.Exception.Message.Contains("cannot set null").IgnoreCase);

        }
    }
}
