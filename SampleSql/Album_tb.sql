/**
 *@title SelfAspNet / SampleSql / Album_tb.sql
 *@database SQL Server 2016 Express LocalDB 
 *@target SelfAspNet / App_Data / SelfAspDB.mdf 
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第４章 DB / p142 / 練習問題 4-2
 *@subject ◆[Album_tb]の新規作成、更新、修正
 *
 *@author shika
 *@date 2021-11-26
*/
/*
CREATE TABLE [dbo].[Album]
(
	[id] CHAR(5) NOT NULL PRIMARY KEY, 
    [category] NVARCHAR(20) NOT NULL, 
    [comment] NVARCHAR(100) NULL, 
    [update] DATE NOT NULL DEFAULT GETDATE(), 
    [favorite] BIT NOT NULL DEFAULT 1
)
*/
/*
INSERT INTO Album 
  VALUES ('A0001', 'Animal', 
    N'ペットのハムスター。我が家の一員になった頃です。',
    '2019/08/06', 0);
INSERT INTO Album 
  VALUES ('A0002', 'Travel', 
    N'沖縄の海、たくさんの魚が泳いでいます。',
    '2019/10/22', 1);
INSERT INTO Album 
  VALUES ('A0003', 'Animal', 
    N'モルモット。動物園のふれあいコーナーにて。',
    '2019/12/20', 1);
INSERT INTO Album 
  VALUES ('A0004', 'Animal', 
    N'フラミンゴ。鳥のゾーンで放し飼いでした。',
    '2020/03/15', 1);
INSERT INTO Album 
  VALUES ('S0001', 'Travel', 
    N'浜名湖。ホテルからの風景です。',
    '2019/08/19', 0);
INSERT INTO Album 
  VALUES ('S0002', 'Other', 
    N'梨狩り。鎌ヶ谷の名産品らしい。',
    '2019/09/20', 0);
INSERT INTO Album 
  VALUES ('S0003', 'Other', 
    N'ピアノ部屋。毎日練習しています。',
    '2020/01/24', 1);
INSERT INTO Album 
  VALUES ('T0001', 'Other', 
    N'ウミガメのぬいぐるみ。PCの前に置いています。',
    '2020/03/01', 1);
INSERT INTO Album 
  VALUES ('T0002', 'Other', 
    N'クマとネズミのぬいぐるみ。いつも一緒で仲良しです。',
    '2020/03/26', 1);
*/

-- (9 行処理されました)


-- SELECT * FROM Album;
/*
A0001	Animal	ペットのハムスター。我が家の一員になった頃です。	2019-08-06	0
A0002	Travel	沖縄の海、たくさんの魚が泳いでいます。	2019-10-22	1
A0003	Animal	モルモット。動物園のふれあいコーナーにて。	2019-12-20	1
A0004	Animal	フラミンゴ。鳥のゾーンで放し飼いでした。	2020-03-15	1
S0001	Travel	浜名湖。ホテルからの風景です。	2019-08-19	0
S0002	Other	梨狩り。鎌ヶ谷の名産品らしい。	2019-09-20	0
S0003	Other	ピアノ部屋。毎日練習しています。	2020-01-24	1
T0001	Other	ウミガメのぬいぐるみ。PCの前に置いています。	2020-03-01	1
T0002	Other	クマとネズミのぬいぐるみ。いつも一緒で仲良しです。	2020-03-26	1
*/
/*
SELECT category AS N'分類', comment AS N'備考', updated AS N'最終更新日'
  FROM Album
  WHERE category = 'Other' AND updated >= '2020/01/01'
;
*/
/*
Other	ピアノ部屋。毎日練習しています。	2020-01-24
Other	ウミガメのぬいぐるみ。PCの前に置いています。	2020-03-01
Other	クマとネズミのぬいぐるみ。いつも一緒で仲良しです。	2020-03-26
*/

-- NT11_AjaxDevelop / AjaxExtentions / AjaxUpdatePanel.aspx
-- Timer更新のテストのため、データを変更
/*
UPDATE Album 
  SET comment=N'ピアノ部屋。毎日練習しています。バッハが好きです。'
  WHERE Id='S0003';
*/