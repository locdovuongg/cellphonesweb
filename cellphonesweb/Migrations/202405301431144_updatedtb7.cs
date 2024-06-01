﻿namespace cellphonesweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedtb7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Posts", "Category_Id", "dbo.tb_Category");
            DropIndex("dbo.tb_Posts", new[] { "Category_Id" });
            DropTable("dbo.tb_Posts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Alias = c.String(maxLength: 150),
                        Description = c.String(),
                        Detail = c.String(),
                        Image = c.String(maxLength: 250),
                        PostsCategoryId = c.Int(nullable: false),
                        SeoTitle = c.String(maxLength: 250),
                        SeoDescription = c.String(maxLength: 500),
                        SeoKeywords = c.String(maxLength: 250),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Modifiedby = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.tb_Posts", "Category_Id");
            AddForeignKey("dbo.tb_Posts", "Category_Id", "dbo.tb_Category", "Id");
        }
    }
}
