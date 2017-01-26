$(document).ready(function () {
   
    $("#res").bind('click', function ()
    {
        setTimeout("$('textarea').val('')", 100);
        setTimeout("$('input').val('')", 100);
        
    });
   
});

