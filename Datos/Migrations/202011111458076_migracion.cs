namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contactos",
                c => new
                    {
                        IdContacto = c.Int(nullable: false, identity: true),
                        IdDepartamento = c.Int(nullable: false),
                        NombreContacto = c.String(nullable: false, maxLength: 100),
                        Estado = c.Boolean(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdContacto)
                .ForeignKey("dbo.Departamentos", t => t.IdDepartamento, cascadeDelete: true)
                .Index(t => t.IdDepartamento);
            
            CreateTable(
                "dbo.Departamentos",
                c => new
                    {
                        IdDepartamento = c.Int(nullable: false, identity: true),
                        NombreDepartamento = c.String(nullable: false, maxLength: 100),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdDepartamento);
            
            CreateTable(
                "dbo.Direcciones",
                c => new
                    {
                        IdDireccion = c.Int(nullable: false, identity: true),
                        IdContacto = c.Int(nullable: false),
                        Direccion = c.String(nullable: false, maxLength: 100),
                        Estado = c.Boolean(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdDireccion)
                .ForeignKey("dbo.Contactos", t => t.IdContacto, cascadeDelete: true)
                .Index(t => t.IdContacto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Direcciones", "IdContacto", "dbo.Contactos");
            DropForeignKey("dbo.Contactos", "IdDepartamento", "dbo.Departamentos");
            DropIndex("dbo.Direcciones", new[] { "IdContacto" });
            DropIndex("dbo.Contactos", new[] { "IdDepartamento" });
            DropTable("dbo.Direcciones");
            DropTable("dbo.Departamentos");
            DropTable("dbo.Contactos");
        }
    }
}
