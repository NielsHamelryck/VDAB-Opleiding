// javascript library nuttig_lib.js


//-----------------datum arrays---------------------

//dagen volgens getDay() volgorde
var arrWeekdagen = new Array('zondag','maandag','dinsdag','woensdag','donderdag','vrijdag','zaterdag');

//vervang feb dagen voor een schrikkeljaar

var arrMaanden = new Array(['januari',31],['februari',28],['maart',31],
							['april',30],['mei',31],['juni',30],['juli',31],
							['augustus',31],['september',30],['oktober',31],
							['november',30],['december',31]);
	
/************** Datum, tijd functies ****************/
	
	//globale datum objecten te gebruiken in je pagina
	
	var vandaag = new Date();
	var huidigeDag= vandaag.getDate(); // dag vd maandContainer{
	var huidigeWeekDag = vandaag.getDay(); // weekdag
	var huidigeMaand = vandaag.getMonth();
	var huidigJaar = vandaag.getFullYear();
	
//---------------------------------------------------





/***************Cookies**********/

function setCookie(naam,waarde,dagen)
{
		/*
			plaatst een cookie
			@naam  : naam van de cookie
			@waarde  : inhoud van de cookie
			@dagen :optioneel wnr het cookie vervalt
		
		*/
		var verval='';
		if(dagen)
		{
			var vervalDatum = new Date(vandaag.getTime()+dagen*24*60*60*1000);
			verval += vervalDatum.toUTCString();
		}
		document.cookie = naam + "=" + waarde +";expires=" +verval;
	
}




function getCookie(naam)
{
	/*
		opvragen van de informatie in een cookie
		
		@taal vereist , om te bepalen naar welke pagina je wil gaan
		
	*/
	var zoek = naam +"=";
	if(document.cookie.length>0)
	{
			var begin = document.cookie.indexOf(zoek);
			if(begin!=-1)
			{
				begin += zoek.lenght;
				var einde = document.cookie.indexOf(";",begin);
				if(einde==-1){
					
					einde = document.cookie.length;
				}
				return document.cookie.substring(begin,einde);
			}
	}
	
}

function clearCookie(naam)
{
	/*
	 verwijderen van een cookie
	 naam = cookienaam
	*/
	setCookie(naam,"",-1);
}