// script inhoudstafel JS basis_project
// innerHTML versie, zie ook DOM versie en applicatie versie
// @ jan vandorpe 2010

// principe: elke kop (h1,h2,...) die een id heeft komt in de inhoudstafel
// laat id achterwege om over te slaan
// element met id TOC verondersteld (TOC = Table of Contents)



window.onload = function(){
	
	var toc = document.getElementById('toc'); // element waarvan inhoud overschreven wordt met inhoudstafel

	if(toc){
	
	//globals
		var arrKoppen 	= ["h1","h2","h3","h4","h5","h6"];
		var strTOC 		= "";
		var koppenMetId = new Array(); //array met DOM elementen/ nodig? enkele tekst en id ok?
		var startLevel = 2;
		var alleElementen = document.getElementsByTagName("*"); //collection
	//overloop alle elementen in volgorde
		//console.time("koppenTimer");
		for(var i=0;i<alleElementen.length;i++){
			var e		= alleElementen[i];
			var aidee 	= e.id; // 
			var tag 	= e.tagName.toLowerCase();
			
			for (var k=0;k<arrKoppen.length;k++){
				if((arrKoppen[k]==tag)&&(aidee!="")){
					koppenMetId.push(e); // voeg toe aan collectie
					break; //breek af zodra gevonden
				}	
			}
		}
		//console.timeEnd("koppenTimer");
		//console.log(koppenMetId.length);
		
		
		var level 		= startLevel;
		var prevLevel 	= level;
		
		strTOC += openTag('ul',{id:'toc'}); // de eerste ul 	
		
		//lus doorheen de koppen in dezelfde volgorde
		for (var i=0;i<koppenMetId.length;i++){
			
				level = getKopLevel(koppenMetId[i]);//bepaal niveau kop
					
				if(level>prevLevel){
					// geneste lijst
					strTOC += openTag('li'); 
					strTOC += maakLink('#' + koppenMetId[i].id,koppenMetId[i].firstChild.nodeValue); 
					strTOC += openTag('ul'); 					
				}
				
				if(level<prevLevel){
					// breek uit geneste lijst en ga naar hoger niveau
					strTOC += sluitTag('ul');
					strTOC += sluitTag('li');
					strTOC += openTag('li');
					strTOC += maakLink('#' + koppenMetId[i].id,koppenMetId[i].firstChild.nodeValue); 
					strTOC += sluitTag('li');
				}
			
			  if(level==prevLevel){
				  //normaal list item
				  strTOC += openTag('li'); 
				  strTOC += maakLink('#' + koppenMetId[i].id,koppenMetId[i].firstChild.nodeValue); 
				  strTOC += sluitTag('li');
				  }
			  			  
			  prevLevel=level;		


		}//einde for
		
		strTOC += sluitTag('ul'); // de hoofd ul 	
	
		//debug
		console.log(strTOC);
		
		// overschrijf tenslotte de inhoud van het doel
	  	toc.innerHTML = strTOC;
	}//einde if
	
}//einde window.onload


//functies 
//==============================================================
function openTag(tag,attribs){
  /*
  return 	HTML string
  @tag		string, verplicht, HTML element, bv UL
  @attribs 	object, optioneel, met attributen als eigenschappen
  */
  if(tag&&tag!=""){
	  //
	  attribs = attribs || {};
	  
	  tag = tag.toLowerCase();
	  var str ="";
	  str += "\n<" + tag;
	  //overloop attributen
	  for (prop in attribs){
		  str += " " + prop;
		  str += "='" + attribs[prop] + "'";
		  }
	  str += ">";
	  return str;
  }
}
//==============================================================
function sluitTag(tag){
/*
return 		HTML string
@tag		string, verplicht, HTML element
*/
  if(tag&&tag != ""){
	  tag = tag.toLowerCase();
	  var str ="\n</" + tag + ">";
	  return str;
	  }
}
//==============================================================
function maakLink(url,tekst){
  /*
  return 		HTML string A tag
  @url			string
  @tekst 		string
  */
 	if(url && url!=""){
	  var str = "";
	  str += openTag('a', {href:url});
	  str += tekst;
	  str += sluitTag('a');
	  return str;
	}
}		
//=========================================================	
	function getKopLevel(kop){
	/*
	getKopLevel: returnt het getal van een header, h2 -> 2
	@kop :  DOM node verondersteld een header te zijn
	return integer
	*/	
		return parseInt(kop.tagName.substring(1));
		
}
//=========================================================	



