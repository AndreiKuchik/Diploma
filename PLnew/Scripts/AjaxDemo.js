//$(document).ready(function () {
   
//    $("#res").bind('click', function ()
//    {
//        $('#name').val('');
        
        
//    });
//    $("#res").bind('click', function () {
       
//        $('theme').val('');

//    });
   
//});

//$("#res").click(function () {

//    $("form")[0].reset();

//});
//$(document).ready( function OnComplete(AjaxContext) {
//    if ($("#frmID").validate().form()) {
//        $("#frmID").clearForm();
//    }
           
//  });

function OnSuccess() {
   
    this.reset();

    $('#questionTxt').val(''); //Modified, put it AFTER reset()
}

