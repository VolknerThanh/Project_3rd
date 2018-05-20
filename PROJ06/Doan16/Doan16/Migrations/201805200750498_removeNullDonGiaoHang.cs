namespace Doan16.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeNullDonGiaoHang : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhieuGiaoHang", "id_DonDatHang", "dbo.DonDatHang");
            DropIndex("dbo.PhieuGiaoHang", new[] { "id_DonDatHang" });
            AlterColumn("dbo.PhieuGiaoHang", "id_DonDatHang", c => c.Int(nullable: false));
            CreateIndex("dbo.PhieuGiaoHang", "id_DonDatHang");
            AddForeignKey("dbo.PhieuGiaoHang", "id_DonDatHang", "dbo.DonDatHang", "id_DonDatHang", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhieuGiaoHang", "id_DonDatHang", "dbo.DonDatHang");
            DropIndex("dbo.PhieuGiaoHang", new[] { "id_DonDatHang" });
            AlterColumn("dbo.PhieuGiaoHang", "id_DonDatHang", c => c.Int());
            CreateIndex("dbo.PhieuGiaoHang", "id_DonDatHang");
            AddForeignKey("dbo.PhieuGiaoHang", "id_DonDatHang", "dbo.DonDatHang", "id_DonDatHang");
        }
    }
}
