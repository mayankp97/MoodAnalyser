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
        public void Initialize_WhenPassedClassNameOnly_ReturnsMoodAnalyserObject()
        {
            //Arrange
            var className = "MoodAnalyser";

            //Act
            var obj = MoodAnalyserFactory.Initialize(className);
    
            //Assert
            Assert.IsTrue(new MoodAnalyser.MoodAnalyser().Equals(obj));
        }

        [Test]
        public void Initialize_WhenPassedInvalidClassNameOnly_ReturnsMoodAnalysisException()
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
        [Test]
        public void Initialize_WhenPassedClassNameWithParameters_ReturnsMoodAnalyserObject()
        {
            //Arrange
            var className = "MoodAnalyser";
            var parameter = "I am in Happy Mood";

            //Act
            var obj = MoodAnalyserFactory.Initialize(className,parameter);

            //Assert
            Assert.IsTrue(new MoodAnalyser.MoodAnalyser(parameter).Equals(obj));
        }

        [Test]
        public void Initialize_WhenPassedInvalidClassNameWithParameters_ReturnsMoodAnalysisException()
        {
            //Arrange
            var className = "MoodAnalyse";
            var parameter = "I am in Happy Mood";

            //Assert
            Assert.That(() => MoodAnalyserFactory.Initialize(className,parameter), Throws.InstanceOf<MoodAnalysisException>());
            Assert.That(() => MoodAnalyserFactory.Initialize(className,parameter), Throws.Exception.Message.Contains("No Such class").IgnoreCase);

        }
    }
}
