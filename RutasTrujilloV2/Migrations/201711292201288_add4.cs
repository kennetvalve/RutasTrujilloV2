namespace RutasTrujilloV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tarifa", "Precio", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tarifa", "Precio", c => c.Double(nullable: false));
        }
    }
}
