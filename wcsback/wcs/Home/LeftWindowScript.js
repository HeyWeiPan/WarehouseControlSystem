
/*
* Show Menu Div Or Favorite Div Or History Div
*
*/

//设置favorate页面是否已经绑定数据.避免重复取数据
var isTrvFavorateDataBind = false;

//Show Menu
function window_onload() {
    show('Menu');
}
//Add Function To FavMenu
function addtoFavMenu() {
    var oCurrNode = f_getSelectedNode(getTreeView());
    WsHome.InsertScrFavorate(oCurrNode.getAttribute("NodeData"), FavMenuAdded, f_wserror);
}
//Move Function From FavMenu
function movefromFavMenu() {
    var oCurrNode = f_getSelectedNode(getFavorateTreeview());
    WsHome.DeleteScrFavorate(oCurrNode.getAttribute("NodeData"), GetFavorateData, f_wserror);
}

function FavMenuAdded() {
    isTrvFavorateDataBind = false;
}

//Show Menu Div Or Favorite Div Or History Div
var divSelectedTab;
function show(tabName) {
    if (divSelectedTab != null) {
        //ie 9 兼容
        divSelectedTab.style.height = 0;
    }
    TrMenuDiv.className = "TrHide";
    TrFavoriteDiv.className = "TrHide";
    TrHistoryDiv.className = "TrHide";
    var height = tdMain.offsetHeight - tbMain.offsetHeight;
    if (height < 300) {
        height = 300;
    }
    var showRow;
    if (tabName == "Menu") {
        TrMenuDiv.className = "TrShow";
        showRow = TrMenuDiv;
    }
    else if (tabName == "Favorite") {
        TrFavoriteDiv.className = "TrShow";
        if (!isTrvFavorateDataBind) {
            GetFavorateData();
        }
        showRow = TrFavoriteDiv;
    }
    else if (tabName == "History") {
        TrHistoryDiv.className = "TrShow";
        GetHistoryData();
        showRow = TrHistoryDiv
    }
    showRow.height = height;
    divSelectedTab = showRow.cells(0).children(0);
    divSelectedTab.style.height = height;
}
//Menu,Favorite,History Mouse Over
function mouseover(tr) {
    tr.cells(0).style.backgroundImage = "url(images/index_26_left.gif)";
    tr.cells(1).style.backgroundImage = "url(images/index_26_mid.gif)";
    tr.cells(2).style.backgroundImage = "url(images/index_26_mid.gif)";
    tr.cells(3).style.backgroundImage = "url(images/index_26_right.gif)";
}
//Menu,Favorite,History Mouse out
function mouseout(tr) {
    tr.cells(0).style.backgroundImage = "url(images/index_25_left.gif)";
    tr.cells(1).style.backgroundImage = "url(images/index_25_mid.gif)";
    tr.cells(2).style.backgroundImage = "url(images/index_25_mid.gif)";
    tr.cells(3).style.backgroundImage = "url(images/index_25_right.gif)";
}
//Get History Div Data
function GetHistoryData() {
    TrvHistory.treeNodeSrc = "GetHistroyChildNodes.aspx";
    TrvHistory.databind();
}
//Get Favorate Div Data
function GetFavorateData() {
    isTrvFavorateDataBind = true;
    TrvFavorite.treeNodeSrc = "FavorateDefinitionGetChildNodes.aspx";
    TrvFavorite.databind();
}
//Show Context Menu
function showContextMenu() {
    var index = event.treeNodeIndex;
    if (index != null) {
        var tv = getTreeView();
        var treeNode = tv.getTreeNode(index);
        if (f_isLeaf(treeNode) == true) {
            f_showContextMenu(tv, treeNode, mLeft);
        }
    }
    event.returnValue = false;
}
//Show FavContext Menu
function showFavContextMenu() {
    var index = event.treeNodeIndex;
    if (index != null) {
        var tv = getFavorateTreeview();
        var treeNode = tv.getTreeNode(index);
        if (f_isLeaf(treeNode) == true) {
            f_showContextMenu(tv, treeNode, mFavorate);
        }
    }
    event.returnValue = false;
}

/*
* Menu And Page Synchronization
*
*/

//Menu And Page Synchronization



//Navigate Node
function navigateNode(el) {
    var url = el.getAttribute("NavigateUrl");
    if (url != null && url != "") {
        var target = el.getAttribute("Target");
        if (target == null) {
            target = "MainWindow";
        }
        //window.open(url, target);
        var anchor = document.createElement("<A>");
        anchor.target = target;
        anchor.href = url;
        document.body.insertBefore(anchor);
        anchor.click();
        document.body.removeChild(anchor);
    }
}
//Expand
function expand(oNode) {
    if (oNode.getParent() != null) {
        expand(oNode.getParent());
    }
    oNode.setAttribute("expanded", true);
}

function getTreeView() { return TrvMenu; }

function getFavorateTreeview() { return TrvFavorite; }