use Opleidingen;
go
create table Cursussen4 (
  CursusNr int identity primary key,
  Naam varchar(50) not null,
);
create table KlassikaleCursussen4 (
  CursusNr int primary key references Cursussen4(CursusNr),
  Van datetime not null,
  Tot datetime not null
);
go
create table ZelfstudieCursussen4 (
  CursusNr int primary key references Cursussen4(CursusNr),
  Duurtijd int not null
);
go

insert into Cursussen4(Naam)
values ('Frans voor beginners');

insert into KlassikaleCursussen4(CursusNr,Van,Tot)
values (@@identity,'2009-6-8','2009-6-12');

insert into Cursussen4(Naam)
values ('Engels voor beginners');

insert into KlassikaleCursussen4(CursusNr,Van,Tot)
values (@@identity,'2009-6-1','2009-6-5');

insert into Cursussen4(Naam)
values ('Frans voor gevorderden');

insert into KlassikaleCursussen4(CursusNr,Van,Tot)
values (@@identity,'2009-6-8','2009-6-12');

insert into Cursussen4(Naam)
values ('Engels voor gevorderden');

insert into KlassikaleCursussen4(CursusNr,Van,Tot)
values (@@identity,'2009-6-15','2009-6-19');

insert into Cursussen4(Naam)
values ('Franse correspondentie')

insert into ZelfstudieCursussen4(CursusNr,Duurtijd)
values (@@identity,5);

insert into Cursussen4(Naam)
values ('Engelse correspondentie')

insert into ZelfstudieCursussen4(CursusNr,Duurtijd)
values (@@identity,5);