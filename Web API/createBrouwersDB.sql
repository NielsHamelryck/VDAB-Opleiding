create database Brouwers;
go
use Brouwers;
go
create table Provincies (
  ID int identity primary key,
  Naam nvarchar(50) not null
);

insert into Provincies(Naam) values ('Antwerpen');
insert into Provincies(Naam) values ('Limburg');
insert into Provincies(Naam) values ('Oost-Vlaanderen');
insert into Provincies(Naam) values ('Vlaams-Brabant');
insert into Provincies(Naam) values ('West-Vlaanderen');
insert into Provincies(Naam) values ('Henegouwen');
insert into Provincies(Naam) values ('Luik');
insert into Provincies(Naam) values ('Luxemburg');
insert into Provincies(Naam) values ('Namen');
insert into Provincies(Naam) values ('Waals-Brabant');