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
