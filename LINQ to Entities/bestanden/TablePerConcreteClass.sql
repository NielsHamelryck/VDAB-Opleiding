use Opleidingen;
go
create table KlassikaleCursussen (
  CursusNr int identity(1,2) primary key,
  Naam varchar(50) not null,
  Van datetime not null,
  Tot datetime not null
);
go
create table ZelfstudieCursussen (
  CursusNr int identity(2,2) primary key,
  Naam varchar(50) not null,
  Duurtijd int not null
);
go

insert into KlassikaleCursussen(Naam,Van,Tot)
values ('Frans voor beginners','2009-6-1','2009-6-5');

insert into KlassikaleCursussen(Naam,Van,Tot)
values ('Frans voor gevorderden','2009-6-8','2009-6-12');

insert into KlassikaleCursussen(Naam,Van,Tot)
values ('Engels voor beginners','2009-6-15','2009-6-19');

insert into KlassikaleCursussen(Naam,Van,Tot)
values('Engels voor gevorderden','2009-6-22','2009-6-26');

insert into ZelfstudieCursussen(Naam,Duurtijd)
values ('Franse correspondentie',5);

insert into ZelfstudieCursussen(Naam,Duurtijd)
values ('Engelse correspondentie',5);