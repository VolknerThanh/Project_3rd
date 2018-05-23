namespace Doan16.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeNull_PhanQuyen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TaiKhoan", "PhanQuyen", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TaiKhoan", "PhanQuyen", c => c.Boolean());
        }
    }
}
