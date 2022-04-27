/**
 *@title Stock_tb
 *@see SampleAsp / NT09_RichControl / ChartGraph / ChartColumnGraph.aspx.cs
*/
/*
CREATE TABLE [dbo].[Stock]
(
	[brand] INT NOT NULL , 
    [dating] DATE NOT NULL, 
    [opening] INT NOT NULL, 
    [high] INT NOT NULL, 
    [low] INT NOT NULL, 
    [closing] INT NOT NULL, 
    [volume] INT NOT NULL, 
    PRIMARY KEY ([brand], [dating])
)
*/
/*
-- Official Sample DB [SelfAsp.mdf]からコピー
--【実装手順】〔NT134〕
-- ~/App_Data に配布サンプルの [SelfAsp.mdf]をコピー
-- => [SelfAsp.mdf]を Wクリック(新規DBを生成)
-- => Server-Explorer -> [SelfAsp.mdf] -> テーブル -> Stock 右クリック ->
--    データを表示 -> 上部アイコン[スクリプト]をクリック -> INSERT文が表示される
--    コピー -> [SelfAspDB] テーブル -> Stock -> 新しいクエリ [Stock_tb.sql]に添付
--    ファイル内の上部 実行アイコン(緑△) 

INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-01', 1101, 1211, 1101, 1111, 251)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-02', 1111, 1169, 1111, 1213, 290)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-03', 1213, 1321, 1213, 1318, 549)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-04', 1318, 1398, 1318, 1387, 651)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-05', 1387, 1387, 1357, 1357, 356)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-06', 1357, 1357, 1307, 1311, 311)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-07', 1311, 1349, 1310, 1327, 340)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-08', 1327, 1330, 1314, 1319, 358)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-09', 1319, 1329, 1319, 1320, 347)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-10', 1320, 1320, 1156, 1156, 663)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-11', 1156, 1214, 1156, 1180, 489)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-12', 1180, 1280, 1180, 1266, 514)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-13', 1249, 1252, 1227, 1231, 464)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-14', 1231, 1232, 1196, 1199, 447)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-15', 1199, 1200, 1176, 1178, 434)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-16', 1178, 1179, 1123, 1124, 393)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-17', 1124, 1258, 1123, 1251, 634)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-18', 1251, 1259, 1247, 1256, 441)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-19', 1256, 1261, 1254, 1260, 411)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-20', 1260, 1261, 1248, 1251, 389)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-21', 1251, 1252, 1236, 1239, 374)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-22', 1239, 1241, 1219, 1224, 321)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-23', 1224, 1224, 1165, 1172, 298)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-24', 1172, 1173, 1101, 1104, 609)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-25', 1104, 1108, 1101, 1102, 479)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-26', 1102, 1109, 1101, 1108, 382)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-27', 1108, 1121, 1108, 1119, 390)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-28', 1119, 1124, 1115, 1121, 385)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-29', 1121, 1148, 1120, 1145, 397)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (28710, N'2020-03-30', 1145, 1151, 1141, 1150, 352)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-01', 1210, 1219, 1201, 1208, 232)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-02', 1208, 1209, 1197, 1198, 238)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-03', 1198, 1198, 1097, 1103, 547)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-04', 1103, 1105, 1098, 1100, 351)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-05', 1100, 1103, 1100, 1100, 356)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-06', 1100, 1117, 1098, 1115, 291)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-07', 1115, 1231, 1114, 1230, 340)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-08', 1230, 1330, 1226, 1327, 428)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-09', 1327, 1529, 1325, 1488, 667)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-10', 1488, 1487, 1485, 1486, 363)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-11', 1486, 1511, 1483, 1485, 389)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-12', 1485, 1486, 1280, 1288, 514)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-13', 1288, 1290, 1277, 1281, 464)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-14', 1281, 1291, 1279, 1286, 447)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-15', 1286, 1301, 1285, 1300, 534)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-16', 1300, 1179, 1123, 1124, 393)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-17', 1124, 1258, 1123, 1251, 634)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-18', 1251, 1259, 1247, 1256, 441)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-19', 1256, 1550, 1254, 1550, 679)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-20', 1550, 1502, 1548, 1549, 389)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-21', 1549, 1549, 1523, 1545, 374)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-22', 1545, 1549, 1399, 1341, 521)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-23', 1341, 1345, 1315, 1232, 498)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-24', 1232, 1235, 1230, 1231, 489)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-25', 1231, 1308, 1231, 1307, 519)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-26', 1307, 1501, 1305, 1498, 582)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-27', 1498, 1521, 1498, 1503, 690)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-28', 1503, 1505, 1501, 1500, 585)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-29', 1500, 1592, 1500, 1592, 497)
INSERT INTO [dbo].[Stock] ([brand], [dating], [opening], [high], [low], [closing], [volume]) VALUES (34259, N'2020-03-30', 1592, 1599, 1588, 1590, 452)
*/

