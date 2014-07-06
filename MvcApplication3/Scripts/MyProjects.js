function edit_p(cid, num) {
    alertify.log("Пожалуйста, подождите");
    cname = $("#names" + num).val();
    cdescription = $("#description" + num).val();
    //sdescription = $("#s_description" + num).val();
    curl = $("#url" + num).val();
    //vk = $("#vk_url" + num).val();
    //video = $("#video_url" + num).val();
    //ssc1 = $("#screen1" + num).val();
    //ssc2 = $("#screen2" + num).val();
    //ssc3 = $("#screen3" + num).val();
    //ssc4 = $("#screen4" + num).val();
   // ts = $("#teamspeak" + num).val();
    // rk = $("#raidcall" + num).val();
    cbanner = $("#banner" + num).val();
    $.post("/Projects/Edit/", { id: cid, name: cname, description: cdescription, url: curl, banner:cbanner }, function (data) {
        alertify.log(data);
        var curPos = $(document).scrollTop();
        var scrollTime = curPos / 1.73;
        $("body,html").animate({ "scrollTop": 0 }, scrollTime);
    });    
}

function hide(cid, num) {
    alertify.log("Пожалуйста, подождите");
    $.post("/Projects/Hide", { id: cid }, function (data) {
        alertify.success(data);
        var curPos = $(document).scrollTop();
        var scrollTime = curPos / 1.73;
        $("body,html").animate({ "scrollTop": 0 }, scrollTime);
    });
}

function vote(cid, num) {
    alertify.log("Пожалуйста, подождите");
    clogin = $("#voter" + num).val();
    $.post("/Votes/Test", { login: clogin, id: cid }, function (data) {
        alertify.success(data);
        var curPos = $(document).scrollTop();
        var scrollTime = curPos / 1.73;
        $("body,html").animate({ "scrollTop": 0 }, scrollTime);
    });

}

function transfer(cid, num) {
    var nu = $("#new_owner" + num).val();
    $.post("/Projects/Transfer", { id: cid, new_owner: nu }, function (data) {
        alertify.alert(data);
        var curPos = $(document).scrollTop();
        var scrollTime = curPos / 1.73;
        $("body,html").animate({ "scrollTop": 0 }, scrollTime); });
}

function del(cid, num) {
    alertify.log("Пожалуйста, подождите");
    $.post("/Projects/Delete", { id: cid }, function (data) {
        alertify.success(data);
        var curPos = $(document).scrollTop();
        var scrollTime = curPos / 1.73;
        $("body,html").animate({ "scrollTop": 0 }, scrollTime);
    });

}

function newURL(cid, num) {
    alertify.log("Пожалуйста, подождите");
    curl = $("#api_url" + num).val();
    $.post("/Projects/NewUrl", { id: cid, url: curl }, function (data) {
        alertify.success(data);
        var curPos = $(document).scrollTop();
        var scrollTime = curPos / 1.73;
        $("body,html").animate({ "scrollTop": 0 }, scrollTime);
    });
    
}

function newKey(cid, num) {
    alertify.log("Пожалуйста, подождите");
    $.post("/Projects/NewApiHash", { id: cid }, function (data) {
        $("#api_key" + num).val(data);
    });
}