<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommodityEdit.aspx.cs"
    Inherits="Shopping.Web.Manage.CommodityEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>商品信息</title>
    <link href="/base/Css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/zTreeStyle.css" rel="stylesheet" type="text/css" />
    <script src="/base/JS/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/base/JS/ligerui.min.js" type="text/javascript"></script>
    <script src="/base/JS/base.js" type="text/javascript"></script>
    <script charset="utf-8" src="/kindeditor/kindeditor.js"></script>
    <script language="javascript">
        KE.show({
            id: 'txtRemark',
            width: '680px',
            height: '500px',
            uploadpath: '/Images/Product/CommodityDetail/'
        });
    </script>
</head>
<body style="height: 100%">
    <form id="form1" runat="server" class="form-panel">
    <div class="grid-panel">
        <div class="grid-header" style="mozuserselect: none; khtmluserselect: none" unselectable="on">
            <img src="/icons/table.gif" />&nbsp;商品信息</div>
        <div>
            <div class="grid-container grid-wrap header-noborder">
                <fieldset>
                    <div id="add_cate">
                        <table class="edit-table">
                            <colgroup>
                                <col width="20%" />
                                <col width="250" />
                                <col />
                            </colgroup>
                            <colgroup>
                                <col width="10%" />
                                <col />
                            </colgroup>
                            <tr>
                                <td align="right">
                                    类别：<br />
                                </td>
                                <td>
                                    <select id="txtCateID" name="txtCateID" runat="server">
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    图片：
                                </td>
                                <td>
                                    <img name="txtPhoto" id="Img1" width="100" height="100" runat="server" />
                                    <input type="file" name="txtPhoto" id="txtPhoto" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    名称：
                                </td>
                                <td>
                                    <input type="text" class="w300" name="txtName" id="txtName" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    编号：
                                </td>
                                <td>
                                    <input type="text" name="txtCommodityNo" id="txtCommodityNo" runat="server" /><font
                                        color="red">自动生成</font>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    市场价：
                                </td>
                                <td>
                                    <input type="text" name="txtMarketPrice" id="txtMarketPrice" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    售价：
                                </td>
                                <td>
                                    <input type="text" name="txtPrice" id="txtPrice" runat="server" />
                                </td>
                            </tr>
                            


               
                            <tr>
                                <td align="right">
                                    库存：
                                </td>
                                <td>
                                    <input type="text" name="txtStock" id="txtStock" runat="server" />
                                </td>
                            </tr>



                            <tr>
                                <td align="right">
                                    简介：
                                </td>
                                <td>
                                    <input type="text" name="txtRemark" id="txtRemark" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="subitBtn" runat="server" OnClientClick="return checkInfo();" CssClass="btn2"
                                        Text="提交" OnClick="subitBtn_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
    <input type="hidden" runat="server" id="parentId" name="parentId" />
    </form>
    <script type="text/javascript">
        function checkInfo() {
            var name = $.trim($("#txtName").val());
            if (name == "") {
                alert("请输入类别名称!");
                $("#txtName").focus();
                return false;
            }
        }
    </script>
</body>
</html>
