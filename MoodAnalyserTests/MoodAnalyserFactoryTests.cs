using MoodAnalyser;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserTests
{
    [TestFixture]
    class MoodAnalyserFactoryTests
    {
        [Test]
        public void Initialize_WhenPassedClassName_ReturnsMoodAnalyserObject()
        {
            //Arrange
            var className = "MoodAnalyser";

            //Act
            var obj = MoodAnalyserFactory.Initialize(className);
    
            //Assert
            Assert.IsTrue(new MoodAnalyser.MoodAnalyser().Equals(obj));
        }

        [Test]
        public void Initialize_WhenPassedInvalidClassName_ReturnsMoodAnalysisException()
        {
            //Arrange
            var className = "MoodAnalyse";

            //Assert
            Assert.That(() => MoodAnalyserFactory.Initialize(className),Throws.InstanceOf<MoodAnalysisException>());
            Assert.That(() => MoodAnalyserFactory.Initialize(className), Throws.Exception.Message.Contains("No Such class").IgnoreCase);

        }

        [Test]
        public void Initialize_WhenPassedInvalidParameters_ReturnsMoodAnalysisException()
        {
            //Arrange
            var className = "MoodAnalyser";

            //Assert
            Assert.That(() => MoodAnalyserFactory.Initialize(className,5), Throws.InstanceOf<MoodAnalysisException>());
            Assert.That(() => MoodAnalyserFactory.Initialize(className,5), Throws.Exception.Message.Contains("No such method").IgnoreCase);

        }
    }
}
