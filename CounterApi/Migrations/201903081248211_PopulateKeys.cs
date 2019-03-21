namespace CounterApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateKeys : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into XApiKeys(ApiKey) Values('V24e05S83')");
        }
        
        public override void Down()
        {
        }
    }
}
