/*
 *@title SampleSql / AccessLog_tb.sql
 *@source SelfAspDB / AccessLog_tb
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第10章 部品化 / 10.4 Global.asax / p512
           アクセスログを記録するテーブル
 */
 /*
 CREATE TABLE [dbo].[AccessLog]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [url] VARCHAR(255) NOT NULL, 
    [userAgent] VARCHAR(255) NOT NULL, 
    [referrer] VARCHAR(255) NOT NULL, 
    [accessTime] DATETIME NOT NULL
)
 */

 -- ValidSample.aspx実行後
 -- SELECT * FROM AccessLog;
 /*
 1	https://localhost:44377/SampleAsp/NT03_ServerControl/ValidSample.aspx	Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.4951.54 Safari/537.36		2022-05-11 16:43:38.000
2	https://localhost:44377/WebResource.axd?d=x2nkrMJGXkMELz33nwnakGoNrpKz_7HanxfuEI8QlwMiyaXcOoiSg-zuxemmoUApMKWM2yO7GpZJXG9v3rhI00tEzGjp3KFqMZcIhhhHptg1&t=637814984020000000	Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.4951.54 Safari/537.36	https://localhost:44377/SampleAsp/NT03_ServerControl/ValidSample.aspx	2022-05-11 16:43:38.000
 */