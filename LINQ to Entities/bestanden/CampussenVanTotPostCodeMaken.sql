use Opleidingen;
go
create procedure CampussenVanTotPostCode(@VanPostCode nvarchar(10), @TotPostCode nvarchar(10))
as
select * from Campussen
where Postcode between @VanPostCode and @TotPostCode
order by PostCode, Naam
