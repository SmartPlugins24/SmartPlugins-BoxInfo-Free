namespace SmartPlugins.BoxInfo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BoxInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EnableInfoBoxOne = c.Boolean(nullable: false),
                        EnableInfoBoxTwo = c.Boolean(nullable: false),
                        EnableInfoBoxThree = c.Boolean(nullable: false),
                        EnableInfoBoxFour = c.Boolean(nullable: false),
                        EnableInfoBoxFive = c.Boolean(nullable: false),
                        InfoBoxOneUrl = c.String(),
                        InfoBoxTwoUrl = c.String(),
                        InfoBoxThreeUrl = c.String(),
                        InfoBoxFourUrl = c.String(),
                        InfoBoxFiveUrl = c.String(),
                        InfoBoxOneTitle = c.String(),
                        InfoBoxTwoTitle = c.String(),
                        InfoBoxThreeTitle = c.String(),
                        InfoBoxFourTitle = c.String(),
                        InfoBoxFiveTitle = c.String(),
                        InfoBoxOneText = c.String(),
                        InfoBoxTwoText = c.String(),
                        InfoBoxThreeText = c.String(),
                        InfoBoxFourText = c.String(),
                        InfoBoxFiveText = c.String(),
                        InfoBoxOneImageId = c.Int(nullable: false),
                        InfoBoxTwoImageId = c.Int(nullable: false),
                        InfoBoxThreeImageId = c.Int(nullable: false),
                        InfoBoxFourImageId = c.Int(nullable: false),
                        InfoBoxFiveImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BoxInfo");
        }
    }
}
