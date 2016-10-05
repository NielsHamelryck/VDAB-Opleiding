use Opleidingen;
go
create view BestBetaaldeDocentenPerCampus as
select Tussen.CampusNr,Tussen.Naam, Tussen.GrootsteWedde, Docenten.DocentNr, Docenten.Voornaam, Docenten.Familienaam from 
(select Campussen.CampusNr, Campussen.Naam, max(Docenten.Wedde) as GrootsteWedde from
Campussen inner join Docenten on Campussen.CampusNr=Docenten.CampusNr
group by Campussen.CampusNr,Campussen.Naam) Tussen inner join Docenten
on Tussen.CampusNr=Docenten.CampusNr and Tussen.GrootsteWedde=Docenten.Wedde