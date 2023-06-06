CREATE TABLE Login (
  LoginID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
  Username VARCHAR(50) NOT NULL,
  Password VARCHAR(50) NOT NULL,
);
CREATE TABLE TipoLogin (
    TipoLoginID INT PRIMARY KEY,
    Descricao VARCHAR(50)
);

-- Inserir os tipos de login
INSERT INTO TipoLogin (TipoLoginID, Descricao)
VALUES (1, 'Administrador'), (2, 'Professor'), (3, 'Estudante');

-- Adicionar coluna de TipoLogin na tabela Login
ALTER TABLE Login
ADD TipoLoginID INT;

-- Adicionar chave estrangeira para relacionar com a tabela TipoLogin
ALTER TABLE Login
ADD CONSTRAINT FK_Login_TipoLogin
FOREIGN KEY (TipoLoginID) REFERENCES TipoLogin (TipoLoginID);


CREATE TABLE Curso (
  CursoID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
  Nome VARCHAR(50) NOT NULL,
  ProfessorID int foreign key references Professor(ProfessorID)
);


CREATE TABLE Professor (
  ProfessorID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
  Nome VARCHAR(50) NOT NULL,
  LoginID INT FOREIGN KEY REFERENCES Login(LoginID)
);



CREATE TABLE Admin (
  AdminID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
  Nome VARCHAR(50) NOT NULL,
  LoginID INT FOREIGN KEY REFERENCES Login(LoginID)
);

CREATE TABLE Disciplina (
  DisciplinaID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
  Nome VARCHAR(50) NOT NULL,
  CursoID INT FOREIGN KEY REFERENCES Curso(CursoID)
);

CREATE TABLE Estudante (
  EstudanteID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
  Nome VARCHAR(50) NOT NULL,
  CursoID INT FOREIGN KEY REFERENCES Curso(CursoID),
  LoginID INT FOREIGN KEY REFERENCES Login(LoginID)
);