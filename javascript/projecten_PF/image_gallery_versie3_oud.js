// Image_gallery_versie3.js
// een Javascript_basis project
// dropdown uit array versie

var versie = " versie 3.0";

window.onload = function () {
	//test
	console.log(arrModernArt[0][0]);
	
	
	
	//versie info
	var kop = document.getElementsByTagName('h1')[0];
	kop.innerHTML = kop.innerHTML + versie;
	//neutraliseer het click event van alle hyperlinks in de menubalk
	var sidebar = document.getElementById('sidebar');
	sidebar.appendChild(maakKunstKiezer());
	
	
	
	
	
	
	
	var sidebarLinks = sidebar.getElementsByTagName('a'); //array
	//console.log('sidebarLinks %s',sidebarLinks.length);
	
	for(var i=0;i<sidebarLinks.length;i++){
		sidebarLinks[i].onclick = function () {
									return false;
									}
		
		sidebarLinks[i].onmouseover = function () {
									toonFoto(this);
									}
		}
	
	}
//====================================================================
function toonFoto(welkItem){
/* wisselt de bron van het src attribuut van de img#beeld
@ index, geheel getal op te zoeken in arrModernArt in images.gallery.js  
*/
  var plaatshouder = document.getElementById('plaatshouder');
  
  if(plaatshouder){ 
  
  		plaatshouder.src = "art/" + arrModernArt[welkItem][0]; 
		var strInfo = arrModernArt[welkItem][1];
		
		var pee = document.getElementById('info');
		if(pee){
		//wijzig info
			pee.firstChild.nodeValue = strInfo;
		}
		else {
		//maak nieuwe p info aan
		  var pee = document.createElement('p');
		  pee.id = "info";
		  pee.appendChild(document.createTextNode(strInfo));
		  plaatshouder.parentNode.insertBefore(pee,plaatshouder.parentNode.firstChild);
		}
	}
}
//=============================================================================
function maakKunstKiezer(){
/*
returnt een SELECT element met de lijst van kunstwerken en een GO knop
*/
	var kiezer 		= document.createDocumentFragment();
	var keuzelijst 	= document.createElement('select');
	//standaard option element
	var eersteOption 	= document.createElement('option');
	eersteOption.appendChild(document.createTextNode("Maak een keuze"));
	keuzelijst.appendChild(eersteOption);
	//de artiesten
	for(var i=0;i<arrModernArt.length;i++){
		var keuzeItem 	= document.createElement('option');
		artiest = arrModernArt[i][2];
		var txtKeuze	= document.createTextNode(artiest);
		keuzeItem.appendChild(txtKeuze);
		keuzelijst.appendChild(keuzeItem);
	}
	//keuzelijst.onchange = function(){toonFoto(keuzelijst.selectedIndex - 1)}
	//'Kies' knop
	var knop = document.createElement('button');
	knop.setAttribute("type","button");
	knop.appendChild(document.createTextNode('kies'));
	knop.onclick = function(){toonFoto(keuzelijst.selectedIndex-1)}
	
	kiezer.appendChild(keuzelijst);
	kiezer.appendChild(knop);

	return kiezer;
}
