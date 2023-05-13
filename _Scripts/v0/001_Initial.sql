set timezone = 'America/Sao_Paulo';

create schema sistema;

create table sistema."PessoaTipo" (
	"IdPessoaTipo" bigint not null primary key generated by default as identity
	,"Nome" varchar(50) not null
	,"Descricao" varchar(255) null
	,"CreatedAt" timestamptz not null
	,"UpdatedAt" timestamptz not null
);

insert into sistema."PessoaTipo"  (
									  "Nome"
									, "Descricao"
									, "CreatedAt"
									, "UpdatedAt"
								  ) values 
								  (  'Aluno'
								   , 'Tipo Aluno'
								   , now()
								   , now()
								  )
								  ,( 'Professor'
								   , 'Tipo Professor'
								   , now()
								   , now()
								  )
								  ,( 'Coordenador'
								   , 'Tipo Coordenador'
								   , now()
								   , now()
								  );
								  
create table sistema."DocumentoTipo" (
	"IdDocumentoTipo" bigint not null primary key generated by default as identity
	, "Nome" varchar(50) not null
	, "Descricao" varchar(255) null
	, "CreatedAt" timestamptz not null
	, "UpdatedAt" timestamptz not null
);

insert into sistema."DocumentoTipo"  (
								   	    "Nome"
								   	  , "Descricao"
								   	  , "CreatedAt"
								   	  , "UpdatedAt"
								     ) values 
								     (  'RG'
								      , 'Registro Geral'
								      , now()
								      , now()
								     )
								     ,( 'CPF'
								      , 'Cadastro de Pessoa Física'
								      , now()
								      , now()
								     )
								     ,( 'RA'
								      , 'Registro do Aluno'
								      , now()
								      , now()
								     );
create table sistema."Turma" (
	  "IdTurma" bigint not null primary key generated by default as identity
	, "Serie" varchar(20) not null
	, "Turma" varchar(20) not null	
	, "Nivel" varchar(20) not null	
	, "Periodo" varchar(20) not null
	, "CreatedAt" timestamptz not null
	, "UpdatedAt" timestamptz not null
);

insert into sistema."Turma" (
							  "Serie"
							, "Turma"
							, "Nivel"
							, "Periodo"
							, "CreatedAt"
							, "UpdatedAt"
							) values
							(
							  '1'
							, 'A'
							, 'Fundamental'
							, 'Manhã'
							, now()
							, now()
							)
							,(
							  '1'
							, 'B'
							, 'Fundamental'
							, 'Manhã'
							, now()
							, now()
							)
							,(
							  '1'
							, 'C'
							, 'Fundamental'
							, 'Tarde'
							, now()
							, now()
							) 
							,(
							  '1'
							, 'D'
							, 'Fundamental'
							, 'Tarde'
							, now()
							, now()
							);
									 
create table sistema."Pessoa" (
	  "IdPessoa" bigint not null primary key generated by default as identity
	, "IdPessoaTipo" bigint not null
	, "IdDocumentoTipo" bigint not null
	, "IdTurma" bigint null
	, "Nome" varchar(50) not null
	, "Sobrenome" varchar(50) not null
	, "DataNascimento" date not null
	, "Sexo" varchar(20) not null
	, "NroDocumento" varchar(20) not null unique
	, constraint "fk_pessoa_pessoaTipo"
		foreign key("IdPessoaTipo")
			references "PessoaTipo"("IdPessoaTipo")
	, constraint "fk_pessoa_documentoTipo"
		foreign key("IdDocumentoTipo")
			references "DocumentoTipo"("IdDocumentoTipo")
	, constraint "fk_pessoa_turma"
		foreign key("IdTurma")
			references "Turma"("IdTurma")
	, constraint "check_id_turma"
		check (IdPessoaTipo = 1 and IdTurma is not null)
);

insert into sistema."Pessoa" (
							    "IdPessoaTipo"
							  , "IdDocumentoTipo"
							  , "IdTurma"
							  , "Nome"
							  , "Sobrenome"
							  , "DataNascimento"
							  , "Sexo"
							  , "NroDocumento"
							 ) values
							 (
							    1
							  , 3
							  ,	 
							 )

create schema seguranca;