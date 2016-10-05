use Opleidingen;
go
create table Voorraden (
  MagazijnNr int not null,
  ArtikelNr int not null,
  AantalStuks int not null,
  RekNr int not null
);
go
alter table Voorraden add constraint VoorradenMagazijnNrArtikelNr primary key clustered (MagazijnNr,ArtikelNr);
go

insert into Voorraden(MagazijnNr,ArtikelNr,AantalStuks,RekNr) values (1,10,100,3);
insert into Voorraden(MagazijnNr,ArtikelNr,AantalStuks,RekNr) values (2,10,1000,17);
insert into Voorraden(MagazijnNr,ArtikelNr,AantalStuks,RekNr) values (1,20,200,12);
insert into Voorraden(MagazijnNr,ArtikelNr,AantalStuks,RekNr) values (2,20,2000,23)
insert into Voorraden(MagazijnNr,ArtikelNr,AantalStuks,RekNr) values (1,30,300,4);
insert into Voorraden(MagazijnNr,ArtikelNr,AantalStuks,RekNr) values (2,30,3000,9);

