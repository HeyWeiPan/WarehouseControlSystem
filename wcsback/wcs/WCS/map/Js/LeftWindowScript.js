//Show Menu
function window_onload() {
    show('QxTeam');
}

//Show Menu Div Or Favorite Div Or History Div
var showRowName = "QxTeam";
var divSelectedTab;
function show(tabName) {    
    if (divSelectedTab != null) {
        //ie 9 兼容
        divSelectedTab.style.height = 0;
    }
    TrQxTeamDiv.className = "TrHide";
    Tr95598TaskDiv.className = "TrHide";
    
    var height = tdMain.offsetHeight - tbMain.offsetHeight;
    if (height < 300) {
        height = 300;
    }
    var showRow;
    if (tabName == "QxTeam") {
        TrQxTeamDiv.className = "TrShow";
        showRow = TrQxTeamDiv;
        showRowName = "QxTeam";
    }
    else if (tabName == "95598Task") {
        Tr95598TaskDiv.className = "TrShow";
        showRow = Tr95598TaskDiv;
        showRowName = "95598Task";
    }
    showRow.height = height;
    divSelectedTab = showRow.cells(0).children(0).children(1);
    //divSelectedTab.style.height = height;
    divSelectedTab.style.height = height - showRow.cells(0).children(0).children(0).style.posHeight - showRow.cells(0).children(0).children(2).style.posHeight;    
}

//Menu,Favorite,History Mouse Over
function mouseover(tr) {
//    tr.cells(0).style.backgroundImage = "url(images/index_26_left.gif)";
//    tr.cells(1).style.backgroundImage = "url(images/index_26_mid.gif)";
//    tr.cells(2).style.backgroundImage = "url(images/index_26_mid.gif)";
//    tr.cells(3).style.backgroundImage = "url(images/index_26_right.gif)";
}
//Menu,Favorite,History Mouse out
function mouseout(tr) {
//    tr.cells(0).style.backgroundImage = "url(images/index_25_left.gif)";
//    tr.cells(1).style.backgroundImage = "url(images/index_25_mid.gif)";
//    tr.cells(2).style.backgroundImage = "url(images/index_25_mid.gif)";
//    tr.cells(3).style.backgroundImage = "url(images/index_25_right.gif)";
}

function LocationTr() {
    show(showRowName);
}

//function showroute(cmdid, whid, fromfloornum)
//{
//    window.parent.window.frames[2].window.showroute(cmdid);
//    alert(whid + fromfloornum);
//    //改变右下方块的内容，即调用MapWh.aspx文件，构建最大的仓库表格，具体表格分布是由仓库编号和楼层编号共同决定的，因为每个仓库每个楼层的格局不一样
//    window.parent.window.frames[2].window.location.href = "MapWh.aspx?WhId=" + whid + "&FloorNum=" + fromfloornum;
//}

//function DeleteCmd(a,whId,floorNum) {
//    WsSetup.DeleteCmd(a, deleteOK, f_wserror);

//    //WsSetup.GetAsrvList(whId, floorNum, SetAsrvList, f_wserror);//通过数据库提取相应仓库楼层的小车列表，均表示：如果执行成功则执行SetAsrvList函数内容，若执行出错则f_wserror报错
//}

//function deleteOK() {
//    window.location.href = window.location.href;
//}


function SetCurrentCMD(a)
{
    WsSetup.SetCurrentCMD(a, deleteOK, f_wserror);
}

