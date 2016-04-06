using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using STEM_Db.Models;

namespace STEM_Db.Tests.Models
{
    [TestClass]
    public class ExperimentTests
    {
        [TestMethod]
        public void ExperimentEnsureICanCreateInstanceOfAnExperiment()
        {
            Experiment experiment = new Experiment();
            Assert.IsNotNull(experiment);
        }

        [TestMethod]
        public void ExperimentEnsureHasAllTheThings()
        {
            Experiment experiment = new Experiment();
            experiment.ExperimentId = 224;
            experiment.ExperimentTitle = "Test Science";
            experiment.ExperimentCatagory = "chemistry";
            experiment.ExperimentBackground = "Chemistry is the study of atoms and molecules";
            experiment.ExperimentProcedure = "First take 5mL of water";
            experiment.ExperimentSummary = "This expermiment gives an understanding of the worlds buliding blocks, molecules";

            Assert.AreEqual(224, experiment.ExperimentId);
            Assert.AreEqual("Test Science", experiment.ExperimentTitle);
            Assert.AreEqual("chemistry", experiment.ExperimentCatagory);
            Assert.AreEqual("Chemistry is the study of atoms and molecules", experiment.ExperimentBackground);
            Assert.AreEqual("First take 5mL of water", experiment.ExperimentProcedure);
            Assert.AreEqual("This expermiment gives an understanding of the worlds buliding blocks, molecules", experiment.ExperimentSummary);
        }
    }
}
