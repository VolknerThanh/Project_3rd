namespace Doan16.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditId : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.ChiTietPhieuGiaoHang", "id_PhieuGiao", "dbo.PhieuGiaoHang");
            //DropPrimaryKey("dbo.PhieuGiaoHang");
            AlterColumn("dbo.PhieuGiaoHang", "id_PhieuGiao", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.PhieuGiaoHang", "id_PhieuGiao");
            AddForeignKey("dbo.ChiTietPhieuGiaoHang", "id_PhieuGiao", "dbo.PhieuGiaoHang", "id_PhieuGiao");
        }
        
        public override void Down()
        {
          //  DropForeignKey("dbo.ChiTietPhieuGiaoHang", "id_PhieuGiao", "dbo.PhieuGiaoHang");
           // DropPrimaryKey("dbo.PhieuGiaoHang");
            AlterColumn("dbo.PhieuGiaoHang", "id_PhieuGiao", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PhieuGiaoHang", "id_PhieuGiao");
            AddForeignKey("dbo.ChiTietPhieuGiaoHang", "id_PhieuGiao", "dbo.PhieuGiaoHang", "id_PhieuGiao");
        }
    }
}
