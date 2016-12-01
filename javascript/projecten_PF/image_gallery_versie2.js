// Image_gallery_versie2.js
// een Javascript PF project

var versie = " versie 2.0";

window.onload = function () {
	
	//versie info
	var eKop 		= document.querySelector('h1');
	eKop.innerHTML 	= eKop.innerHTML + versie;
	
	var eImg		= document.getElementById('plaatshouder');
	//var eSidebar 	= document.querySelector('sidebar');
	//var eLinks	= eSidebar.getElementsByTagName('a'); //collection
	var eLinks 		= document.querySelectorAll('aside a'); //collection
	console.log('eLinks %s',eLinks.length);
	
	for(var i=0;i<eLinks.length;i++){
		eLinks[i].addEventListener('click',function (e){
			e.preventDefault();
			toonFoto(this,eImg);
		})
		eLinks[i].addEventListener('mouseover',function (e){
			toonFoto(this,eImg);
		})
	}
}
	
function toonFoto(eLink, eImg){
/* wisselt de bron van het src attribuut van de img#beeld
@ eLink, een hyperlink element
@ eImg,	plaatshouder img 
*/
  
  //console.log(eLink.href);
  eImg.src 		= eLink.href; //wissel de foto in plaatshouder
  var sInfo 	= eLink.getAttribute('title');	//info tekst vanuit het title attribuut
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
