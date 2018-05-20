namespace Doan16.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNull_CTDDH : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChiTietDonDatHang", "SoLuongDat", c => c.Int(nullable: false));
            AlterColumn("dbo.NuocGK", "soluongton", c => c.Int(nullable: false));
            AlterColumn("dbo.ChiTietHoaDon", "soluongmua", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChiTietHoaDon", "soluongmua", c => c.Int());
            AlterColumn("dbo.NuocGK", "soluongton", c => c.Int());
            AlterColumn("dbo.ChiTietDonDatHang", "SoLuongDat", c => c.Int());
        }
    }
}
