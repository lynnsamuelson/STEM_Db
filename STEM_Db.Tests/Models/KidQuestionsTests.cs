using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using STEM_Db.Models;
namespace STEM_Db.Tests.Models
{
    [TestClass]
    public class KidQuestionsTests
    {
        [TestMethod]
        public void KidQuestionsCanCreateInstanceOfQuestion()
        {
            KidQuestions question = new KidQuestions();
            Assert.IsNotNull(question);
        }

        [TestMethod]
        public void KidQuestionsEnsureQuestionHasAllTheThings()
        {
            KidQuestions question = new KidQuestions();
            DateTime date = DateTime.Now;
            question.KidQuestionsId = 59;
            question.Question = "Why are the sun and moon out at the same time?";
            question.Answer = "Because the way the earth rotates around the sun and the moon around the earth this happens";
            question.QuestionDate = date;
            question.KidAge = 3;
            question.Catagory = "Astronomy";
            Assert.AreEqual(59, question.KidQuestionsId);
            Assert.AreEqual("Why are the sun and moon out at the same time?", question.Question);
            Assert.AreEqual("Because the way the earth rotates around the sun and the moon around the earth this happens", question.Answer);
            Assert.AreEqual(date, question.QuestionDate);
            Assert.AreEqual(3, question.KidAge);
            Assert.AreEqual("Astronomy", question.Catagory);
        }
        [TestMethod]
        public void KidQuestionsEnsureICanCreateObjectWithInitializerSyntax()
        {
            DateTime date = DateTime.Now;
            KidQuestions question = new KidQuestions { KidQuestionsId = 59, Question = "Why are the sun and moon out at the same time?", Answer = "Because the way the earth rotates around the sun and the moon around the earth this happens", QuestionDate = date, KidAge = 3, Catagory = "Astronomy" };
            Assert.AreEqual(59, question.KidQuestionsId);
            Assert.AreEqual("Why are the sun and moon out at the same time?", question.Question);
            Assert.AreEqual("Because the way the earth rotates around the sun and the moon around the earth this happens", question.Answer);
            Assert.AreEqual(date, question.QuestionDate);
            Assert.AreEqual(3, question.KidAge);
            Assert.AreEqual("Astronomy", question.Catagory);
        }
    }
}
