INSERT INTO Curso (Nome)
VALUES ('Curso A');

-- Inserir registros na tabela Professor
INSERT INTO Professor (Nome, CursoID, LoginID)
VALUES ('Professor 1', 1, 1);

-- Inserir registros na tabela Admin
INSERT INTO Admin (Nome, LoginID)
VALUES ('Admin 1', 1);

-- Inserir registros na tabela Disciplina
INSERT INTO Disciplina (Nome, CursoID)
VALUES ('Disciplina 1', 1);

-- Inserir registros na tabela Estudante
INSERT INTO Estudante (Nome, CursoID, LoginID)
VALUES ('Estudante 1', 1, 1);

INSERT INTO Login (Username, Password, TipoLoginID)
VALUES ('usuario1', 'senha1', 1);

select * from admin