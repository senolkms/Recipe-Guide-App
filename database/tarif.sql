USE [master]
GO
/****** Object:  Database [TarifRehberi]    Script Date: 13.02.2025 22:01:04 ******/
CREATE DATABASE [TarifRehberi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TarifRehberi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SENOL\MSSQL\DATA\TarifRehberi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TarifRehberi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SENOL\MSSQL\DATA\TarifRehberi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [TarifRehberi] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TarifRehberi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TarifRehberi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TarifRehberi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TarifRehberi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TarifRehberi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TarifRehberi] SET ARITHABORT OFF 
GO
ALTER DATABASE [TarifRehberi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TarifRehberi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TarifRehberi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TarifRehberi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TarifRehberi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TarifRehberi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TarifRehberi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TarifRehberi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TarifRehberi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TarifRehberi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TarifRehberi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TarifRehberi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TarifRehberi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TarifRehberi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TarifRehberi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TarifRehberi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TarifRehberi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TarifRehberi] SET RECOVERY FULL 
GO
ALTER DATABASE [TarifRehberi] SET  MULTI_USER 
GO
ALTER DATABASE [TarifRehberi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TarifRehberi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TarifRehberi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TarifRehberi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TarifRehberi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TarifRehberi] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TarifRehberi', N'ON'
GO
ALTER DATABASE [TarifRehberi] SET QUERY_STORE = ON
GO
ALTER DATABASE [TarifRehberi] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [TarifRehberi]
GO
/****** Object:  Table [dbo].[Malzemeler]    Script Date: 13.02.2025 22:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Malzemeler](
	[MalzemeID] [int] IDENTITY(1,1) NOT NULL,
	[MalzemeAdi] [varchar](255) NOT NULL,
	[ToplamMiktar] [varchar](100) NULL,
	[MalzemeBirim] [varchar](50) NULL,
	[BirimFiyat] [float] NULL,
 CONSTRAINT [PK__Malzemel__4ED155E0DC3F9A10] PRIMARY KEY CLUSTERED 
(
	[MalzemeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarifler]    Script Date: 13.02.2025 22:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarifler](
	[TarifID] [int] IDENTITY(1,1) NOT NULL,
	[TarifAdi] [varchar](255) NOT NULL,
	[Kategori] [varchar](100) NOT NULL,
	[HazirlamaSuresi] [int] NOT NULL,
	[Talimatlar] [text] NOT NULL,
	[Resim] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[TarifID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TarifMalzeme]    Script Date: 13.02.2025 22:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TarifMalzeme](
	[TarifID] [int] NOT NULL,
	[MalzemeID] [int] NOT NULL,
	[MalzemeMiktar] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TarifID] ASC,
	[MalzemeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Malzemeler] ON 

INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (1, N'Domates', N'1', N'kg', 5.5)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (2, N'Biber', N'50', N'kg', 7)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (3, N'Soğan', N'75', N'kg', 3.5)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (4, N'Yumurta', N'500', N'adet', 1)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (5, N'Patlıcan', N'80', N'kg', 6.5)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (6, N'Kıyma', N'50', N'kg', 85)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (7, N'Yoğurt', N'100', N'litre', 12)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (8, N'Salatalık', N'60', N'kg', 4.5)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (9, N'Sarımsak', N'10', N'kg', 20)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (10, N'Kırmızı Mercimek', N'40', N'kg', 15)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (11, N'Havuç', N'30', N'kg', 4)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (12, N'Un', N'1', N'kg', 8)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (13, N'Şeker', N'75', N'kg', 10)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (14, N'Sucuk', N'30', N'kg', 120)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (15, N'Peynir', N'40', N'kg', 70)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (16, N'Pirinç', N'50', N'kg', 25)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (17, N'Süt', N'200', N'litre', 10)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (18, N'Tereyağı', N'20', N'kg', 150)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (19, N'Zeytinyağı', N'50', N'litre', 80)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (20, N'Ceviz', N'25', N'kg', 120)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (21, N'Baklava Yufkası', N'1', N'paket', 15)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (22, N'Tavuk', N'75', N'kg', 50)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (23, N'Kabak', N'40', N'kg', 5)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (24, N'Kuru Fasulye', N'30', N'kg', 30)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (25, N'Taze Fasulye', N'35', N'kg', 15)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (26, N'Şehriye', N'20', N'kg', 12)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (27, N'Limon', N'30', N'kg', 8)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (28, N'Bulgur', N'40', N'kg', 15)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (29, N'Mantar', N'25', N'kg', 25)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (30, N'Kuru Üzüm', N'10', N'kg', 40)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (31, N'Fındık', N'15', N'kg', 150)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (32, N'Nohut', N'30', N'kg', 25)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (33, N'Kuşbaşı Et', N'40', N'kg', 120)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (34, N'Tahin', N'10', N'kg', 60)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (35, N'Brokoli', N'30', N'kg', 20)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (36, N'Krema', N'20', N'litre', 40)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (37, N'Kaşar Peyniri', N'30', N'kg', 90)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (38, N'Margarin', N'25', N'kg', 40)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (39, N'Makarna', N'50', N'kg', 10)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (40, N'Portakal', N'60', N'kg', 7)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (41, N'Tuz', N'50', N'kg', 2)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (42, N'Karabiber', N'10', N'kg', 100)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (43, N'Pul Biber', N'5', N'kg', 80)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (44, N'Salça', N'30', N'kg', 20)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (45, N'Sıvı Yağ', N'100', N'litre', 30)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (46, N'Maydanoz', N'10', N'kg', 15)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (47, N'Dereotu', N'5', N'kg', 20)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (48, N'Nane', N'5', N'kg', 25)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (49, N'Kimyon', N'5', N'kg', 60)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (50, N'Karbonat', N'5', N'kg', 10)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (51, N'Kabartma Tozu', N'2', N'kg', 5)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (52, N'Tarhana', N'5', N'kg', 15)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (53, N'Ekmek', N'10', N'adet', 10)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (54, N'Su', N'10', N'litre', 15)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (55, N'Barbunya', N'5', N'kg', 20)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (56, N'Buğday', N'3', N'kg', 8)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (57, N'Badem', N'4', N'kg', 12)
INSERT [dbo].[Malzemeler] ([MalzemeID], [MalzemeAdi], [ToplamMiktar], [MalzemeBirim], [BirimFiyat]) VALUES (58, N'Pide', N'3', N'kg', 15)
SET IDENTITY_INSERT [dbo].[Malzemeler] OFF
GO
SET IDENTITY_INSERT [dbo].[Tarifler] ON 

INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (1, N'Menemen', N'Kahvaltı', 20, N'Domates, biber ve soğanı küp küp doğrayın. Tavada yağı kızdırın, soğanları kavurun. Biber ve domatesi ekleyip pişirin. Yumurtaları kırıp karıştırın.', N'C:\Users\senol\Desktop\img\kiymalimenemen.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (2, N'Karnıyarık', N'Ana Yemek', 10, N'Patlıcanları yarıp kızartın. İç harcı için soğan, kıyma ve domatesi kavurun. Patlıcanları doldurup fırınlayın.', N'C:\Users\senol\Desktop\img\2.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (3, N'Cacık', N'Yan Yemek', 15, N'Yoğurdu çırpın. Salatalığı rendeleyin. Sarımsağı ezin. Tüm malzemeleri karıştırıp nane ve zeytinyağı ekleyin.', N'C:\Users\senol\Desktop\img\3.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (4, N'Mercimek Çorbası', N'Çorba', 40, N'Mercimeği haşlayın. Soğan ve havucu kavurun. Tüm malzemeleri blenderdan geçirin. Tuz ve baharatlarla tatlandırın.', N'C:\Users\senol\Desktop\img\4.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (5, N'Revani', N'Tatlı', 50, N'Un, yumurta ve şekeri çırpın. Yoğurt ve kabartma tozu ekleyin. Karışımı yağlanmış tepsiye dökün. Pişirdikten sonra şerbetini dökün.', N'C:\Users\senol\Desktop\img\5.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (6, N'Sucuklu Yumurta', N'Kahvaltı', 15, N'Sucukları dilimleyip tavada kızartın. Üzerine yumurtaları kırın ve pişirin.', N'C:\Users\senol\Desktop\img\6.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (7, N'İmam Bayıldı', N'Ana Yemek', 70, N'Patlıcanları oyun. Soğan, domates ve biberi kavurun. Patlıcanları doldurup fırınlayın.', N'C:\Users\senol\Desktop\img\7.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (8, N'Haydari', N'Yan Yemek', 20, N'Süzme yoğurdu ezilmiş sarımsak, kekik ve zeytinyağı ile karıştırın. Üzerine kuru nane serpin.', N'C:\Users\senol\Desktop\img\8.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (9, N'Domates Çorbası', N'Çorba', 30, N'Domatesleri rendeleyin. Soğan ve sarımsağı kavurun. Domates salçası ekleyin. Kaynatıp blenderdan geçirin.', N'C:\Users\senol\Desktop\img\9.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (10, N'Kazandibi', N'Tatlı', 60, N'Süt, şeker ve unu kaynatın. Muhallebiyi tepsiye dökün. Fırında üstünü kızartın.', N'C:\Users\senol\Desktop\img\10.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (11, N'Peynirli Omlet', N'Kahvaltı', 10, N'Yumurtaları çırpın, tuz ve karabiber ekleyin. Tavada pişirirken üzerine peynir serpin.', N'C:\Users\senol\Desktop\img\11.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (12, N'Etli Güveç', N'Ana Yemek', 90, N'Eti kuşbaşı doğrayın. Sebzeleri ekleyip güveçte pişirin. Fırında kızartın.', N'C:\Users\senol\Desktop\img\12.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (13, N'Patlıcan Salatası', N'Yan Yemek', 40, N'Patlıcanları közleyin. Soğan, domates ve biberi doğrayın. Zeytinyağı ve limonla karıştırın.', N'C:\Users\senol\Desktop\img\13.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (14, N'Yayla Çorbası', N'Çorba', 35, N'Pirinci haşlayın. Yoğurt ve yumurtayı çırpın. Çorbayı kaynatıp yoğurdu ekleyin. Üzerine nane yakın.', N'C:\Users\senol\Desktop\img\14.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (15, N'Sütlaç', N'Tatlı', 50, N'Pirinci sütle pişirin. Şeker ekleyip kaynatın. Fırın kaplarına koyup fırınlayın.', N'C:\Users\senol\Desktop\img\15.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (16, N'Kahvaltılık Acuka', N'Kahvaltı', 25, N'Kırmızı biberi közleyip doğrayın. Ceviz, sarımsak ve baharatlarla karıştırın. Zeytinyağı ekleyin.', N'C:\Users\senol\Desktop\img\16.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (17, N'Mantı', N'Ana Yemek', 120, N'Hamur açın. İç harcı hazırlayıp küçük parçalara sarın. Haşlayıp üzerine yoğurt ve kızdırılmış tereyağı dökün.', N'C:\Users\senol\Desktop\img\17.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (18, N'Havuç Tarator', N'Yan Yemek', 30, N'Havuçları rendeleyip haşlayın. Yoğurt, sarımsak ve zeytinyağı ile karıştırın.', N'C:\Users\senol\Desktop\img\18.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (19, N'Tarhana Çorbası', N'Çorba', 25, N'Tarhanayı suda bekletin. Soğan ve salçayı kavurun. Tarhanayı ekleyip pişirin.', N'C:\Users\senol\Desktop\img\19.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (20, N'Baklava', N'Tatlı', 120, N'Yufkaları serin. Aralarına ceviz serpin. Kesin ve tereyağı dökün. Pişirip şerbet dökün.', N'C:\Users\senol\Desktop\img\20.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (21, N'Kaşarlı Tost', N'Kahvaltı', 10, N'Ekmek dilimlerinin arasına kaşar peyniri koyun. Tost makinesinde kızartın.', N'C:\Users\senol\Desktop\img\21.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (22, N'Kuru Fasulye', N'Ana Yemek', 90, N'Fasulyeyi ıslatın. Soğan ve salçayı kavurun. Fasulyeyi ekleyip pişirin.', N'C:\Users\senol\Desktop\img\22.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (23, N'Közlenmiş Patlıcan', N'Yan Yemek', 35, N'Patlıcanları közleyin. Kabuklarını soyup ezin. Sarımsak, limon suyu ve zeytinyağı ekleyin.', N'C:\Users\senol\Desktop\img\23.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (24, N'Ezogelin Çorbası', N'Çorba', 45, N'Mercimek ve bulguru haşlayın. Soğan ve salçayı kavurun. Tüm malzemeleri karıştırıp pişirin.', N'C:\Users\senol\Desktop\img\24.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (25, N'Profiterol', N'Tatlı', 60, N'Hamur toplarını pişirin. İçlerini kremşanti ile doldurun. Üzerine çikolata sosu dökün.', N'C:\Users\senol\Desktop\img\25.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (26, N'Simit', N'Kahvaltı', 90, N'Hamuru yoğurup şekillendirin. Pekmezli suya batırıp susamlayın. Fırında pişirin.', N'C:\Users\senol\Desktop\img\26.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (27, N'Patlıcan Musakka', N'Ana Yemek', 70, N'Patlıcanları kızartın. Kıymalı harç hazırlayın. Katmanlar halinde dizin. Beşamel sos döküp fırınlayın.', N'C:\Users\senol\Desktop\img\27.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (28, N'Barbunya Pilaki', N'Yan Yemek', 50, N'Barbunyaları haşlayın. Soğan, havuç ve domatesi kavurun. Tüm malzemeleri karıştırıp pişirin.', N'C:\Users\senol\Desktop\img\28.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (29, N'Tavuk Suyu Çorba', N'Çorba', 60, N'Tavuğu haşlayın. Sebzeleri doğrayıp ekleyin. Limon suyu ve yumurta sarısı ile terbiye yapın.', N'C:\Users\senol\Desktop\img\29.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (30, N'Kabak Tatlısı', N'Tatlı', 60, N'Kabakları soyup dilimleyin. Şekerle kaynatın. Soğuyunca üzerine ceviz serpin.', N'C:\Users\senol\Desktop\img\30.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (31, N'Poğaça', N'Kahvaltı', 45, N'Hamuru yoğurun. İç harcı hazırlayın. Hamurları doldurup şekillendirin. Fırında pişirin.', N'C:\Users\senol\Desktop\img\31.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (32, N'Tas Kebabı', N'Ana Yemek', 100, N'Eti kuşbaşı doğrayın. Sebzelerle birlikte güveçte pişirin. Salça ve baharatlarla tatlandırın.', N'C:\Users\senol\Desktop\img\32.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (33, N'Zeytinyağlı Fasulye', N'Yan Yemek', 55, N'Taze fasulyeleri ayıklayın. Soğan ve domatesi kavurun. Fasulyelerle birlikte zeytinyağında pişirin.', N'C:\Users\senol\Desktop\img\33.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (34, N'Şehriye Çorbası', N'Çorba', 30, N'Şehriyeyi kavurun. Et suyunda pişirin. Limon suyu ve yumurta sarısı ile terbiye yapın.', N'C:\Users\senol\Desktop\img\34.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (35, N'Tulumba Tatlısı', N'Tatlı', 60, N'Hamuru hazırlayıp sıkma torbasına koyun. Kızgın yağda kızartın. Soğuk şerbete atın.', N'C:\Users\senol\Desktop\img\35.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (36, N'Çılbır', N'Kahvaltı', 20, N'Yumurtaları poşe yapın. Sarımsaklı yoğurt hazırlayın. Yumurtaları yoğurdun üzerine koyup kızdırılmış tereyağı gezdirin.', N'C:\Users\senol\Desktop\img\36.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (37, N'Lahmacun', N'Ana Yemek', 50, N'İnce hamur açın. Kıymalı harcı hazırlayıp hamura yayın. Fırında pişirin.', N'C:\Users\senol\Desktop\img\37.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (38, N'Kısır', N'Yan Yemek', 30, N'İnce bulguru ıslatın. Domates, biber ve soğanı ince doğrayın. Tüm malzemeleri karıştırıp baharatları ekleyin.', N'C:\Users\senol\Desktop\img\38.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (39, N'Mantar Çorbası', N'Çorba', 35, N'Mantarları doğrayıp kavurun. Un ekleyip çevirin. Süt ve et suyu ekleyip pişirin. Blenderdan geçirin.', N'C:\Users\senol\Desktop\img\39.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (40, N'Aşure', N'Tatlı', 120, N'Buğdayı haşlayın. Kuru meyveler ve kuruyemişleri ekleyin. Şeker ilave edip pişirin. Soğutup servis yapın.', N'C:\Users\senol\Desktop\img\40.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (41, N'Gözleme', N'Kahvaltı', 40, N'Hamur açın. İç malzemeyi hazırlayıp hamurun içine koyun. Sacda pişirin.', N'C:\Users\senol\Desktop\img\41.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (42, N'Hünkar Beğendi', N'Ana Yemek', 80, N'Patlıcanları közleyip püre yapın. Beşamel sos ekleyin. Ayrı bir tavada et sote yapın. Beğendiyi tabağa alıp üzerine et soteyi koyun.', N'C:\Users\senol\Desktop\img\42.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (43, N'Şakşuka', N'Yan Yemek', 45, N'Patlıcan, biber ve kabakları kızartın. Domates sosu hazırlayıp sebzelerin üzerine dökün.', N'C:\Users\senol\Desktop\img\43.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (44, N'Düğün Çorbası', N'Çorba', 50, N'Eti haşlayın. Nohut ve keşkek ilave edin. Un ve yumurta ile terbiye yapın.', N'C:\Users\senol\Desktop\img\44.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (45, N'Keşkül', N'Tatlı', 30, N'Süt, şeker ve nişastayı karıştırıp pişirin. Badem ekleyin. Soğutup üzerine Hindistan cevizi serpin.', N'C:\Users\senol\Desktop\img\45.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (46, N'Sahanda Yumurta', N'Kahvaltı', 10, N'Tavaya tereyağı koyun. Yumurtaları kırıp pişirin. Tuz ve karabiber serpin.', N'C:\Users\senol\Desktop\img\46.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (47, N'İskender Kebap', N'Ana Yemek', 60, N'Döner etini hazırlayın. Pideleri doğrayıp üzerine eti koyun. Domates sosu ve yoğurt ilave edin. Kızdırılmış tereyağı gezdirin.', N'C:\Users\senol\Desktop\img\47.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (48, N'Humus', N'Yan Yemek', 20, N'Nohutları haşlayıp ezin. Tahin, sarımsak, limon suyu ve zeytinyağı ekleyip karıştırın.', N'C:\Users\senol\Desktop\img\48.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (49, N'Brokoli Çorbası', N'Çorba', 35, N'Brokoliyi haşlayın. Soğan ve sarımsağı kavurun. Tüm malzemeleri blenderdan geçirin. Krema ekleyip pişirin.', N'C:\Users\senol\Desktop\img\49.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (50, N'Trileçe', N'Tatlı', 60, N'Pandispanya hazırlayın. Üç çeşit sütü karıştırıp kekin üzerine dökün. Karamel sos yapıp en üste gezdirin.', N'C:\Users\senol\Desktop\img\50.jpg')
INSERT [dbo].[Tarifler] ([TarifID], [TarifAdi], [Kategori], [HazirlamaSuresi], [Talimatlar], [Resim]) VALUES (1058, N'deneme', N'Çorba', 5, N'sjdnakjdskajsd', N'')
SET IDENTITY_INSERT [dbo].[Tarifler] OFF
GO
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (1, 1, 2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (1, 2, 0.2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (1, 3, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (1, 4, 3)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (1, 45, 0.03)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (2, 1, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (2, 3, 0.2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (2, 5, 2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (2, 6, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (2, 45, 0.05)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (3, 7, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (3, 8, 0.2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (3, 9, 0.05)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (3, 19, 0.02)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (3, 48, 0.01)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (4, 3, 0.2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (4, 10, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (4, 11, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (4, 41, 0.01)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (4, 45, 0.03)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (5, 4, 4)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (5, 7, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (5, 12, 1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (5, 13, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (5, 51, 0.01)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (6, 4, 2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (6, 14, 0.2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (6, 45, 0.02)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (7, 1, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (7, 3, 0.2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (7, 5, 2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (7, 45, 0.05)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (8, 7, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (8, 9, 0.05)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (8, 19, 0.02)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (8, 48, 0.01)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (9, 1, 1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (9, 3, 0.2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (9, 9, 0.05)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (9, 45, 0.03)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (10, 4, 2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (10, 12, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (10, 13, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (10, 17, 1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (11, 4, 2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (11, 15, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (11, 45, 0.02)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (12, 3, 0.2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (12, 11, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (12, 33, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (12, 45, 0.03)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (13, 1, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (13, 3, 0.2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (13, 5, 1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (13, 19, 0.02)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (14, 4, 1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (14, 7, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (14, 16, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (14, 45, 0.02)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (15, 4, 1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (15, 13, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (15, 16, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (15, 17, 1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (16, 9, 0.05)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (16, 19, 0.02)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (16, 20, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (16, 43, 0.2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (17, 3, 0.2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (17, 6, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (17, 12, 2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (17, 45, 0.03)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (18, 7, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (18, 9, 0.05)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (18, 11, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (18, 19, 0.02)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (19, 3, 0.2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (19, 9, 0.05)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (19, 45, 0.03)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (19, 52, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (20, 13, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (20, 18, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (20, 20, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (20, 21, 3)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (21, 18, 0.02)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (21, 37, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (21, 53, 2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (22, 3, 0.2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (22, 9, 0.05)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (22, 24, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (22, 45, 0.03)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (23, 5, 2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (23, 9, 0.05)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (23, 19, 0.02)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (23, 27, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (24, 3, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (24, 10, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (24, 28, 0.2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (24, 45, 0.03)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (25, 4, 2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (25, 12, 1)
GO
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (25, 13, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (25, 45, 0.02)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (26, 12, 1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (26, 41, 0.01)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (26, 45, 0.01)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (26, 54, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (27, 3, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (27, 5, 2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (27, 6, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (27, 45, 0.03)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (28, 3, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (28, 11, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (28, 45, 0.03)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (28, 55, 1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (29, 3, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (29, 11, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (29, 22, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (29, 45, 0.03)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (30, 13, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (30, 20, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (30, 23, 2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (30, 45, 0.02)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (31, 12, 1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (31, 41, 0.01)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (31, 45, 0.01)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (31, 54, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (32, 3, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (32, 11, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (32, 33, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (32, 45, 0.03)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (33, 1, 0.2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (33, 3, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (33, 19, 0.02)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (33, 25, 1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (34, 3, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (34, 22, 0.2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (34, 26, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (34, 45, 0.03)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (35, 12, 1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (35, 41, 0.01)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (35, 45, 0.01)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (35, 54, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (36, 4, 4)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (36, 7, 0.2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (36, 9, 0.05)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (36, 18, 0.02)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (37, 12, 1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (37, 41, 0.01)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (37, 45, 0.01)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (37, 54, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (38, 1, 0.2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (38, 3, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (38, 19, 0.02)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (38, 28, 1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (39, 3, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (39, 17, 0.2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (39, 29, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (39, 45, 0.03)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (40, 30, 0.2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (40, 31, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (40, 45, 0.02)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (40, 56, 1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (41, 12, 1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (41, 41, 0.01)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (41, 45, 0.01)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (41, 54, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (42, 3, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (42, 5, 2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (42, 6, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (42, 45, 0.03)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (43, 2, 0.2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (43, 3, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (43, 5, 2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (43, 45, 0.03)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (44, 3, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (44, 11, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (44, 22, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (44, 45, 0.03)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (45, 13, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (45, 17, 1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (45, 45, 0.02)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (45, 57, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (46, 4, 2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (46, 18, 0.01)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (46, 41, 0.005)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (46, 42, 0.002)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (47, 1, 0.2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (47, 7, 0.2)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (47, 18, 0.02)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (47, 33, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (47, 58, 4)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (48, 9, 0.05)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (48, 19, 0.02)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (48, 27, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (48, 32, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (48, 34, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (49, 3, 0.1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (49, 9, 0.05)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (49, 35, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (49, 36, 0.1)
GO
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (49, 45, 0.03)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (50, 4, 4)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (50, 12, 1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (50, 13, 0.5)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (50, 17, 1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (50, 45, 0.02)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (1058, 12, 1)
INSERT [dbo].[TarifMalzeme] ([TarifID], [MalzemeID], [MalzemeMiktar]) VALUES (1058, 13, 1)
GO
ALTER TABLE [dbo].[TarifMalzeme]  WITH CHECK ADD  CONSTRAINT [FK__TarifMalz__Malze__3C69FB99] FOREIGN KEY([MalzemeID])
REFERENCES [dbo].[Malzemeler] ([MalzemeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TarifMalzeme] CHECK CONSTRAINT [FK__TarifMalz__Malze__3C69FB99]
GO
ALTER TABLE [dbo].[TarifMalzeme]  WITH CHECK ADD FOREIGN KEY([TarifID])
REFERENCES [dbo].[Tarifler] ([TarifID])
ON DELETE CASCADE
GO
USE [master]
GO
ALTER DATABASE [TarifRehberi] SET  READ_WRITE 
GO
