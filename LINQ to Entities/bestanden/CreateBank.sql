create database Bank;
go
use Bank;
go
create table Klanten (
  KlantNr int identity primary key,
  Voornaam nvarchar(50) not null
);
go
create table Rekeningen (
  RekeningNr nvarchar(20) primary key,
  KlantNr int not null references Klanten(KlantNr),
  Saldo decimal(10,2) not null default 0,
  Soort char not null
);
go

insert into Klanten(Voornaam) values ('Marge');
insert into Klanten(Voornaam) values ('Homer');
insert into Klanten(Voornaam) values ('Lisa');
insert into Klanten(Voornaam) values ('Maggie');
insert into Klanten(Voornaam) values ('Bart');

insert into Rekeningen(RekeningNr,KlantNr,Saldo,Soort) values ('123-4567890-02',1,1000,'Z');
insert into Rekeningen(RekeningNr,KlantNr,Saldo,Soort) values ('234-5678901-69',1,2000,'S');
insert into Rekeningen(RekeningNr,KlantNr,Saldo,Soort) values ('345-6789012-12',2,500,'S');