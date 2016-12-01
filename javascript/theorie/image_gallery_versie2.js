// Image_gallery_versie2.js
// een javascript PF project

var versie = " versie 2.0";

window.onload = function(){
	
	//versie info 
	var eKop  			= document.querySelector('h1');
	eKop.innerHTML 		= eKop.innerHTML + versie;
	
	
	var eImg 			= document.getElementById('plaatshouder');
	
	var eLinks			= document.querySelectorAll('aside a');//collection
	
	for(var i=0;i<=eLinks.length;i++){
		eLinks[i].addEventListener('click',function(e){
			e.preventDefault();
		toonFoto(this,eImg);})
		eLinks[i].addEventListener('mouseover',function(e){
			
		toonFoto(this,eImg);})
		}
		}
		
	


function toonFoto(eLink,eImg){
	
	/* wisselt de bron van het src attribuut van de img#beeld
	eLink , een hyperlink elementFromPoint
	eImg, plaatshouder img
	
	*/
	
	eImg.src= eLink.href;
	var sInfo = eLink.getAttribute('title');
	var eInfo = document.getElementById('info');
	
	if(eInfo){
		eInfo.innerHTML = sInfo;
		
	}else{
		
		var eInfo = document.createElement('p');
		eInfo.id = "info";
		eInfo.innerHTML = sInfo;
		eImg.parentNode.insertBefore(eInfo,eImg.parentNode.firstChild);
	}
}