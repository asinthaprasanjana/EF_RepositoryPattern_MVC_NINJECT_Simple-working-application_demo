namespace DataEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Maths = c.Int(nullable: false),
                        Science = c.Int(nullable: false),
                        Language = c.Int(nullable: false),
                        createdate = c.DateTime(),
                        createdby = c.String(nullable: false),
                        modifiedby = c.String(nullable: false),
                        modifieddate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.Int(name: "Student ID", nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        createdate = c.DateTime(),
                        createdby = c.String(nullable: false),
                        modifiedby = c.String(nullable: false),
                        modifieddate = c.DateTime(),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false),
                        PasswordSalt = c.String(),
                        NumOfInvalidLogins = c.Int(nullable: false),
                        IsLoked = c.Boolean(nullable: false),
                        LastLogin = c.DateTime(),
                        createdate = c.DateTime(),
                        createdby = c.String(nullable: false),
                        modifiedby = c.String(nullable: false),
                        modifieddate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.Student");
            DropTable("dbo.Marks");
        }
    }
}
