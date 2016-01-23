<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcCalculator.ascx.cs"
    Inherits="Public_UcCalculator" %>
<style type="text/css">
    .style1
    {
        width: 26%;
    }
</style>
<script language="javascript" type="text/javascript">
// <![CDATA[

    function InputNumber(btn) {
        var txtResult = document.getElementById('TxtResult');
        txtResult.value += btn.value;
    }

    function InputSymbol(btn) {
        var txtResult = document.getElementById('TxtResult');
        txtResult.value += btn.value;

        txtResult.scrollTop = 100;
    }
    function Clear() {
        document.getElementById('TxtResult').value = '';
    }
    function ClearOne() {
        var txtResult = document.getElementById('TxtResult');
        var result = txtResult.value;
        var length = result.length;
        if (length != 0) {
            txtResult.value = result.substring(0, length - 1);
        }
    }
    function Equal() {       
        var txtResult = document.getElementById('TxtResult');
        var result = txtResult.value;

        var lastSymbol = '';
        var currentNum = '';
        var value = 0;

        for (var i = 0; i < result.length; i++) {
            if (result.charAt(i) == '+') {    //如果有连续的+,每次+时计算一次

                if (lastSymbol == '')
                    value = parseFloat(currentNum);
                else if (lastSymbol == '+')
                    value += parseFloat(currentNum);
                else if (lastSymbol == '-')
                    value -= parseFloat(currentNum);                         
                
                currentNum = '';
                lastSymbol = '+';
            }
            else if (result.charAt(i) == '-') { //如果有连续的-,每次-时计算一次  
                if (lastSymbol == '')
                    value = parseFloat(currentNum);
                else if (lastSymbol == '+')
                    value += parseFloat(currentNum);
                else if (lastSymbol == '-')
                    value -= parseFloat(currentNum); 

                currentNum = '';
                lastSymbol = '-';
            }
            else {
                currentNum += result.charAt(i).toString();              
            }
        }

        //计算最后一个
        if (lastSymbol == '+')
            value += parseFloat(currentNum);
        else if (lastSymbol == '-')
            value -= parseFloat(currentNum);

        //最后一个数字在最后统一计算
        txtResult.value = value;
    }

    function window_onkeydown() {
        if (event.keyCode >= 96 && event.keyCode <= 110) {
            var keyCode = '';
            keyCode = event.keyCode;
            window.setTimeout(function () {
                var btn = document.getElementById('Btn' + keyCode.toString());
                if (btn != null) {
                    btn.focus();
                    window.setTimeout(btn.click, 30);
                }
                else
                    alert('无效的快捷键');

            }, 30);
        }
        else if (event.keyCode == 187) { //=

            window.setTimeout(function () {
                var btn = document.getElementById('BtnEqual');
                if (btn != null) {
                    btn.focus();
                    window.setTimeout(btn.click, 30);
                }
                else
                    alert('无效的快捷键');

            }, 30);
        }
        else if (event.keyCode == 13) { //回车        
            window.returnValue = document.getElementById('TxtResult').value;
            window.close();
        }
    }

// ]]>
</script>
<table id="tableCalculator" style="table-layout: fixed; width: 250px; background-color: ActiveCaption;
    border: 1px solid black">
    <colgroup>
        <col width="1%" />
        <col width="24%" />
        <col width="25%" />
        <col width="25%" />
        <col width="25%" />
    </colgroup>
    <tr>
        <td colspan="5">
            <asp:TextBox ID="TxtResult" ClientIDMode="Static" Rows="3" runat="server" TextMode="MultiLine"
                ReadOnly="true" Width="99%" Style="text-align: right" />
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <input type="button" id="Btn103" value="7" style="width: 45px" onclick="return InputNumber(this)" />
        </td>
        <td>
            <input type="button" id="Btn104" value="8" style="width: 45px" onclick="return InputNumber(this)" />
        </td>
        <td>
            <input type="button" id="Btn105" value="9" style="width: 45px" onclick="return InputNumber(this)" />
        </td>
        <td class="style1">
            <input type="button" id="BtnC" value="C" style="width: 45px" onclick="return Clear()" />
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <input type="button" id="Btn100" value="4" style="width: 45px" onclick="return InputNumber(this)" />
        </td>
        <td>
            <input type="button" id="Btn101" value="5" style="width: 45px" onclick="return InputNumber(this)" />
        </td>
        <td>
            <input type="button" id="Btn102" value="6" style="width: 45px" onclick="return InputNumber(this)" />
        </td>
        <td class="style1">
            <input type="button" id="BtnBacks" value="<-" style="width: 45px" onclick="return ClearOne()" />
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <input type="button" id="Btn97" value="1" style="width: 45px" onclick="return InputNumber(this)" />
        </td>
        <td>
            <input type="button" id="Btn98" value="2" style="width: 45px" onclick="return InputNumber(this)" />
        </td>
        <td>
            <input type="button" id="Btn99" value="3" style="width: 45px" onclick="return InputNumber(this)" />
        </td>
        <td class="style1">
            <input type="button" id="Btn109" value="-" style="width: 45px" onclick="return InputSymbol(this)" />
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <input type="button" id="Btn96" value="0" style="width: 45px" onclick="return InputNumber(this)" />
        </td>
        <td>
            <input type="button" id="Btn110" value="." style="width: 45px" onclick="return InputNumber(this)" />
        </td>
        <td>
            <input type="button" id="BtnEqual" value="=" style="width: 45px" onclick="return Equal()" />
        </td>
        <td class="style1">
            <input type="button" id="Btn107" value="+" style="width: 45px" onclick="return InputSymbol(this)" />
        </td>
    </tr>
</table>
