jQuery(document).ready(function () {
    jQuery('#form').change(function () {
        $("#cost").val(calculate());
    });
});



function order() {
    alertify.log("Пожалуйста, подождите.");
    var cimage = $("#image").val();
    var curl = $("#url").val();
    var chelp = $("#help").val();
    var cplace = document.getElementById("place").selectedIndex;
    var ctype = document.getElementById("type").selectedIndex;
    var coption = $("#option").val();
    if (curl == "") {
        alertify.error("Необходимо указать ссылку на проект!");
        var curPos = $(document).scrollTop();
        var scrollTime = curPos / 1.73;
        $("body,html").animate({ "scrollTop": 0 }, scrollTime);
        return;
    };
    if (cimage == "") {
        alertify.error("Необходимо указать ссылку к баннеру");
        var curPos = $(document).scrollTop();
        var scrollTime = curPos / 1.73;
        $("body,html").animate({ "scrollTop": 0 }, scrollTime);
        return;
    };
    if (curl.indexOf("http://") == -1) {
        curl = 'http://' + curl;
    };
    if (cimage.indexOf("http://") == -1) {
        cimage = 'http://' + cimage;
    };

    if ((cimage.indexOf(".jpg") == -1) && (cimage.indexOf(".png") == -1) && (cimage.indexOf(".gif") == -1)) {
        alertify.error("Ссылка на баннер должна заканчиваться на .jpg | .png | .gif");
        var curPos = $(document).scrollTop();
        var scrollTime = curPos / 1.73;
        $("body,html").animate({ "scrollTop": 0 }, scrollTime);
        return;
    };
    $.post("/Ad/Add", { Banner: cimage, Url: curl, Alt: chelp, Position: cplace, Goal: ctype, Value: coption }, function (data) {
        alertify.success(data);
        var curPos = $(document).scrollTop();
        var scrollTime = curPos / 1.73;
        $("body,html").animate({ "scrollTop": 0 }, scrollTime);
    });
}

function vip() {
    alertify.log("Пожалуйста, подождите.");
    var cproject = $("#project").val();
    var ctime = document.getElementById("time").selectedIndex;
    $.post("{=={$DOMAIN_URL}==}/index.php?mode=ad", { mode: 'buy', place: 'vip', project: cproject, time: ctime }, function (data) {
        alertify.success(data);
        var curPos = $(document).scrollTop();
        var scrollTime = curPos / 1.73;
        $("body,html").animate({ "scrollTop": 0 }, scrollTime);
    });
}

function mmm() {
    var cname = $("#mmm_proj").val();
    $.post("{=={$DOMAIN_URL}==}/index.php?mode=mmm", { name: cname }, function (data) {
        alertify.alert(data);
        var curPos = $(document).scrollTop();
        var scrollTime = curPos / 1.73;
        $("body,html").animate({ "scrollTop": 0 }, scrollTime);
    });
}