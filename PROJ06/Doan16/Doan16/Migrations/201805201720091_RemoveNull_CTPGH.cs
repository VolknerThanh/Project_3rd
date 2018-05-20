namespace Doan16.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNull_CTPGH : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChiTietPhieuGiaoHang", "SoLuongGiao", c => c.Int(nullable: false));
            AlterColumn("dbo.ChiTietPhieuGiaoHang", "DonGiaGiao", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChiTietPhieuGiaoHang", "DonGiaGiao", c => c.Int());
            AlterColumn("dbo.ChiTietPhieuGiaoHang", "SoLuongGiao", c => c.Int());
        }
    }
}
