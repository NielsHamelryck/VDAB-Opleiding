use Opleidingen;
go
create table Cursussen3 (
  CursusNr int identity primary key,
  Naam varchar(50) not null,
  Van datetime,
  Tot datetime,
  Duurtijd int,
  SoortCursus char not null
);
go

insert into Cursussen3(Naam,Van,Tot,SoortCursus)
values ('Frans voor beginners','2009-6-1','2009-6-5','K');

insert into Cursussen3(Naam,Van,Tot,SoortCursus)
values ('Frans voor gevorderden','2009-6-8','2009-6-12','K');

insert into Cursussen3(Naam,Van,Tot,SoortCursus)
values ('Engels voor beginners','2009-6-15','2009-6-19','K');

insert into Cursussen3(Naam,Van,Tot,SoortCursus)
values('Engels voor gevorderden','2009-6-22','2009-6-26','Z');

insert into Cursussen3(Naam,Duurtijd,SoortCursus)
values ('Franse correspondentie',5,'Z');

insert into Cursussen3(Naam,Duurtijd,SoortCursus)
values ('Engelse correspondentie',5, 'Z');