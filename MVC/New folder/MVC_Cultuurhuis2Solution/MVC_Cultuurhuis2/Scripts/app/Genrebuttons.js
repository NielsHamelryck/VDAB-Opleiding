function toggleClass(el) {
    // alle genres op 'niet actief' zetten
    var ulElement = el.parentElement;
    var liElementen = ulElement.children;
    var i;
    for ( i = 0; i < liElementen.length; i++) {
        liElementen[i].className = "";

    }
    // gekozen element op active zetten
    el.className = "active";
    //mededeling 'kies genre' verwijderen na eerste keuze genre
var mededeling = document.getElementById("kiesgenre");
mededeling.style.display = "none";
}
