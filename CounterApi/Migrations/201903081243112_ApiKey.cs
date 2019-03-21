namespace CounterApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApiKey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.XApiKeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.XApiKeys");
        }
    }
}
