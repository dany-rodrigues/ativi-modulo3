
(
Id_Cliente int primary key identity,
Nome varchar(50) not null,
cpf char(11)unique not null,
Data_Nasc date not null,
Email varchar(50) not null,
telefone char(11) not null
)

create table Acomapanhante
(
Id_Acompanhante int primary key identity,
Nome varchar(50) not null,
Data_Nasc date not null,
Cpf char(11) unique null,
Responsavel int not null

)

create table Excursao 
(
Id_Excursao int primary key identity,
Descricao varchar(200) null,
Origem varchar(50) not null,
Destino varchar(50) not null,
Data_ida smalldatetime not null,
Data_volta smalldatetime not null,
Valor float not null,

)


create table Cliente_Excursao(
Id_CLieEx int primary key identity,
N_Cliente int not null,
N_Excursao int not null
)




