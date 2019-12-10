namespace User.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TokenAddedPersonTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Token", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Token");
        }
    }
}
