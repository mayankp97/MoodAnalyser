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
    }
}
