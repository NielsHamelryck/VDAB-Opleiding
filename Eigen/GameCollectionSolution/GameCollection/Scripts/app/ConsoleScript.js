

$('#consoleLijst  ul  li  div').hover(
    function() { $(this).animate({ height: "+=25", width: "+=25" }) },
    function() {
        $(this).animate({ height: "-=25", width: "-=25" });
    });
