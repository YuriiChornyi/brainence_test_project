$(document).ready(
    function(){
        $("#fileInput").change(
            function(){
                if ($(this).val()) {
                    $('input:submit').attr('disabled',false);
                }
            }
        );
    });