/// <reference path="../WCS/traffic/TrafficConfig.aspx" />
/// <reference path="../WCS/traffic/TrafficConfig.aspx" />
function InsertFavorate(s) {

    WsHome.InsertScrFavorate(s, onInsertFavorate, f_wserror);

}

function onInsertFavorate(result) {
    alert('收藏成功！');
    parent.frames[2].window.document.getElementById('LnkFavorate').style.display = "none";
    parent.frames[2].window.document.getElementById('LnkDeleteFavorate').style.display = "";
}
function DeleteFavorate(s) {
    parent.frames[0].window.WsHome.DeleteScrFavorate(s, onDeleteFavorate, f_wserror);
}

function onDeleteFavorate(result) {
    alert('取消收藏成功！');
    parent.frames[2].window.document.getElementById('LnkFavorate').style.display = "";
    parent.frames[2].window.document.getElementById('LnkDeleteFavorate').style.display = "none";
}


function ShowHomePage() {
    window.parent.document.getElementById("b").cols = "0,*";
    window.parent.document.getElementById("a").rows = "90,*";
    window.parent.document.getElementById("c").rows = "0,*";

    $("#homeLink").addClass("change");
    $("#appLink").removeClass("change");
    $("#conLink").removeClass("change");
    $("#msgLink").removeClass("change");
    $("#ctrlLink").removeClass("change");
    $("#trafficLink").removeClass("change");
    window.parent.window.frames[3].window.location.href = "../Public/Home.aspx";

}

function ShowFavorate() {
    window.parent.document.getElementById("b").cols = "0,*";
    window.parent.document.getElementById("a").rows = "90,*";
    window.parent.document.getElementById("c").rows = "0,*";
    $("#conLink").addClass("change");
    $("#appLink").removeClass("change");
    $("#homeLink").removeClass("change");
    $("#msgLink").removeClass("change");
    $("#ctrlLink").removeClass("change");
    $("#trafficLink").removeClass("change");
    window.parent.window.frames[3].window.location.href = "../WCS/Map/MapSetup.aspx";
}

function ShowTraffic() {
    window.parent.document.getElementById("b").cols = "0,*";
    window.parent.document.getElementById("a").rows = "90,*";
    window.parent.document.getElementById("c").rows = "0,*";
    $("#trafficLink").addClass("change");
    $("#conLink").removeClass("change");
    $("#appLink").removeClass("change");
    $("#homeLink").removeClass("change");
    $("#msgLink").removeClass("change");
    $("#ctrlLink").removeClass("change");
    window.parent.window.frames[3].window.location.href = "../WCS/traffic/TrafficConfig.aspx";
}

function ShowApplication() {


    var status = window.parent.window.frames[1].window.document.getElementById("HidStatus").value;

    window.parent.document.getElementById("a").rows = "95,*";
    window.parent.document.getElementById("c").rows = "*,0";
    
    if(status=="0")
        window.parent.document.getElementById("b").cols = "280,*";
    else
        window.parent.document.getElementById("b").cols = "16,*";

    $("#appLink").addClass("change");
    $("#homeLink").removeClass("change");
    $("#conLink").removeClass("change");
    $("#msgLink").removeClass("change");
    $("#ctrlLink").removeClass("change");
    $("#trafficLink").removeClass("change");
}

function ShowMessage() {
    window.parent.document.getElementById("b").cols = "0,*";
    window.parent.document.getElementById("a").rows = "90,*";
    window.parent.document.getElementById("c").rows = "0,*";
    $("#msgLink").addClass("change");
    $("#conLink").removeClass("change");
    $("#appLink").removeClass("change");
    $("#homeLink").removeClass("change");
    $("#ctrlLink").removeClass("change");
    $("#trafficLink").removeClass("change");

    window.parent.window.frames[3].window.location.href = "../Public/MessageList.aspx";
}


function MsgLinkClick() {
    $("#msgLink").addClass("change");
    $("#conLink").removeClass("change");
    $("#appLink").removeClass("change");
    $("#homeLink").removeClass("change");
    $("#ctrlLink").removeClass("change");
    $("#trafficLink").removeClass("change");
}

function ShowCtrl()
{
    window.parent.document.getElementById("b").cols = "0,*";
    window.parent.document.getElementById("a").rows = "90,*";
    window.parent.document.getElementById("c").rows = "0,*";
    $("#msgLink").removeClass("change");
    $("#conLink").removeClass("change");
    $("#appLink").removeClass("change");
    $("#homeLink").removeClass("change");
    $("#ctrlLink").addClass("change");
    $("#trafficLink").removeClass("change");

    window.parent.window.frames[3].window.location.href = "../WCS/Map/MapMain.aspx";
}


function f_wserror(error) {
    var stackTrace = error.get_stackTrace();
    var message = error.get_message();
    var statusCode = error.get_statusCode();
    var exceptionType = error.get_exceptionType();
    var timedout = error.get_timedOut();

    // Display the error.    
    var errmsg = "Service Error: " + message + "\n" +
        "Stack Trace: " + stackTrace + "\n" +
        "Status Code: " + statusCode + "\n" +
        "Exception Type: " + exceptionType + "\n" +
        "Timedout: " + timedout;

    alert(errmsg);
}


function LogOut() {
    window.parent.window.location.href = "Logout.aspx";
}
$(document).ready(function load() { ShowHomePage();});
       