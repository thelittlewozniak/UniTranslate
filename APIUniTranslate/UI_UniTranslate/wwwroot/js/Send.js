$(document).ready(function () {
    var cpt = 0;

    $('#submitBtn').click(function () {
        var val = $('#textVal').val();
        if (cpt == 0) {
            detect(val);
        }
    });

    function detect(val) {
        $.ajax({
            type: 'GET',
            url: 'DetectAsync',
            data: { text: val },
            cache: false,
            success: function (result) {
                if (result != null) {
                    $('#textVal').val('');
                    $('#textVal').attr('placeholder', result);
                } else {
                    alert("ph is null !")
                }
            }
        });
    }

    function chat(lg) {
        $.ajax({
            type: 'GET',
            url: 'ChatAsync',
            data: { lang: lg },
            cache: false,
            success: function (result) {
                if (result != null) {
                    // Put message
                } else {
                    alert("Answer is null !")
                }
            }
        });
    }
});