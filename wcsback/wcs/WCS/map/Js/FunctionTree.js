function refreshNode(oNode)
{
    if(f_isLeaf(oNode)){
        oNode = oNode.getParent();}
    oNode.setAttribute("treeNodeSrc", "QxTeamGetChildNodes.aspx?parentNodeID=" + f_getNodeID(oNode));
    oNode.databind();
}