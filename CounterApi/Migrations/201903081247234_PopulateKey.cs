namespace CounterApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.XApiKeys", "ApiKey", c => c.String());
            DropColumn("dbo.XApiKeys", "Key");
        }
        
        public override void Down()
        {
            AddColumn("dbo.XApiKeys", "Key", c => c.String());
            DropColumn("dbo.XApiKeys", "ApiKey");
        }
    }
}
