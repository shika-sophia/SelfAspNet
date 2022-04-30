/**
 *@title SampleSql / Sitemap_tb.sql
 *@target SelfAspDB
 *@reference
 *@content 第９章 Rich / 9.1.9 SitemapのDB登録
 */
/*
CREATE TABLE [dbo].[Sitemap] (
    [mid]         INT            IDENTITY (1, 1) NOT NULL,
    [url]         VARCHAR (100)  NOT NULL,
    [title]       NVARCHAR (100) NOT NULL,
    [keywd]       NVARCHAR (100) NOT NULL,
    [description] NVARCHAR (200) NOT NULL,
    [parent]      INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([mid] ASC)
);
*/

-- INSERT Data from [SelfAsp] (=配布サンプルコードのDB)からコピー
/*
SET IDENTITY_INSERT [dbo].[Sitemap] ON
INSERT INTO [dbo].[Sitemap] ([mid], [url], [title], [keywd], [description], [parent]) VALUES (1, N'Rdb.aspx', N'データベース連携', N'データベース, 連携', N'データベース連携について', 0)
INSERT INTO [dbo].[Sitemap] ([mid], [url], [title], [keywd], [description], [parent]) VALUES (2, N'~/Chap09/db.aspx', N'データベース', N'データベース', N'データベースについて', 1)
INSERT INTO [dbo].[Sitemap] ([mid], [url], [title], [keywd], [description], [parent]) VALUES (3, N'~/Chap09/Type.aspx', N'データ型', N'データ型', N'データ型について', 2)
INSERT INTO [dbo].[Sitemap] ([mid], [url], [title], [keywd], [description], [parent]) VALUES (4, N'~/Chap09/Limit.aspx', N'制約', N'制約, 条件', N'制約について', 2)
INSERT INTO [dbo].[Sitemap] ([mid], [url], [title], [keywd], [description], [parent]) VALUES (5, N'~/Chap09/Sql.aspx', N'SQL', N'SQL, 命令', N'SQLについて', 2)
INSERT INTO [dbo].[Sitemap] ([mid], [url], [title], [keywd], [description], [parent]) VALUES (6, N'DataSource.aspx', N'データソースコントロール', N'データソースコントロール', N'データソースコントロールについて', 1)
INSERT INTO [dbo].[Sitemap] ([mid], [url], [title], [keywd], [description], [parent]) VALUES (7, N'~/Chap10/Content.aspx', N'SqlDataSource', N'リレーショナルデータベース', N'SqlDataSourceについて', 6)
INSERT INTO [dbo].[Sitemap] ([mid], [url], [title], [keywd], [description], [parent]) VALUES (8, N'SiteMapDataSource.aspx', N'SiteMapDataSource', N'サイトマップファイル', N'SiteMapDataSourceについて', 6)
INSERT INTO [dbo].[Sitemap] ([mid], [url], [title], [keywd], [description], [parent]) VALUES (9, N'ObjectDataSource.aspx', N'ObjectDataSource', N'ビジネスオブジェクト', N'ObjectDataSourceについて', 6)
INSERT INTO [dbo].[Sitemap] ([mid], [url], [title], [keywd], [description], [parent]) VALUES (10, N'DataAccess.aspx', N'データバインドコントロール', N'データバインドコントロール', N'データバインドコントロールについて', 1)
INSERT INTO [dbo].[Sitemap] ([mid], [url], [title], [keywd], [description], [parent]) VALUES (11, N'~/Chap08/Auth/GridView.aspx', N'GridView', N'一覧表', N'GridViewについて', 10)
INSERT INTO [dbo].[Sitemap] ([mid], [url], [title], [keywd], [description], [parent]) VALUES (12, N'~/Chap08/Auth/DetailsView.aspx', N'DetailsView', N'詳細', N'DetailsViewについて', 10)
INSERT INTO [dbo].[Sitemap] ([mid], [url], [title], [keywd], [description], [parent]) VALUES (13, N'~/Chap08/Auth/FormView.aspx', N'FormView', N'単票', N'FormViewについて', 10)
INSERT INTO [dbo].[Sitemap] ([mid], [url], [title], [keywd], [description], [parent]) VALUES (14, N'~/Chap09/Dml.aspx', N'DML', N'データ操作', N'データ操作言語について', 5)
INSERT INTO [dbo].[Sitemap] ([mid], [url], [title], [keywd], [description], [parent]) VALUES (15, N'~/Chap09/Ddl.aspx', N'DDL', N'データ定義', N'データ定義言語について', 5)
INSERT INTO [dbo].[Sitemap] ([mid], [url], [title], [keywd], [description], [parent]) VALUES (16, N'~/Chap09/Dcl.aspx', N'DCL', N'データ制御', N'データ制御言語について', 5)
SET IDENTITY_INSERT [dbo].[Sitemap] OFF
*/

-- SELECT * FROM Sitemap; 
/*
1	Rdb.aspx	データベース連携	データベース, 連携	データベース連携について	0
2	~/Chap09/db.aspx	データベース	データベース	データベースについて	1
3	~/Chap09/Type.aspx	データ型	データ型	データ型について	2
4	~/Chap09/Limit.aspx	制約	制約, 条件	制約について	2
5	~/Chap09/Sql.aspx	SQL	SQL, 命令	SQLについて	2
6	DataSource.aspx	データソースコントロール	データソースコントロール	データソースコントロールについて	1
7	~/Chap10/Content.aspx	SqlDataSource	リレーショナルデータベース	SqlDataSourceについて	6
8	SiteMapDataSource.aspx	SiteMapDataSource	サイトマップファイル	SiteMapDataSourceについて	6
9	ObjectDataSource.aspx	ObjectDataSource	ビジネスオブジェクト	ObjectDataSourceについて	6
10	DataAccess.aspx	データバインドコントロール	データバインドコントロール	データバインドコントロールについて	1
11	~/Chap08/Auth/GridView.aspx	GridView	一覧表	GridViewについて	10
12	~/Chap08/Auth/DetailsView.aspx	DetailsView	詳細	DetailsViewについて	10
13	~/Chap08/Auth/FormView.aspx	FormView	単票	FormViewについて	10
14	~/Chap09/Dml.aspx	DML	データ操作	データ操作言語について	5
15	~/Chap09/Ddl.aspx	DDL	データ定義	データ定義言語について	5
16	~/Chap09/Dcl.aspx	DCL	データ制御	データ制御言語について	5
*/
