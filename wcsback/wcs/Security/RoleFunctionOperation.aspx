<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleFunctionOperation.aspx.cs"
    Inherits="Security_RoleFunctionOperation" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>

    <script src="../CommonUI/js/XMLHttpRequestPool.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
 // <!CDATA[        
        function removeSelectedNode()
        {
            var oCurrNode = f_getSelectedNode(getTreeView());  
            WSSecurity.DeleteRoleFunction(oCurrNode.getAttribute("NodeData"),document.all('hRoleID').value,userId, removeNode,f_wserror);          
        }        
        function removeNode(result)
        {        
            var t = result;      
            if (t == 'true'){            
               var oCurrNode = f_getSelectedNode(getTreeView());
               oCurrNode.remove();}     
            else{
                alert(t);}        
        }        
        function deleteMenu()
        {            
            if(!CheckDelete()){
                return;}
            else{
                var oCurrNode = f_getSelectedNode(getTreeView());
                if(f_isLeaf(oCurrNode)){
                    removeSelectedNode();}
               else{alert('Can not delete')}} 
        }        
        function addMenu()
        {
            ShowDetail("ADD");
        }
        function editMenu()
        {
            ShowDetail("EDIT")
        }
        function getTreeView()
        {
            return <%=Trv1.ClientID%>;
        }        
        function refreshParentNode()
        {
            var oCurrNode = f_getSelectedNode(getTreeView());
            if(f_isRoot(oCurrNode)){
                refreshNode(oCurrNode);}
            else{
                refreshNode(oCurrNode.getParent());}    
        }
        function refreshSelectedNode()
        {
            refreshNode(f_getSelectedNode(getTreeView()));
        }
        function refreshNode(oNode)
        {
            var tree=getTreeView();
            tree.treeNodeSrc='RoleFunctionOperationGetTreeNodes.aspx?RoleID='+document.all('hRoleID').value +'&parentNodeID=0';
            tree.databind();
        }        
        function showContextMenu() 
        {	
	        var index = event.treeNodeIndex;        	
	        if(index != null){
	            var tv = getTreeView();
		        var treeNode = tv.getTreeNode(index);   
		        if(pageAddRight == 'False'){mMain.mAdd.disabled = true;}
                if(pageEditRight == 'False'){mMain.mEdit.disabled = true;}
                if(pageDeleteRight =='False'){mMain.mDelete.disabled = true;}
		        f_showContextMenu( tv,treeNode,mMain) ;}        	
	        event.returnValue=false;
        }           
// ]]>
    </script>

</head>
<body style="margin: 0px;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="WSSecurity.asmx" />
            </Services>
        </asp:ScriptManager>
        <table style="width: 95%;">
            <tr>
                <td>
                    <cc1:UcButton ID="BtnTreeAdd" runat="server" ColumnName="add" Width="80px" />
                    <cc1:UcButton ID="BtnTreeEdit" runat="server" ColumnName="Edit" Width="80px" />
                    <cc1:UcButton ID="BtnTreeDelete" runat="server" ColumnName="Delete" Width="80px" />
                    <cc1:UcButton ID="BtnTreeRefresh" runat="server" ColumnName="Refresh" Width="80px" />
                </td>
            </tr>
            <tr>
                <td>
                    <div style="overflow: auto; width: 868px; height: 400px">
                        <cc1:UcTreeView ID="Trv1" runat="server" OnContextMenuClientScript="showContextMenu();"
                            ExpandLevel="1" /></div>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="hRoleID" runat="server" type="hidden" style="width: 1px" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
