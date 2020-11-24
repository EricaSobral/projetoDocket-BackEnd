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
VALUES ('Certid�o uni�o est�vel, Certid�o de escritura, Certid�o de procura��o, Certid�o de testamento'), ('Certid�o de Cancelamento de Protesto,  Certid�o de Protesto 5 Anos'),
('Certid�o de Casamento, Certid�o de Nascimento Certid�o de �bito'),('Certid�o Dominial');

INSERT INTO Cartorio(Nome, Endereco, fk_tipoCertidao)
VALUES ('59� Cart�rio de Protesto - Vila X', 'AV Eespeto  7598 - Vila X, Vitoria-ES', 4),('101� Cart�rio de Registro Civil - Horizonte','Rua Ouro Preto 97 - Horizonte, Rio de Janeiro-RJ',1),('20� Cart�rio de Registro Imoveis - Ipiranga','Rua Santos 497 - Ipiranga, Sao Paulo-SP',3),('11� Cart�rio de Notas - Vila Y','Rua Mauri 1497 - Vila Y, Rio de Janeiro-RJ',2);

--DQL
SELECT * FROM Usuario;
SELECT * FROM Cartorio;
SELECT * FROM TipoCertidao;