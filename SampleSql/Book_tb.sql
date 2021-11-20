/**
 *@title SelfAspNet / SampleSql / Book_tb.sql
 *@database SQL Server 2016 Express LocalDB 
 *@target SelfAspNet / App_Data / SelfAspDB.mdf 
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第４章 DB / p124-142 / Matrix 4-4, 4-6, List 4-1, 4-2
 *@subject ◆[Book_tb]の新規作成、更新、修正
 *
 *@author shika
 *@date 2021-11-21
 */
/*
CREATE TABLE [dbo].[Book]
(
	[isbn] CHAR(17) NOT NULL PRIMARY KEY, 
    [title] NVARCHAR(100) NOT NULL, 
    [price] INT NOT NULL, 
    [publisher] NVARCHAR(30) NOT NULL DEFAULT N'翔泳社', 
    [publishDate] DATE NOT NULL DEFAULT GETDATE(), 
    [cdrom] BIT NULL, 
)
*/
 SELECT * FROM Book;

/*
INSERT INTO Book 
  VALUES ('978-4-8026-1226', N'SQLデータ分析 活用入門', 
    2600, N'ソシム', '2019-09-12', 0);
INSERT INTO Book 
  VALUES ('978-4-7981-5322', N'Docker教科書', 
    3000, N'翔泳社', '2018-04-11', 0);
INSERT INTO Book (isbn, title, price, cdrom)
  VALUES ('978-4-7981-6365-9', N'独習 ASP.NET 第６版', 3800, 0);
INSERT INTO Book (isbn, title, price, publisher, publishDate)
  VALUES ('978-4-7981-6149-5', N'実践ドメイン駆動設計 DDD入門',
    1600, N'翔泳社', '2019-05-31');
-- (1 行処理されました)
-- (1 行処理されました)

*/
/*
UPDATE Book SET publishDate = '2020-02-17'
  WHERE isbn = '978-4-7981-6365-9';
UPDATE book SET isbn = '978-4-8026-1226-5'
  WHERE isbn = '978-4-8026-1226';
UPDATE Book SET isbn = '978-4-7981-5757-3'
  WHERE isbn = '9t8-4-7981-5757-3';
UPDATE book SET isbn = '978-4-7981-5322-3'
  WHERE isbn = '978-4-7981-5322';
-- (1 行処理されました)
-- (1 行処理されました)
*/
/*
-- SELECT * FROM Book;
978-4-7980-5759-0	はじめてのAndroidアプリ開発	3200	秀和システム	2019-08-10	0
978-4-7981-5112-0	独習 Java [新版}	2980	翔泳社	2019-05-15	0
978-4-7981-5322-3	Docker教科書	3000	翔泳社	2018-04-11	0
978-4-7981-5757-3	JavaScript 逆引きレシピ	2800	翔泳社	2018-10-15	0
978-4-7981-6044-3	Androidアプリ開発の教科書	2850	翔泳社	2019-07-10	1
978-4-7981-6149-5	実践ドメイン駆動設計 DDD入門	1600	翔泳社	2019-05-31	NULL
978-4-7981-6365-9	独習 ASP.NET 第６版	3800	翔泳社	2020-02-17	0
978-4-8026-1226-5	SQLデータ分析 活用入門	2600	ソシム	2019-09-12	0
978-4-8156-0182-9	Vue.js実践入門	3380	ＳＢクリエイティブ	2019-08-22	0
978-4-8222-5399-8	Visual C#超入門 2019	2000	日経ＢＰ	2019-08-22	1
978-4-8222-8651-4	Visual C++超入門2019	2000	日経ＢＰ	2019-10-03	1
*/