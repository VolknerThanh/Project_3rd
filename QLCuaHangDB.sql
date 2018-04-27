use master if exists (select * from sysdatabases where name = 'QLCuaHangDB') drop database QLCuaHangDB
go
create database QLCuaHangDB
go

use QLCuaHangDB
go

create table TaiKhoan(
	id int identity primary key,
	TenDangNhap nvarchar(100) not null,
	MatKhau nvarchar(100) not null,
	PhanQuyen bit,
	-- them
	DiaChi nvarchar(100) not null,
	SDT nvarchar(12),
	-- them++
	daDangKy bit
)
go
create table NhaCungUng(
	id_NhaCungUng int identity primary key,
	TenNhaCungUng nvarchar(200) not null,
	DiaChi nvarchar(100) not null,
	SDT nvarchar(20) not null
)
go
create table LoaiNGK(
	id_LoaiNGK int identity primary key,
	TenLoaiNGK nvarchar(100) not null,
	NhaCungUng int

	foreign key (NhaCungUng) references NhaCungUng(id_NhaCungUng)
)
go
create table NuocGK(
	id_NuocGK int identity primary key,
	tenNGK nvarchar(50) not null,
	dongia int not null,
	nhanhieuNGK int,
	soluongton int,
	-- them
	hinhanh nvarchar(200),

	foreign key (nhanhieuNGK) references LoaiNGK(id_LoaiNGK)
)
alter table NuocGK alter column hinhanh varchar(200)

go
create table KhachHang(
	id_KhachHang int identity primary key,
	tenKhachHang nvarchar(100) not null,
	diachi nvarchar(100) not null,
	SoDienThoai varchar(20) not null,
	SoTienConNo int,
	daDangKy bit
)

go
create table HoaDon(
	id_HoaDon int identity primary key,
	NgayXuatHD Date not null,
	id_KhachHang int,
	-- them
	soHD varchar(5),
	TongTien int

	foreign key (id_KhachHang) references KhachHang(id_KhachHang)
)
go
create table ChiTietHoaDon(
	id_HoaDon int,
	id_NuocGK int,
	soluongmua int,
	dongiaban int,
	thanhtien int,
	primary key(id_HoaDon, id_NuocGK),

	foreign key(id_HoaDon) references HoaDon(id_HoaDon),
	foreign key(id_NuocGK) references NuocGK(id_NuocGK)
)
go
create table PhieuHen(
	id_PhieuHen int identity primary key,
	ngaylapphieu Date not null,
    ngayhen Date not null,
	id_KhachHang int

	foreign key(id_KhachHang) references KhachHang(id_KhachHang),
)
go
create table ChiTietPhieuHen(
	id_NuocGK int,
	id_PhieuHen int,
	soluongHang int,
	primary key(id_PhieuHen, id_NuocGK),
	
	foreign key(id_NuocGK) references NuocGK(id_NuocGK),
	foreign key(id_PhieuHen) references PhieuHen(id_PhieuHen)
)
go
create table PhieuTraNo(
	id_PhieuTraNo int identity primary key,
	NgayTra date not null,
	SoTienTra int not null,
	id_HoaDon int

	foreign key (id_HoaDon) references HoaDon(id_HoaDon)
)
go
create table DonDatHang(
	id_DonDatHang int identity primary key,
	NgayDatHang date,
	NhaCungUng int

	foreign key (NhaCungUng) references NhaCungUng(id_NhaCungUng)
)
go
create table ChiTietDonDatHang(
	id_DonDatHang int,
	id_NuocGK int,
	SoLuongDat int

	primary key (id_DonDatHang,id_NuocGK),
	foreign key (id_DonDatHang) references DonDatHang(id_DonDatHang),
	foreign key (id_NuocGK) references NuocGK(id_NuocGK)
)
go
create table PhieuGiaoHang(
	id_PhieuGiao int primary key,
	id_DonDatHang int,
	NgayGiaoHang Date

	foreign key (id_DonDatHang) references DonDatHang(id_DonDatHang)
)
go
create table ChiTietPhieuGiaoHang(
	id_PhieuGiao int,
	id_NuocGK int,
	SoLuongGiao int,
	DonGiaGiao int

	primary key(id_PhieuGiao,id_NuocGK),
	foreign key (id_PhieuGiao) references PhieuGiaoHang(id_PhieuGiao),
	foreign key (id_NuocGK) references NuocGK(id_NuocGK)
)

