CREATE TABLE [dbo].[Homework]
(
	[ID] INT IDENTITY(1,1) NOT NULL,
	[Urgency] INT NOT NULL,
	[DueDate] DATETIME NOT NULL,
	[DueTime] TIME NOT NULL,
	[Department] NVARCHAR(32) NOT NULL,
	[Course] INT NOT NULL,
	[Title] NVARCHAR(64) NOT NULL,
	[Notes] NVARCHAR(512) NOT NULL,
	CONSTRAINT [Pk_dbo.Homeworks] Primary key clustered ([ID] ASC)
	);

INSERT INTO [dbo].[Homework] (Urgency, DueDate, DueTime, DEPARTMENT, COURSE, TITLE, NOTES) Values
	('1', '19450812', '10:10:10', 'HIS', '420', 'MANHATTAN', 'CLASSIFIED'),
	('2', '19450812', '10:10:10', 'HIS', '420', 'OVERLORD', 'CLASSIFIED'),
	('3', '19450812', '05:05:05', 'HIS', '420', 'OLYMPIC', 'CLASSIFIED'),
	('4', '19450812', '23:50:50', 'HIS', '420', 'TORCH', 'CLASSIFIED'),
	('5', '19450812', '20:20:20', 'HIS', '420', 'PAPERCLIP', 'CLASSIFIED'); 
