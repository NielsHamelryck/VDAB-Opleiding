use Opleidingen;
go
create table Boeken2 (
  BoekNr int identity primary key,
  ISBNNr nvarchar(17) not null unique,
  Titel nvarchar(50) not null
);
go
create table Cursussen2 (
  CursusNr int identity primary key,
  Naam nvarchar(50) not null,
);
go
create table BoekenCursussen2 (
  BoekNr int not null references Boeken2(BoekNr),
  CursusNr int not null references Cursussen2(CursusNr),
  VolgNr int not null
);
go
alter table BoekenCursussen2 add constraint BoekenCursussen2BoekNrCursusNr primary key clustered (BoekNr,CursusNr);
go
create unique index BoekenCursussenCursusNrVolgNr on BoekenCursussen2(CursusNr,VolgNr);
go

insert into Boeken2(ISBNNr,Titel) values ('0-0705918-0-6','C++ : For Scientists and Engineers');
insert into Boeken2(ISBNNr,Titel) values ('0-0788212-3-1','C++ : The Complete Reference');
insert into Boeken2(ISBNNr,Titel) values ('1-5659211-6-X','C++ : The Core Language');
insert into Boeken2(ISBNNr,Titel) values ('0-4448771-8-5','Relational Database Systems');
insert into Boeken2(ISBNNr,Titel) values ('1-5595851-1-0','Access from the Ground Up');
insert into Boeken2(ISBNNr,Titel) values ('0-0788212-2-3','Oracle : A Beginner''s Guide');
insert into Boeken2(ISBNNr,Titel) values ('0-0788209-7-9','Oracle : The Complete Reference');

insert into Cursussen2(Naam) values ('C++');
insert into Cursussen2(Naam) values ('Access');
insert into Cursussen2(Naam) values ('Oracle');

insert into BoekenCursussen2(BoekNr,CursusNr,VolgNr) values (1,1,3);
insert into BoekenCursussen2(BoekNr,CursusNr,VolgNr) values (2,1,2);
insert into BoekenCursussen2(BoekNr,CursusNr,VolgNr) values (3,1,1);
insert into BoekenCursussen2(BoekNr,CursusNr,VolgNr) values (4,2,1);
insert into BoekenCursussen2(BoekNr,CursusNr,VolgNr) values (5,2,2);
insert into BoekenCursussen2(BoekNr,CursusNr,VolgNr) values (4,3,1);
insert into BoekenCursussen2(BoekNr,CursusNr,VolgNr) values (6,3,2);
insert into BoekenCursussen2(BoekNr,CursusNr,VolgNr) values (7,3,3);