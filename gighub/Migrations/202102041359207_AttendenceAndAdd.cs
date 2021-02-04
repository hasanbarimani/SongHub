namespace gighub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttendenceAndAdd : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Attendances");
            AddColumn("dbo.Attendances", "AttendeeId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Attendances", new[] { "GigId", "AttendeeId" });
            CreateIndex("dbo.Attendances", "AttendeeId");
            AddForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Attendances", "AtendeeId");
            DropColumn("dbo.Attendances", "Atendee_RequireUniqueEmail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "Atendee_RequireUniqueEmail", c => c.Boolean(nullable: false));
            AddColumn("dbo.Attendances", "AtendeeId", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "AttendeeId" });
            DropPrimaryKey("dbo.Attendances");
            DropColumn("dbo.Attendances", "AttendeeId");
            AddPrimaryKey("dbo.Attendances", new[] { "GigId", "AtendeeId" });
        }
    }
}
