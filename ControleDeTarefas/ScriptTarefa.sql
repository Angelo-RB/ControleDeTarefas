CREATE TABLE [dbo].[TBTarefa] (
    [Id]              INT          NOT NULL,
    [Titulo]          VARCHAR (50) NULL,
    [DataCriacao]     DATETIME     NULL,
    [DataConclusao] DATETIME     NULL,
    [Prioridade]      VARCHAR (50) NULL,
    [Percentual]      VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


insert into [TBTarefa] 
	(
		[Titulo], 
		[DataCriacao],
		[DataConclusao],
		[Prioridade],
		[Percentual]
	) 
	values 
	(
		'Limpar o pc', 
		'10/06/2021',
		'21/06/2021',
		 1,
		'100%'
	)

	SELECT SCOPE_IDENTITY();
insert into [TBTarefa] 
	(
		[Titulo], 
		[DataCriacao],
		[DataConclusao],
		[Prioridade],
		[Percentual]
	) 
	values 
	(
		'Arrumar o quarto', 
		'12/06/2021',
		'19/06/2021',
		 2,
		'100%'
	)
update [TBTarefa] 
	set	
		[Titulo]='Arrumar o quarto', 
		[DataCriacao]='12/06/2021',
		[DataConclusao]='19/06/2021',
		[Prioridade]=2,
		[Percentual]='100%'
	where 
		[Id] = 16

Delete from [TBTarefa] 
	where 
		[Id] = 1

select [Id], [Titulo], [DataCriacao], [DataConclusao], [Prioridade], [Percentual] from [TBTarefa] 

select [Id], [Titulo], [DataCriacao], [DataConclusao], [Prioridade], [Percentual] from [TBTarefa] 
	where 
		[Id] = 3