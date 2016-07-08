CREATE PROCEDURE Storten
	(@teStorten money, @rekeningNr nvarchar(14))
AS
	update Rekeningen
	set saldo=saldo+@teStorten
	where RekeningNr=@rekeningNr
