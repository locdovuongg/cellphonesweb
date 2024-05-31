namespace cellphonesweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedtb2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Category", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.tb_ProductCategory", "ProductCategoryId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_ProductCategory", "ProductCategoryId");
            DropColumn("dbo.tb_Category", "CategoryId");
        }
    }
}
