function addMenu(){ShowDetail("ADD");}
function editMenu(){ShowDetail("EDIT");}
function viewMenu(){ShowDetail("VIEW");}

var iflag;
var oLdNode;

function DeleteFunction(functionId){ WSSecurity.DeleteFunction(functionId,userId, OnRemoveNode,f_wserror);}
function CopyFunction(fromId,toId){WSSecurity.CopyFunction(fromId,toId,userId,OnPasterNode,f_wserror);}   
function CutFunction(fromId,toId){ WSSecurity.CutFunction(fromId,toId,userId,OnPasterNode,f_wserror); } 

function removeSelectedNode(){
    var oCurrNode = f_getSelectedNode(TVOrg);   
    DeleteFunction(oCurrNode.getAttribute("NodeData"));
}
function pasterSeletedNode(){
    var oCurrNode = f_getSelectedNode(TVOrg);   
    if (iflag == -1){
        CopyFunction(oLdNode.getAttribute("NodeData"),oPastNode.getAttribute("NodeData"));}
    else if(iflag == 0){
        CutFunction(oLdNode.getAttribute("NodeData"),oPastNode.getAttribute("NodeData"));}  
}
function OnPasterNode(result){       
    if (result == 'true'){      
        var oCurrNode = f_getSelectedNode(TVOrg);
        if (iflag == -1){
             refreshSelectedNode();}
        else if (iflag == 0){
            refreshSelectedNode();   
            oLdNode.remove();       
            }} 
    else{
        alert(result);}     
    iflag = 1;    
}
function OnRemoveNode(result)
{    
    if (result == 'true'){                
        var oCurrNode = f_getSelectedNode(TVOrg);
        oCurrNode.remove();}              
    else{
         alert(result);
    }    
}
function showContextMenu(){	
    var index = event.treeNodeIndex;
    if(index != null && index !=''){	        
        var curNode = TVOrg.getTreeNode(index);                
	    TVOrg.selectedNodeIndex = curNode.getNodeIndex();
	    var left, top;	   
	    left = window.event.screenX;
	    top = window.event.screenY;
    	configMenu(curNode);
	    mMain.invalidate();
	    mMain.show( left, top );}		
	    event.returnValue = false;	 
}
function configMenu(curNode)
{     
    mMain.mView.disabled = f_isRoot(curNode) || f_isMore(curNode) ;  
    mMain.mAdd.disabled = f_isMore(curNode);        
    mMain.mEdit.disabled = f_isRoot(curNode)  || f_isMore(curNode);  
    mMain.mDelete.disabled = f_isRoot(curNode)|| f_isMore(curNode);   
    mMain.mCopy.disabled = f_isRoot(curNode) ||  f_isMore(curNode);
    mMain.mCut.disabled = f_isRoot(curNode)  ||  f_isMore(curNode);
    mMain.mPaste.disabled = f_isMore(curNode);
    mMain.mRefresh.disabled =  f_isMore(curNode);
        
    if(pageAddRight.toLowerCase() == 'false'){mMain.mAdd.disabled = true;mMain.mCopy.disabled =true;mMain.mCut.disabled =true;mMain.mPaste.disabled=true;}
    if(pageEditRight.toLowerCase() == 'false'){mMain.mEdit.disabled = true;mMain.mCopy.disabled =true;mMain.mCut.disabled =true;mMain.mPaste.disabled=true;}
    if(pageDeleteRight.toLowerCase() =='false'){mMain.mDelete.disabled = true;}
    if(pageReadRight.toLowerCase() =='false'){mMain.mView.disabled=true;mMain.mAdd.disabled = true;mMain.mEdit.disabled = true;mMain.mCopy.disabled =true;mMain.mCut.disabled =true;mMain.mPaste.disabled=true;mMain.mRefresh.disabled=true;mMain.mDelete.disabled = true;}        
}      
function copyMenu(){  
     var oCurrNode = f_getSelectedNode(TVOrg);
     if (f_isLeaf(oCurrNode)){
         iflag = -1;
        oLdNode = oCurrNode;}
     else{               
        window.alert("Only Leaf Can Copy");}  
}
function cutMenu()
{
     var oCurrNode = f_getSelectedNode(TVOrg);

     if (f_isRoot(oCurrNode)){
        window.alert("Parent Node Can not Cut!");}
     else{
       iflag = 0;
        oLdNode = oCurrNode; }             
}
function pasteMenu(){
    if (iflag != -1 && iflag != 0){
        window.alert("please copy or cut node first");}
    else{
        var oCurrNode = f_getSelectedNode(TVOrg);
        oPastNode = oCurrNode;  
        
        //如果是copy,不做任何限制
        //如果是cut,不能自已cut给自已,也不能向父节点cut
        if (iflag == 0){
            if (oPastNode.getAttribute("NodeData") == oLdNode.getAttribute("NodeData")){
                alert('Can not Paste Self!');
                iflag =1;
                return;
            }
            if (oPastNode.getAttribute("NodeData") == oLdNode.getParent().getAttribute("NodeData")){
                alert('Can not Paste To Parent!');
                iflag =1;
                return;
            }
        }                 
       
       sMsg = (iflag == 0)?"Move":"Copy"
       sMsg += "\n"
       sMsg += "      " + getText(oLdNode.getAttribute("text"));
       sMsg += "\n"
       sMsg += "To "
       sMsg += "\n"
       sMsg += "      " + getText(oPastNode.getAttribute("text")) + " ?"	            
       if(!window.confirm(sMsg)){
          iflag =1;
          return;}        		         
      pasterSeletedNode();}
               
}
function getText(text){
    var first = text.indexOf(">");
    if (first < 0)
        return text;
    else 
        var last = text.indexOf("</");
        return text.substr(first+1, last-first-1);
}
function getParentTeamID(oNode){
        if(!f_isRoot(oNode))
            return oNode.getParent().getAttribute("NodeData");
        else
            return -99;
}        
function deleteMenu(){
    if(!CheckDelete()){
        return;}
    else{
        removeSelectedNode();} 
}
function refreshSelectedNode()
{
    refreshNode(f_getSelectedNode(TVOrg));
}
function refreshNode(oNode)
{
    if(f_isLeaf(oNode)){
        oNode = oNode.getParent();}
    oNode.setAttribute("treeNodeSrc","FunctionDefinitionGetChildNodes.aspx?parentNodeID=" + f_getNodeID(oNode));
    oNode.databind();
}
function refreshParentNode(mode){     
    oCurrNode = f_getSelectedNode(TVOrg);
    if (mode == 'ADD'){            
        if(oCurrNode.getParent() == null){
            refreshNode(oCurrNode);}
        else{
            refreshNode(oCurrNode.getParent());}}
    else if (mode =="EDIT" || mode == "VIEW"){                  
        WSSecurity.GetFunctionName(oCurrNode.getAttribute("NodeData"), callBackRefreshNodeText,f_wserror);}
}

function callBackRefreshNodeText(result){
    var oNode = f_getSelectedNode(TVOrg);
    var str = result;
    var text = f_getNodeText(oNode);oNode.setAttribute('text',str.replace(/\(\)/g,""));
}