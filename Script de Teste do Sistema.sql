use master;
go
Drop database TesteImob;
go
create database TesteImob;
go
use TesteImob;
go

create table Funcionario(
	id int identity primary key,
	nome varchar(100),
	cpf varchar(30),
	rg varchar(30),
	datNasc date,
	telRes varchar(30),
	telCel varchar(30),
	email varchar(100),
	cargo varchar(100),
	sal decimal,
	endereco varchar(100),
	status_func varchar(30)
)
go
create table Logar(
	id int identity primary key,
	usuario varchar(100),
	senha varchar(100),
	id_Func int,
	status_User varchar(30)
	

	Constraint id_Func_Logar foreign key(id_Func) references Funcionario(id)
)
go
create table Atendimento(
	id int identity  primary key,
	cliente varchar(100),
	data varchar(13),
	hora varchar(13),
	descricao varchar(200),
	id_User int

	Constraint id_User_Atendimento foreign key(id_User) references Logar(id)
)
go
create table Locador(
	id int identity primary key,
	nome varchar(100),
	cpf varchar(30),
	rg varchar(30),
	datNasc date,
	telRes varchar(30),
	telCel varchar(30),
	email varchar(100),
	endereco varchar(100)
)
go
create table Locatario(
	id int identity primary key,
	nome varchar(100),
	cpf varchar(30),
	rg varchar(30),
	dataNasc date,
	telRes varchar(30),
	telCel varchar(30),
	email varchar(100),
	endereco varchar(100),
	id_User int

	Constraint id_User_Locatario foreign key(id_User) references Logar(id)
)
go
create table Fiador(
	id int identity primary key,
	nome varchar(100),
	cpf varchar(30),
	rg varchar(30),
	dataNasc date,
	telRes varchar(30),
	telCel varchar(30),
	email varchar(100),
	endereco varchar(100),
	valorFianca varchar(100),
	id_User int

	Constraint id_User_Fiador foreign key(id_User) references Logar(id)
)
go
create table FonteDeRenda(
	id int identity primary key,
	empresaFonte varchar(200),
	cargo varchar(100),
	salario varchar(100),
	horarioTrabalho varchar(30),
	telComercial varchar(30),
	id_Locatario int
	
	Constraint id_Locatario_FonteDeRenda foreign key(id_Locatario) references Locatario(id)
)
go
create table Imovel(
	id int identity primary key,
	fileNameImg char(600),
	Data image,
	descricao varchar(200),
	rua_Avenida varchar(200),
	complemento varchar(100),
	uf varchar(2),
	numero int,
	bairro varchar(100),
	cidade varchar(100),
	valor_Aluguel decimal,
	status_Imovel varchar(30),
	id_User int,
	id_Locador int

	Constraint id_User_Imovel foreign key(id_User) references Logar(id),
	Constraint id_Locador_Imovel foreign Key(id_Locador) references Locador(id)
)
go
create table Locacao(
	id int identity primary key,
	fileNameImg char(600),
	id_Locador int,
	id_Locatario int,
	id_Fiador int,
	valorLocacao varchar(100),
	dataLoc varchar(15),
	dataFinal varchar(15),
	id_Imovel int
	
	CONSTRAINT id_Locador_Locacao foreign key(id_Locador) references Locador(id),
	CONSTRAINT id_Locatario_Locacao foreign key(id_Locatario) references Locatario(id),
	CONSTRAINT id_Fiador_Locacao foreign key(id_Fiador) references Fiador(id),
	CONSTRAINT id_Imovevl_Locacao foreign key(id_Imovel) references Imovel(id)
)
go
create table Fiador_Locacao(
	id_Locacao int,
	id_Fiador int

	CONSTRAINT id_Locacao_Fiador_Locacao foreign key(id_Locacao) references Locacao(id),
	CONSTRAINT id_Fiador_Fiador_Locacao foreign key(id_Fiador) references Fiador(id)
)






