create database LandenStedenTalen;
go
use LandenStedenTalen;
go
create table Landen (
  LandCode nvarchar(3) not null primary key,
  Naam nvarchar(50) not null
);
go
create table Steden (
  StadNr int identity primary key,
  Naam nvarchar(50) not null,
  LandCode nvarchar(3) not null references Landen(LandCode),
);
go
create table Talen (
  TaalCode nvarchar(3) not null primary key,
  Naam nvarchar(50) not null
);
go
create table LandenTalen (
  LandCode nvarchar(3) not null references Landen(LandCode),
  TaalCode nvarchar(3) not null references Talen(TaalCode),
  primary key (LandCode, TaalCode)
);
go

insert into Landen(LandCode, Naam) values ('BEL','België');
insert into Landen(LandCode, Naam) values ('NLD', 'Nederland');
insert into Landen(LandCode, Naam) values ('DEU', 'Duitsland');
insert into Landen(LandCode, Naam) values ('LUX', 'Luxemburg');
insert into Landen(LandCode, Naam) values ('FRA', 'Frankrijk');

insert into Steden(Naam, LandCode) values ('Brussel', 'BEL');
insert into Steden(Naam, LandCode) values ('Antwerpen', 'BEL');
insert into Steden(Naam, LandCode) values ('Luik', 'BEL');
insert into Steden(Naam, LandCode) values ('Amsterdam', 'NLD');
insert into Steden(Naam, LandCode) values ('Den Haag', 'NLD');
insert into Steden(Naam, LandCode) values ('Rotterdam', 'NLD');
insert into Steden(Naam, LandCode) values ('Berlijn', 'DEU');
insert into Steden(Naam, LandCode) values ('Hamburg', 'DEU');
insert into Steden(Naam, LandCode) values ('München', 'DEU');
insert into Steden(Naam, LandCode) values ('Luxemburg', 'LUX');
insert into Steden(Naam, LandCode) values ('Parijs', 'FRA');
insert into Steden(Naam, LandCode) values ('Marseille', 'FRA');
insert into Steden(Naam, LandCode) values ('Lyon', 'FRA');

insert into Talen(TaalCode, Naam) values ('nl','Nederlands');
insert into Talen(TaalCode, Naam) values ('fr','Frans');
insert into Talen(TaalCode, Naam) values ('de','Duits');
insert into Talen(TaalCode, Naam) values ('lb','Luxemburgs');

insert into LandenTalen(LandCode, TaalCode) values ('BEL','nl');
insert into LandenTalen(LandCode, TaalCode) values ('BEL','fr');
insert into LandenTalen(LandCode, TaalCode) values ('BEL','de');
insert into LandenTalen(LandCode, TaalCode) values ('NLD','nl');
insert into LandenTalen(LandCode, TaalCode) values ('DEU','de');
insert into LandenTalen(LandCode, TaalCode) values ('LUX','lb');
insert into LandenTalen(LandCode, TaalCode) values ('LUX','fr');
insert into LandenTalen(LandCode, TaalCode) values ('LUX','de');
insert into LandenTalen(LandCode, TaalCode) values ('FRA','fr');