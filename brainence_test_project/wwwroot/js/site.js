$(document).ready(
    function(){
        $("#fileInput").change(
            function(){
                if ($(this).val()) {
                    alert("file selected");
                    $('input:submit').attr('disabled',false);
                    // or, as has been pointed out elsewhere:
                    // $('input:submit').removeAttr('disabled'); 
                }
            }
        );
    });