use Bank;
go
create procedure AdministratieveKost(@Kost as decimal(10,2))
as
update Rekeningen set Saldo=Saldo-@Kost;