use Opleidingen;
go
create procedure WeddeVerhoging(@Percentage decimal(5,2))
as
update Docenten
set wedde=wedde*(1+@Percentage/100)