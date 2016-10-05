use Opleidingen;
go
create table Boeken (
  BoekNr int identity primary key,
  ISBNNr nvarchar(17) not null unique,
  Titel nvarchar(50) not null
);
go
create table Cursussen (
  CursusNr int identity primary key,
  Naam nvarchar(50) not null,
);
go
create table BoekenCursussen (
  BoekNr int not null references Boeken(BoekNr),
  CursusNr int not null references Cursussen(CursusNr)
);
go
alter table BoekenCursussen add constraint BoekenCursussenBoekNrCursusNr primary key clustered (BoekNr,CursusNr);
go

insert into Boeken(ISBNNr,Titel) values ('0-0705918-0-6','C++ : For Scientists and Engineers');
insert into Boeken(ISBNNr,Titel) values ('0-0788212-3-1','C++ : The Complete Reference');
insert into Boeken(ISBNNr,Titel) values ('1-5659211-6-X','C++ : The Core Language');
insert into Boeken(ISBNNr,Titel) values ('0-4448771-8-5','Relational Database Systems');
insert into Boeken(ISBNNr,Titel) values ('1-5595851-1-0','Access from the Ground Up');
insert into Boeken(ISBNNr,Titel) values ('0-0788212-2-3','Oracle : A Beginner''s Guide');
insert into Boeken(ISBNNr,Titel) values ('0-0788209-7-9','Oracle : The Complete Reference');

insert into Cursussen(Naam) values ('C++');
insert into Cursussen(Naam) values ('Access');
insert into Cursussen(Naam) values ('Oracle');

insert into BoekenCursussen(BoekNr,CursusNr) values (1,1);
insert into BoekenCursussen(BoekNr,CursusNr) values (2,1);
insert into BoekenCursussen(BoekNr,CursusNr) values (3,1);
insert into BoekenCursussen(BoekNr,CursusNr) values (4,2);
insert into BoekenCursussen(BoekNr,CursusNr) values (5,2);
insert into BoekenCursussen(BoekNr,CursusNr) values (4,3);
insert into BoekenCursussen(BoekNr,CursusNr) values (6,3);
insert into BoekenCursussen(BoekNr,CursusNr) values (7,3);