use Opleidingen;
go
create procedure AantalDocentenPerVoornaam
as
select  Voornaam, count(*) as Aantal
from docenten
group by Voornaam
order by Voornaam