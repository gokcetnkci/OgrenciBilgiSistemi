USE [OBS]
GO
/****** Object:  Table [dbo].[Bolum]    Script Date: 12.09.2019 10:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bolum](
	[BolumId] [int] IDENTITY(1,1) NOT NULL,
	[BolumAdi] [nvarchar](max) NULL,
	[FakulteAdi] [nvarchar](max) NULL,
 CONSTRAINT [PK_Bolum] PRIMARY KEY CLUSTERED 
(
	[BolumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ders]    Script Date: 12.09.2019 10:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ders](
	[DersId] [int] IDENTITY(1,1) NOT NULL,
	[DersAdi] [nvarchar](max) NULL,
	[DersKodu] [nchar](10) NULL,
	[Kredi] [int] NULL,
	[BolumId] [int] NULL,
	[AktifPasif] [smallint] NULL,
 CONSTRAINT [PK_Ders] PRIMARY KEY CLUSTERED 
(
	[DersId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ogrenci]    Script Date: 12.09.2019 10:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ogrenci](
	[OgrId] [int] IDENTITY(1,1) NOT NULL,
	[OgrNo] [int] NULL,
	[Ad] [nvarchar](max) NULL,
	[Soyad] [nvarchar](max) NULL,
	[Tc] [nvarchar](max) NULL,
	[BolumId] [int] NULL,
	[KayityapanID] [int] NULL,
	[KayitYapilantarih] [date] NULL,
	[DogumTarih] [date] NULL,
	[Cinsiyet] [smallint] NULL,
	[AktifPasif] [smallint] NULL,
	[Email] [nvarchar](max) NULL,
 CONSTRAINT [PK_Ogrenci] PRIMARY KEY CLUSTERED 
(
	[OgrId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ogretmen]    Script Date: 12.09.2019 10:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ogretmen](
	[OgretmenId] [int] IDENTITY(1,1) NOT NULL,
	[OgretmenAdi] [nvarchar](max) NULL,
	[Email] [nvarchar](50) NULL,
	[BolumId] [int] NULL,
 CONSTRAINT [PK_Ogretmen] PRIMARY KEY CLUSTERED 
(
	[OgretmenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ogretmen_Ogrenci_Ders]    Script Date: 12.09.2019 10:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ogretmen_Ogrenci_Ders](
	[Ogretmen_Ogrenci_DersID] [int] IDENTITY(1,1) NOT NULL,
	[Ogrt_Ogr_ID] [int] NULL,
	[DersID] [int] NULL,
	[Type] [int] NULL,
	[Vize1] [int] NULL,
	[Vize2] [int] NULL,
	[Final] [int] NULL,
 CONSTRAINT [PK_Ogretmen_Ogrenci_Ders] PRIMARY KEY CLUSTERED 
(
	[Ogretmen_Ogrenci_DersID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12.09.2019 10:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Ogrt_ogrID] [int] NULL,
	[Type] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bolum] ON 

INSERT [dbo].[Bolum] ([BolumId], [BolumAdi], [FakulteAdi]) VALUES (1, N'Bilgisayar Mühendisliği', N'Mühendislik Fakültesi')
INSERT [dbo].[Bolum] ([BolumId], [BolumAdi], [FakulteAdi]) VALUES (2, N'Makine Mühendisliği', N'Mühendislik Fakültesi')
INSERT [dbo].[Bolum] ([BolumId], [BolumAdi], [FakulteAdi]) VALUES (3, N'Elektrik-Elektronik Mühendisliği', N'Mühendislik Fakültesi')
INSERT [dbo].[Bolum] ([BolumId], [BolumAdi], [FakulteAdi]) VALUES (4, N'Ekonometri', N'İktisadi Ve İdari Bilimler Fakültesi')
INSERT [dbo].[Bolum] ([BolumId], [BolumAdi], [FakulteAdi]) VALUES (5, N'İktisat', N'İktisadi Ve İdari Bilimler Fakültesi')
INSERT [dbo].[Bolum] ([BolumId], [BolumAdi], [FakulteAdi]) VALUES (6, N'İşletme', N'İktisadi Ve İdari Bilimler Fakültesi')
SET IDENTITY_INSERT [dbo].[Bolum] OFF
SET IDENTITY_INSERT [dbo].[Ders] ON 

INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (1, N'Nesneye Yönelik Programlama', N'BIL105    ', 6, 1, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (2, N'Bilgisayar Mühendisliğine Giriş', N'BIL102    ', 3, 1, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (3, N'Veri Yapıları Ve Algoritmalar', N'BIL211    ', 4, 1, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (4, N'Web Tabanlı Programlama', N'BIL207    ', 4, 1, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (5, N'Makine Mühendisliğine Giriş', N'M211      ', 4, 2, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (6, N'Teknik Çizim', N'M109      ', 4, 2, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (7, N'Termodinamik', N'M111      ', 6, 2, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (8, N'Malzeme Bilimi', N'M206      ', 4, 2, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (9, N'Elektroteknik ', N'EEM206    ', 4, 3, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (10, N'Mantık Devreleri ', N'EEM204    ', 3, 3, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (11, N'Sayısal Analiz', N'EEM214    ', 4, 3, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (12, N'Doğrusal Cebir', N'EEM308    ', 4, 3, 0)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (13, N'Doğrusal Cebir', N'BIL308    ', 4, 1, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (14, N'Doğrusal Cebir', N'EEM308    ', 4, 3, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (15, N'Sosyoloji', N'EKO111    ', 2, 4, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (16, N'Genel Muhasebe', N'EKO110    ', 4, 4, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (17, N'İktisada Giriş', N'EKO206    ', 4, 4, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (18, N'Makro İktisat', N'EKO214    ', 5, 4, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (19, N'Borçlar Hukuku', N'IKT102    ', 4, 5, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (20, N'Genel Muhasebe I', N'IKT115    ', 3, 5, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (21, N'Genel Muhasebe II', N'IKT106    ', 3, 5, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (22, N'İktisat Tarihi', N'IKT210    ', 5, 5, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (23, N'İktisada Giriş', N'ISL104    ', 3, 6, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (24, N'Mikro İktisat', N'ISL112    ', 4, 6, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (25, N'Genel Muhasebe I', N'ISL108    ', 3, 6, 1)
INSERT [dbo].[Ders] ([DersId], [DersAdi], [DersKodu], [Kredi], [BolumId], [AktifPasif]) VALUES (26, N'Genel Muhasebe II', N'ISL202    ', 3, 6, 1)
SET IDENTITY_INSERT [dbo].[Ders] OFF
SET IDENTITY_INSERT [dbo].[Ogrenci] ON 

INSERT [dbo].[Ogrenci] ([OgrId], [OgrNo], [Ad], [Soyad], [Tc], [BolumId], [KayityapanID], [KayitYapilantarih], [DogumTarih], [Cinsiyet], [AktifPasif], [Email]) VALUES (1, 1141602039, N'Gökçe', N'Tenekeci', N'11111111111', 1, 2, CAST(N'2019-09-10' AS Date), CAST(N'1996-08-21' AS Date), 0, 1, N'gokce@gmail.com')
INSERT [dbo].[Ogrenci] ([OgrId], [OgrNo], [Ad], [Soyad], [Tc], [BolumId], [KayityapanID], [KayitYapilantarih], [DogumTarih], [Cinsiyet], [AktifPasif], [Email]) VALUES (2, 1141602021, N'Fadime', N'Açıkgöz', N'22222222222', 1, 2, CAST(N'2019-09-10' AS Date), CAST(N'1996-11-20' AS Date), 0, 1, N'fadime@gmail.com')
INSERT [dbo].[Ogrenci] ([OgrId], [OgrNo], [Ad], [Soyad], [Tc], [BolumId], [KayityapanID], [KayitYapilantarih], [DogumTarih], [Cinsiyet], [AktifPasif], [Email]) VALUES (3, 1141602003, N'Zeynep', N'Pektaş', N'33333333333', 2, 2, CAST(N'2019-09-11' AS Date), CAST(N'1995-09-17' AS Date), 0, 1, N'zeynep@gmail.com')
INSERT [dbo].[Ogrenci] ([OgrId], [OgrNo], [Ad], [Soyad], [Tc], [BolumId], [KayityapanID], [KayitYapilantarih], [DogumTarih], [Cinsiyet], [AktifPasif], [Email]) VALUES (4, 1141602015, N'Rengin', N'Atilla', N'44444444444', 2, 2, CAST(N'2019-09-10' AS Date), CAST(N'1997-07-17' AS Date), 0, 1, N'rengin@gmail.com')
INSERT [dbo].[Ogrenci] ([OgrId], [OgrNo], [Ad], [Soyad], [Tc], [BolumId], [KayityapanID], [KayitYapilantarih], [DogumTarih], [Cinsiyet], [AktifPasif], [Email]) VALUES (5, 1191702001, N'Mehmet', N'Özer', N'32165498765', 3, 2, CAST(N'2019-09-11' AS Date), CAST(N'1996-08-21' AS Date), 1, 1, N'mehmet@gmail.om')
INSERT [dbo].[Ogrenci] ([OgrId], [OgrNo], [Ad], [Soyad], [Tc], [BolumId], [KayityapanID], [KayitYapilantarih], [DogumTarih], [Cinsiyet], [AktifPasif], [Email]) VALUES (6, 1191702012, N'Barış', N'Çelebi', N'65432002687', 3, 2, CAST(N'2019-09-11' AS Date), CAST(N'1998-05-04' AS Date), 1, 1, N'baris@gmail.com')
INSERT [dbo].[Ogrenci] ([OgrId], [OgrNo], [Ad], [Soyad], [Tc], [BolumId], [KayityapanID], [KayitYapilantarih], [DogumTarih], [Cinsiyet], [AktifPasif], [Email]) VALUES (7, 1191401023, N'Ahmet', N'Yıldız', N'12320654253', 4, 2, CAST(N'2019-09-11' AS Date), CAST(N'1998-02-17' AS Date), 1, 1, N'ahmet@gmail.com')
INSERT [dbo].[Ogrenci] ([OgrId], [OgrNo], [Ad], [Soyad], [Tc], [BolumId], [KayityapanID], [KayitYapilantarih], [DogumTarih], [Cinsiyet], [AktifPasif], [Email]) VALUES (8, 1191401016, N'Merve', N'Öner', N'32105648623', 4, 2, CAST(N'2019-09-11' AS Date), CAST(N'1997-10-21' AS Date), 0, 1, N'merve@gmail.com')
INSERT [dbo].[Ogrenci] ([OgrId], [OgrNo], [Ad], [Soyad], [Tc], [BolumId], [KayityapanID], [KayitYapilantarih], [DogumTarih], [Cinsiyet], [AktifPasif], [Email]) VALUES (9, 1191502008, N'Duygu', N'Aktaş', N'21265412325', 5, 2, CAST(N'2019-09-11' AS Date), CAST(N'1996-04-01' AS Date), 0, 1, N'duygu@gmail.com')
INSERT [dbo].[Ogrenci] ([OgrId], [OgrNo], [Ad], [Soyad], [Tc], [BolumId], [KayityapanID], [KayitYapilantarih], [DogumTarih], [Cinsiyet], [AktifPasif], [Email]) VALUES (10, 1191502010, N'Deniz', N'Köse', N'32154865321', 5, 2, CAST(N'2019-09-11' AS Date), CAST(N'1986-08-12' AS Date), 1, 1, N'deniz@gmail.com')
SET IDENTITY_INSERT [dbo].[Ogrenci] OFF
SET IDENTITY_INSERT [dbo].[Ogretmen] ON 

INSERT [dbo].[Ogretmen] ([OgretmenId], [OgretmenAdi], [Email], [BolumId]) VALUES (1, N'admin', NULL, NULL)
INSERT [dbo].[Ogretmen] ([OgretmenId], [OgretmenAdi], [Email], [BolumId]) VALUES (2, N'Hakan Yıldırım', N'hakan@gmail.com', 1)
INSERT [dbo].[Ogretmen] ([OgretmenId], [OgretmenAdi], [Email], [BolumId]) VALUES (3, N'Cem Taşkın', N'cem@gmail.com', 1)
INSERT [dbo].[Ogretmen] ([OgretmenId], [OgretmenAdi], [Email], [BolumId]) VALUES (4, N'Aydın Carus', N'aydin@gmail.com', 1)
INSERT [dbo].[Ogretmen] ([OgretmenId], [OgretmenAdi], [Email], [BolumId]) VALUES (5, N'Özlem Aydın', N'ozlem@gmail.com', 1)
INSERT [dbo].[Ogretmen] ([OgretmenId], [OgretmenAdi], [Email], [BolumId]) VALUES (6, N'Hasan Keskin', N'hasan@gmail.com', 2)
INSERT [dbo].[Ogretmen] ([OgretmenId], [OgretmenAdi], [Email], [BolumId]) VALUES (7, N'Berk Aydoğdu', N'berk@gmail.com', 2)
INSERT [dbo].[Ogretmen] ([OgretmenId], [OgretmenAdi], [Email], [BolumId]) VALUES (8, N'Melike Genç', N'melike@gmail.com', 2)
INSERT [dbo].[Ogretmen] ([OgretmenId], [OgretmenAdi], [Email], [BolumId]) VALUES (9, N'Alper Çakır', N'alper@gmail.com', 2)
INSERT [dbo].[Ogretmen] ([OgretmenId], [OgretmenAdi], [Email], [BolumId]) VALUES (10, N'Burak Türkeri', N'burak@gmail.com', 3)
INSERT [dbo].[Ogretmen] ([OgretmenId], [OgretmenAdi], [Email], [BolumId]) VALUES (11, N'Suzan Demirbaş', N'suzan@gmail.com', 3)
INSERT [dbo].[Ogretmen] ([OgretmenId], [OgretmenAdi], [Email], [BolumId]) VALUES (12, N'Gizem Taşkın', N'gizem@gmail.com', 3)
INSERT [dbo].[Ogretmen] ([OgretmenId], [OgretmenAdi], [Email], [BolumId]) VALUES (13, N'Ali Duru', N'ali@gmail.com', 4)
INSERT [dbo].[Ogretmen] ([OgretmenId], [OgretmenAdi], [Email], [BolumId]) VALUES (14, N'Tolga Sakallı', N'tolga@gmail.com', 4)
INSERT [dbo].[Ogretmen] ([OgretmenId], [OgretmenAdi], [Email], [BolumId]) VALUES (15, N'Altan Mesut', N'altan@gmail.com', 4)
INSERT [dbo].[Ogretmen] ([OgretmenId], [OgretmenAdi], [Email], [BolumId]) VALUES (16, N'İlhan Umut', N'ilhan@gmail.com', 5)
INSERT [dbo].[Ogretmen] ([OgretmenId], [OgretmenAdi], [Email], [BolumId]) VALUES (17, N'Derya Arda', N'derya@gmail.com', 5)
INSERT [dbo].[Ogretmen] ([OgretmenId], [OgretmenAdi], [Email], [BolumId]) VALUES (18, N'Özlem Uçar', N'ozlem@gmail.com', 5)
INSERT [dbo].[Ogretmen] ([OgretmenId], [OgretmenAdi], [Email], [BolumId]) VALUES (19, N'Emir Öztürk', N'emir@gmail.com', 6)
INSERT [dbo].[Ogretmen] ([OgretmenId], [OgretmenAdi], [Email], [BolumId]) VALUES (20, N'Tuğba Çalış', N'tugba@gmail.com', 6)
INSERT [dbo].[Ogretmen] ([OgretmenId], [OgretmenAdi], [Email], [BolumId]) VALUES (21, N'Deniz Taşkın', N'deniz@gmail.com', 6)
SET IDENTITY_INSERT [dbo].[Ogretmen] OFF
SET IDENTITY_INSERT [dbo].[Ogretmen_Ogrenci_Ders] ON 

INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (1, 2, 1, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (2, 5, 2, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (3, 4, 3, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (4, 3, 4, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (47, 6, 5, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (48, 7, 6, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (49, 8, 7, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (50, 9, 8, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (51, 10, 9, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (52, 11, 10, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (53, 12, 11, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (54, 10, 12, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (132, 1, 1, 2, 75, 20, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (133, 1, 2, 2, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (134, 1, 3, 2, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (135, 1, 4, 2, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (136, 2, 1, 2, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (137, 2, 2, 2, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (138, 4, 5, 2, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (139, 4, 6, 2, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (140, 4, 7, 2, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (141, 13, 15, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (142, 14, 16, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (143, 15, 17, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (144, 14, 18, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (145, 16, 19, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (146, 17, 20, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (147, 17, 21, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (148, 18, 22, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (149, 19, 23, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (150, 20, 24, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (151, 21, 25, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (152, 21, 26, 1, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (153, 8, 15, 2, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (154, 8, 16, 2, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (155, 8, 17, 2, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (156, 10, 19, 2, 55, 85, 45)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (157, 10, 20, 2, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (158, 10, 21, 2, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (159, 10, 22, 2, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (160, 9, 19, 2, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (161, 9, 20, 2, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (162, 9, 21, 2, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (163, 7, 15, 2, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (164, 7, 16, 2, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (165, 7, 17, 2, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (166, 7, 18, 2, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (167, 6, 9, 2, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (168, 6, 10, 2, 0, 0, 0)
INSERT [dbo].[Ogretmen_Ogrenci_Ders] ([Ogretmen_Ogrenci_DersID], [Ogrt_Ogr_ID], [DersID], [Type], [Vize1], [Vize2], [Final]) VALUES (169, 6, 11, 2, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Ogretmen_Ogrenci_Ders] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [Username], [Password], [Ogrt_ogrID], [Type]) VALUES (1, N'admin', N'1234', 2, 3)
INSERT [dbo].[User] ([UserId], [Username], [Password], [Ogrt_ogrID], [Type]) VALUES (2, N'1141602039', N'2039', 1, 2)
INSERT [dbo].[User] ([UserId], [Username], [Password], [Ogrt_ogrID], [Type]) VALUES (3, N'1141602021', N'2021', 2, 2)
INSERT [dbo].[User] ([UserId], [Username], [Password], [Ogrt_ogrID], [Type]) VALUES (4, N'1141602003', N'2003', 3, 2)
INSERT [dbo].[User] ([UserId], [Username], [Password], [Ogrt_ogrID], [Type]) VALUES (5, N'1141602015', N'2015', 4, 2)
INSERT [dbo].[User] ([UserId], [Username], [Password], [Ogrt_ogrID], [Type]) VALUES (6, N'hakan', N'1234', 2, 1)
INSERT [dbo].[User] ([UserId], [Username], [Password], [Ogrt_ogrID], [Type]) VALUES (7, N'berk', N'1122', 7, 1)
INSERT [dbo].[User] ([UserId], [Username], [Password], [Ogrt_ogrID], [Type]) VALUES (8, N'1191702001', N'2001', 5, 2)
INSERT [dbo].[User] ([UserId], [Username], [Password], [Ogrt_ogrID], [Type]) VALUES (9, N'1191702012', N'2012', 6, 2)
INSERT [dbo].[User] ([UserId], [Username], [Password], [Ogrt_ogrID], [Type]) VALUES (10, N'1191401023', N'1023', 7, 2)
INSERT [dbo].[User] ([UserId], [Username], [Password], [Ogrt_ogrID], [Type]) VALUES (11, N'1191401016', N'1016', 8, 2)
INSERT [dbo].[User] ([UserId], [Username], [Password], [Ogrt_ogrID], [Type]) VALUES (12, N'1191502008', N'2008', 9, 2)
INSERT [dbo].[User] ([UserId], [Username], [Password], [Ogrt_ogrID], [Type]) VALUES (13, N'1191502010', N'2010', 10, 2)
INSERT [dbo].[User] ([UserId], [Username], [Password], [Ogrt_ogrID], [Type]) VALUES (14, N'burak', N'1234', 10, 1)
INSERT [dbo].[User] ([UserId], [Username], [Password], [Ogrt_ogrID], [Type]) VALUES (15, N'ali', N'1234', 13, 1)
INSERT [dbo].[User] ([UserId], [Username], [Password], [Ogrt_ogrID], [Type]) VALUES (16, N'ilhan', N'1234', 16, 1)
INSERT [dbo].[User] ([UserId], [Username], [Password], [Ogrt_ogrID], [Type]) VALUES (17, N'derya', N'1234', 17, 1)
INSERT [dbo].[User] ([UserId], [Username], [Password], [Ogrt_ogrID], [Type]) VALUES (18, N'deniz', N'1234', 21, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Ders]  WITH CHECK ADD  CONSTRAINT [FK_Ders_Bolum] FOREIGN KEY([BolumId])
REFERENCES [dbo].[Bolum] ([BolumId])
GO
ALTER TABLE [dbo].[Ders] CHECK CONSTRAINT [FK_Ders_Bolum]
GO
ALTER TABLE [dbo].[Ogrenci]  WITH CHECK ADD  CONSTRAINT [FK_Ogrenci_Bolum] FOREIGN KEY([BolumId])
REFERENCES [dbo].[Bolum] ([BolumId])
GO
ALTER TABLE [dbo].[Ogrenci] CHECK CONSTRAINT [FK_Ogrenci_Bolum]
GO
ALTER TABLE [dbo].[Ogrenci]  WITH CHECK ADD  CONSTRAINT [FK_Ogrenci_Ogretmen] FOREIGN KEY([KayityapanID])
REFERENCES [dbo].[Ogretmen] ([OgretmenId])
GO
ALTER TABLE [dbo].[Ogrenci] CHECK CONSTRAINT [FK_Ogrenci_Ogretmen]
GO
ALTER TABLE [dbo].[Ogretmen]  WITH CHECK ADD  CONSTRAINT [FK_Ogretmen_Bolum] FOREIGN KEY([BolumId])
REFERENCES [dbo].[Bolum] ([BolumId])
GO
ALTER TABLE [dbo].[Ogretmen] CHECK CONSTRAINT [FK_Ogretmen_Bolum]
GO
ALTER TABLE [dbo].[Ogretmen_Ogrenci_Ders]  WITH CHECK ADD  CONSTRAINT [FK_Ogretmen_Ogrenci_Ders_Ders] FOREIGN KEY([DersID])
REFERENCES [dbo].[Ders] ([DersId])
GO
ALTER TABLE [dbo].[Ogretmen_Ogrenci_Ders] CHECK CONSTRAINT [FK_Ogretmen_Ogrenci_Ders_Ders]
GO
ALTER TABLE [dbo].[Ogretmen_Ogrenci_Ders]  WITH CHECK ADD  CONSTRAINT [FK_Ogretmen_Ogrenci_Ders_Ogretmen] FOREIGN KEY([Ogrt_Ogr_ID])
REFERENCES [dbo].[Ogretmen] ([OgretmenId])
GO
ALTER TABLE [dbo].[Ogretmen_Ogrenci_Ders] CHECK CONSTRAINT [FK_Ogretmen_Ogrenci_Ders_Ogretmen]
GO
