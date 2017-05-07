namespace VidlyMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterAddDobToCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Dob", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Dob");
        }
    }
}
