use Bank;
go
create table Personeel (
	PersoneelsNr int identity primary key,
	Voornaam nvarchar(50) not null,
	ManagerNr int references Personeel(PersoneelsNr)
);
go
insert into Personeel(Voornaam) values ('Diane');
insert into Personeel(Voornaam,ManagerNr) values ('Mary',1);
insert into Personeel(Voornaam,ManagerNr) values ('Jeff',1);
insert into Personeel(Voornaam,ManagerNr) values ('William',2);
insert into Personeel(Voornaam,ManagerNr) values ('Gerard',2);
insert into Personeel(Voornaam,ManagerNr) values ('Anthony',2);
insert into Personeel(Voornaam,ManagerNr) values ('Leslie',6);
insert into Personeel(Voornaam,ManagerNr) values ('July',6);
insert into Personeel(Voornaam,ManagerNr) values ('Steve',6);
insert into Personeel(Voornaam,ManagerNr) values ('Foon Yue',6);
insert into Personeel(Voornaam,ManagerNr) values ('George',6);
insert into Personeel(Voornaam,ManagerNr) values ('Loui',5);
insert into Personeel(Voornaam,ManagerNr) values ('Pamela',5);
insert into Personeel(Voornaam,ManagerNr) values ('Larry',5);
insert into Personeel(Voornaam,ManagerNr) values ('Barry',5);
insert into Personeel(Voornaam,ManagerNr) values ('Andy',4);
insert into Personeel(Voornaam,ManagerNr) values ('Peter',4);
insert into Personeel(Voornaam,ManagerNr) values ('Tom',4);
insert into Personeel(Voornaam,ManagerNr) values ('Mami',2);
insert into Personeel(Voornaam,ManagerNr) values ('Yoshimi',19);
insert into Personeel(Voornaam,ManagerNr) values ('Martin',5);