/*=====================================================================================================================================*/
/* --------------------------------------------------- TẠO CƠ SỞ DỮ LIỆU -------------------------------------------------------------*/
/*----- Nhà Cung Ứng --------*/
set identity_insert NhaCungUng ON

insert into NhaCungUng (id_NhaCungUng, TenNhaCungUng, DiaChi, SDT) values (1, 'Ruthy Flaherty', '6513 Artisan Trail', '1115709975');
insert into NhaCungUng (id_NhaCungUng, TenNhaCungUng, DiaChi, SDT) values (2, 'Ethelin Comrie', '46289 Waxwing Place', '8467683557');
insert into NhaCungUng (id_NhaCungUng, TenNhaCungUng, DiaChi, SDT) values (3, 'Johnath Estable', '9 Victoria Circle', '5024385868');
insert into NhaCungUng (id_NhaCungUng, TenNhaCungUng, DiaChi, SDT) values (4, 'Jojo Simoneschi', '421 Oneill Way', '8982943902');
insert into NhaCungUng (id_NhaCungUng, TenNhaCungUng, DiaChi, SDT) values (5, 'Vidovic Kendal', '65466 Tennessee Drive', '4417341951');
set identity_insert NhaCungUng OFF

/*------ Loại Nước giải khát ---------*/
set identity_insert LoaiNGK ON

insert into LoaiNGK (id_LoaiNGK, TenLoaiNGK, NhaCungUng) values (1, 'Networked', 5);
insert into LoaiNGK (id_LoaiNGK, TenLoaiNGK, NhaCungUng) values (2, 'eco-centric', 4);
insert into LoaiNGK (id_LoaiNGK, TenLoaiNGK, NhaCungUng) values (3, 'Profound', 5);
insert into LoaiNGK (id_LoaiNGK, TenLoaiNGK, NhaCungUng) values (4, 'Programmable', 1);
insert into LoaiNGK (id_LoaiNGK, TenLoaiNGK, NhaCungUng) values (5, 'Open-source', 3);
insert into LoaiNGK (id_LoaiNGK, TenLoaiNGK, NhaCungUng) values (6, 'Synergized', 3);
insert into LoaiNGK (id_LoaiNGK, TenLoaiNGK, NhaCungUng) values (7, '6th generation', 3);
insert into LoaiNGK (id_LoaiNGK, TenLoaiNGK, NhaCungUng) values (8, 'Virtual', 5);
insert into LoaiNGK (id_LoaiNGK, TenLoaiNGK, NhaCungUng) values (9, 'zero tolerance', 5);
insert into LoaiNGK (id_LoaiNGK, TenLoaiNGK, NhaCungUng) values (10, 'task-force', 2);
set identity_insert LoaiNGK OFF

/*------- Nước giải khát ------*/
set identity_insert NuocGK ON

insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (1, 'Decentralized', 14000, 9, 14, 'mission-critical');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (2, 'Compatible', 19000, 7, 7, 'secured line');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (3, 'secondary', 30000, 2, 77, 'Secured');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (4, 'toolset', 21000, 2, 0, 'fault-tolerant');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (5, 'software', 27000, 9, 51, 'dynamic');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (6, 'flexibility', 37000, 3, 4, 'Devolved');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (7, 'solution-oriented', 17000, 8, 67, 'Multi-tiered');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (8, 'Phased', 18000, 8, 7, 'Object-based');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (9, 'extranet', 38000, 9, 40, 'Decentralized');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (10, 'Configurable', 24000, 6, 39, 'throughput');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (11, 'Fundamental', 18000, 2, 71, 'asynchronous');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (12, 'Virtual', 33000, 9, 44, 'global');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (13, 'framework', 28000, 1, 62, 'frame');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (14, 'approach', 29000, 2, 47, 'hardware');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (15, 'Switchable', 21000, 9, 51, 'portal');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (16, 'capacity', 14000, 1, 27, 'Ergonomic');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (17, 'logistical', 9000, 10, 26, 'Vision-oriented');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (18, 'Profound', 9000, 10, 27, 'transitional');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (19, 'Cross-platform', 36000, 5, 83, 'full-range');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (20, 'Adaptive', 92000, 8, 77, 'static');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (21, 'zero tolerance', 72000, 1, 49, 'protocol');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (22, 'coherent', 28000, 6, 44, 'Compatible');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (23, 'capacity', 69000, 7, 37, 'function');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (24, 'motivating', 69000, 2, 74, 'hub');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (25, 'infrastructure', 24000, 3, 9, 'toolset');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (26, '6th generation', 28000, 4, 84, 'definition');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (27, 'executive', 18000, 7, 5, 'Customizable');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (28, 'standardization', 10000, 5, 52, 'optimizing');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (29, 'budgetary management', 9000, 6, 32, 'algorithm');
insert into NuocGK (id_NuocGK, tenNGK, dongia, nhanhieuNGK, soluongton, hinhanh) values (30, 'groupware', 8000, 8, 4, 'user-facing');
set identity_insert NuocGK OFF

/*------- Khách hàng ----*/
set identity_insert KhachHang ON

