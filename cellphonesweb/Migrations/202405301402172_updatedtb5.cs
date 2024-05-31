namespace cellphonesweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedtb5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Posts", "CategoryId", "dbo.tb_Category");
            DropIndex("dbo.tb_Posts", new[] { "CategoryId" });
            RenameColumn(table: "dbo.tb_Posts", name: "CategoryId", newName: "Category_Id");
            AddColumn("dbo.tb_Category", "PostsCategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.tb_Posts", "PostsCategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_Posts", "Category_Id", c => c.Int());
            CreateIndex("dbo.tb_Posts", "Category_Id");
            AddForeignKey("dbo.tb_Posts", "Category_Id", "dbo.tb_Category", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Posts", "Category_Id", "dbo.tb_Category");
            DropIndex("dbo.tb_Posts", new[] { "Category_Id" });
            AlterColumn("dbo.tb_Posts", "Category_Id", c => c.Int(nullable: false));
            DropColumn("dbo.tb_Posts", "PostsCategoryId");
            DropColumn("dbo.tb_Category", "PostsCategoryId");
            RenameColumn(table: "dbo.tb_Posts", name: "Category_Id", newName: "CategoryId");
            CreateIndex("dbo.tb_Posts", "CategoryId");
            AddForeignKey("dbo.tb_Posts", "CategoryId", "dbo.tb_Category", "Id", cascadeDelete: true);
        }
    }
}
