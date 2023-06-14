insert into Estudante(Nome,CursoID,LoginID)
values ('Francisco',1,)

INSERT INTO Curso (Nome, ProfessorID)
VALUES ('Curso A',1	);

-- Inserir registros na tabela Professor
INSERT INTO Professor (Nome, LoginID)
VALUES ('Professor 1', 2);

-- Inserir registros na tabela Admin
INSERT INTO Admin (Nome, LoginID)
VALUES ('Admin 1', 1);

-- Inserir registros na tabela Disciplina
INSERT INTO Disciplina (Nome, CursoID)
VALUES ('Disciplina 1', 1);

-- Inserir registros na tabela Estudante
INSERT INTO Estudante (Nome, CursoID, LoginID)
VALUES ('Estudante 1', 2, 3);
INSERT INTO Estudante (Nome, CursoID, LoginID)
VALUES ('Stanke', 2, 3);
INSERT INTO Estudante (Nome, CursoID, LoginID)
VALUES ('xesco', 2, 3);


INSERT INTO Login (Username, Password, TipoLoginID)
VALUES ('usuario1', 'senha1', 1);



Select * from login
