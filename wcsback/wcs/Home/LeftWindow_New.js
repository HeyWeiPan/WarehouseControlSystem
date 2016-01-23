var showName = "";
var treeHeight = 0;

function setBg(target, num) {
    target.css("background", "url(images/index_" + num + "_mid.gif)")
             .find(".Menu_Left").css("background", "url(images/index_" + num + "_left.gif)")
             .find(".Menu_Right").css("background", "url(images/index_" + num + "_right.gif)");
};

$(document).ready(function () {


    setBg($(".mMenu"), 25);
    $(".mMenu").mouseover(function () { setBg($(this), 26); })
                    .mouseout(function () { setBg($(this), 25); });

    SetTree("../CommonUI/WebForm/GetMenuTreeData.aspx", "treeMenu", true);
    show("menu");
    if ($.browser.msie && ($.browser.version == "6.0") && !$.support.style) {
        $(".ztree").css("margin-top", "-15px");
    }

});

function SetTree(url, id, open) {
    var Setting = GetSetting(url, open);
    Setting.callback.onClick = navigate;
    Setting.callback.onNodeCreated = nodeCreated;
    $.fn.zTree.init($("#" + id), Setting);
}

function show(name) {

    if (showName == name) return;
    $("#" + name + "Tree").show();
    if (showName != "") hide(showName);
    showName = name;
}
function hide(name) {
    $("#" + name + "Tree").hide();
}

function GetTree(treeId) {
    return $.fn.zTree.getZTreeObj(treeId);
};
function GetSetting(url, open) {
    var setting = {
        async: {
            enable: true, url: url
        },
        view: {
            showLine: true,
            showIcon: false,
            selectedMulti: false,
            dblClickExpand: false
        },
        data: {
            simpleData: {
                enable: true,
                idKey: "id",
                pIdKey: "pId",
                rootPId: 2900000
            }
        },
        callback: {
            onAsyncSuccess: function (event, treeId, treeNode, msg) {
                if (open) {
                    var treeObj = GetTree(treeId);
                    var nodes = treeObj.getNodes();
                    if (nodes.length > 0) {
                        treeObj.expandNode(nodes[0], true, false, false);
                    }
                }
            },
            onMouseUp: function (e, treeId, node) {
                GetTree(treeId).expandNode(node);
            }
        }
    };
    return setting;
}



function navigate(e, treeId, node) {
    var target = node.TARGET;
    if (target == "" || target == undefined || target == null) { target = "MainWindow"; }
    var url = "Navigate.aspx?FuncID=" + node.id;
    if (!node.isParent) {
        window.open(url, target);
    }
}

function nodeCreated(e, treeId, node) {
    if (node.name == "密码修改") {
        $("span:contains('密码修改')").css("font-weight", "bold");
    }
}




function resizeMenu() {
    //            if (tdMain.style.display == '') {
    //                tdMain.style.display = 'none';
    //                resizeIcon_Show.style.display = 'none';
    //                resizeIcon_Hidden.style.display = '';
    //                top.Bottom.cols = '8,*';
    //            }
    //            else {
    //                tdMain.style.display = '';
    //                resizeIcon_Show.style.display = '';
    //                resizeIcon_Hidden.style.display = 'none';
    //                top.Bottom.cols = '220,*';
    //            }

    var cols = window.parent.document.getElementById("b").cols;
    if (cols == "280,*") {

        window.parent.document.getElementById("b").cols = "16,*";
        document.getElementById("divShow").style.display = "none";
        document.getElementById("divHidden").style.display = "";
        document.getElementById("HidStatus").value = "-1";
        document.body.style.background = "";


    } else {
        window.parent.document.getElementById("b").cols = "280,*";
        document.getElementById("divShow").style.display = "";
        document.getElementById("divHidden").style.display = "none";
        document.getElementById("HidStatus").value = "0";
        document.body.style.background = "#f0f0f0 url(images/sidebar_bg.gif) repeat-y right top";
    }
}



function BtnMouse(s) {
    if (s == 1) {
        $("#BtnSearch").removeClass("btns").addClass("btn_hover");
    } else {
        $("#BtnSearch").removeClass("btn_hover").addClass("btns");
    }
}
function GetSearchFunction() {
    var a = SearchFunction(document.getElementById("txt").value);
    if (a == false) {
        alert("查询的菜单未找到或为父节点，请重新输入");
    }
    document.getElementById("txt").value = "";
}

function txt_keydown() {
    if (event.keyCode == 13) {
        GetSearchFunction();
        return false;
    }
    return true;
}

function ChangeTreeHeight() {

    document.getElementById("menuTree").style.height = (document.body.clientHeight - 40) + "px";
}

function sync(iFuncID) {

    var treeObj = GetTree("treeMenu");

    var node = treeObj.getNodeByParam("id", iFuncID, null)

    if (node != null) {
       
      
        treeObj.expandNode(node, true, true, false);
        treeObj.selectNode(node);
     
    }
}



function SearchFunction(iFuncName) {
    
    var treeObj = GetTree("treeMenu");
    var nodes = treeObj.getNodesByParamFuzzy("name", iFuncName);
    var node;
    if (nodes.length == 0 || nodes[0].isParent==true)
        return false;
    else {
        node = nodes[0];
        treeObj.expandNode(node, true, true, false);
        treeObj.selectNode(node);
        navigate(event, "treeMenu", node);
        return true;
    }

}

window.onresize = ChangeTreeHeight;

