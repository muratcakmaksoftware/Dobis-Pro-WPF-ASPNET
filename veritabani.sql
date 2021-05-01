CREATE TABLE kullanicilar(
	id int not null IDENTITY(1,1),
	isim varchar(1000),
	kadi varchar(1000),
	sifre varchar(1000),
	resim varchar(MAX)
	PRIMARY KEY (id)
)
INSERT INTO kullanicilar (isim,kadi,sifre) VALUES ('Murat Çakmak', 'murat','1234')
	CREATE PROCEDURE kullaniciKontrol
		@kadi varchar(1000),
		@sifre varchar(1000)
	AS
	BEGIN 
		SELECT * FROM kullanicilar WHERE kadi=@kadi AND sifre=@sifre
	END


CREATE TABLE slayt(
	id int not null IDENTITY(1,1),
	resimAdi varchar(1000),
	resimSira int not null,
	resim varchar(MAX)	
	PRIMARY KEY (id)
)
	CREATE PROCEDURE resimEkle
		@resimAdi varchar(1000),
		@resimSira int,
		@resimData varchar(MAX)
	AS
	BEGIN
		INSERT INTO slayt(resimAdi,resimSira,resim) VALUES (@resimAdi, @resimSira, @resimData); 
	END
	
	CREATE PROCEDURE slaytlariGetir
	AS
	BEGIN
		SELECT * FROM slayt ORDER BY resimSira ASC
	END
	
	CREATE PROCEDURE slaytigetir
		@id int
	AS
	BEGIN
		SELECT * FROM slayt WHERE id=@id
	END
	
	CREATE PROCEDURE slaytGuncelle
		@id int,
		@resimAdi varchar(1000),
		@resimSira int,
		@resimData varchar(MAX)
	AS
	BEGIN
		UPDATE slayt SET resimAdi=@resimAdi, resimSira=@resimSira, resim=@resimData WHERE id=@id
	END
	
	CREATE PROCEDURE slaytsil
		@id int
	AS
	BEGIN
		DELETE FROM slayt WHERE id=@id
	END
	
CREATE TABLE genel(
	id int,
	okulAdi varchar(1000),
	slaytSuresi int,
	beklemeSuresi int,
	sayfaBasiFiyat decimal (20,2) NOT NULL DEFAULT 0 
)
INSERT INTO genel (id, okulAdi, slaytSuresi, beklemeSuresi, sayfaBasiFiyat) VALUES (1, 'Maltepe Üniversitesi', 1, 3, 1);

	CREATE PROCEDURE genelguncelle
		@okulAdi varchar(1000),
		@slaytSuresi int,
		@beklemeSuresi int,
		@sayfaBasiFiyat decimal(20,2)
		
	AS
	BEGIN
		UPDATE genel SET okulAdi=@okulAdi, slaytSuresi=@slaytSuresi, beklemeSuresi=@beklemeSuresi, sayfaBasiFiyat=@sayfaBasiFiyat
	END
	
	CREATE PROCEDURE genelgetir
	AS
	BEGIN
		SELECT * FROM genel
	END
	
