CREATE DATABASE SHOP;

use SHOP;

CREATE TABLE KULLANICI(
	Ad nvarchar(50) NOT NULL,
	Soyad nvarchar(50) NOT NULL,
	Email nvarchar(100) NOT NULL,
	cinsiyetID INT,
	kullanıcıID INT IDENTITY(1,1) PRIMARY KEY,
	şifre nvarchar(25) NOT NULL,
	kullanıcıTürüID INT NOT NULL
);
CREATE TABLE Fatura(
	faturaID INT IDENTITY(1,1) PRIMARY KEY,
	kullanıcıID INT,
	toplam INT,
	siparişNo INT
);

CREATE TABLE Cinsiyet (
	cinsiyet_ID INT IDENTITY(1,1) PRIMARY KEY,
	cinsiyetAdı nvarchar(20) NOT NULL	
);

CREATE TABLE KullanıcıTürü(
	kullanıcıTürüID INT IDENTITY(1,1) PRIMARY KEY,
	kullanıcıAdı  nvarchar(25) NOT NULL
);
CREATE TABLE Ürün (
	ürünID INT IDENTITY(1,1) PRIMARY KEY,
	fiyat Numeric,
	ürünTürüID INT NOT NULL,
	tasarımcıID INT,
	bileşenID INT,
	ürünAdı  nvarchar(50) NOT NULL
);

CREATE TABLE ÜrünBeden (
	ürünBedenID INT IDENTITY(1,1) PRIMARY KEY,
	BedenID INT NOT NULL,
	ürünID INT,
	stokMiktarı INT,
	mankenID INT
);

CREATE TABLE Sipariş(
	siparişNo INT IDENTITY(1,1) PRIMARY KEY,
	kullanıcıID INT NOT NULL,
	ürünBedenID INT NOT NULL,
	tutar INT NOT NULL,
	tarih Date DEFAULT GETDATE()
	);

CREATE TABLE Manken (
	mankenID INT IDENTITY(1,1) PRIMARY KEY,
	BedenID INT NOT NULL,
	boy Numeric,
	kilo Numeric
);
CREATE TABLE Beden (
	BedenID  INT IDENTITY(1,1) PRIMARY KEY,
	bedenAdı nvarchar(25) NOT NULL
);
CREATE TABLE ÜrünTürü(
	ürünTürüID INT IDENTITY(1,1) PRIMARY KEY,
	ürünAdı  nvarchar(25) NOT NULL,
);

CREATE TABLE BileşenOranı (
	bileşenID INT IDENTITY(1,1) PRIMARY KEY,
	pamukOranı Numeric,
	polyesterOranı Numeric,
	KetenOranı Numeric
);

CREATE TABLE Tasarımcı (
	tasarımcıID INT IDENTITY(1,1) PRIMARY KEY,
	kullanıcıID INT,
	kazanç numeric,
);

ALTER TABLE KULLANICI
ADD CONSTRAINT FK_cinsiyet
FOREIGN KEY (cinsiyetID)  REFERENCES Cinsiyet(cinsiyet_ID)


ALTER TABLE KULLANICI
ADD CONSTRAINT FK_kullanıcıtürü
FOREIGN KEY (kullanıcıTürüID)  REFERENCES KullanıcıTürü(kullanıcıTürüID)

ALTER TABLE Sipariş
ADD CONSTRAINT FK_kullanıcı
FOREIGN KEY (kullanıcıID)  REFERENCES KULLANICI(kullanıcıID)
ON DELETE CASCADE 

ALTER TABLE Sipariş
ADD CONSTRAINT FK_ürünbeden
FOREIGN KEY (ürünBedenID)  REFERENCES ÜrünBeden(ürünBedenID)
ON DELETE CASCADE 

ALTER TABLE ÜrünBeden
ADD CONSTRAINT FK_beden
FOREIGN KEY (BedenID)  REFERENCES Beden(BedenID)

ALTER TABLE ÜrünBeden
ADD CONSTRAINT FK_ürünbedeni
FOREIGN KEY (ürünID)  REFERENCES Ürün(ürünID)
ON DELETE CASCADE 

ALTER TABLE ÜrünBeden
ADD CONSTRAINT FK_mankenürün
FOREIGN KEY (mankenID)  REFERENCES Manken(mankenID)
ON DELETE SET NULL

ALTER TABLE Ürün
ADD CONSTRAINT FK_ürüntürü
FOREIGN KEY (ürünTürüID)  REFERENCES ÜrünTürü(ürünTürüID)

ALTER TABLE Ürün
ADD CONSTRAINT FK_ürünbileşen
FOREIGN KEY (bileşenID)  REFERENCES BileşenOranı(bileşenID)

ALTER TABLE Ürün
ADD CONSTRAINT FK_ürüntasarımcı
FOREIGN KEY (tasarımcıID)  REFERENCES Tasarımcı(tasarımcıID)
ON DELETE SET NULL;

ALTER TABLE Manken
ADD CONSTRAINT FK_mankenbedeni
FOREIGN KEY (BedenID)  REFERENCES Beden(BedenID)

ALTER TABLE Tasarımcı
ADD CONSTRAINT FK_kullanıcıtasarımcı
FOREIGN KEY (kullanıcıID)  REFERENCES KULLANICI(kullanıcıID)
ON DELETE CASCADE

DELETE from Manken where mankenID=3;
DELETE from Ürün where ürünID=4;
DELETE from KULLANICI where kullanıcıID=2;
DELETE from KULLANICI where kullanıcıID=3;
DELETE from ÜrünBeden where ürünBedenID=4;
