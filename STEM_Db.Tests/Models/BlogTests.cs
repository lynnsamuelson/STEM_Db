using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using STEM_Db.Models;

namespace STEM_Db.Tests.Models
{
    [TestClass]
    public class BlogTests
    {
        [TestMethod]
        public void BlogCanCreatInstanceOfABlog()
        {
            Blog blog = new Blog();
            Assert.IsNotNull(blog);

         }

        [TestMethod]
        public void BlogEnsureIHaveAllTheThings()
        {
            Blog blog = new Blog();
            DateTime publish = DateTime.Now;
            blog.BlogId = 33;
            blog.BlogTitle = "Why Kids Should learn Science";
            blog.BlogContent = "There are many reasons kids should learn science";
            blog.BlogSummary = "It is important we teach are kids science.";
            blog.DatePublished = publish;

            Assert.AreEqual(33, blog.BlogId);
            Assert.AreEqual("Why Kids Should learn Science", blog.BlogTitle);
            Assert.AreEqual("There are many reasons kids should learn science", blog.BlogContent);
            Assert.AreEqual("It is important we teach are kids science.", blog.BlogSummary);
            Assert.AreEqual(publish, blog.DatePublished);
        }

    }
}



