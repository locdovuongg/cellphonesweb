namespace cellphonesweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedtb8 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Category", "PostsCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Category", "PostsCategoryId", c => c.Int(nullable: false));
        }
    }
}
