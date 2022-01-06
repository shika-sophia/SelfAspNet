/*
 *@title SelfAspNet / SampleSql / AlbumHistory_tb.sql
 */
/*
-- Create Table 
CREATE TABLE [dbo].[AlbumHistory]
(
	[history] INT NOT NULL PRIMARY KEY IDENTITY,
	[id] CHAR(5) NOT NULL, 
    [comment] NVARCHAR(100) NOT NULL, 
    [lastMod] DATETIME NOT NULL DEFAULT GETDATE(),
)

-- AlbumDataSet.xsd / AlbumTableAdapter
INSERT INTO [AlbumHistory] ([Id], [comment], [lastMod])
  VALUES (@Id, @comment, GETDATE())
*/
