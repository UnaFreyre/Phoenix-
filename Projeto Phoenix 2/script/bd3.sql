CREATE TABLE Login (
  LoginID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
  Username VARCHAR(50) NOT NULL,
  Password VARCHAR(50) NOT NULL
);

INSERT INTO Login (Username, Password) 
VALUES ('adm', '123');

delete from Login
where Username='adm' 

select * from Login

select * from tipologin

ALTER TABLE Login
ADD TipoLogin VARCHAR(20) NOT NULL;

--ALTER TABLE Login
--MODIFY COLUMN TipoLogin ENUM('Estudante', 'Professor', 'Administrador') NOT NULL;

ALTER TABLE Login
DROP COLUMN tipologinid;

CREATE TABLE TipoLogin (
    TipoLoginID INT PRIMARY KEY,
    Descricao VARCHAR(50)
);

-- Inserir os tipos de login
INSERT INTO TipoLogin (TipoLoginID, Descricao)
VALUES (1, 'Estudante'), (2, 'Professor'), (3, 'Administrador');

-- Adicionar coluna de TipoLogin na tabela Login
ALTER TABLE Login
ADD TipoLoginID INT;

-- Adicionar chave estrangeira para relacionar com a tabela TipoLogin
ALTER TABLE Login
ADD CONSTRAINT FK_Login_TipoLogin
FOREIGN KEY (TipoLoginID) REFERENCES TipoLogin (TipoLoginID);

