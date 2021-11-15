USE [master]
GO
/****** Object:  Database [raminagrobis]    Script Date: 28/10/2021 14:59:36 ******/
CREATE DATABASE [raminagrobis]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'raminagrobis', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\raminagrobis.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'raminagrobis_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\raminagrobis_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [raminagrobis] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [raminagrobis].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [raminagrobis] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [raminagrobis] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [raminagrobis] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [raminagrobis] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [raminagrobis] SET ARITHABORT OFF 
GO
ALTER DATABASE [raminagrobis] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [raminagrobis] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [raminagrobis] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [raminagrobis] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [raminagrobis] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [raminagrobis] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [raminagrobis] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [raminagrobis] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [raminagrobis] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [raminagrobis] SET  DISABLE_BROKER 
GO
ALTER DATABASE [raminagrobis] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [raminagrobis] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [raminagrobis] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [raminagrobis] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [raminagrobis] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [raminagrobis] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [raminagrobis] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [raminagrobis] SET RECOVERY FULL 
GO
ALTER DATABASE [raminagrobis] SET  MULTI_USER 
GO
ALTER DATABASE [raminagrobis] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [raminagrobis] SET DB_CHAINING OFF 
GO
ALTER DATABASE [raminagrobis] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [raminagrobis] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [raminagrobis] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [raminagrobis] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'raminagrobis', N'ON'
GO
ALTER DATABASE [raminagrobis] SET QUERY_STORE = OFF
GO
USE [raminagrobis]
GO
/****** Object:  Table [dbo].[adherents]    Script Date: 28/10/2021 14:59:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[adherents](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[societe] [nvarchar](50) NOT NULL,
	[civilite] [bit] NOT NULL,
	[nom] [nvarchar](50) NOT NULL,
	[prenom] [nvarchar](50) NOT NULL,
	[email] [nvarchar](150) NOT NULL,
	[adresse] [nvarchar](228) NOT NULL,
	[date_adhesion] [date] NOT NULL,
	[desactive] [bit] NOT NULL,
 CONSTRAINT [PK_adherents] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fournisseurs]    Script Date: 28/10/2021 14:59:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fournisseurs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[societe] [nvarchar](50) NOT NULL,
	[civilite] [bit] NOT NULL,
	[nom] [nvarchar](50) NOT NULL,
	[prenom] [nvarchar](50) NOT NULL,
	[email] [nvarchar](150) NOT NULL,
	[adresse] [varchar](228) NOT NULL,
	[desactive] [bit] NOT NULL,
 CONSTRAINT [PK_fournisseurs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fournisseurs_references]    Script Date: 28/10/2021 14:59:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fournisseurs_references](
	[id_fournisseur] [int] NOT NULL,
	[id_reference] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[liste_achats]    Script Date: 28/10/2021 14:59:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[liste_achats](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_adherent] [int] NOT NULL,
	[semaine] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_liste_achats] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[liste_achats_details]    Script Date: 28/10/2021 14:59:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[liste_achats_details](
	[id_liste_achats] [int] NOT NULL,
	[id_reference] [int] NOT NULL,
	[quantite] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[offres]    Script Date: 28/10/2021 14:59:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[offres](
	[id] [int] NOT NULL,
	[id_fournisseur] [int] NOT NULL,
	[id_panier_global_details] [int] NOT NULL,
	[puht] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[panier_global]    Script Date: 28/10/2021 14:59:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[panier_global](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_liste_achat] [int] NOT NULL,
 CONSTRAINT [PK_panier_global] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[panier_global_details]    Script Date: 28/10/2021 14:59:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[panier_global_details](
	[id_panier_global] [int] NOT NULL,
	[id_reference] [int] NOT NULL,
	[quantite] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_panier_global_details] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[references]    Script Date: 28/10/2021 14:59:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[references](
	[id] [int] NOT NULL,
	[reference] [nvarchar](50) NOT NULL,
	[libelle] [nvarchar](100) NOT NULL,
	[marque] [nvarchar](50) NOT NULL,
	[desactive] [bit] NOT NULL,
 CONSTRAINT [PK_references] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[fournisseurs_references]  WITH CHECK ADD  CONSTRAINT [FK_fournisseurs_references_fournisseurs] FOREIGN KEY([id_fournisseur])
REFERENCES [dbo].[fournisseurs] ([id])
GO
ALTER TABLE [dbo].[fournisseurs_references] CHECK CONSTRAINT [FK_fournisseurs_references_fournisseurs]
GO
ALTER TABLE [dbo].[fournisseurs_references]  WITH CHECK ADD  CONSTRAINT [FK_fournisseurs_references_references] FOREIGN KEY([id_reference])
REFERENCES [dbo].[references] ([id])
GO
ALTER TABLE [dbo].[fournisseurs_references] CHECK CONSTRAINT [FK_fournisseurs_references_references]
GO
ALTER TABLE [dbo].[liste_achats]  WITH CHECK ADD  CONSTRAINT [FK_liste_achats_adherents1] FOREIGN KEY([id_adherent])
REFERENCES [dbo].[adherents] ([id])
GO
ALTER TABLE [dbo].[liste_achats] CHECK CONSTRAINT [FK_liste_achats_adherents1]
GO
ALTER TABLE [dbo].[liste_achats_details]  WITH CHECK ADD  CONSTRAINT [FK_liste_achats_details_liste_achats] FOREIGN KEY([id_liste_achats])
REFERENCES [dbo].[liste_achats] ([id])
GO
ALTER TABLE [dbo].[liste_achats_details] CHECK CONSTRAINT [FK_liste_achats_details_liste_achats]
GO
ALTER TABLE [dbo].[liste_achats_details]  WITH CHECK ADD  CONSTRAINT [FK_liste_achats_details_references] FOREIGN KEY([id_reference])
REFERENCES [dbo].[references] ([id])
GO
ALTER TABLE [dbo].[liste_achats_details] CHECK CONSTRAINT [FK_liste_achats_details_references]
GO
ALTER TABLE [dbo].[offres]  WITH CHECK ADD  CONSTRAINT [FK_offres_fournisseurs] FOREIGN KEY([id_fournisseur])
REFERENCES [dbo].[fournisseurs] ([id])
GO
ALTER TABLE [dbo].[offres] CHECK CONSTRAINT [FK_offres_fournisseurs]
GO
ALTER TABLE [dbo].[offres]  WITH CHECK ADD  CONSTRAINT [FK_offres_panier_global_details] FOREIGN KEY([id_panier_global_details])
REFERENCES [dbo].[panier_global_details] ([id])
GO
ALTER TABLE [dbo].[offres] CHECK CONSTRAINT [FK_offres_panier_global_details]
GO
ALTER TABLE [dbo].[panier_global]  WITH CHECK ADD  CONSTRAINT [FK_panier_global_liste_achats] FOREIGN KEY([id_liste_achat])
REFERENCES [dbo].[liste_achats] ([id])
GO
ALTER TABLE [dbo].[panier_global] CHECK CONSTRAINT [FK_panier_global_liste_achats]
GO
ALTER TABLE [dbo].[panier_global_details]  WITH CHECK ADD  CONSTRAINT [FK_panier_global_details_panier_global] FOREIGN KEY([id_panier_global])
REFERENCES [dbo].[panier_global] ([id])
GO
ALTER TABLE [dbo].[panier_global_details] CHECK CONSTRAINT [FK_panier_global_details_panier_global]
GO
ALTER TABLE [dbo].[panier_global_details]  WITH CHECK ADD  CONSTRAINT [FK_panier_global_details_references] FOREIGN KEY([id_reference])
REFERENCES [dbo].[references] ([id])
GO
ALTER TABLE [dbo].[panier_global_details] CHECK CONSTRAINT [FK_panier_global_details_references]
GO
USE [master]
GO
ALTER DATABASE [raminagrobis] SET  READ_WRITE 
GO
