// Image_gallery_versie3.js
// een Javascript PF project

var versie = " versie 3.0";

window.onload = function () {
	//noscript verbergen
	var eNoScript = document.getElementById('noscript');
	eNoScript.style.display = "none";
	
	//is aModernArt geladen?
	if(typeof aModernArt == "undefined"){
		throw new Error("array aModernArt niet gevonden");
		}
	else{
		//console.log(aModernArt[0][0]);
		//versie info
		var eKop 		= document.querySelector('h1');
		eKop.innerHTML 	= eKop.innerHTML + versie;
		//plaatshouder
		var eImg		= document.getElementById('plaatshouder');
		//dynamische keuzelijst
		var eKeuzelijst = maakKeuzelijst(aModernArt);
		var eSidebar	= document.querySelector('aside');
		eSidebar.appendChild(eKeuzelijst);	
		
		eKeuzelijst.addEventListener("change",function(){
			//console.log(this.value);
			var waarde = this.value;
			if(waarde!="" && waarde!=null){
				toonFoto(this.value,eImg)
				} 
		});
	}
}//einde window.onload

//======FUNCTIES======================================================================	

function toonFoto(nIndex, eImg){
/* wisselt de bron van het src attribuut van de img#beeld
@ nIndex, een hyperlink element
@ eImg,	plaatshouder img 
@ aModernArt array, global
*/
  
	aArt 	= aModernArt[nIndex]; //subarray
  	sPad 	= aArt[0];
	sInfo 	= aArt[1];
	sNaam 	= aArt[2];
	
  eImg.src 		= "art/" + sPad; //wissel de foto in plaatshouder
  var eInfo 	= document.getElementById('info');
 // 
  if(eInfo){
  	//wijzig info
	eInfo.innerHTML = sInfo;
  }
  else {
	//maak nieuwe p#info aan
	var eInfo 		= document.createElement('p');
	eInfo.id 		= "info";
	//eInfo.style.clear="both"; //cSS method vr probleem 1
	eInfo.innerHTML = sInfo;
	//eImg.parentNode.appendChild(eInfo);
	eImg.parentNode.insertBefore(eInfo,eImg.parentNode.firstChild);
  }	
}
//========================================================
function maakKeuzelijst(a){
	/*
	return SELECT element
	@a array van images
	*/
	var nArt		= a.length;
	var eSelect 	= document.createElement('select');
	eSelect.id		= "keuzelijst";
	//standaard option element
	var eOption 	= document.createElement('option');
	eOption.innerHTML = "Maak een keuze";
	eOption.setAttribute("value", "");
	eSelect.appendChild(eOption);
	//andere option elementen met artiesten
	for(var i=0;i<nArt;i++){
		var eOption 		= document.createElement('option');
		eOption.innerHTML	= a[i][2];
		eOption.value		= i;
		eSelect.appendChild(eOption);
	}
	
	return eSelect;
}