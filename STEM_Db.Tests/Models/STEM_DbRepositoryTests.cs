using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using STEM_Db.Models;
using Moq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace STEM_Db.Tests.Models
{
    [TestClass]
    public class STEM_DbRepositoryTests
    {
        private Mock<STEM_DbContext> mock_context;
        private Mock<DbSet<Blog>> mock_blog_set;
        private Mock<DbSet<Experiment>> mock_experiment_set;
        private Mock<DbSet<Fact>> mock_fact_set;
        private Mock<DbSet<KidQuestions>> mock_kidQuestion_set;
        private ApplicationUser test_user;
        

        private STEM_DbRepository repository;

        private void ConnectMocksToDataStore(IEnumerable<Blog> data_store)
        {
            var data_source = data_store.AsQueryable<Blog>();

            mock_blog_set.As<IQueryable<Blog>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_blog_set.As<IQueryable<Blog>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_blog_set.As<IQueryable<Blog>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_blog_set.As<IQueryable<Blog>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            mock_context.Setup(a => a.Blogs).Returns(mock_blog_set.Object);
        }

        private void ConnectMocksToDataStore(IEnumerable<Experiment> data_store)
        {
            var data_source = data_store.AsQueryable<Experiment>();

            mock_experiment_set.As<IQueryable<Experiment>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_experiment_set.As<IQueryable<Experiment>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_experiment_set.As<IQueryable<Experiment>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_experiment_set.As<IQueryable<Experiment>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            mock_context.Setup(a => a.Experiments).Returns(mock_experiment_set.Object);
        }

        private void ConnectMocksToDataStore(IEnumerable<Fact> data_store)
        {
            var data_source = data_store.AsQueryable<Fact>();

            mock_fact_set.As<IQueryable<Fact>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_fact_set.As<IQueryable<Fact>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_fact_set.As<IQueryable<Fact>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_fact_set.As<IQueryable<Fact>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            mock_context.Setup(a => a.Facts).Returns(mock_fact_set.Object);
        }

        private void ConnectMocksToDataStore(IEnumerable<KidQuestions> data_store)
        {
            var data_source = data_store.AsQueryable<KidQuestions>();

            mock_kidQuestion_set.As<IQueryable<KidQuestions>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_kidQuestion_set.As<IQueryable<KidQuestions>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_kidQuestion_set.As<IQueryable<KidQuestions>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_kidQuestion_set.As<IQueryable<KidQuestions>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            mock_context.Setup(a => a.KidQuestions).Returns(mock_kidQuestion_set.Object);
        }


        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<STEM_DbContext>();
            mock_blog_set = new Mock<DbSet<Blog>>();
            mock_experiment_set = new Mock<DbSet<Experiment>>();
            mock_fact_set = new Mock<DbSet<Fact>>();
            mock_kidQuestion_set = new Mock<DbSet<KidQuestions>>();
            repository = new STEM_DbRepository(mock_context.Object);
            test_user = new ApplicationUser {Email = "test@example.com", Id = "test" };
            
            

        }



        [TestCleanup]
        public void Cleanup()
        {
            mock_context = null;
            mock_blog_set = null;
            mock_experiment_set = null;
            mock_fact_set = null;
            mock_kidQuestion_set = null;
            repository = null;
        }

        [TestMethod]
        public void STEM_DbContextEnsureCanCreateInstance()
        {
           STEM_DbContext context = new STEM_DbContext();
            Assert.IsNotNull(context);
        }
        [TestMethod]
        public void STEM_DbRepositoryEnsureCanCreateRepository()
        {
            STEM_DbRepository repository = new STEM_DbRepository();
            Assert.IsNotNull(repository);
        }



        [TestMethod]
        public void STEM_DbRepositoryEnsureICanGetAllBlogs()
        {
            var expected = new List<Blog>
            {
                new Blog {BlogTitle = "Test Title 1" },
                new Blog {BlogTitle = "Test Title 2" }
            };
            mock_blog_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);

            var actual = repository.GetAllBlogs();

            Assert.AreEqual("Test Title 1", actual.First().BlogTitle);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void STEM_DbRepositroyEnsureICanGetBlogById()
        {
            var blogList = new List<Blog>
            {
                new Blog {BlogTitle = "Test Title 1", BlogId = 1 },
                new Blog {BlogTitle = "Test Title 2", BlogId =2}
            };
            mock_blog_set.Object.AddRange(blogList);
            ConnectMocksToDataStore(blogList);

            Blog expected = new Blog { BlogTitle = "Test Title 1", BlogId = 1 };

            Blog actual = repository.GetBlog(1);
            Assert.AreEqual("Test Title 1", actual.BlogTitle);
            Assert.AreEqual(1, actual.BlogId);

        }


        [TestMethod]
        public void STEM_DbEnsureICanGetAllExperiments()
        {
            var experiments = new List<Experiment>
            {
                new Experiment {ExperimentId = 1, ExperimentBackground = "Science is cool", ExperimentCatagory = "Chemistry", ExperimentTitle = "Cool Things with Chemistry" },
                new Experiment {ExperimentId = 2, ExperimentBackground = "Chemistry is cool", ExperimentCatagory = "Chemistry", ExperimentTitle = " More Cool Things with Chemistry" },
                new Experiment {ExperimentId = 3, ExperimentBackground = "Biology is cool", ExperimentCatagory = "Bilogy", ExperimentTitle = "Cool Things with Biology" },
                new Experiment {ExperimentId = 4, ExperimentBackground = "Physics is cool", ExperimentCatagory = "Pyysics", ExperimentTitle = "Cool Things with Physics" }
            };
            mock_experiment_set.Object.AddRange(experiments);
            ConnectMocksToDataStore(experiments);

           var expected = new List<Experiment>
            {
                new Experiment {ExperimentId = 1, ExperimentBackground = "Science is cool", ExperimentCatagory = "Chemistry", ExperimentTitle = "Cool Things with Chemistry" },
                new Experiment {ExperimentId = 2, ExperimentBackground = "Chemistry is cool", ExperimentCatagory = "Chemistry", ExperimentTitle = " More Cool Things with Chemistry" },
                new Experiment {ExperimentId = 3, ExperimentBackground = "Biology is cool", ExperimentCatagory = "Bilogy", ExperimentTitle = "Cool Things with Biology" },
                new Experiment {ExperimentId = 4, ExperimentBackground = "Physics is cool", ExperimentCatagory = "Pyysics", ExperimentTitle = "Cool Things with Physics" }
            };

            var actual = repository.GetAllExperiments();

            Assert.AreEqual(actual[0].ExperimentId, expected[0].ExperimentId);
        }

        [TestMethod]
        public void ExperimantEnsureICanGetExperimentById()



        {
            var experiments = new List<Experiment>
            {
                new Experiment {ExperimentId = 1, ExperimentBackground = "Science is cool", ExperimentCatagory = "Chemistry", ExperimentTitle = "Cool Things with Chemistry" },
                new Experiment {ExperimentId = 2, ExperimentBackground = "Chemistry is cool", ExperimentCatagory = "Chemistry", ExperimentTitle = " More Cool Things with Chemistry" },
                new Experiment {ExperimentId = 3, ExperimentBackground = "Biology is cool", ExperimentCatagory = "Bilogy", ExperimentTitle = "Cool Things with Biology" },
                new Experiment {ExperimentId = 4, ExperimentBackground = "Physics is cool", ExperimentCatagory = "Pyysics", ExperimentTitle = "Cool Things with Physics" }
            };
            mock_experiment_set.Object.AddRange(experiments);
            ConnectMocksToDataStore(experiments);

            var expected = new Experiment { ExperimentId = 3, ExperimentBackground = "Biology is cool", ExperimentCatagory = "Bilogy", ExperimentTitle = "Cool Things with Biology" };
       
            var actual = repository.GetExperimentById(3);

            Assert.AreEqual(experiments[2].ExperimentTitle, actual.ExperimentTitle);
            //CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExperimentEnsureICanGetExperimentsInACatagory()
        {
            var experiments = new List<Experiment>
            {
                new Experiment {ExperimentId = 1, ExperimentBackground = "Science is cool", ExperimentCatagory = "Chemistry", ExperimentTitle = "Cool Things with Chemistry" },
                new Experiment {ExperimentId = 2, ExperimentBackground = "Chemistry is cool", ExperimentCatagory = "Chemistry", ExperimentTitle = " More Cool Things with Chemistry" },
                new Experiment {ExperimentId = 3, ExperimentBackground = "Biology is cool", ExperimentCatagory = "Bilogy", ExperimentTitle = "Cool Things with Biology" },
                new Experiment {ExperimentId = 4, ExperimentBackground = "Physics is cool", ExperimentCatagory = "Pyysics", ExperimentTitle = "Cool Things with Physics" }
            };
            mock_experiment_set.Object.AddRange(experiments);
            ConnectMocksToDataStore(experiments);

            var expected = new List<Experiment>
            {
                new Experiment {ExperimentId = 1, ExperimentBackground = "Science is cool", ExperimentCatagory = "Chemistry", ExperimentTitle = "Cool Things with Chemistry" },
                new Experiment {ExperimentId = 2, ExperimentBackground = "Chemistry is cool", ExperimentCatagory = "Chemistry", ExperimentTitle = " More Cool Things with Chemistry" },
            };

            var actual = repository.GetExperimentByCatagory("Chemistry");

            Assert.AreEqual("Chemistry is cool", actual[1].ExperimentBackground);
            //CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FactGetAllFacts()
        {
            var facts = new List<Fact>
            {
                new Fact {FactId = 1, FactText = "this is 1", IsQuote = false },
                new Fact {FactId = 2, FactText = "this is 2", IsQuote = true },
                new Fact {FactId = 3, FactText = "this is 3", IsQuote = false }
            };
            mock_fact_set.Object.AddRange(facts);
            ConnectMocksToDataStore(facts);

            var actual = repository.GetAllFacts();

            Assert.AreEqual(1, actual[0].FactId);
            Assert.AreEqual("this is 3", actual[2].FactText);
        }

        [TestMethod]
        public void FactGetFactByid()
        {
            var facts = new List<Fact>
            {
                new Fact {FactId = 1, FactText = "this is 1", IsQuote = false },
                new Fact {FactId = 2, FactText = "this is 2", IsQuote = true },
                new Fact {FactId = 3, FactText = "this is 3", IsQuote = false }
            };
            mock_fact_set.Object.AddRange(facts);
            ConnectMocksToDataStore(facts);

            var actual = repository.GetFact(facts[1].FactId);

            Assert.AreEqual("this is 2", actual.FactText);
        }

        [TestMethod]
        public void FactGetFactsThatAreQuotes()
        {
            var facts = new List<Fact>
            {
                new Fact {FactId = 1, FactText = "this is 1", IsQuote = false },
                new Fact {FactId = 2, FactText = "this is 2", IsQuote = true },
                new Fact {FactId = 3, FactText = "this is 3", IsQuote = false }
            };
            mock_fact_set.Object.AddRange(facts);
            ConnectMocksToDataStore(facts);

            var actual = repository.GetQuotes();

            Assert.AreEqual("this is 2", actual[0].FactText);
        }

    [TestMethod]
    public void KidQuestionsEnsureICanGetAllQuestions()
    {
        DateTime date = DateTime.Now;
        var questions = new List<KidQuestions>
        {
            new KidQuestions {KidQuestionsId = 1, Question = "Why are there stars?", KidAge = 3, Answer = "because there are other suns.", Catagory = "astronomy", QuestionDate = date },
            new KidQuestions {KidQuestionsId = 2, Question = "What is a color?", KidAge = 3, Answer = "Light absorbing and reflecting", Catagory = "chemistry", QuestionDate = date },
            new KidQuestions {KidQuestionsId = 3, Question = "Why?", KidAge = 3, Answer = "because", Catagory = "general", QuestionDate = date },
            new KidQuestions {KidQuestionsId = 4, Question = "How?", KidAge = 3, Answer = "by solving problems", Catagory = "engineering", QuestionDate = date }
        };
        mock_kidQuestion_set.Object.AddRange(questions);
        ConnectMocksToDataStore(questions);
        var actual = repository.GetQuestions();

            CollectionAssert.AreEqual(questions, actual);
    }

        [TestMethod]
        public void KidQuestionsEnSureICanGetQuestionById()
        {
            DateTime date = DateTime.Now;
            var questions = new List<KidQuestions>
        {
            new KidQuestions {KidQuestionsId = 1, Question = "Why are there stars?", KidAge = 3, Answer = "because there are other suns.", Catagory = "astronomy", QuestionDate = date },
            new KidQuestions { KidQuestionsId = 2, Question = "What is a color?", KidAge = 3, Answer = "Light absorbing and reflecting", Catagory = "chemistry", QuestionDate = date },
            new KidQuestions { KidQuestionsId = 3, Question = "Why?", KidAge = 3, Answer = "because", Catagory = "general", QuestionDate = date },
            new KidQuestions { KidQuestionsId = 4, Question = "How?", KidAge = 3, Answer = "by solving problems", Catagory = "engineering", QuestionDate = date }
        };
            mock_kidQuestion_set.Object.AddRange(questions);
            ConnectMocksToDataStore(questions);

            var expected = new KidQuestions { KidQuestionsId = 2, Question = "What is a color?", KidAge = 3, Answer = "Light absorbing and reflecting", Catagory = "chemistry", QuestionDate = date };

            var actual = repository.GetQuestion(2);

            Assert.AreEqual(expected.KidQuestionsId, actual.KidQuestionsId);
        }

   }
  


}

