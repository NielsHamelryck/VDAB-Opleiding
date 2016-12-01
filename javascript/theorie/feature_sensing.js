//feature_sensing.js
// Taak feature sensing op auto genereren van een lijst

window.onload=function()
{
	
	//kijken welke browser je aan het gebruiken bent
	var eBrowser = document.querySelector('#browserTest');
	var eBrowserSoort = document.createElement('p');
	eBrowserSoort.innerHTML = "Uw browser is " + navigator.userAgent;
	eBrowser.appendChild(eBrowserSoort);
	
	//controlleren of de array is geimplementeerd
	
	if(typeof aFeatures=='undefined'){
		throw new Error("de array met features is niet ingeladen");
	}
	
	//
	var eFeatureLijst = document.querySelector('#featureLijst');
	
	var eLijst = document.createElement('ul');
	
	
	var nFeaturelijst = aFeatures.length;
		
	for(var i = 0; i< nFeaturelijst ; i++){
		
		var eItem = document.createElement('li');
		
		var bSupport = (eval(aFeatures[i]))?true:false;
		var sKleur = (bSupport===true)?"groen":"rood";
		eItem.className = sKleur;
		
		var eSpan = document.createElement("span");
		eSpan.className="support";
		eSpan.innerText =bSupport;
		
		//eSpan.appendChild(document.createTextNode(bSupport));
		
		eItem.innerText = aFeatures[i];
		eItem.appendChild(eSpan);
		
		
		console.log(aFeatures[i]);
		eLijst.appendChild(eItem);
	}
	eFeatureLijst.appendChild(eLijst);
}