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
        public void STEM_DbRespositoryEnsureICanGetAllBlogs()
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
    }
}
