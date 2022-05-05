namespace lab8p2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pierwsza : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Studenci",
                c => new
                    {
                        IdStudent = c.Int(nullable: false, identity: true),
                        Imie = c.String(nullable: false, maxLength: 30),
                        Nazwisko = c.String(nullable: false, maxLength: 50),
                        Ocena = c.Double(),
                        Wiek = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.IdStudent);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Studenci");
        }
    }
}
