// array van verscheidene features


var aFeatures = [

	'document.images',
	'document.layers', 							// niet meer, enkel vroege versies van Netscape
	'document.all', 							// enkel IE
	'document.getElementById',
	'document.querySelector',					//selector API
	'document.styleSheets',
	'document.createElement',
	'document.createNodeIterator',				// niet IE
	'document.implementation.createDocument', 	// niet IE
	'window.walkTheDog', 						// bestaat niet
	'window.focus', 
	'window.hasFeatures',  						// elke vrije functie die je zelf schrijft, is een property van het window object
	'window.ActiveXObject', 					// enkel IE
	'window.XMLHttpRequest',
	'window.localStorage',						// HTML5 feature
	'[].push', 									// array method JS 1.2
	'[].filter',								// array method JS 1.6
	'Object.prototype',
	'document.documentElement.style.WebkitBorderRadius',
	'navigator.geolocation', 					// HTML5 feature
	'document.documentElement.classList' 		// HTML5 feature
];