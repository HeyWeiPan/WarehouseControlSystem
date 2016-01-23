  var s = 1; function  AutoClose(){ if(s==0){window.close();} s--;}
        
function setSelect(oTabId,bVal) {        
    var tabs = document.getElementsByTagName('TABLE');   
    for(var i=0;i<tabs.length;i++)
    {
        if(tabs[i].id.indexOf(oTabId) != -1)
        {
            var chks = tabs[i].getElementsByTagName('INPUT'); 
            for(var j=0;j<chks.length;j++){
                var obj = chks[j];
                if(obj.type.toLowerCase()=="checkbox" && obj.disabled==false)
                obj.checked=bVal;
            }
            break;
        }
    }
}
function getTabElement(oTabId){
    var tabs = document.getElementsByTagName('TABLE');   
    for(var i=0;i<tabs.length;i++){
        if(tabs[i].id.indexOf(oTabId) != -1){return tabs[i];}
    }
    return null;
}
function onSelect(){
    var returnArray = new Array();
    var selectCount = 0;
    var tab = getTabElement("GrdList");
    var trs = tab.rows;
    for(var i=1;i < trs.length;i++){
        var obj = new Object();
        var trRow = trs[i];
        var chk = trRow.cells[0].children[0];
        if(typeof(chk) == "undefined" || chk.type != 'checkbox' || chk.checked == false){continue;}
        obj.user_id = trRow.getAttribute('selectedRowID');
        returnArray[selectCount] = obj;
        selectCount ++;
    }
    if (selectCount==0){
        if (table.selectedRowID == ''){return false;}
        else{var obj = new Object();obj.user_id = tab.selectedRowID;returnArray[0] = obj;}                
    }
    window.returnValue=returnArray;window.close();
    return false;
}
