namespace CounterApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUsers : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Users(Username, Password) Values('teknik', 'TekniK2019')");
            Sql("Insert into Users(Username, Password) Values('muhasebe', 'MuhasebE2019')");
            Sql("Insert into Users(Username, Password) Values('admin', '52245224')");
        }
        
        public override void Down()
        {
        }
    }
}
