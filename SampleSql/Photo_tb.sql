/**
 *@title SelfAspNet / SampleSql / Photo_tb.sql
 *@database SQL Server 2016 Express LocalDB 
 *@target SelfAspNet / App_Data / SelfAspDB.mdf 
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第５章 DataSourceControl / p208 / Matrix 5-6
 *@subject ◆[Photo_tb]の新規作成
 *         ＊IDENTITY (= auto increment)の設定
 *         ・テーブルデザインView -> id列 -> プロパティ・ウインドゥ
 *           -> IDENTITYの指定 -> idである true -> DBの更新
 *         ・テーブルデザインView -> 項目名を右クリック -> 表示する項目
 *           -> id にチェック -> 表のチェックマークが IDENTITY設定
 *               ↓
 *          SQL CREATE文に IDENTITY制約が表示されていればOK
 *
 *@author shika
 *@date 2021-12-07
 */

/*
-- CREATE TABLE [dbo].[Photo]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [type] VARCHAR(50) NOT NULL, 
    [data] VARBINARY(MAX) NOT NULL
)
CREATE TABLE [dbo].[Photo] (
    [id]   INT             IDENTITY NOT NULL,
    [type] VARCHAR (50)    NOT NULL,
    [data] VARBINARY (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

*/
/*
SELECT [type], [data] FROM [Photo]
INSERT INTO Photo(type, data) VALUES (@type, @data)
*/
/*
(SampleAsp / NT05_DataSourceControl / PhotoUpload.aspx を実行、
 1 画像ファイル ResultFile/ SaveMyEarth480.jpg (88.5KB)を選択、upload。
 2 Photo_tb.sqlをアップ )
*/

-- SELECT * FROM Photo;
-- |ID| type     | data
-- | 1|image/jpeg| 0xFFD8FFE000104A46494600010201012C012C0000...(延々と続く)
-- | 2|application/octet-stream | 0xEFBBBF
