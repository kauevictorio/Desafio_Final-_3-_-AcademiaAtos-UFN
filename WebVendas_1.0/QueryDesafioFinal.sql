CREATE DATABASE Users_db;

CREATE LOGIN Users_db WITH PASSWORD='Users_db';
CREATE USER Users_db from LOGIN Users_db;

exec sp_addrolemember 'DB_DATAREADER' , 'Users_db';
exec sp_addrolemember 'DB_DATAWRITER' , 'Users_db' ;

CREATE TABLE ACESSO(
    ID_LOGIN INT IDENTITY NOT NULL,
    EMAIL VARCHAR(100),
    SENHA VARCHAR(100),
  
    PERFIL VARCHAR(15),
    NOME VARCHAR(30),
    SOBRENOME VARCHAR(30)
)
INSERT INTO ACESSO (EMAIL, SENHA, PERFIL, NOME, SOBRENOME)
VALUES ('admin@admin.com', '123456', 'Administrador', 'Kaue', 'Admin')

INSERT INTO ACESSO (EMAIL, SENHA, PERFIL, NOME, SOBRENOME)
VALUES ('user@user.com', '123456', 'Usuario', 'KaVik', 'Usuario')

SELECT * FROM ACESSO;

DROP TABLE ACESSO;

