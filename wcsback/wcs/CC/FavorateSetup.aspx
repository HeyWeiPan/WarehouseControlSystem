<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FavorateSetup.aspx.cs" Inherits="CC_FavorateSetup" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="Images/ext/resources/css/ext-all.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Images/Ext/adapter/ext/ext-base.js"></script>
    <script type="text/javascript" src="Images/ext/ext-all.js"></script>
    <script type="text/javascript">





        Ext.onReady(function () {




            var Tree = Ext.tree;


            var tree = new Tree.TreePanel({
                el: 'west_content',
                useArrows: true,
                autoHeight: true,
                split: true,
                lines: true, //是否显示树线
                autoScroll: true,
                width: 420,
                animate: true, //以动画形式伸展,收缩子节点
                enableDD: true,
                border: false,
                containerScroll: true, //是否将树型面板注册到滚动管理器ScrollManager
                loader: new Tree.TreeLoader({ //loader树的加载器
                    //dataUrl: 'ext_tree_json.aspx' //生成 ext 2.0 所需要的树型格式
                    dataUrl: 'ext.aspx' //获取子节点的URL
                })
            });

            var root = new Tree.AsyncTreeNode({
                text: '菜单',
                draggable: false,
                icon: 'Images/Ext/icons/folder.gif',
                id: '0' // 0 为根目录
            });

            tree.on('dblclick', function (node) {
                if (node.isLeaf()) {
                    InsertItem(node.id, node.text);
                }
            });
            //设置根根节点
            tree.setRootNode(root);
            // render the tree

            tree.render();

            //            setTimeout(function () {
            //            }, 250)
        });

        function InsertItem(id, text)//选择源全部插入到目标
        {
            var listBox = document.getElementById('LB');
            var length = listBox.options.length;

            if (length == 0) {
                listBox.options[0] = new Option(text, id, true, true);

            }
            else {
                for (var i = 0; i < length; i++) {
                    var v = listBox.options[i].value;
                    if (v == id) {
                        alert("您选择的菜单已存在！"); return;
                    }

                }
                listBox.options[length] = new Option(text, id, true, true);
                listBox.selectedIndex = length;
            }
        }

        function DeleteAll()//删除全部
        {
            var listBox = document.getElementById('LB');
            var length = listBox.options.length;
            for (var i = length; i > 0; i--) {
                listBox.options[i - 1].parentNode.removeChild(listBox.options[i - 1]);
            }
        }

        function DeleteSelected()//删除获得焦点的项目
        {
            var listBox = document.getElementById('LB');
            var lstindex = listBox.selectedIndex;
            if (lstindex >= 0) {
                listBox.options[lstindex].parentNode.removeChild(listBox.options[lstindex]);
            }
        }

        function ItemUp() {
            var listBox = document.getElementById('LB');
            var lstindex = listBox.selectedIndex;
            if (lstindex >= 1) {
                var upId = listBox.options[lstindex - 1].value;
                var upName = listBox.options[lstindex - 1].text;
                listBox.options[lstindex - 1].value = listBox.options[lstindex].value
                listBox.options[lstindex - 1].text = listBox.options[lstindex].text
                listBox.options[lstindex].value = upId;
                listBox.options[lstindex].text = upName;
                listBox.selectedIndex = lstindex - 1;
            }
        }

        function ItemDown() {
            var listBox = document.getElementById('LB');
            var lstindex = listBox.selectedIndex;
            var length = listBox.options.length;
            if (length > 1 && lstindex < length - 1) {
                var downId = listBox.options[lstindex + 1].value;
                var downName = listBox.options[lstindex + 1].text;
                listBox.options[lstindex + 1].value = listBox.options[lstindex].value
                listBox.options[lstindex + 1].text = listBox.options[lstindex].text
                listBox.options[lstindex].value = downId;
                listBox.options[lstindex].text = downName;
                listBox.selectedIndex = lstindex + 1;
            }
        }

        function SetXmlValue() {
            var xmlStr = "<NewDataSet>";
            var listBox = document.getElementById('LB');
            var hidXml = document.getElementById('HidXml');

            var length = listBox.options.length;
            for (var i = 0; i < length; i++) {
                xmlStr += "<Table1>";

                xmlStr += "<functionId>" + f_toxmlstr(listBox.options[i].value) + "</functionId>";
                xmlStr += "<showOrder>" + i + "</showOrder>";
                xmlStr += "</Table1>";
            }
            xmlStr += "</NewDataSet>";

            hidXml.value = escape(xmlStr);


        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <base target="_self" />
    <div style="width: 100%; text-align: center; display: block;">
        <p style="font-weight: bold; font-size: 18pt;  font-family: 宋体;margin-top:10px;">
            我的收藏设置</p>
            <br />
        <table>
            <tr>
                <td valign="top">
                    <div id="west_content" style="height: 485px; overflow-y: auto; overflow-x: hidden;background-color: White; border: 1px solid black;">
                    </div>
                    <p style="margin-top:5px;">请双击菜单添加收藏</p>
                </td>
                <td valign="top">
                    <p>
                        <cc1:UcListBox ID="LB" runat="server" Width="420px" Height="500px" IsInsertItem="false"
                            SelectionMode="Multiple" InsertedItemText="All" InsertedItemValue="All" ClientIDMode="Static">
                        </cc1:UcListBox>
                    </p>
                    <p>
                        <asp:Button ID="BtnDeleteAll" runat="server" Width="80px" Text="全部删除" OnClientClick="DeleteAll();return false;" />
                        <asp:Button ID="BtnDelete" runat="server" Width="80px" Text="删除" OnClientClick="DeleteSelected();return false;" />
                        <asp:Button ID="BtnUp" runat="server" Width="80px" Text="上移" OnClientClick="ItemUp();return false;" />
                        <asp:Button ID="BtnDown" runat="server" Width="80px" Text="下移" OnClientClick="ItemDown();return false;" />
                        <asp:Button ID="BtnSave" runat="server" Width="80px" Text="保存" OnClientClick="SetXmlValue();"
                            OnClick="BtnSave_Click" />
                    </p>
                </td>
            </tr>
        </table>
    </div>
    <cc1:UcHiddenField ID="HidXml" runat="server" RenderToClient="true" ClientIDMode="Static" />
    </form>
</body>
</html>
