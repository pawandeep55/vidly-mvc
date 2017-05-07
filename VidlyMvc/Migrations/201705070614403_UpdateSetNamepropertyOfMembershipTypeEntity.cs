namespace VidlyMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSetNamepropertyOfMembershipTypeEntity : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes set Name='Pay As You Go' where DurationInMonths=0");
            Sql("update MembershipTypes set Name='Monthly' WHERE DurationInMonths=1");
            Sql("update MembershipTypes set Name='Quartely' WHERE DurationInMonths=3");
            Sql("update MembershipTypes set Name='Annual' where DurationInMonths=12");
           // Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE Id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
