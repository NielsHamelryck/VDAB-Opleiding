use Bank;
go
create view TotaleSaldoPerKlant as
select Klanten.KlantNr,Klanten.Voornaam, sum(Saldo) as TotaleSaldo
from Klanten left outer join Rekeningen
on Klanten.KlantNr=Rekeningen.KlantNr
group by Klanten.KlantNr,Klanten.Voornaam