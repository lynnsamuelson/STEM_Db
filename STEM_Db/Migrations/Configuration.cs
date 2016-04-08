namespace STEM_Db.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<STEM_Db.Models.STEM_DbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(STEM_Db.Models.STEM_DbContext context)
        {
            context.Blogs.AddOrUpdate(p => p.BlogTitle,
            new Blog() { BlogId = 1, BlogTitle = "Why Encourage Kids to do Science", BlogSummary = "Encouraging science provides much more for kids that filling future STEM jobs.", DatePublished = DateTime.Now, BlogContent = "Blog Content Here" }
            );

            context.Experiments.AddOrUpdate(p => p.ExperimentTitle,
                new Experiment() { ExperimentId = 1, ExperimentTitle = "Marshmellow Molecules", ExperimentBackground = "Background Content Here", ExperimentCatagory = "Chemistry", ExperimentProcedure = "Take marshmellows and toothpicks and use them to connect the toothpicks to form molecules.  The toothpicks represent the bonds between molecules and the marshmellows represent the atom.  Look up the molecular structure of things and use different colored marshmellows for the different atoms and build larger versions of the molecular structure.", ExperimentSummary = "an activity for learning the structures of molecules"}
                );

            context.Facts.AddOrUpdate(p => p.FactText,
                new Fact() {FactId = 1, Author = "Albert Einstein", FactText ="Logic will get you from A to B.  Imagination will take you everywhere.", IsQuote = true }
                );

            context.KidQuestions.AddOrUpdate(p => p.Question,
                new KidQuestions { KidQuestionsId = 1, Question = "Why are the sun and moon out at the same time?", Answer = "The moon revolves around the sun like the the earth revolves around the sun.  While we may picture the moon on opposite side of the earth than the sun is, it really is moving aound the earth and is sometimes on the same side of earth as the sun.  These two separate cycles occaionally allow a daytime moon.", Catagory = "Astronomy", KidAge = 3, QuestionDate = new DateTime(2013, 2, 17) }
                );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
