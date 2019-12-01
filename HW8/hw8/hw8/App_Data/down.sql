ALTER TABLE [dbo].[Teams] DROP CONSTRAINT [FK_dbo.Teams_dbo.Coaches_ID]
GO
ALTER TABLE [dbo].[RaceResults] DROP CONSTRAINT [FK_dbo.RaceRusults_dbo.Meets_ID]
GO
ALTER TABLE [dbo].[RaceResults] DROP CONSTRAINT [FK_dbo.RaceResults_dbo.Athletes_ID]
GO
ALTER TABLE [dbo].[Athletes] DROP CONSTRAINT [FK_dbo.Athletes_dbo.Teams_ID]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 12/1/2019 2:10:37 PM ******/
DROP TABLE [dbo].[Teams]
GO
/****** Object:  Table [dbo].[RaceResults]    Script Date: 12/1/2019 2:10:37 PM ******/
DROP TABLE [dbo].[RaceResults]
GO
/****** Object:  Table [dbo].[Meets]    Script Date: 12/1/2019 2:10:37 PM ******/
DROP TABLE [dbo].[Meets]
GO
/****** Object:  Table [dbo].[Coaches]    Script Date: 12/1/2019 2:10:37 PM ******/
DROP TABLE [dbo].[Coaches]
GO
/****** Object:  Table [dbo].[Athletes]    Script Date: 12/1/2019 2:10:37 PM ******/
DROP TABLE [dbo].[Athletes]
GO
/****** Object:  Table [dbo].[AllData]    Script Date: 12/1/2019 2:10:37 PM ******/
DROP TABLE [dbo].[AllData]
GO