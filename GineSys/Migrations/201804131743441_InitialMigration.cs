namespace GineSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ocupaciones",
                c => new
                    {
                        OcupacionId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 500),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                        UsuarioCreacion = c.String(nullable: false, maxLength: 50),
                        UsuarioModificacion = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.OcupacionId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Usuario = c.String(nullable: false, maxLength: 50),
                        Nombre = c.String(nullable: false, maxLength: 500),
                        Contrasena = c.String(nullable: false, maxLength: 100),
                        IsAdmin = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                        UsuarioCreacion = c.String(nullable: false, maxLength: 50),
                        UsuarioModificacion = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
            DropTable("dbo.Ocupaciones");
        }
    }
}
