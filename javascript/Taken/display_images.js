//display_images.js
//javascript op het verbergen van images via click-events

//globale variabelen
var bToonAlle = true;

var aLanguages = [
						[
							["Toon alle screenshots", "Verberg alle screenshots"],
							["Toon dit screenshot", "Verberg dit screenshot"]
						],
						[
							["Montrez toutes captures d'écrans", "Cachez toutes captures d'écrans"],
							["Montrez cette capture d'écran", "Cachez cette capture d'écran"]
						]
					]
var nLanguage	= 1;
//window onload	
window.onload=function()
{
	//variabelen
	var eHoofdknop = document.querySelector('#hoofdknop');
	var eScreenshots = document.querySelectorAll('img.screenshot');
	eHoofdknop.innerHTML = aLanguages[nLanguage][0][1];
	eHoofdknop.addEventListener('click',function(e)
	{
		var self = this;
		toggleAlleFiguren(self,eScreenshots);
	})
	
	//maak knoppen voor elke figuur
	var nScreens = eScreenshots.length;
	for(var i = 0 ; i<nScreens ; i++){
		
		var eFig = eScreenshots[i];
		var eButton = document.createElement('button');
		eButton.innerHTML= aLanguages[nLanguage][1][1];
		
		eButton.addEventListener('click',togglefiguur);
		eFig.parentNode.appendChild(eButton);
		}
		
	
	
	
	
	
}

//=====================
function togglefiguur(){
	/*toont of verbergt individuele figuren via een button
	  en veranderd ook de tekst op de button bij taalverandering
	  	    
	*/
	var eScreen = getFiguur(this);
	var sDisplay = eScreen.style.display;
	console.log(eScreen.nodeName,sDisplay);
	
	if(!sDisplay || sDisplay=="" || sDisplay=="block"){			//style.display is een inline property: die is afwezig in het begin: testen

			//figuur is nu getoond en wordt verborgen
			eScreen.style.display	= "none";
			this.innerHTML 			= aLanguages[nLanguage][1][0];
			}
		else{
			//figuur is verborgen en wordt getoond
			eScreen.style.display	= "block";
			this.innerHTML 			= aLanguages[nLanguage][1][1];
			}
}

	
function toggleAlleFiguren(eHoofdknop,eFiguren)
{
	/* toont of verbergt alle"screenshots"-figuren
		gebaseerd op de var boolean 'schermen' init=false
		returnt de tegengestelde waarde van 'toonAlle'
		@elm de hoofdknop
		@eFiguren
		
		return void , maar wisselt de global bToonAlle
		*/
	
	var nFiguren = eFiguren.length;
	//console.log(nFiguren)
		if(bToonAlle===false){
			//screens zijn nu verborgen en worden getoond
			for(var i= 0 ; i< nFiguren; i++){
				eFiguren[i].style.display = 'block';
			//toon ze	
				var eKnop = getKnop(eFiguren[i]);
				eKnop.innerHTML = aLanguages[nLanguage][1][1];
				eHoofdknop.innerHTML= aLanguages[nLanguage][0][1];
			}
		}else{
			//screens zijn nu getoond en worden verborgen
			for(var i= 0 ; i< nFiguren ; i++){
				eFiguren[i].style.display='none';
			
			}
		}bToonAlle=!bToonAlle;
}

//===================================================
function getKnop(eScreen){
	//return de knop bij de figuur
	return eScreen.parentNode.querySelector('button');
	}
//===================================================
function getFiguur(eKnop){
	//return de figuur bij de knop
	return eKnop.parentNode.querySelector('img.screenshot');
	}
