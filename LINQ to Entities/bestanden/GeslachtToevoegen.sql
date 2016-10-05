use Opleidingen;
alter table Docenten add Geslacht int;
go
update Docenten set Geslacht=1;
insert into Docenten(Voornaam, Familienaam, CampusNr, Wedde, Geslacht) values ('Marianne','Vos',1, 2000, 2);
insert into Docenten(Voornaam, Familienaam, CampusNr, Wedde, Geslacht) values ('Jeanine','Longo',1, 2100, 2);
insert into Docenten(Voornaam, Familienaam, CampusNr, Wedde, Geslacht) values ('Grace','Verbeke',1, 2200, 2);