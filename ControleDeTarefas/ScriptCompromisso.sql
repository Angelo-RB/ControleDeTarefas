CREATE TABLE [dbo].[TBCompromisso] (
    [Id]                INT          NOT NULL,
    [Assunto]           VARCHAR (50) NULL,
    [Local]             VARCHAR (50) NULL,
    [DataDoCompromisso] DATETIME     NULL,
    [HoraInicio]        DATETIME     NULL,
    [HoraTermino]       DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

insert into [TBCompromisso] 
	(
		[Assunto], 
		[Local], 
		[DataDoCompromisso],
		[HoraInicio],
		[HoraTermino]
	) 
	values 
	(
		'Ir na empresa', 
		'Bairro 1, avenida 2',
		 2021/06/28,
		'13:30',
		'17:30'
	)

	SELECT SCOPE_IDENTITY();
insert into TBCompromisso 
	(
		[Assunto], 
		[Local],  
		[DataDoCompromisso],
		[HoraInicio],
		[HoraTermino]
	) 
	values 
	(
		'Ir na empresa', 
		'Bairro 1, avenida 2',
		 2021/06/28,
		'13:30',
		'17:30'
	)
update TBCompromisso 
	set	
		[Assunto] = 'Ir na empresa', 
		[Local]='Bairro 1, avenida 2',
		[DataDoCompromisso]= 2021/06/28,
		[HoraInicio]='13:30',
		[HoraTermino]='17:30'
	where 
		[Id] = 18

Delete from TBCompromisso 
	where 
		[Id] = 1

select [Id], [Assunto], [Local], [DataDoCompromisso], [HoraInicio], [HoraTermino] from TBCompromisso 

select [Id], [Assunto], [Local], [DataDoCompromisso], [HoraInicio], [HoraTermino] from TBCompromisso 
	where 
		[Id] = 3


