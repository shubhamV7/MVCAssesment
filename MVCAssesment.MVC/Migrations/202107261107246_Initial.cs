namespace MVCAssesment.MVC.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                {
                    DeptID = c.Int(nullable: false, identity: true),
                    DptName = c.String(nullable: false, maxLength: 50),
                    Description = c.String(nullable: false),
                })
                .PrimaryKey(t => t.DeptID);

            CreateTable(
                "dbo.Employees",
                c => new
                {
                    EmployeeId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    DOJ = c.DateTime(nullable: false),
                    Mobile = c.String(nullable: false, maxLength: 10),
                    Email = c.String(nullable: false, maxLength: 50),
                    Address = c.String(nullable: false, maxLength: 100),
                    DeptID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Departments", t => t.DeptID, cascadeDelete: true)
                .Index(t => t.DeptID);

            CreateTable(
                "dbo.Salaries",
                c => new
                {
                    Id = c.Int(nullable: false),
                    SalaryAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Salaries", "Id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "DeptID", "dbo.Departments");
            DropIndex("dbo.Salaries", new[] { "Id" });
            DropIndex("dbo.Employees", new[] { "DeptID" });
            DropTable("dbo.Salaries");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}