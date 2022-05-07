/*
CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[AspNetUsers]([UserName] ASC);

*/
-- SELECT * FROM AspNetUsers;
/*
[Id]    a48724cf-330c-4623-b815-638202f23962
[Email] dammy@sample.jp
[EmailConfirmed] 0	
[PasswordHash]   ALdTNeh9nvIuc/LM/jIomigarFEjeyDC9Nfo5gbGYGtKw7ZJFlTmny9ewCa21GcseQ==
[SecurityStamp]  11ea9da2-9666-41db-87da-2e3d6a27c343
[PhoneNumber]    NULL
[PhoneNumberConfirmed] 0
[TwoFactorEnabled]  0
[LockoutEndDateUtc] NULL
[LockoutEnabled]    1
[AccessFailedCount] 0
[UserName]  dammy@sample.jp

*/

-- after Enabled-Migration
-- [Url] 列を追加
/*
 *@see ~/Migration/ MigrationSetting_PackageManager.txt

CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    [Url]                  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

-- SELECT * FROM AspNetUsers;
/*
0faab511-0b0a-457b-8876-a088d6bd9955	profile@sample.jp	0	AEt7wXDaTGjKcVRCe8mNkYF9dSqisGqF2tlbzYVBxGDBtq6xeVszj4mgT0yA8ke67A==	3546da90-710e-4b59-8006-f2b5737920f6	NULL	0	0	NULL	1	0	profile@sample.jp	http://www.profileSample.com
a48724cf-330c-4623-b815-638202f23962	dammy@sample.jp	0	ALdTNeh9nvIuc/LM/jIomigarFEjeyDC9Nfo5gbGYGtKw7ZJFlTmny9ewCa21GcseQ==	11ea9da2-9666-41db-87da-2e3d6a27c343	NULL	0	0	NULL	1	0	dammy@sample.jp	NULL
*/

GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[AspNetUsers]([UserName] ASC);


*/
