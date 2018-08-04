$(document).ready(function () {
    $('#submitBtn').click(function () {
        var val = $('.mytext').val();
        detect(val);
    });

    function detect(val) {
        $.ajax({
            type: 'GET',
            url: 'DetectAsync',
            data: { text: val },
            cache: false,
            success: function (result) {
                if (result != null) {
                    $('.mytext').val('');
                    $('.mytext').attr('placeholder', result);
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