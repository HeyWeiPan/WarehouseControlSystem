function showContextMenu(){    
    var index = event.treeNodeIndex;
    if(index != null && index !=''){	        
        var curNode = TVOrg.getTreeNode(index); TVOrg.selectedNodeIndex = curNode.getNodeIndex();	       
	    var left = window.event.screenX;var top = window.event.screenY;configMenu(curNode);mMain.invalidate();mMain.show( left, top );
    }event.returnValue = false;	 
}
function configMenu(curNode){         
    mMain.mView.disabled = f_isRoot(curNode) || f_isMore(curNode) ;  
    mMain.mAdd.disabled = f_isMore(curNode);        
    mMain.mEdit.disabled = f_isRoot(curNode)  || f_isMore(curNode);  
    mMain.mDelete.disabled = f_isRoot(curNode)|| f_isMore(curNode) || !f_isLeaf(curNode);   

    mMain.mRefresh.disabled =  f_isMore(curNode);
        
    if(pageAddRight.toLowerCase() == 'false'){mMain.mAdd.disabled = true;mMain.mCopy.disabled =true;mMain.mCut.disabled =true;mMain.mPaste.disabled=true;}
    if(pageEditRight.toLowerCase() == 'false'){mMain.mEdit.disabled = true;mMain.mCopy.disabled =true;mMain.mCut.disabled =true;mMain.mPaste.disabled=true;}
    if(pageDeleteRight.toLowerCase() =='false'){mMain.mDelete.disabled = true;}
    if(pageReadRight.toLowerCase() =='false'){mMain.mView.disabled=true;mMain.mAdd.disabled = true;mMain.mEdit.disabled = true;mMain.mCopy.disabled =true;mMain.mCut.disabled =true;mMain.mPaste.disabled=true;mMain.mRefresh.disabled=true;mMain.mDelete.disabled = true;}
}
//---------------------------------------------------------------------------------------------------
function addMenu(){ShowDetail("ADD","");}
function editMenu(){ShowDetail("EDIT","");}
function viewMenu(){ShowDetail("VIEW","");}
function refreshParentNode(mode,type){   
    oCurrNode = f_getSelectedNode(TVOrg);
    if (mode == "ADD" || mode == "VIEW"){if(oCurrNode.getParent() == null){refreshNode(oCurrNode);}else{ refreshNode(oCurrNode.getParent());}}
    else if(mode == "EDIT"){var geoId = f_getNodeID(oCurrNode);WsSetup.GetFileFolderName(geoId,callBackRefreshNodeText,f_wserror);}     
}
function callBackRefreshNodeText(result){refreshNodeText(TVOrg,result);}  
function refreshNodeText(TVOrg,result){var oNode = f_getSelectedNode(TVOrg);var str = result;var text = f_getNodeText(oNode);oNode.setAttribute('text',str.replace(/\(\)/g,""));}
//---------------------------------------------------------------------------------------------------
function refreshSelectedNode(){refreshNode(f_getSelectedNode(TVOrg));}
function refreshNode(oNode){
    if(!f_isRoot(oNode) && f_isLeaf(oNode)){oNode = oNode.getParent();}
    oNode.setAttribute("treeNodeSrc", "FileFolderGetChildNodes.aspx?parentNodeID=" + f_getNodeID(oNode)); oNode.databind();
}
//---------------------------------------------------------------------------------------------------
function deleteMenu(){if(!CheckDelete()){return;}else{removeSelectedNode();} }
function removeSelectedNode() { var oCurrNode = f_getSelectedNode(TVOrg); var folderId = f_getNodeID(oCurrNode); WsSetup.DeleteFileFolder(folderId, refreshRemoveNodes, f_wserror); }
function refreshRemoveNodes(result){if (result == 'true'){var oCurrNode = f_getSelectedNode(TVOrg);oCurrNode.remove();}else{alert(result);}    }
//---------------------------------------------------------------------------------------------------
var iflag;
var oLdNode;
function copyMenu(){if(!checkCopy()){return;} var oCurrNode = f_getSelectedNode(TVOrg);if (f_isLeaf(oCurrNode)){iflag = -1;oLdNode = oCurrNode;}else{window.alert(notCopyOnlyLeaf);}  }
function cutMenu(){if(!checkCut()){return;}var oCurrNode = f_getSelectedNode(TVOrg);if (f_isRoot(oCurrNode)){window.alert(notCutParent);}else{iflag = 0;oLdNode = oCurrNode;}}
function pasteMenu(){
    if (iflag != -1 && iflag != 0){window.alert(pleaseCopyOrCut);}
    else{var oCurrNode = f_getSelectedNode(TVOrg);oPastNode = oCurrNode;                          
        if (iflag == 0){
            if (f_getNodeID(oPastNode) == f_getNodeID(oLdNode)){alert(notPasteSelf);iflag =1;return;}//如果是copy,不做任何限制
            if (f_getNodeID(oPastNode) == f_getNodeID(oLdNode.getParent())){alert(notPasteParent);iflag =1;return;}//如果是cut,不能自已cut给自已,也不能向父节点cut
        }  
       sMsg = (iflag == 0)?cut:copy;sMsg += "\n";sMsg += "    " + getText(f_getNodeText(oLdNode));
       sMsg += "\n";sMsg += to;sMsg += "\n";sMsg += "    " + getText(f_getNodeText(oPastNode)) + " ?";                                 
       if(!window.confirm(sMsg)){iflag =1;return;}pasterSeletedNode();
   }               
}
function getText(text){var first = text.indexOf(">");if (first < 0){return text;}else {var last = text.indexOf("</");return text.substr(first+1, last-first-1);}}
function pasterSeletedNode(){var oCurrNode = f_getSelectedNode(TVOrg);if (iflag == -1){copyNode(f_getNodeID(oLdNode),f_getNodeID(oPastNode));}else if(iflag == 0){cutNode(f_getNodeID(oLdNode),f_getNodeID(oPastNode));}}
function copyNode(fromId,toId){WsSetup.CopyGeography(fromId,toId,onPasterNode,f_wserror);  }   
function cutNode(fromId,toId){WsSetup.CutGeography(fromId,toId,onPasterNode,f_wserror);  }    
function onPasterNode(result){      
    if (result == 'true'){var oCurrNode = f_getSelectedNode(TVOrg);if (iflag == -1){refreshSelectedNode();}else if (iflag == 0){oLdNode.remove();refreshSelectedNode();}}
    else{alert(result);}iflag = 1;        
}   
//---------------------------------------------------------------------------------------------------
function CheckDelete(){if(!CheckSelected()) {alert(pleaseSelectNode);return false;}if(!window.confirm(confirmDeleteNode)){return false;}return true;}
function CheckSelected(){if(TVOrg.selectedNodeIndex == ''){return false;} else {return true;}}function checkCut(){return true;}function checkCopy(){return true;}