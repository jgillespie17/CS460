
-- ################### SEED DATA ######################

-- Extract data from .csv file and load into our db

-- Create a staging table to hold all the seed data.  We'll query this 
-- table in order to extract what we need to then insert into our real
-- tables.
CREATE TABLE [dbo].[AllData]
(
	[Location] NVARCHAR(50),
	[MeetDate] DATETIME,
	[Team] NVARCHAR(50),
	[Coach] NVARCHAR(50),
	[Event] NVARCHAR(20),
	[Gender] NVARCHAR(20),
	[Athlete] NVARCHAR(50),
	[RaceTime] REAL
);

-- Hard code the full path to the csv file.  It'll be better this way 
-- when we run this in HW 9 to build an Azure db 
BULK INSERT [dbo].[AllData]
	FROM 'C:\Users\Jon\Documents\0-Wou work\Fall2019\CS460\files\racetimes.csv'
	WITH
	(
		FIELDTERMINATOR = ',',
		ROWTERMINATOR = '\n',
		FIRSTROW = 2
	);

-- Load coaches data, no foreign keys here to worry about so we can 
-- do a straight insert of just the distinct values

CREATE TABLE [dbo].[Coaches]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[NAME] NVARCHAR (50) NOT NULL
	CONSTRAINT [PK_dbo.Coaches] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[Coaches] ([Name])
	SELECT DISTINCT Coach from [dbo].[AllData];
	
-- Load Team data, a team has a coach so we need to find the correct entry in the 
-- Coaches table so we can set the foreign key appropriately
CREATE TABLE [dbo].[Teams]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[NAME] NVARCHAR (50) NOT NULL,
	[CoachID] INT,
	CONSTRAINT [PK_dbo.Teams] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Teams_dbo.Coaches_ID] FOREIGN KEY ([CoachID]) REFERENCES [dbo].[Coaches] ([ID])

);
INSERT INTO [dbo].[Teams]
	(Name,CoachID)
	SELECT DISTINCT ad.Team,cs.ID
		FROM dbo.AllData as ad, dbo.Coaches as cs
		WHERE ad.Coach = cs.Name;


CREATE TABLE [dbo].[Athletes]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[NAME] NVARCHAR (50) NOT NULL,
	[GENDER] NVARCHAR (20) NOT NULL,
	[TeamID] INT,
	CONSTRAINT [PK_dbo.Athletes] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Athletes_dbo.Teams_ID] FOREIGN KEY ([TeamID]) REFERENCES [dbo].[Teams] ([ID])
);
INSERT INTO [dbo].[Athletes]
	(NAME,GENDER,TeamID)
	Select DISTINCT ad.Athlete, ad.Gender, ts.ID
		FROM dbo.AllData as ad, dbo.Teams as ts
		WHERE ad.Team = ts.NAME;


CREATE TABLE [dbo].[Meets]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[DATE] NVARCHAR (50) NOT NULL,
	[LOCATION] NVARCHAR (50) NOT NULL,
	CONSTRAINT [PK_dbo.Meets] PRIMARY KEY CLUSTERED ([ID] ASC),
);
INSERT INTO [dbo].[Meets]
	(LOCATION, DATE)
	Select DISTINCT Location, MeetDate from [dbo].[AllData];

CREATE TABLE [dbo].[RaceResults]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[NAME] NVARCHAR (50) NOT NULL,
	[TIME] REAL NOT NULL,
	[MeetID] INT,
	[AthleteID] INT,
	CONSTRAINT [PK_dbo.RaceResults] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.RaceRusults_dbo.Meets_ID] FOREIGN KEY ([MeetID]) REFERENCES [dbo].[Meets] ([ID]),
	CONSTRAINT [FK_dbo.RaceResults_dbo.Athletes_ID] FOREIGN KEY ([AthleteID]) REFERENCES [dbo].[Athletes] ([ID])

);
INSERT INTO [dbo].[RaceResults]
	(NAME, TIME, MeetID, AthleteID)
	Select DISTINCT ad.Event, ad.RaceTime, ms.ID, ats.ID
		FROM dbo.AllData as ad, dbo.Meets as ms, dbo.Athletes as ats
		WHERE ad.Location = ms.LOCATION AND ats.NAME = ad.Athlete;
/*
-- Load all the other tables in a similar fashion.  Race results is the hardest since
-- it has several FK's.  Think joins.

-- We don't need this staging table anymore so clear it away

-- DROP TABLE [dbo].[AllData];
*/

