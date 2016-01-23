function addMenu(){ShowDetail("ADD","");}
function editMenu(){ShowDetail("EDIT","");}
function viewMenu(){ShowDetail("VIEW","");}
function refreshParentNode(mode,type){    
    oCurrNode = f_getSelectedNode(TVOrg);
    if(oCurrNode.getParent() == null){refreshNode(oCurrNode);}else{ refreshNode(oCurrNode.getParent());}
}
function callBackRefreshNodeText(result){refreshNodeText(TVOrg,result);}  
function refreshNodeText(TVOrg,result){var oNode = f_getSelectedNode(TVOrg);var str = result;var text = f_getNodeText(oNode);oNode.setAttribute('text',str.replace(/\(\)/g,""));}

function refreshSelectedNode(){refreshNode(f_getSelectedNode(TVOrg));}
function refreshNode(oNode){
    if(!f_isRoot(oNode) && f_isLeaf(oNode)){oNode = oNode.getParent();}
    oNode.setAttribute("treeNodeSrc","TeamTreeGetChildNode.aspx?parentNodeID=" + f_getNodeID(oNode));oNode.databind();
}

function deleteMenu(){if(!CheckDelete()){return;}else{removeSelectedNode();} }
function removeSelectedNode(){var oCurrNode = f_getSelectedNode(TVOrg);var teamId = f_getNodeID(oCurrNode);WsHR.DeleteTeam(teamId,refreshRemoveNodes,f_wserror);}
function refreshRemoveNodes(result){if (result == 'true'){var oCurrNode = f_getSelectedNode(TVOrg);oCurrNode.remove();}else{alert(result);}    }

var iflag;
var oLdNode;
function copyMenu(){if(!checkCopy()){return;} var oCurrNode = f_getSelectedNode(TVOrg);if (f_isLeaf(oCurrNode)){iflag = -1;oLdNode = oCurrNode;}else{window.alert(notCopyOnlyLeaf);}  }
function cutMenu(){if(!checkCut()){return;}var oCurrNode = f_getSelectedNode(TVOrg);if (f_isRoot(oCurrNode)){window.alert(notCutParent);}else{iflag = 0;oLdNode = oCurrNode;}}
function pasteMenu(){
    if (iflag != -1 && iflag != 0){window.alert(pleaseCopyOrCut);}
    else{var oCurrNode = f_getSelectedNode(TVOrg);oPastNode = oCurrNode;                          
        if (iflag == 0){
            if (f_getNodeID(oPastNode) == f_getNodeID(oLdNode)){alert(notPasteSelf);iflag =1;return;}
            if (f_getNodeID(oPastNode) == f_getNodeID(oLdNode.getParent())){alert(notPasteParent);iflag =1;return;}
        }  
       sMsg = (iflag == 0)?cut:copy;sMsg += "\n";sMsg += "    " + getText(f_getNodeText(oLdNode));
       sMsg += "\n";sMsg += to + " ";sMsg += "\n";sMsg += "    " + getText(f_getNodeText(oPastNode)) + " ?";                                 
       if(!window.confirm(sMsg)){iflag =1;return;}pasterSeletedNode();
   }               
}
function getText(text){var first = text.indexOf(">");if (first < 0){return text;}else {var last = text.indexOf("</");return text.substr(first+1, last-first-1);}}
function pasterSeletedNode(){var oCurrNode = f_getSelectedNode(TVOrg);if (iflag == -1){copyNode(f_getNodeID(oLdNode),f_getNodeID(oPastNode));}else if(iflag == 0){cutNode(f_getNodeID(oLdNode),f_getNodeID(oPastNode));}}
function copyNode(fromId,toId){WsHR.CopyTeam(fromId,toId,onPasterNode,f_wserror);  }   
function cutNode(fromId,toId){WsHR.CutTeam(fromId,toId,onPasterNode,f_wserror);  }    
function onPasterNode(result){      
    if (result == 'true'){var oCurrNode = f_getSelectedNode(TVOrg);if (iflag == -1){refreshSelectedNode();}else if (iflag == 0){oLdNode.remove();refreshSelectedNode();}}
    else{alert(result);}iflag = 1;        
}   

function CheckDelete(){if(!CheckSelected()) {alert(pleaseSelectNode);return false;}if(!window.confirm(confirmDeleteNode)){return false;}return true;}
function CheckSelected(){if(TVOrg.selectedNodeIndex == ''){return false;} else {return true;}}
function checkCut(){if(!CheckSelected()) {alert(pleaseSelectNode);return false;}return true;}/*if(!window.confirm(confirmCutNode)){return false;}*/
function checkCopy(){if(!CheckSelected()) {alert(pleaseSelectNode);return false;}if(!window.confirm(confirmCopyNode)){return false;}return true;}

function getTeamGuid(oTv){if (oTv.selectedNodeIndex == null) return '';else return oTv.getTreeNode(oTv.selectedNodeIndex).getAttribute("team_guid");}
function getTeamTypeId(oTv){if (oTv.selectedNodeIndex == null) return '';else return oTv.getTreeNode(oTv.selectedNodeIndex).getAttribute("team_type_id");}