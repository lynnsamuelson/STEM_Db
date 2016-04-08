namespace STEM_Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class STEM2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facts", "Author", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Facts", "Author");
        }
    }
}
