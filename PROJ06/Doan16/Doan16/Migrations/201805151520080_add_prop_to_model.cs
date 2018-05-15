namespace Doan16.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_prop_to_model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HoaDon", "Status", c => c.Int(nullable: false));
            //DropColumn("dbo.KhachHang", "Permission");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.KhachHang", "Permission", c => c.Boolean(nullable: false));
            DropColumn("dbo.HoaDon", "Status");
        }
    }
}
