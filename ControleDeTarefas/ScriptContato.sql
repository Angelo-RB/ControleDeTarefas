CREATE TABLE [dbo].[TBContato] (
    [Id]       INT          NOT NULL,
    [Nome]     VARCHAR (50) NULL,
    [Email]    VARCHAR (50) NULL,
    [Telefone] INT          NULL,
    [Empresa ] VARCHAR (50) NULL,
    [Cargo ]   VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
