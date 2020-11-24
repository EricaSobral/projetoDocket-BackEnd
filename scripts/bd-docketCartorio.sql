--CREATE DATABASE "Cartorios"

USE Cartorios;

--DDL
CREATE TABLE Usuario(
id_Usuario	INT PRIMARY KEY IDENTITY,
Nome varchar(300) NOT NULL, 
);

CREATE TABLE TipoCertidao(
id_tipoCerdidao	INT PRIMARY KEY IDENTITY,
Certidao VARCHAR (200) UNIQUE NOT NULL, 
);

CREATE TABLE Cartorio(
id_cartorio	INT PRIMARY KEY IDENTITY,
Nome VARCHAR (200) NOT NULL UNIQUE, 
Endereco VARCHAR(300) NOT NULL UNIQUE,
fk_tipoCertidao INT FOREIGN KEY REFERENCES TipoCertidao (id_tipoCerdidao) NOT NULL, 
);

--DML
INSERT INTO Usuario(Nome) VALUES ('Maria Silva');

INSERT INTO TipoCertidao(Certidao)
VALUES ('Certidão união estável, Certidão de escritura, Certidão de procuração, Certidão de testamento'), ('Certidão de Cancelamento de Protesto,  Certidão de Protesto 5 Anos'),
('Certidão de Casamento, Certidão de Nascimento Certidão de Óbito'),('Certidão Dominial');

INSERT INTO Cartorio(Nome, Endereco, fk_tipoCertidao)
VALUES ('59º Cartório de Protesto - Vila X', 'AV Eespeto  7598 - Vila X, Vitoria-ES', 4),('101º Cartório de Registro Civil - Horizonte','Rua Ouro Preto 97 - Horizonte, Rio de Janeiro-RJ',1),('20º Cartório de Registro Imoveis - Ipiranga','Rua Santos 497 - Ipiranga, Sao Paulo-SP',3),('11º Cartório de Notas - Vila Y','Rua Mauri 1497 - Vila Y, Rio de Janeiro-RJ',2);

--DQL
SELECT * FROM Usuario;
SELECT * FROM Cartorio;
SELECT * FROM TipoCertidao;