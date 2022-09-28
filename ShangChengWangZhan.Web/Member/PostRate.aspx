<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostRate.aspx.cs" Inherits="Shopping.Web.Member.PostRate" %>

<%@ Register Src="/Controls/Header.ascx" TagName="Header" TagPrefix="Shopping" %>
<%@ Register Src="/Controls/Footer.ascx" TagName="Footer" TagPrefix="Shopping" %>
<%@ Register Src="Lefter.ascx" TagName="Lefter" TagPrefix="Shopping" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员中心</title>
    <link href="/CSS/Common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/member.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../JS/base.js" type="text/javascript"></script>
    <style type="text/css">
        .tb-3 a:link
        {
            color: #ce0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <!-- header end -->
    <div class="body-skin w990">
        <ul class="navigation clearfix mb10">
        </ul>
        <div class="body-main clearfix">
            <Shopping:Lefter ID="Lefter1" runat="server" />
            <div class="main">
                <div class="tabview mb10">
                    <ul class="tab-nav clearfix">
                        <li class="active"><a href="javascript:;">参与评价</a></li>
                    </ul>
                    <div class="tab-content">
                        <table class="tb">
                            <colgroup>
                                <col width="50" />
                                <col />
                                <col />
                                <col width="50" />
                                <col width="50" />
                                <col width="50" />
                            </colgroup>
                            <tr>
                                <th class="first">
                                    图片
                                </th>
                                <th>
                                      
                                </th>
                                <th>
                                    名称
                                </th>
                                <th>
                                    价格
                                </th>
                                <th>
                                    数量
                                </th>
                                <th>
                                    合计
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <img id="photo" runat="server" width="50" height="50" />
                                </td>
                                <td>
                                    <asp:Literal ID="ISBN" runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="Commodityname" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="Commodityprice" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="quantity" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="totalprice" runat="server"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                        <div class="b-rate">
                            <div class="b-title">
                                进行评价</div>
                            <table class="tb-4">
                                <colgroup>
                                </colgroup>
                                <tr>
                                    <td align="right">
                                        评分：
                                    </td>
                                    <td>
                                        <span class="rate"><a href="javascript:;"><span></span><span></span><span></span><span>
                                        </span><span></span></a>
                                            <input type="hidden" id="grade" name="grade" runat="server" />
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        内容：
                                    </td>
                                    <td>
                                        <textarea id="content" class="text" style="width: 600px; height: 100px;" runat="server"></textarea>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                    </td>
                                    <td>
                                        <asp:Button ID="subitBtn" OnClick="subitBtn_Click" OnClientClick="return  checkInfo();"
                                            runat="server" CssClass="btn2" Text="提交" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
    <script type="text/javascript">

        function checkInfo() {
            var content = $("#content");

            if (content.val() == "") {
                alert("请输入评价内容!");
                content.focus();
                return false;
            }

            var length = content.length;

            if (length > 140) {
                alert("评价内容限制在140里面!");
                content.focus();
                return false;
            }
        }

        $(function () {
            var span = $(".rate a span");
            $.Onit_GetGrade(span, $("#grade"));
        });
    </script>
    <script type="text/javascript">
        $("#allSortOuterbox").hide();
        $("#global_menu").addClass("tqyClass");
    </script>
</body>
</html>
