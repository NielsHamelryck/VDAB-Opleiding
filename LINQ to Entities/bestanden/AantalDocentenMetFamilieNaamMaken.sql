use Opleidingen;
go
create procedure AantalDocentenMetFamilienaam(@Familienaam nvarchar(50))
as
select count(*)
from Docenten
where Docenten.Familienaam=@Familienaam