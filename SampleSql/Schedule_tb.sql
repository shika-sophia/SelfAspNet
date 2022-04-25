/*
CREATE TABLE [dbo].[Schedule]
(
	[sid] INT NOT NULL PRIMARY KEY IDENTITY, 
    [uid] NVARCHAR(10) NULL, 
    [scheduleDate] DATE NULL, 
    [scheduleTime] CHAR(5) NULL, 
    [subject] NVARCHAR(100) NULL,
)

*/
/*
INSERT INTO Schedule
  (uid, scheduleDate, scheduleTime, subject)
  VALUES( 'yamada', '2019/12/01', '12:00', '書籍打合せ(翔泳社)');
INSERT INTO Schedule
  (uid, scheduleDate, scheduleTime, subject)
  VALUES( 'yamada', '2019/12/20', '15:00', 'Webアプリ開発フォーラム');
INSERT INTO Schedule
  (uid, scheduleDate, scheduleTime, subject)
  VALUES( 'kakeya', '2019/12/15', '16:00', 'WINGSメンバー面接');
INSERT INTO Schedule
  (uid, scheduleDate, scheduleTime, subject)
  VALUES( 'kakeya', '2019/12/25', '20:00', '書籍Aパーティ');
-- (1 行処理されました)
-- (1 行処理されました)
-- (1 行処理されました)
-- (1 行処理されました)
*/

-- SELECT * FROM Schedule;
/*
1	yamada	2019-12-01	12:00	?????(???)
2	yamada	2019-12-20	15:00	Web??????????
3	kakeya	2019-12-15	16:00	WINGS??????
4	kakeya	2019-12-25	20:00	??A????
*/
/*
UPDATE Schedule
  SET subject = N'書籍打合せ(翔泳社)'
  WHERE sid = 1;
UPDATE Schedule
  SET subject = N'Webアプリ開発フォーラム'
  WHERE sid = 2;
  UPDATE Schedule
  SET subject = N'WINGSメンバー面接'
  WHERE sid = 3;
  UPDATE Schedule
  SET subject = N'書籍Aパーティ'
  WHERE sid = 4;

  --  (1 行処理されました)
  --  (1 行処理されました)
  --  (1 行処理されました)
  --  (1 行処理されました)
*/

-- SELECT * FROM Schedule;
/*
1	yamada	2019-12-01	12:00	書籍打合せ(翔泳社)
2	yamada	2019-12-20	15:00	Webアプリ開発フォーラム
3	kakeya	2019-12-15	16:00	WINGSメンバー面接
4	kakeya	2019-12-25	20:00	書籍Aパーティ
*/