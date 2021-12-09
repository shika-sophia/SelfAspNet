CREATE PROCEDURE [dbo].[AlbumFilterProcedure]
	@category NVARCHAR(20),
	@recordNUM INT OUTPUT
AS
	IF @category = N'(No Selected)'
	  BEGIN 
	    SELECT id, comment, updated, favorite, category
		  FROM Album
	  END
	ELSE
	  BEGIN
	    SELECT id, comment, updated, favorite, category
		  FROM Album
		  WHERE (category=@category)
	  END

	SELECT @recordNum = @@ROWCOUNT

/* 
-- 実行コード
DECLARE	@return_value Int,
	@recordNUM int

SELECT	@recordNUM = NULL

EXEC	@return_value = [dbo].[AlbumFilterProcedure]
		@category = N'Animal', -- N'(No Selected)',
		@recordNUM = @recordNUM OUTPUT

SELECT	@recordNUM as N'@recordNUM'

SELECT	@return_value as 'Return Value'

GO

-- 実行結果 catgory = N'Animal'
A0001	ペットのハムスター。我が家の一員になった頃です。	2019-08-06	0	Animal
A0003	モルモット。動物園のふれあいコーナーにて。	2019-12-20	1	Animal
A0004	フラミンゴ。鳥のゾーンで放し飼いでした。	2020-03-15	1	Animal

@recordNum: 3

-- 実行結果 catgory = N'(No Selected)'
A0001	ペットのハムスター。我が家の一員になった頃です。	2019-08-06	0	Animal
A0002	沖縄の海、たくさんの魚が泳いでいます。	2019-10-22	1	Travel
A0003	モルモット。動物園のふれあいコーナーにて。	2019-12-20	1	Animal
A0004	フラミンゴ。鳥のゾーンで放し飼いでした。	2020-03-15	1	Animal
S0001	浜名湖。ホテルからの風景です。	2019-08-19	0	Travel
S0002	梨狩り。鎌ヶ谷の名産品らしい。	2019-09-20	0	Other
S0003	ピアノ部屋。毎日練習しています。	2020-01-24	1	Other
T0001	ウミガメのぬいぐるみ。PCの前に置いています。	2020-03-01	1	Other
T0002	クマとネズミのぬいぐるみ。いつも一緒で仲良しです。	2020-03-26	1	Other

@recordNum: 9
*/

