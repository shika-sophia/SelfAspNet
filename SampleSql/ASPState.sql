-- Å° ASPState_db
-- Åü ASPStateTempApplications_tb
/*
CREATE TABLE [dbo].[ASPStateTempApplications] (
    [AppId]   INT        NOT NULL,
    [AppName] CHAR (280) NOT NULL,
    PRIMARY KEY CLUSTERED ([AppId] ASC)
);

GO
CREATE NONCLUSTERED INDEX [Index_AppName]
    ON [dbo].[ASPStateTempApplications]([AppName] ASC);

*/

SELECT * FROM ASPStateTempApplications;
/*
AppId: 729231826	
AppName: /lm/w3svc/2/root
*/

-- Åü ASPStateTempSessions_tb
/*
CREATE TABLE [dbo].[ASPStateTempSessions] (
    [SessionId]        NVARCHAR (88)    NOT NULL,
    [Created]          DATETIME         DEFAULT (getutcdate()) NOT NULL,
    [Expires]          DATETIME         NOT NULL,
    [LockDate]         DATETIME         NOT NULL,
    [LockDateLocal]    DATETIME         NOT NULL,
    [LockCookie]       INT              NOT NULL,
    [Timeout]          INT              NOT NULL,
    [Locked]           BIT              NOT NULL,
    [SessionItemShort] VARBINARY (7000) NULL,
    [SessionItemLong]  IMAGE            NULL,
    [Flags]            INT              DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([SessionId] ASC)
);

GO
CREATE NONCLUSTERED INDEX [Index_Expires]
    ON [dbo].[ASPStateTempSessions]([Expires] ASC);
*/

SELECT * FROM ASPStateTempSessions;
/*
[SessionId] wlxsbdwghufu3tdkbusrh0fo2b7731d2	
[Created]   2022-02-06 00:43:10.430	
[Expires]   2022-02-06 01:03:17.183	
[LockDate]  2022-02-06 00:43:17.180	
[LockDateLocal] 2022-02-06 09:43:17.180	
[LockCookie] 3	
[Timeout]    20	
[Locked]     0	
[SessionItemShort] 0x14000000010001000000FFFFFFFF057469746C6522000000012053656C66204C6561726E204153502E4E4554205B3674682045646974696F6E5DFF
[SessionItemLong]  NULL
[Flags]      0

*/
