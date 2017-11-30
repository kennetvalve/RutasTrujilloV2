namespace RutasTrujilloV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tarifa", "Precio", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tarifa", "Precio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