CREATE TABLE ogrencibilgileri(
  id int not null IDENTITY(1,1),
  isim varchar(1000) NOT NULL,
  tcno varchar(11) NOT NULL,
  sifre varchar(20) NOT NULL,
  okulno varchar(MAX) NOT NULL,
  ogSinif varchar(1000) NOT NULL,
  ogResim varchar(MAX) NOT NULL,
  miktar decimal (20,2) NOT NULL DEFAULT 0 
  PRIMARY KEY (id)
)

	CREATE PROCEDURE ogrencilogin
		@ogtc varchar(11),
		@ogsifre varchar(20)
	AS
	BEGIN
		SELECT * FROM ogrencibilgileri WHERE tcno=@ogtc AND sifre=@ogsifre
	END
	
	CREATE PROCEDURE ogrenciekle
		@ogrenciAdi varchar(1000),
		@tcno varchar(11),
		@sifre varchar(20),
		@okulNo varchar(MAX),
		@sinif varchar(1000),
		@miktar decimal(20,2),
		@resimData varchar(MAX)		
	AS
	BEGIN
		INSERT INTO ogrencibilgileri (isim,tcno,sifre,okulno,ogSinif,miktar,ogResim) VALUES (@ogrenciAdi,@tcno,@sifre,@okulNo,@sinif,@miktar,@resimData)	
	END
	
	
	CREATE PROCEDURE ogrencilerigetir
	AS
	BEGIN
		SELECT * FROM ogrencibilgileri
	END
	
	CREATE PROCEDURE ogrenciyigetir
		@id int
	AS
	BEGIN
		SELECT * FROM ogrencibilgileri WHERE id=@id
	END
	
	CREATE PROCEDURE ogrenciguncelle
		@id int,
		@ogrenciAdi varchar(1000),
		@tcno varchar(11),
		@sifre varchar(20),
		@okulNo varchar(MAX),
		@sinif varchar(1000),
		@miktar decimal(20,2),
		@resimData varchar(MAX)	
	AS
	BEGIN
		UPDATE ogrencibilgileri SET isim=@ogrenciAdi, tcno=@tcno, sifre=@sifre, okulno=@okulNo, ogSinif=@sinif, miktar=@miktar, ogResim=@resimData WHERE id=@id
	END
	
	CREATE PROCEDURE ogrencisil
		@id int
	AS
	BEGIN
		DELETE FROM ogrencibilgileri WHERE id=@id
	END
	
	CREATE PROCEDURE ogrenciara
		@tcno varchar(11),
		@ogrenciAdi varchar(1000),
		@okulno varchar(MAX)
	AS
	BEGIN
		SELECT * FROM ogrencibilgileri WHERE tcno LIKE ''+@tcno+'%' OR isim LIKE ''+@ogrenciAdi+'%' OR okulno LIKE ''+@okulno+'%'
	END
	
	CREATE PROCEDURE ogrenciYazici
		@id int,
		@yeniBakiye decimal
	AS
	BEGIN
		UPDATE ogrencibilgileri SET miktar=@yeniBakiye WHERE id=@id
	END
	
	
CREATE TABLE dilekvesikayet(
	id int not null IDENTITY(1,1),
	konu varchar(MAX),
	mesaj varchar(MAX),
	okunma bit DEFAULT 0
	PRIMARY KEY (id)
)

	CREATE PROCEDURE dvsekle
		@konu varchar(MAX),
		@mesaj varchar(MAX)
	AS
	BEGIN
		INSERT INTO dilekvesikayet (konu,mesaj) VALUES (@konu,@mesaj)
	END
	
	CREATE PROCEDURE dvsgetir
	AS
	BEGIN
		SELECT id,konu=LEFT(konu, 30), mesaj=LEFT(mesaj, 30), okunma FROM dilekvesikayet
	END
	
	CREATE PROCEDURE dvsokunduisaretle
		@id int
	AS
	BEGIN
		UPDATE dilekvesikayet SET okunma=1 WHERE id=@id
	END
	
	CREATE PROCEDURE dvsokunanmesaj
		@id int
	AS
	BEGIN
		SELECT * FROM dilekvesikayet WHERE id=@id
	END
	
	CREATE PROCEDURE dvssil
		@id int
	AS
	BEGIN
		DELETE FROM dilekvesikayet WHERE id=@id
	END

CREATE TABLE dersprogramiResim(
	id int not null IDENTITY(1,1),
	sinif varchar(1000),
	resimAdi varchar(1000),
	resim varchar(MAX)
	PRIMARY KEY (id)	
)

	CREATE PROCEDURE dprgetir		
	AS	
	BEGIN
		SELECT * FROM dersprogramiResim
	END
	
	CREATE PROCEDURE dprSadeceSinifResmi
	AS	
	BEGIN
		SELECT * FROM dersprogramiResim WHERE sinif != ''
	END
	
	CREATE PROCEDURE dprgetirid		
		@id int
	AS	
	BEGIN
		SELECT * FROM dersprogramiResim WHERE id=@id
	END
	
	CREATE PROCEDURE dprekle
		@sinif varchar(1000),
		@resimAdi varchar(1000),
		@resim varchar(MAX)
	AS	
	BEGIN
		INSERT INTO dersprogramiResim (sinif,resimAdi,resim) VALUES (@sinif, @resimAdi,@resim)
	END

	CREATE PROCEDURE dprguncelle
		@id int,
		@sinif varchar(1000),
		@resimAdi varchar(1000),
		@resim varchar(MAX)
	AS	
	BEGIN
		UPDATE dersprogramiResim SET sinif=@sinif, resimAdi=@resimAdi, resim=@resim WHERE id=@id
	END
	
	CREATE PROCEDURE dprsil		
		@id int
	AS	
	BEGIN
		DELETE FROM dersprogramiResim WHERE id=@id
	END
	--Seçilen ders programında ders in olduğu bölgenin resmini getirir.
	CREATE PROCEDURE dprbolgegetir
		@resimAdi varchar(1000)
	AS
	BEGIN
		SELECT * FROM dersprogramiResim WHERE resimAdi=@resimAdi
	END
	
