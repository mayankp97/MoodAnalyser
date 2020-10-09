using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using MoodAnalyser;

namespace MoodAnalyserTests
{
    [TestFixture]
    class MoodAnalyserTests
    {
        [Test]
        public void AnalyseMood_SadMessage_ReturnsSAD()
        {
            //Arrange
            var moodAnalyser = new MoodAnalyser.MoodAnalyser();
            var message = "I am in Sad Mood";

            //Act
            var result = moodAnalyser.AnalyseMood(message);

            //Assert
            Assert.That(result, Is.EqualTo("SAD").IgnoreCase);

        }

        [Test]
        public void AnalyseMood_NoSadMessage_ReturnsHappy()
        {
            //Arrange
            var moodAnalyser = new MoodAnalyser.MoodAnalyser();
            var message = "I am in any mood";

            //Act
            var result = moodAnalyser.AnalyseMood(message);

            //Assert
            Assert.That(result, Is.EqualTo("HAPPY").IgnoreCase);
        }

        [Test]
        public void AnalyseMood_SadMessageCtor_ReturnsSAD()
        {
            //Arrange
            var moodAnalyser = new MoodAnalyser.MoodAnalyser("I am in Sad Mood");

            //Act
            var result = moodAnalyser.AnalyseMood();

            //Assert
            Assert.That(result, Is.EqualTo("SAD").IgnoreCase);

        }

        [Test]
        public void AnalyseMood_NoSadMessageCtor_ReturnsHappy()
        {
            //Arrange
            var moodAnalyser = new MoodAnalyser.MoodAnalyser("I am in any mood");

            //Act
            var result = moodAnalyser.AnalyseMood();

            //Assert
            Assert.That(result, Is.EqualTo("HAPPY").IgnoreCase);
        }

        [Test]
        public void AnalyseMood_IfNullMessage_ThrowsMoodAnalysisException()
        {
            //Arrange
            var moodAnalyser = new MoodAnalyser.MoodAnalyser(null);

            //Assert
            Assert.That(() => moodAnalyser.AnalyseMood(), Throws.InstanceOf<MoodAnalysisException>());
            Assert.That(() => moodAnalyser.AnalyseMood(), Throws.Exception.Message.Contains("null").IgnoreCase);

        }

        [Test]
        public void AnalyseMood_IfEmptyMessage_ThrowsMoodAnalysisException()
        {
            //Arrange
            var moodAnalyser = new MoodAnalyser.MoodAnalyser("");

            //Assert
            Assert.That(() => moodAnalyser.AnalyseMood(), Throws.InstanceOf<MoodAnalysisException>());
            Assert.That(() => moodAnalyser.AnalyseMood(), Throws.Exception.Message.Contains("empty").IgnoreCase);

        }
    }
}
