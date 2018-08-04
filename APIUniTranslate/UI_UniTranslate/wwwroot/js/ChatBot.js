$(document).ready(function () {
    $('.mytext').attr('placeholder', phGlobal);

    //Detection of the ENTER keypress
    $(".mytext").on("keypress", function (e) {
        if (e.which == 13) {
            var text = $(this).val();
            if (text !== "") {
                insertChat("me", text);
                var txtval = $(this).val();
                detect(txtval);
                chat(txtval);
                $(this).val('');
            }
        }
    });


});

var me = {};

var you = {};

function detect(val) {
    $.ajax({
        type: 'GET',
        url: 'DetectAsync',
        data: { text: val, lg: culture },
        cache: false,
        success: function (result) {
            if (result != null) {
                $('.mytext').val('');
                $('.mytext').attr('placeholder', result.text);
                culture = result.language;
            } else {
                console.log("ph is null !");
            }
        }
    });
}

function chat(val) {
    console.log(culture);
    $.ajax({
        type: 'GET',
        url: 'ChatAsync',
        data: { text: val, lang: culture },
        cache: false,
        success: function (result) {
            if (result != null && result != '') {
                insertChat("you", result);
            } else {
                console.log("Answer is null !");
            }
        }
    });
}

function formatAMPM(date) {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var ampm = hours >= 12 ? 'PM' : 'AM';
    hours = hours % 12;
    hours = hours ? hours : 12; // the hour '0' should be '12'
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var strTime = hours + ':' + minutes + ' ' + ampm;
    return strTime;
}



//Insert in Chat
function insertChat(who, text, time = 0) {
    var control = "";
    var date = formatAMPM(new Date());

    if (who == "me") {

        control = '<li style="width:100%">' +
            '<div class="msj-rta macro">' +
            '<div class="text text-r">' +
            '<p>' + text + '</p>' +
            '<p class=".text-small-r"><small>' + date + '</small></p>' +
            '</div>' +
            '</div>' +
            '</li>';
    } else {
        control = '<li style="width:100%;">' +
            '<div class="msj macro">' +
            '<div class="text text-l">' +
            '<p>' + text + '</p>' +
            '<p class=".text-small-l"><small>' + date + '</small></p>' +
            '</div>' +
            '</li>';
    }
    setTimeout(
        function () {
            $("ul").append(control);

        }, time);

}


function testChat() {
    //-- Clear Chat
    resetChat();

    //-- Print Messages
    insertChat("me", "Hello Tom...", 0);
    insertChat("you", "Hi, Pablo", 500);
    insertChat("me", "What would you like to talk about today?", 1000);
    insertChat("you", "Tell me a joke", 1500);
    insertChat("me", "Spaceman: Computer! Computer! Do we bring battery?!", 2000);
    insertChat("you", "LOL", 2500);
    insertChat("me", "MES COUILLES AU BORD DE L'EAU", 3000);
}

function resetChat() {
    $("ul").empty();
}