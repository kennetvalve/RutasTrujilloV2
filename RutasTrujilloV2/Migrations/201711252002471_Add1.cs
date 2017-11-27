namespace RutasTrujilloV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        IdEmpresa = c.Int(nullable: false, identity: true),
                        RazonSocial = c.String(),
                        Ruc = c.String(),
                    })
                .PrimaryKey(t => t.IdEmpresa);
            
            CreateTable(
                "dbo.Horario",
                c => new
                    {
                        IdHorario = c.Int(nullable: false, identity: true),
                        HoraSalida = c.DateTime(nullable: false),
                        HoraLlegada = c.DateTime(nullable: false),
                        IdRuta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdHorario)
                .ForeignKey("dbo.Ruta", t => t.IdRuta, cascadeDelete: true)
                .Index(t => t.IdRuta);
            
            CreateTable(
                "dbo.Ruta",
                c => new
                    {
                        IdRuta = c.Int(nullable: false, identity: true),
                        Letra = c.String(),
                        Origen = c.String(),
                        Destino = c.String(),
                        IdEmpresa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdRuta)
                .ForeignKey("dbo.Empresa", t => t.IdEmpresa, cascadeDelete: true)
                .Index(t => t.IdEmpresa);
            
            CreateTable(
                "dbo.Punto",
                c => new
                    {
                        IdPunto = c.Int(nullable: false, identity: true),
                        Latitud = c.Single(nullable: false),
                        Longitud = c.Single(nullable: false),
                        IdRuta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPunto)
                .ForeignKey("dbo.Ruta", t => t.IdRuta, cascadeDelete: true)
                .Index(t => t.IdRuta);
            
            CreateTable(
                "dbo.Tarifa",
                c => new
                    {
                        IdTarifa = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                        Precio = c.Single(nullable: false),
                        IdEmpresa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTarifa)
                .ForeignKey("dbo.Empresa", t => t.IdEmpresa, cascadeDelete: true)
                .Index(t => t.IdEmpresa);
            
            CreateTable(
                "dbo.Vehiculo",
                c => new
                    {
                        IdVehiculo = c.Int(nullable: false, identity: true),
                        NumeroVehiculo = c.Int(nullable: false),
                        Placa = c.String(),
                        IdEmpresa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdVehiculo)
                .ForeignKey("dbo.Empresa", t => t.IdEmpresa, cascadeDelete: true)
                .Index(t => t.IdEmpresa);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehiculo", "IdEmpresa", "dbo.Empresa");
            DropForeignKey("dbo.Tarifa", "IdEmpresa", "dbo.Empresa");
            DropForeignKey("dbo.Punto", "IdRuta", "dbo.Ruta");
            DropForeignKey("dbo.Horario", "IdRuta", "dbo.Ruta");
            DropForeignKey("dbo.Ruta", "IdEmpresa", "dbo.Empresa");
            DropIndex("dbo.Vehiculo", new[] { "IdEmpresa" });
            DropIndex("dbo.Tarifa", new[] { "IdEmpresa" });
            DropIndex("dbo.Punto", new[] { "IdRuta" });
            DropIndex("dbo.Ruta", new[] { "IdEmpresa" });
            DropIndex("dbo.Horario", new[] { "IdRuta" });
            DropTable("dbo.Vehiculo");
            DropTable("dbo.Tarifa");
            DropTable("dbo.Punto");
            DropTable("dbo.Ruta");
            DropTable("dbo.Horario");
            DropTable("dbo.Empresa");
        }
    }
}
