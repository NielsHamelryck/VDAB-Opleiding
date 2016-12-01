//javascript library

//===============GLOBALS======================================
//array van functies
var aFuncties	= ["instructeur","bediende","manager","arbeider"];
//array van personen, elke persoon is een object
var aoPersoneel = [
	{id:4678,naam:"Roger Mary", functie:"instructeur", leeftijd: 65, sexe:"m", gehuwd:true, kinderen:[{naam:"Liesbeth", leeftijd: 26, sexe:"v"}],vrienden:24},
	{naam:"Evelyn Van Welsenaers", leeftijd: 44, sexe:"v", gehuwd:true, kinderen:[{naam:"Patrick", leeftijd: 12, sexe:"m"},{naam:"Jonas", leeftijd: 14, sexe:"m"},], functie:"bediende",id:1025,vrienden:11},
	{leeftijd: 27, sexe:"v", gehuwd:false,id:9007,functie:"arbeider",naam:"Heidi Vercouteren",vrienden:6}
]

window.onload = function(){

//=======DOM REFERENTIES=======================================

//knoppen
var eToevoegen 		= document.getElementById('toevoegen');
var ePersoneelsLijst= document.getElementById('personeelsLijst');
//invulvelden, keuzelijsten, etc...
var eNaam 			= document.getElementById('naam');
var eFunctie 		= document.getElementById('functie');
var eSexe 			= document.frmPersoneelslid.sexe;
var eLeeftijd 		= document.getElementById('leeftijd');
var eGehuwd 		= document.getElementById('gehuwd');
var eKind1			= document.getElementById('kind1');
var eKind2			= document.getElementById('kind2');
var eKind3			= document.getElementById('kind3');
var eForm 			= document.getElementById('frmPersoneelslid')
//document fragment
var dfPersonen		= document.createDocumentFragment();
//andere
var eOutput			= document.getElementById('output');
var eTeller			= document.getElementById('teller');

//nieuwe element voor de keuzelijst default waarde

var eOption = document.createElement('option');
eOption.innerHTML = "-- maak een keuze --";
eOption.value ="default";
eFunctie.appendChild(eOption);

//event handlers 

eToevoegen.addEventListener('click' , function()
{	//controleren of er een functie gekozen is
	
	var bSelectie= selectieControle(eFunctie);
})

ePersoneelsLijst.addEventListener('click',function()
{
	//weergeven geselecteerde persoon
	if(selectieControle(eFunctie)){
		var sGegevens = persoonGegevens(ePersonenL);
	eOutput.appendChild(sGegevens);
	
	
	}
	
});

//=======KEUZELIJST OPVULLEN ===================================

var nFuncties = aFuncties.length;
// opvullen van de dropdown lijst voor functies

/*for(var i = 0 ; i<nFuncties ; i++){
	eOption = document.createElement('option');
	eOption.innerHTML = aFuncties[i];
	eOption.value = aFuncties[i];
eFunctie.appendChild(eOption);}
	*/
	
	aFuncties.forEach(function(functie)
	{
		eOption = document.createElement('option');
		eOption.innerHTML = functie;
		eOption.value = functie;
		eFunctie.appendChild(eOption);
	});

//aanmaken en vullen van dropdown objecten lijst met perosnen
var nPersonen = aoPersoneel.length;

var ePersonenL = document.createElement('select');
ePersonenL.id= "personenDropBox";
/*
for(var i = 0 ; i<nPersonen ; i++)
{
	eOption = document.createElement('option');
	eOption.innerHTML = aoPersoneel[i].naam
	if(aoPersoneel[i].kinderen == null){
	eOption.title = "geslacht: "+ aoPersoneel[i].sexe +" aantal kinderen: 0";}
	else {eOption.title = "geslacht: "+ aoPersoneel[i].sexe +" aantal kinderen: "+ aoPersoneel[i].kinderen.length};
	eOption.value = aoPersoneel[i].naam ;//+ "_" + aoPersoneel[i].id;
	ePersonenL.appendChild(eOption);
	
}
*/

 aoPersoneel.forEach(function(persoon)
 {
	eOption = document.createElement('option');
	eOption.innerHTML = persoon.naam
	if(persoon.kinderen == null){
	eOption.title = "geslacht: "+ persoon.sexe +" aantal kinderen: 0";}
	else {eOption.title = "geslacht: "+ persoon.sexe +" aantal kinderen: " + persoon.kinderen.length};
	eOption.value = persoon.naam ;//+ "_" + aoPersoneel[i].id;
	ePersonenL.appendChild(eOption);
 });

dfPersonen.appendChild(ePersonenL);
eForm.insertBefore(dfPersonen,eForm.childNodes[1]);

}// einde window.onload functie

/******controle functie juiste selectie functie ********/
function selectieControle(selecteditem)
{
	//gaat controleren of het geselecteerde item niet de default waarde is
	//@selecteditem element van de selectiebox
	var item = selecteditem.options[selecteditem.selectedIndex].value;
	if(item=="default")
	{
			alert("kies een functie!");
	}
	else {return true;}
	
}

/****** geselecteerde persoon***********/

function persoonGegevens(personenlijst)
{
	//gaat in de output de gegevens weergeven van de geselecteerde persoon in de personenlijst
	//personenlijst  het element van de personen selectiebox
	
	var persoon = personenlijst.options[personenlijst.selectedIndex].value;
	var eTekst = document.createElement('div');
	var sTekst="";
	for(var i= 0 ; i<aoPersoneel.length;i++)
	{
		
		
		
		if(aoPersoneel[i].naam==persoon)
		{	eTekst.className="_" +aoPersoneel[i].id;
			sTekst+="id: " + aoPersoneel[i].id + "\n" +
					"naam: "+aoPersoneel[i].naam + "<br>" + 
					"leeftijd: "+aoPersoneel[i].leeftijd + "<br>";
			sTekst+= "vrienden: "+ aoPersoneel[i].vrienden + "<br>" ; 
					if(aoPersoneel[i].kinderen!=null){
						sTekst+="kinderen: "+aoPersoneel[i].kinderen.length +"<br>";
					
					
					
					
					"kinderen gegevens <br>\n<br>";
					for (var key in aoPersoneel[i].kinderen)
					{	
						sTekst+= "naam: "+ aoPersoneel[i].kinderen[key].naam + "<br>";
						sTekst+= "leeftijd: "+ aoPersoneel[i].kinderen[key].leeftijd + "<br>";
						sTekst+= "sexe: "+ aoPersoneel[i].kinderen[key].sexe+ "<br>";
					}
					}
					
		}
		
	}
	var tekst = document.createTextNode(sTekst);
	eTekst.appendChild(tekst);
	return eTekst;
}