-- SELECT * FROM Stock;
/*
28710	2020-03-01	1101	1211	1101	1111	251
28710	2020-03-02	1111	1169	1111	1213	290
28710	2020-03-03	1213	1321	1213	1318	549
28710	2020-03-04	1318	1398	1318	1387	651
28710	2020-03-05	1387	1387	1357	1357	356
28710	2020-03-06	1357	1357	1307	1311	311
28710	2020-03-07	1311	1349	1310	1327	340
28710	2020-03-08	1327	1330	1314	1319	358
28710	2020-03-09	1319	1329	1319	1320	347
28710	2020-03-10	1320	1320	1156	1156	663
28710	2020-03-11	1156	1214	1156	1180	489
28710	2020-03-12	1180	1280	1180	1266	514
28710	2020-03-13	1249	1252	1227	1231	464
28710	2020-03-14	1231	1232	1196	1199	447
28710	2020-03-15	1199	1200	1176	1178	434
28710	2020-03-16	1178	1179	1123	1124	393
28710	2020-03-17	1124	1258	1123	1251	634
28710	2020-03-18	1251	1259	1247	1256	441
28710	2020-03-19	1256	1261	1254	1260	411
28710	2020-03-20	1260	1261	1248	1251	389
28710	2020-03-21	1251	1252	1236	1239	374
28710	2020-03-22	1239	1241	1219	1224	321
28710	2020-03-23	1224	1224	1165	1172	298
28710	2020-03-24	1172	1173	1101	1104	609
28710	2020-03-25	1104	1108	1101	1102	479
28710	2020-03-26	1102	1109	1101	1108	382
28710	2020-03-27	1108	1121	1108	1119	390
28710	2020-03-28	1119	1124	1115	1121	385
28710	2020-03-29	1121	1148	1120	1145	397
28710	2020-03-30	1145	1151	1141	1150	352
34259	2020-03-01	1210	1219	1201	1208	232
34259	2020-03-02	1208	1209	1197	1198	238
34259	2020-03-03	1198	1198	1097	1103	547
34259	2020-03-04	1103	1105	1098	1100	351
34259	2020-03-05	1100	1103	1100	1100	356
34259	2020-03-06	1100	1117	1098	1115	291
34259	2020-03-07	1115	1231	1114	1230	340
34259	2020-03-08	1230	1330	1226	1327	428
34259	2020-03-09	1327	1529	1325	1488	667
34259	2020-03-10	1488	1487	1485	1486	363
34259	2020-03-11	1486	1511	1483	1485	389
34259	2020-03-12	1485	1486	1280	1288	514
34259	2020-03-13	1288	1290	1277	1281	464
34259	2020-03-14	1281	1291	1279	1286	447
34259	2020-03-15	1286	1301	1285	1300	534
34259	2020-03-16	1300	1179	1123	1124	393
34259	2020-03-17	1124	1258	1123	1251	634
34259	2020-03-18	1251	1259	1247	1256	441
34259	2020-03-19	1256	1550	1254	1550	679
34259	2020-03-20	1550	1502	1548	1549	389
34259	2020-03-21	1549	1549	1523	1545	374
34259	2020-03-22	1545	1549	1399	1341	521
34259	2020-03-23	1341	1345	1315	1232	498
34259	2020-03-24	1232	1235	1230	1231	489
34259	2020-03-25	1231	1308	1231	1307	519
34259	2020-03-26	1307	1501	1305	1498	582
34259	2020-03-27	1498	1521	1498	1503	690
34259	2020-03-28	1503	1505	1501	1500	585
34259	2020-03-29	1500	1592	1500	1592	497
34259	2020-03-30	1592	1599	1588	1590	452
*/