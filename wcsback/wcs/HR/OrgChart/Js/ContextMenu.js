var ContextMenu = new Object();

ContextMenu.ShowContextMenu = function()
{
    var index = event.treeNodeIndex;
    if(index != null && index !='')
    {	        
        var curNode = TVOrg.getTreeNode(index); 
        TVOrg.selectedNodeIndex = curNode.getNodeIndex();	       
        
	    var left = window.event.screenX;
	    var top = window.event.screenY;
	    
	    this._ConfigContextMenu(curNode);	  
	    
        //var anchor = document.getElementById(A1);
	    //anchor.href = "about:blank";
	    //anchor.target = "IfraSubWindow";	    	   
	    //anchor.click();
	    
	    mMain.invalidate();
	    mMain.show(left,top);
    }
    event.returnValue = false;	 
}
ContextMenu._ConfigContextMenu=function(curNode){         
    mMain.mView.disabled = f_isMore(curNode) ;  
    mMain.mAdd.disabled = f_isMore(curNode);        
    mMain.mEdit.disabled = f_isMore(curNode);  
    mMain.mDelete.disabled = f_isRoot(curNode)|| f_isMore(curNode);   
    //mMain.mCopy.disabled = f_isRoot(curNode) ||  f_isMore(curNode);
    mMain.mCut.disabled = f_isRoot(curNode)  ||  f_isMore(curNode);
    mMain.mPaste.disabled = f_isMore(curNode);
    mMain.mRefresh.disabled =  f_isMore(curNode);
        
    if(pageAddRight.toLowerCase() == 'false')
    {
        mMain.mAdd.disabled = true;
        //mMain.mCopy.disabled =true;
        mMain.mCut.disabled =true;
        mMain.mPaste.disabled=true;
    }
    if(pageEditRight.toLowerCase() == 'false')
    {
        mMain.mEdit.disabled = true;
        //mMain.mCopy.disabled =true;
        mMain.mCut.disabled =true;
        mMain.mPaste.disabled=true;
    }
    if(pageDeleteRight.toLowerCase() =='false'){mMain.mDelete.disabled = true;}
    
    if(pageReadRight.toLowerCase() =='false')
    {
        mMain.mView.disabled=true;
        mMain.mAdd.disabled = true;
        mMain.mEdit.disabled = true;
        //mMain.mCopy.disabled =true;
        mMain.mCut.disabled =true;
        mMain.mPaste.disabled=true;
        mMain.mRefresh.disabled=true;
        mMain.mDelete.disabled = true;
    }
}

