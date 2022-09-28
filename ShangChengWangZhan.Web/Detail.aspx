<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="Shopping.Web.Detail" %>

<%@ Register Src="Controls/Header.ascx" TagName="Header" TagPrefix="Shopping" %>
<%@ Register Src="Controls/Footer.ascx" TagName="Footer" TagPrefix="Shopping" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>商品详情</title>
    <link href="/CSS/Common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/Detail.css" rel="stylesheet" type="text/css" />
    <script src="JS/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/JS/base.js" type="text/javascript"></script>
    <script src="/JS/jquery.pager.js" type="text/javascript"></script>
    <script src="JS/Detail.js" type="text/javascript"></script>
    <script src="JS/layer/layer.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <Shopping:Header ID="Header1" runat="server" />
    <div class="w990 mt10 clearfix">
        <div class="navigation clearfix mb10">
            您的位置：<em>商品</em>><asp:Literal ID="txtCateNav" runat="server"></asp:Literal></div>
        <div class="detail clr">
            <div class="d-left clearfix">
                <div class="pic-box  clearfix">
                    <input type="hidden" runat="server" id="txtCommodityid" />
                    <img class="photo" id="txtPhoto" runat="server" />
                </div>
            </div>
            <div class="d-right ml30">
                <div class="summary">
                    <div class="summary_name">
                        <h1>
                            <asp:Literal ID="Commodityname" runat="server"></asp:Literal></h1>
                    </div>
                    <div class="summary-market-price">
                        定 价：<del>￥<asp:Literal ID="txtMarketPrice" runat="server"></asp:Literal></del>
                    </div>
                    <div class="summary-price">
                        单 价： <strong>￥<asp:Literal ID="price" runat="server"></asp:Literal></strong>
                    </div>
                    <div class="summary-author" style="display: none">
                        卖家：<em><asp:Literal ID="txtRealName" runat="server"></asp:Literal>
                        </em>
                    </div>


                    
                    <div class="summary-stock">
                        剩余库存：<em><asp:Literal ID="txtStock" runat="server"></asp:Literal></em><asp:Literal
                            ID="stockIntro" runat="server"></asp:Literal>
                    </div>



                    <div class="summary-rate clr">
                        <i>商品评分：</i><a class="t_star" href="javascript:;"><asp:Literal ID="txtGrade" runat="server"></asp:Literal></a><asp:Literal
                            ID="tGrade" runat="server"></asp:Literal>
                    </div>
                    <div class="summary-attention">
                        关注人数：共有 <em>
                            <asp:Literal ID="attentionCount" runat="server"></asp:Literal></em> 关注 <a class="summary-favorite"
                                href="javascript:;" id="addfavBtn">加入收藏</a>
                    </div>
                    <div class="btn-area">
                        <a href="javascript:;" id="buyBtn" class="buy">立即购买</a> <a href="javascript:;" id="addcartBtn"
                            class="addcart">加入购物车</a></div>
                </div>
            </div>
        </div>
        <div class="d-tuijian w990 mt10 clr" style="border: 1px solid #ddd;">
            <div class="hd" style="border-bottom: 1px solid #ddd;">
                <h3>
                    类似推荐</h3>
            </div>
            <ul class="dt-list">
                <asp:Repeater ID="repeater2" runat="server">
                    <ItemTemplate>
                        <li>
                            <div class="pic">
                                <a href="Detail.aspx?Commodityid=<%# Eval("CommodityID") %>" target="_blank" title="<%# Eval("Name") %>">
                                    <img width="140" height="140" src="<%# Eval("Photo") %>" alt="<%# Eval("Name") %>" /></a></div>
                            <div class="price">
                                <%# Eval("Price") %>元</div>
                            <div class="name">
                                <a href="Detail.aspx?Commodityid=<%# Eval("CommodityID") %>" title=" <%# Eval("Name") %>"
                                    target="_blank">
                                    <%# Eval("Name") %></a></div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="d-container clr mt10">
            <div class="d-container-left">
                <!-- 浏览相关 -->
                <div class="d-module y10">
                    <div class="hd">
                        <h3>
                            看过此商品的人还看过：</h3>
                    </div>
                    <div class="bd clr">
                        <ul class="l-list">
                            <asp:Repeater ID="repeater3" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <div class="pic">
                                            <a href="Detail.aspx?Commodityid=<%# Eval("CommodityID") %>" target="_blank" title="<%# Eval("Name") %>">
                                                <img width="140" height="140" src="<%# Eval("Photo") %>" alt="<%# Eval("Name") %>" /></a></div>
                                        <div class="price">
                                            <%# Eval("Price") %>元</div>
                                        <div class="name">
                                            <a title=" <%# Eval("Name") %>" href="Detail.aspx?Commodityid=<%# Eval("CommodityID") %>"
                                                target="_blank">
                                                <%# Eval("Name") %></a></div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <!-- /浏览相关 -->
                <!-- 最近浏览 -->
                <div id="browseMark" class="d-module y10 mt10">
                    <div class="hd">
                        <h3>
                            您最近浏览的商品：</h3>
                    </div>
                    <div class="bd clr">
                        <ul class="l-list">
                            <asp:Repeater ID="repeater1" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <div class="pic">
                                            <a href="Detail.aspx?Commodityid=<%# Eval("CommodityID") %>" target="_blank" title="<%# Eval("Name") %>">
                                                <img width="140" height="140" src="<%# Eval("Photo") %>" alt="<%# Eval("Name") %>" /></a></div>
                                        <div class="price">
                                            <%# Eval("Price") %>元</div>
                                        <div class="name">
                                            <a href="Detail.aspx?Commodityid=<%# Eval("CommodityID") %>" target="_blank">
                                                <%# Eval("Name") %></a></div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <!-- /最近浏览 -->
            </div>
            <div class="d-container-right">
                <div class="tabview">
                    <ul class="tab-nav clearfix">
                        <li class="first"><a href="javascript:;">商品简介</a></li>
                        <li><a href="javascript:;">评价留言</a></li>
                        <%--<li><a href="javascript:;">用户咨询</a></li>--%>
                    </ul>
                    <div class="tab-content">
                        <asp:Literal ID="txtRemark" runat="server"></asp:Literal>
                    </div>
                    <div class="tab-content mod-b">
                        <div class="hd">
                            <h2>
                                最新评价共 <em>(<asp:Literal ID="txtRateTotal" runat="server"></asp:Literal>) 条</em></h2>
                        </div>
                        <div id="t_TabCommentContent">
                            <div class="bd" style="padding: 15px;">
                                <div id="t_CommentList">
                                </div>
                                <div class="pagerbox clearfix">
                                    <div id="pager" class="pager1 pagination-box">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--<div class="tab-content mod-b clr">
                        <div class="hd">
                            <h2>
                                共咨询 <em>(<asp:Literal ID="Literal1" runat="server"></asp:Literal>) 条</em></h2>
                        </div>
                        <div class="bd" style="padding: 15px;">
                            <div id="t_ConsultList">
                            </div>
                            <div class="pagerbox clearfix">
                                <div id="pager1" class="pager2 pagination-box">
                                </div>
                            </div>
                        </div>
                        <div class="hd" style="border-top: 1px solid #ddd;">
                            <h2>
                                提交新的咨询内容</h2>
                        </div>
                        <div class="b-content">
                            <table style="background: #f7f7f7; width: 100%;">
                                <tr>
                                    <td>
                                        咨询内容:
                                    </td>
                                    <td>
                                        <textarea id="txtConsultContent" runat="server" style="width: 480px; height: 100px;"
                                            class="text"></textarea>
                                    </td>
                                    <td>
                                        <asp:Button ID="subitConsultContentBtn" Width="100" Height="100" runat="server" CssClass="btn3"
                                            Text="提交咨询" OnClick="subitConsultContentBtn_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>--%>
                </div>
            </div>
        </div>
    </div>
    <Shopping:Footer ID="Footer1" runat="server" />
    <script type="text/javascript">
        $("#allSortOuterbox").hide();
        $("#global_menu").addClass("tqyClass");
    </script>
    </form>
</body>
</html>
