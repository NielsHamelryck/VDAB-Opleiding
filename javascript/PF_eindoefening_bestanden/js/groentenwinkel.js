//****************Javascript library groentenwinkel.js ********************//

//==============================GLOBALS======================================

//************************* Gebruikte arrays*******************************/
// array Winkels
 var aoWinkels = [
 {naam:"de fruitmand",adres:"steenstraat 34", post:8000,gemeente:"Brugge",tel:"050342218",manager:"Francine Lapoule"},
{naam:"Jos & Anneke",adres:"visserijstraat 1", post:8400,gemeente:"Oostende",tel:"059463689",manager:"Jos Leman"},
{naam:"groene vingers",adres:"hoogstraat 108", post:9000,gemeente:"Gent",tel:"091342218"},
{naam:"de buurtwinkel",adres:"die laene 22", post:2000,gemeente:"Antwerpen",tel:"0230342218",manager:"Bert Simoens"}];

//array Groenten

var aGroenten = [["aardappelen",0.95,"kg"],
["avocado",2.69,"stuk"],
["bloemkool",1.93,"stuk"],
["brocoli",1.29,"stuk"],
["champignons",0.89,"250g"],
["chinese kool",1.59,"stuk"],
["groene kool",1.69,"stuk"],
["knolselder",1.29,"stuk"],
["komkommer",2.49,"stuk"],
["kropsla",1.69,"stuk"],
["paprika",0.89,"net"],
["prei",2.99,"bundel"],
["princessenbonen",1,"250g"],
["rapen",0.99,"bundel"],
["rode kool",1.39,"stuk"],
["sla iceberg",1.49,"stuk"],
["spinazie vers",1.89,"300g"],
["sjalot",0.99,"500g"],
["spruiten",1.86,"kg"],
["trostomaat",2.99,"500g"],
["ui",0.89,"kg"],
["witloof 1ste keus",1.49,"700g"],
["wortelen",2.59,"kg"],
["courgetten",1.5,"stuk"]];



	var nGroente = aGroenten.length;//lengte bepalen van de array groenten
	var nWinkels = aoWinkels.length;//lengte bepalen van de array winkels
//******************************Functies****************************************/

window.onload = function()
{
	//noscript verbergen
	var eNoScript = document.getElementById('noscript');
	eNoScript.style.display = "none";
	//********************DOM referenties***********************//
	//keuzelijsten
	var eWinkel= document.getElementById('winkel'); //element voor de dropdown winkels
	var eGroente = document.getElementById('groente'); //element voor de dropdown groenten
	//knop 
	var eKnop = document.getElementById('toevoegen');
	
	
	//*****************keuzelijsten opvullen *********************//
	
	//winkel lijst vullen
	for(var i = 0; i<nWinkels ; i++)
	{
		var eOption = document.createElement('option');
		eOption.value = aoWinkels[i].naam;
		eOption.title = aoWinkels[i].adres +", "+ aoWinkels[i].post +" " + aoWinkels[i].gemeente;
		eOption.innerHTML = aoWinkels[i].naam;
		eWinkel.appendChild(eOption);
	}
	
	//groentenlijst vullen
	for(var i = 0 ; i<nGroente ; i++)
	{
		var eOption = document.createElement('option');
		eOption.value = aGroenten[i][0];
		eOption.innerHTML = aGroenten[i][0]+"("+aGroenten[i][1]+" €\/"+aGroenten[i][2]+")";
		eGroente.appendChild(eOption);
	}
	
	//****************** evenhandlers *****************************//
	
	eKnop.addEventListener('click', function()
	{
		toevoegen(eWinkel.value,eGroente.value);
	});
}//einde window.onload functie


function toevoegen(winkelNaam,groenteNaam)
{
	/*functie voor het weergeven van het winkelmandje
	 @winkelNaam : string naam van de winkel
	 @groenteNaam : string naam van de groente
	*/
	//element aantal groenten
	var eAantal = document.getElementById('aantal');
	if(winkelNaam != "" && groenteNaam !="")
	{
			if(eAantal.value >0 && !isNaN(eAantal.value))
			{
				var gekozenGroente = [];//variabele voor de gekozenGroente
				//array van groenten doorzoeken naar het geselecteerde groente
				for(var i=0;i<nGroente;i++)
				{
					if(aGroenten[i][0] == groenteNaam)
					{
						gekozenGroente=aGroenten[i];
					}
				}
				
				//verwijderen van de text Winkelmandje is leeg
				//element Leeg
				var eLeeg = document.getElementById('leeg');
				if(eLeeg!=null){
					
				//verwijderen van de child genaamd leeg
				eLeeg.parentNode.removeChild(eLeeg);
				}
				
				
				//*********aanmaken item in winkelmmandje*****//
				//aanmaken van de lijn in winkelmandje
				var eItem = document.createElement('div');
				eItem.className = "item";
				
				//het element voor de naam van het item
				var eNaam = document.createElement('div');
				eNaam.className = "cel cellinks" 
				eNaam.innerHTML = gekozenGroente[0];
				
				//het element voor het hoeveelheid van het item
				var eHoeveelheid = document.createElement('div');
				eHoeveelheid.className = "cel celopschuiven";
				eHoeveelheid.innerHTML = eAantal.value;
				
				//het element voor de stukprijs van het item
				var eStukprijs = document.createElement('div');
				eStukprijs.className = "cel celopschuiven";
				eStukprijs.innerHTML = gekozenGroente[1];
				
				//het element voor subtotaal van het item
				var eSubtotaal = document.createElement('div');
				eSubtotaal.className = "cel celrechts celrechtslichter";
				eSubtotaal.innerHTML = (gekozenGroente[1] * eAantal.value).toFixed(2);
				
				//elementen toevoegen aan het element van het item
				eItem.appendChild(eNaam);
				
				eItem.appendChild(eHoeveelheid);
				eItem.appendChild(eStukprijs);
				eItem.appendChild(eSubtotaal);
				//item toevoegen aan het winkelmandje
				var eWinkelmandje = document.getElementById('winkelmandje');
				eWinkelmandje.insertBefore(eItem,eWinkelmandje.childNodes[2]);
				
				//element maken voor het totaalBedrag weer te geven
				var eTotaal = document.getElementById('totNum');
				eTotaal.innerHTML = (parseFloat(eTotaal.innerHTML) + gekozenGroente[1] * eAantal.value).toFixed(2);
				
			}else
			{
				alert("Moet een positief getal bevatten!")
			}
	}else
	{
			alert("er is geen winkel en/of groente gekozen!");
	}
}