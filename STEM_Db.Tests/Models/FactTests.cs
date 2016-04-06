using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using STEM_Db.Models;

namespace STEM_Db.Tests.Models
{
    [TestClass]
    public class FactTests
    {
        [TestMethod]
        public void FactICanCreateAFact()
        {
            Fact fact = new Fact();
            Assert.IsNotNull(fact);
        }

        [TestMethod]
        public void FactEnsureIHaveAllTheThings()
        {
            Fact fact = new Fact();
            fact.FactId = 1;
            fact.FactText = "The world is round";
            fact.IsQuote = false;

            Assert.AreEqual(1, fact.FactId);
            Assert.AreEqual("The world is round", fact.FactText);
            Assert.AreEqual(false, fact.IsQuote);
           
        }
    }
}

