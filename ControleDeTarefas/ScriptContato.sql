CREATE TABLE [dbo].[TBContato] (
    [Id]       INT          NOT NULL,
    [Nome]     VARCHAR (50) NULL,
    [Email]    VARCHAR (50) NULL,
    [Telefone] INT          NULL,
    [Empresa ] VARCHAR (50) NULL,
    [Cargo ]   VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

insert into TBContato 
	(
		[Nome], 
		[Email], 
		[Telefone],
		[Empresa ],
		[Cargo ]
	) 
	values 
	(
		'João Pedro', 
		'jonzinho@gmail.com',
		 49987253746,
		'Super Mercado',
		'Empacotador'
	)

	SELECT SCOPE_IDENTITY();
insert into TBContato 
	(
		[Nome], 
		[Email],  
		[Telefone],
		[Empresa ],
		[Cargo ]
	) 
	values 
	(
		'Gabriel Batista',
		'gabzinho@gmail.com',
		 49928394573,
		'Loja de automovel',
		'Vendedor'
	)
update TBContato 
	set	
		[Nome] = 'Gabriel Batista', 
		[Email]='gabzinho@gmail.com',
		[Telefone]= 49928394573,
		[Empresa ]='Loja de automovel',
		[Cargo ]='Vendedor'
	where 
		[Id] = 16

Delete from TBContato 
	where 
		[Id] = 1

select [Id], [Nome], [Email], [Telefone], [Empresa ], [Cargo ] from TBContato 

select [Id], [Nome], [Email], [Telefone], [Empresa ], [Cargo ] from TBContato 
	where 
		[Id] = 3