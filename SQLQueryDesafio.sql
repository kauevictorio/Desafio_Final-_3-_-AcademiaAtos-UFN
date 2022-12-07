CREATE DATABASE desafioFinal_db;


CREATE LOGIN desafioFinal_db WITH PASSWORD='desafioFinal_db';

CREATE USER desafioFinal_db FROM LOGIN desafioFinal_db;

exec sp_addrolemember 'DB_DATAWRITER' , 'desafioFinal_db';
exec sp_addrolemember 'DB_DATAREADER' , 'desafioFinal_db';


CREATE TABLE Produtos 
(
	id_produto	integer identity primary key,
	nome_produto varchar (100) not null,
	quantidade integer null,
	preco_compra float not null,
	tributos float not null,
	preco_venda float not null

);

CREATE TABLE Clientes
(
	id_cliente integer identity primary key,
	nome_cliente varchar (150) not null,
	cpf varchar (20) unique not null,
	telefone varchar (20) unique not null,
	email varchar(150) null

);

CREATE TABLE Vendas
(
	id_venda integer identity primary key,
	id_produto INTEGER FOREIGN KEY REFERENCES Produtos(id_produto),
	quantidade_vendido INTEGER NOT NULL,
	id_cliente INTEGER FOREIGN KEY REFERENCES Clientes(id_cliente),
	data_venda TIMESTAMP ,
	valor_venda float NOT NULL,

);
CREATE TABLE Usuario_Sistema
(

);