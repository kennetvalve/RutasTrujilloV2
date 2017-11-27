namespace RutasTrujilloV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cambios : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Horario", "HoraSalida", c => c.String());
            AlterColumn("dbo.Horario", "HoraLlegada", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Horario", "HoraLlegada", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Horario", "HoraSalida", c => c.DateTime(nullable: false));
        }
    }
}
