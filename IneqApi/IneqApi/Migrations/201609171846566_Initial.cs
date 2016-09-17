namespace IneqApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Component",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        ComponentTypeId = c.Int(nullable: false),
                        Equipment_Id = c.Int(nullable: false),
                        EquipmentType_Id = c.Int(nullable: false),
                        Equipments_Id = c.Int(),
                        EquipmentTypes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ComponentType", t => t.ComponentTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Equipment", t => t.Equipments_Id)
                .ForeignKey("dbo.EquipmentType", t => t.EquipmentTypes_Id)
                .Index(t => t.ComponentTypeId)
                .Index(t => t.Equipments_Id)
                .Index(t => t.EquipmentTypes_Id);
            
            CreateTable(
                "dbo.ComponentType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntryDate = c.DateTime(nullable: false),
                        Serie = c.String(),
                        Softtekld = c.String(),
                        Active = c.Boolean(nullable: false),
                        EquipmentTypeld = c.Int(nullable: false),
                        Modelld = c.Int(nullable: false),
                        Brandld = c.Int(nullable: false),
                        Statusld = c.Int(nullable: false),
                        Warehouseld = c.Int(nullable: false),
                        Brands_Id = c.Int(),
                        EquipmentTypes_Id = c.Int(),
                        Models_Id = c.Int(),
                        Statuses_Id = c.Int(),
                        Warehouses_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brand", t => t.Brands_Id)
                .ForeignKey("dbo.EquipmentType", t => t.EquipmentTypes_Id)
                .ForeignKey("dbo.Model", t => t.Models_Id)
                .ForeignKey("dbo.Status", t => t.Statuses_Id)
                .ForeignKey("dbo.Warehouse", t => t.Warehouses_Id)
                .Index(t => t.Brands_Id)
                .Index(t => t.EquipmentTypes_Id)
                .Index(t => t.Models_Id)
                .Index(t => t.Statuses_Id)
                .Index(t => t.Warehouses_Id);
            
            CreateTable(
                "dbo.EquipmentType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        UsefulLife = c.String(),
                        GuaranteeDuration = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Model",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brand", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Warehouse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        IS = c.String(),
                        Responsable = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Component", "EquipmentTypes_Id", "dbo.EquipmentType");
            DropForeignKey("dbo.Component", "Equipments_Id", "dbo.Equipment");
            DropForeignKey("dbo.Equipment", "Warehouses_Id", "dbo.Warehouse");
            DropForeignKey("dbo.Equipment", "Statuses_Id", "dbo.Status");
            DropForeignKey("dbo.Equipment", "Models_Id", "dbo.Model");
            DropForeignKey("dbo.Model", "BrandId", "dbo.Brand");
            DropForeignKey("dbo.Equipment", "EquipmentTypes_Id", "dbo.EquipmentType");
            DropForeignKey("dbo.Equipment", "Brands_Id", "dbo.Brand");
            DropForeignKey("dbo.Component", "ComponentTypeId", "dbo.ComponentType");
            DropIndex("dbo.Model", new[] { "BrandId" });
            DropIndex("dbo.Equipment", new[] { "Warehouses_Id" });
            DropIndex("dbo.Equipment", new[] { "Statuses_Id" });
            DropIndex("dbo.Equipment", new[] { "Models_Id" });
            DropIndex("dbo.Equipment", new[] { "EquipmentTypes_Id" });
            DropIndex("dbo.Equipment", new[] { "Brands_Id" });
            DropIndex("dbo.Component", new[] { "EquipmentTypes_Id" });
            DropIndex("dbo.Component", new[] { "Equipments_Id" });
            DropIndex("dbo.Component", new[] { "ComponentTypeId" });
            DropTable("dbo.User");
            DropTable("dbo.Warehouse");
            DropTable("dbo.Status");
            DropTable("dbo.Model");
            DropTable("dbo.EquipmentType");
            DropTable("dbo.Equipment");
            DropTable("dbo.ComponentType");
            DropTable("dbo.Component");
            DropTable("dbo.Brand");
        }
    }
}
