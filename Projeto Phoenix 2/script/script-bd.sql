create table carro(
	id int not null identity(1,1),
	nome varchar(100) not null,
	cor varchar(50) not null,
	dataFabricacao date,
	valor decimal(8,2),
	constraint pk_carro primary key (id)
);

insert into carro (nome, cor, dataFabricacao, valor)
	values('Gol','branca', '1985-06-13', 15000);

select id, nome, cor, dataFabricacao, valor from carro;

select nome, cor, dataFabricacao, valor
  from carro
 where id = 1;

update carro
  set nome = 'Celta'
where id = 1;

delete from carro where id = 1;