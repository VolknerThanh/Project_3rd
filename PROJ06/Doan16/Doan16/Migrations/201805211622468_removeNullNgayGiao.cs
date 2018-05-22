namespace Doan16.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeNullNgayGiao : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PhieuGiaoHang", "NgayGiaoHang", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PhieuGiaoHang", "NgayGiaoHang", c => c.DateTime(storeType: "date"));
        }
    }
}
