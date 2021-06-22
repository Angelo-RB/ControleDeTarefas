CREATE TABLE [dbo].[Tarefa] (
    [Id]            INT          NOT NULL,
    [Titulo]        VARCHAR (50) NULL,
    [DataCriacao]   DATETIME     NULL,
    [DataConclusao] DATETIME     NULL,
    [Prioridade]    VARCHAR (50) NULL,
    [Percentual]    VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

