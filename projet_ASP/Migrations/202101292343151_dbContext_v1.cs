﻿namespace projet_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbContext_v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contrats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        dateLocation = c.DateTime(nullable: false),
                        dateDebut = c.DateTime(nullable: false),
                        dateFin = c.DateTime(nullable: false),
                        typeDePaiement = c.String(nullable: false),
                        cout = c.Decimal(nullable: false, precision: 18, scale: 2),
                        matricule = c.String(maxLength: 128),
                        idLocataire = c.Int(nullable: false),
                        RetourVoiture_idRetour = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.locataires", t => t.idLocataire, cascadeDelete: true)
                .ForeignKey("dbo.Voitures", t => t.matricule)
                .ForeignKey("dbo.retoursVoitures", t => t.RetourVoiture_idRetour)
                .Index(t => t.matricule)
                .Index(t => t.idLocataire)
                .Index(t => t.RetourVoiture_idRetour);
            
            CreateTable(
                "dbo.locataires",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        nomComplet = c.String(nullable: false),
                        tel = c.String(nullable: false),
                        adresse = c.String(nullable: false),
                        email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Voitures",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        marque = c.String(nullable: false),
                        model = c.String(nullable: false),
                        couleur = c.String(nullable: false),
                        coutParJour = c.Decimal(nullable: false, precision: 18, scale: 2),
                        km = c.Decimal(nullable: false, precision: 18, scale: 2),
                        idProprietaire = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.proprietaires", t => t.idProprietaire, cascadeDelete: true)
                .Index(t => t.idProprietaire);
            
            CreateTable(
                "dbo.proprietaires",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        nomComplet = c.String(nullable: false),
                        tel = c.String(nullable: false),
                        adresse = c.String(nullable: false),
                        email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.retoursVoitures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        dateRetour = c.DateTime(nullable: false),
                        etat = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contrats", "RetourVoiture_idRetour", "dbo.retoursVoitures");
            DropForeignKey("dbo.Voitures", "idProprietaire", "dbo.proprietaires");
            DropForeignKey("dbo.Contrats", "matricule", "dbo.Voitures");
            DropForeignKey("dbo.Contrats", "idLocataire", "dbo.locataires");
            DropIndex("dbo.Voitures", new[] { "idProprietaire" });
            DropIndex("dbo.Contrats", new[] { "RetourVoiture_idRetour" });
            DropIndex("dbo.Contrats", new[] { "idLocataire" });
            DropIndex("dbo.Contrats", new[] { "matricule" });
            DropTable("dbo.retoursVoitures");
            DropTable("dbo.proprietaires");
            DropTable("dbo.Voitures");
            DropTable("dbo.locataires");
            DropTable("dbo.Contrats");
        }
    }
}