CREATE TABLE idaribirimler(
	id int not null IDENTITY(1,1),
	resimAdi varchar(1000),
	resim varchar(MAX)
)

	CREATE PROCEDURE ibgetir		
	AS	
	BEGIN
		SELECT * FROM idaribirimler
	END
	
	CREATE PROCEDURE ibgetirid
		@id int
	AS	
	BEGIN
		SELECT * FROM idaribirimler WHERE id=@id
	END
	
	CREATE PROCEDURE ibekle
		@resimAdi varchar(1000),
		@resim varchar(MAX)	
	AS	
	BEGIN
		INSERT INTO idaribirimler (resimAdi, resim) VALUES (@resimAdi, @resim)
	END
	
	CREATE PROCEDURE ibguncelle	
		@id int,
		@resimAdi varchar(1000),
		@resim varchar(MAX)	
	AS	
	BEGIN
		UPDATE idaribirimler SET resimAdi=@resimAdi, resim=@resim WHERE id=@id
	END
	
	CREATE PROCEDURE ibsil		
		@id int
	AS	
	BEGIN
		DELETE FROM idaribirimler WHERE id=@id
	END
	
CREATE TABLE dersprogrami (
  id int not null IDENTITY(1,1),
  sinif varchar(1000),
  ders varchar(1000),
  giris time,
  cikis time,
  pztDersAdi varchar(1000),
  pztDersOgretmen varchar(1000),
  pztDersSinif varchar(1000),
  saliDersAdi varchar(1000),
  saliDersOgretmen varchar(1000),
  saliDersSinif varchar(1000),
  carDersAdi varchar(1000),
  carDersOgretmen varchar(1000),
  carDersSinif varchar(1000),
  perDersAdi varchar(1000),
  perDersOgretmen varchar(1000),
  perDersSinif varchar(1000),
  cumaDersAdi varchar(1000),
  cumaDersOgretmen varchar(1000),
  cumaDersSinif varchar(1000)
  PRIMARY KEY (id)
)

	CREATE PROCEDURE dpekle
	  @sinif varchar(1000),
	  @ders varchar(1000),
	  @giris time,
	  @cikis time,
	  @pztDersAdi varchar(1000),
	  @pztDersOgretmen varchar(1000),
	  @pztDersSinif varchar(1000),
	  @saliDersAdi varchar(1000),
	  @saliDersOgretmen varchar(1000),
	  @saliDersSinif varchar(1000),
	  @carDersAdi varchar(1000),
	  @carDersOgretmen varchar(1000),
	  @carDersSinif varchar(1000),
	  @perDersAdi varchar(1000),
	  @perDersOgretmen varchar(1000),
	  @perDersSinif varchar(1000),
	  @cumaDersAdi varchar(1000),
	  @cumaDersOgretmen varchar(1000),
	  @cumaDersSinif varchar(1000)
	AS
	BEGIN 
		INSERT INTO dersprogrami (sinif,ders,giris,cikis,pztDersAdi,pztDersOgretmen, pztDersSinif, saliDersAdi, saliDersOgretmen, saliDersSinif, carDersAdi, carDersOgretmen, carDersSinif, perDersAdi, perDersOgretmen, perDersSinif, cumaDersAdi, cumaDersOgretmen, cumaDersSinif) VALUES
		(@sinif, @ders, @giris, @cikis, @pztDersAdi, @pztDersOgretmen, @pztDersSinif, @saliDersAdi, @saliDersOgretmen, @saliDersSinif, @carDersAdi, @carDersOgretmen, @carDersSinif, @perDersAdi, @perDersOgretmen, @perDersSinif, @cumaDersAdi, @cumaDersOgretmen, @cumaDersSinif)
	END
	
	
	CREATE PROCEDURE dpsil
		@sinif varchar(1000)
	AS
	BEGIN
		DELETE FROM dersprogrami WHERE sinif=@sinif
	END
	
	CREATE PROCEDURE dpgetirsinif
		@sinif varchar(1000)
	AS
	BEGIN
		SELECT * FROM dersprogrami WHERE sinif=@sinif
	END
	