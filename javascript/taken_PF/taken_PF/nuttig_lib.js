// JavaScript libary

/**************** Datum, tijd functies *************/
//----------datum arrays----------------------

//dagen volgens getDay() volgorde
var arrWeekdagen = new Array('zondag', 'maandag', 'dinsdag', 'woensdag', 'donderdag', 'vrijdag', 'zaterdag');

//vervang feb dagen voor een schrikkeljaar
var arrMaanden = new Array(['januari',31], ['februari',28], ['maart',31], ['april',30], ['mei',31], ['juni',30], ['juli',31], ['augustus',31], ['september',30], ['oktober',31], ['november',30], ['december',31]);

//globale datum objecten te gebruiken in je pagina
var vandaag 		= new Date();
var huidigeDag 		= vandaag.getDate(); //dag vd maand
var huidigeWeekDag 	= vandaag.getDay(); //weekdag
var huidigeMaand 	= vandaag.getMonth();
var huidigJaar 		= vandaag.getFullYear();

//---------------------------------------------

function isSchrikkeljaar(jaar){
/* test voor schrikkeljaar
@jaar: number, 4 digits, verplicht
return: boolean
*/
eindwaarde=false;

if (!isNaN(jaar)){
	if (jaar%4===0){
		eindwaarde=true;
		if(jaar%100===0){
			eindwaarde=false;
			if(jaar%400===0){
				eindwaarde=true;
			}
		}
	}
}
return eindwaarde;
}
//---------------------------------------------
function getVandaagStr(){
//returnt een lokale datumtijdstring

var strNu = "Momenteel: " + vandaag.toLocaleDateString() + ", " + vandaag.toLocaleTimeString();

return strNu;
}

/**************** DOM functies *******************/

function leegNode(objNode){
/* verwijdert alle inhoud/children van een Node
	@ objNode: node, verplicht, de node die geleegd wordt
*/
	while(objNode.hasChildNodes()){
		objNode.removeChild(objNode.firstChild)
	}
}
//---------------------------------------------

function getElementsByClassName(classname, startElement) {
/* zoekt elementen van een bepaalde CCS clss
*
* @classname: string
* @startElement: DOM element, optional, om de zoektocht in te koreten anders doorloppt alle elementen
* @return: collection (array van nodes)
*/
	var eBegin = (startElement||document)
    var a = [];
    var re = new RegExp('\\b' + classname + '\\b');
    var els = eBegin.getElementsByTagName("*");
    var j = els.length;
	  for(var i=0; i<j; i++)
        if(re.test(els[i].className)){ a.push(els[i]);}
    return a;
}
//---------------------------------------------

function getElementsByTagAndClass(tag, klasse, container){

/*
returnt een collection (=array) van elementNodes, 
alle argumenten verplicht

@tag			= string, verplicht, tagName // gebruik geen tagName als arg !! IE crash
@klasse 		= string, verplicht, CSS class
@container	 	= string, optioneel, tagName, startNode van waaruit kan gezocht worden

*/   
	var coll = []; 
		
	if (document.getElementsByTagName){ 
		if (tag==undefined||tag==""||klasse==undefined||klasse==""){
			throw new Error ("functie argumenten tag en klasse zijn verplicht");
			return;
     	}
		else {
			var startEl =(container&&container!="")?container:document;
			var tempColl  = startEl.getElementsByTagName(tag);	
		}
		
    	for(var i=0;i<tempColl.length;i++){
			
			var zoekterm='\\b'+ klasse +'\\b'; 
			var patroon = new RegExp(zoekterm,"g"); //
			if(patroon.test(tempColl[i].className)) 
				coll.push(tempColl[i]); // vul nieuwe collectie
		}
		//console.log("collection bevat %s nodes", coll.length);
		return coll;
	}
	
}
//===========================================


/**************** COOKIES *******************/

function setCookie(naam,waarde,dagen){
/*plaatst een cookie

naam: cookienaam;
waarde: de inhoud van het cookie
dagen: optioneel, het aantal dagen dat het cookie geldig blijft vanaf nu
		indien afwezig wordt het een session cookie
*/
	var verval = "";
	if(dagen){
		// vandaag 	uit global var bovenaan
		var vervalDatum = new Date(vandaag.getTime()+ parseInt(dagen)*24*60*60*1000);
		//alert(vervaldatum);
		verval = vervalDatum.toUTCString();
	}
	document.cookie = naam + "=" + waarde + ";expires=" + verval;
}
//---------------------------------------------
function getCookie(naam){
/*leest een cookie

naam: cookienaam
*/
	var zoek = naam + "=";
	if (document.cookie.length>0){
		var begin = document.cookie.indexOf(zoek);
		if (begin!=-1){
			begin += zoek.length;
			var einde = document.cookie.indexOf(";", begin);
			if (einde==-1){
				einde = document.cookie.length;
			}
			return document.cookie.substring(begin, einde);
		}
	}
}
//---------------------------------------------
function clearCookie(naam){
/*
verwijdert een cookie

naam: cookienaam
*/	
	//console.log('clearing: ' + naam)
	setCookie(naam,"",-1);
}