insert into KhachHang (id_KhachHang, tenKhachHang, diachi, SoDienThoai, SoTienConNo, daDangKy) values (1, 'Myrilla Cockrill', '9 Burrows Hill', '412-190-7625', 55000, 1);
insert into KhachHang (id_KhachHang, tenKhachHang, diachi, SoDienThoai, SoTienConNo, daDangKy) values (2, 'Merla Bewley', '6605 Armistice Park', '912-706-5754', 645000, 0);
insert into KhachHang (id_KhachHang, tenKhachHang, diachi, SoDienThoai, SoTienConNo, daDangKy) values (3, 'Barty Trevains', '003 Monica Trail', '764-634-1766', 66000, 0);
insert into KhachHang (id_KhachHang, tenKhachHang, diachi, SoDienThoai, SoTienConNo, daDangKy) values (4, 'Simona Hounsham', '52957 Sugar Parkway', '203-691-9073', 560000, 1);
insert into KhachHang (id_KhachHang, tenKhachHang, diachi, SoDienThoai, SoTienConNo, daDangKy) values (5, 'Nickola Jacke', '73 Eggendart Point', '286-949-9138', 588000, 0);
insert into KhachHang (id_KhachHang, tenKhachHang, diachi, SoDienThoai, SoTienConNo, daDangKy) values (6, 'Harley Hagley', '30073 Stang Plaza', '187-336-5818', 994000, 0);
insert into KhachHang (id_KhachHang, tenKhachHang, diachi, SoDienThoai, SoTienConNo, daDangKy) values (7, 'Aguste Brunelleschi', '26555 Hoffman Place', '581-158-7403', 355000, 1);
insert into KhachHang (id_KhachHang, tenKhachHang, diachi, SoDienThoai, SoTienConNo, daDangKy) values (8, 'Denny Gregorowicz', '4163 Sycamore Avenue', '582-487-3906', 784000, 1);
insert into KhachHang (id_KhachHang, tenKhachHang, diachi, SoDienThoai, SoTienConNo, daDangKy) values (9, 'Elaine Connochie', '64245 Mcbride Hill', '113-860-4534', 475000, 1);
insert into KhachHang (id_KhachHang, tenKhachHang, diachi, SoDienThoai, SoTienConNo, daDangKy) values (10, 'Brendan Barensen', '46514 Farragut Parkway', '682-444-7082', 0, 1);
insert into KhachHang (id_KhachHang, tenKhachHang, diachi, SoDienThoai, SoTienConNo, daDangKy) values (11, 'Elisa Endrici', '7879 Menomonie Lane', '414-726-9659', 0, 1);
insert into KhachHang (id_KhachHang, tenKhachHang, diachi, SoDienThoai, SoTienConNo, daDangKy) values (12, 'Indira Oakman', '75704 Truax Plaza', '578-903-8485', 265000, 0);
insert into KhachHang (id_KhachHang, tenKhachHang, diachi, SoDienThoai, SoTienConNo, daDangKy) values (13, 'Brigitte Meecher', '79 Claremont Center', '467-194-0203', 201000, 0);
insert into KhachHang (id_KhachHang, tenKhachHang, diachi, SoDienThoai, SoTienConNo, daDangKy) values (14, 'Meade Steketee', '8577 Tony Way', '560-786-7875', 0, 1);
insert into KhachHang (id_KhachHang, tenKhachHang, diachi, SoDienThoai, SoTienConNo, daDangKy) values (15, 'Andree Arpur', '0 Lunder Hill', '423-211-4222', 305000, 1);
insert into KhachHang (id_KhachHang, tenKhachHang, diachi, SoDienThoai, SoTienConNo, daDangKy) values (16, 'Leoline Royl', '02524 Blackbird Avenue', '545-826-7784', 157000, 0);
insert into KhachHang (id_KhachHang, tenKhachHang, diachi, SoDienThoai, SoTienConNo, daDangKy) values (17, 'Marten Ianizzi', '41099 Stuart Avenue', '908-366-8199', 366000, 0);
insert into KhachHang (id_KhachHang, tenKhachHang, diachi, SoDienThoai, SoTienConNo, daDangKy) values (18, 'Jana Gravatt', '371 Ridgeview Crossing', '195-352-8441', 0, 0);
insert into KhachHang (id_KhachHang, tenKhachHang, diachi, SoDienThoai, SoTienConNo, daDangKy) values (19, 'Vally Mileham', '2 Mayfield Trail', '280-695-6027', 653000, 0);
insert into KhachHang (id_KhachHang, tenKhachHang, diachi, SoDienThoai, SoTienConNo, daDangKy) values (20, 'Yovonnda Caulton', '4277 Schmedeman Alley', '837-682-1990', 467000, 0);
set identity_insert KhachHang OFF

/*--------Hóa đơn ------*/
set identity_insert HoaDon ON

set identity_insert HoaDon OFF

/*-------- Chi tiết hóa đơn ------*/
set identity_insert ChiTietHoaDon ON

set identity_insert ChiTietHoaDon OFF

/*--------Phiếu hẹn ------*/
set identity_insert PhieuHen ON

set identity_insert PhieuHen OFF

/*--------Chi tiết phiếu hẹn ------*/
set identity_insert ChiTietPhieuHen ON

set identity_insert ChiTietPhieuHen OFF

/*-------- Phiếu trả nợ ----*/
set identity_insert PhieuTraNo ON

set identity_insert PhieuTraNo OFF

/*--------- Đơn đặt hàng ----*/
set identity_insert DonDatHang ON

set identity_insert DonDatHang OFF

/*----- Chi tiết đơn đặt hàng ------*/
set identity_insert ChiTietDonDatHang ON

set identity_insert ChiTietDonDatHang OFF

/*------ Phiếu giao hàng ----*/
set identity_insert PhieuGiaoHang ON

set identity_insert PhieuGiaoHang OFF

/*------ Chi tiết phiếu giao hàng ---*/
set identity_insert ChiTietPhieuGiaoHang ON

set identity_insert ChiTietPhieuGiaoHang OFF
