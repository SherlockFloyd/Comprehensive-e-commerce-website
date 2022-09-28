<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Shopping.Web.Index" %>

<%@ Register Src="Controls/Header.ascx" TagName="Header" TagPrefix="Shopping" %>
<%@ Register Src="Controls/Footer.ascx" TagName="Footer" TagPrefix="Shopping" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>欢迎来到购物网站</title>
    <link href="CSS/Common.css" rel="stylesheet" type="text/css" />
    <link href="CSS/default.css" rel="stylesheet" type="text/css" />
    <script src="JS/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="JS/base.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <Shopping:Header ID="Header1" runat="server" />
    <div class="laybox banner_slider clearfix" id="firstScreen">
        <div id="promo_show" class="mod_promo_show" data-tpa="YHD_HOME_BAMBOO_SLIDER">
            <div class="promo_wrapper" id="index_menu_carousel" data-init="0" lunbobackgroudflag="1">
                <ol id="slider" class="clearfix">
                    <li style="background: #f9f9f9;" data-bgcolor="#00023d" flag="1" data-tpc="1"><a
                        class="big_pic global_loading" target="_blank" data-ajax="0" data-fee="" data-done=""
                        data-nsf="" data-tag="0">
                        <img id="lunbo_1" src="Images/blank.gif" si="/Images/ads/1.jpg" wi="/Images/ads/1.jpg"
                            data-advid="15069" data-ajax="0" data-done="" />
                    </a></li>
                    <li style="background: #f9f9f9; display: none;" data-bgcolor="#0b0e13" flag="2" data-tpc="2">
                        <a data-recordtracker="1" data-tc="ad.0.0.15070-32488158.1" class="big_pic global_loading"
                            target="_blank" data-ref="15070_32488158_1" data-advid="15070" data-ajax="1"
                            data-fee="" data-done="" data-nsf="" data-tag="0">
                            <img id="lunbo_2" src="/Images/blank.gif" si="/Images/ads/2.jpg" wi="/Images/ads/2.jpg"
                                data-advid="15070" data-ajax="1" data-done="" />
                        </a></li>
                    <li style="background: #f9f9f9; display: none;" data-bgcolor="#28167f" flag="3" data-tpc="3">
                        <a data-recordtracker="1" data-tc="ad.0.0.15071-32006713.1" class="big_pic global_loading"
                            target="_blank" data-ref="15071_32006713_1" data-advid="15071" data-ajax="1"
                            data-fee="" data-done="" data-nsf="" data-tag="0">
                            <img id="lunbo_3" src="/Images/blank.gif" si="/Images/ads/3.jpg" wi="/Images/ads/3.jpg"
                                data-advid="15071" data-ajax="1" data-done="" />
                        </a></li>
                    <li style="background: #f9f9f9; display: none;" data-bgcolor="#1ba8ed" flag="4" data-tpc="4">
                        <a data-recordtracker="1" data-tc="ad.0.0.15072-32338156.1" class="big_pic global_loading"
                            target="_blank" data-ref="15072_32338156_1" data-advid="15072" data-ajax="1"
                            data-fee="" data-done="" data-nsf="" data-tag="0">
                            <img id="lunbo_4" src="/Images/blank.gif" si="/Images/ads/4.jpg" wi="/Images/ads/4.jpg"
                                data-advid="15072" data-ajax="1" data-done="" />
                        </a></li>
                    <li style="background: #f9f9f9; display: none;" data-bgcolor="" flag="5" data-tpc="5">
                        <a data-recordtracker="1" data-tc="ad.0.0.15073-32006366.1" class="big_pic global_loading"
                            target="_blank" data-ref="15073_32006366_1" data-advid="15073" data-ajax="1"
                            data-fee="" data-done="" data-nsf="" data-tag="0">
                            <img id="lunbo_5" src="/Images/blank.gif" si="/Images/ads/5.jpg" wi="/Images/ads/5.jpg"
                                data-advid="15073" data-ajax="1" data-done="" />
                        </a></li>
                    <li style="background: #f9f9f9; display: none;" data-bgcolor="#060a13" flag="6" data-tpc="6">
                        <a data-recordtracker="1" data-tc="ad.0.0.15074-32415878.1" class="big_pic global_loading"
                            target="_blank" data-ref="15074_32415878_1" data-advid="15074" data-ajax="1"
                            data-fee="" data-done="" data-nsf="" data-tag="0">
                            <img id="lunbo_6" src="/Images/blank.gif" si="/Images/ads/6.jpg" wi="/Images/ads/6.jpg"
                                data-advid="15074" data-ajax="1" data-done="" />
                        </a></li>
                </ol>
            </div>
            <div class="mod_promonum_show">
                <ol class="clearfix" id="lunboNum" style="display: none;">
                    <li flag="1" href="javascript:void(0);"></li>
                    <li flag="2" href="javascript:void(0);"></li>
                    <li flag="3" href="javascript:void(0);"></li>
                    <li flag="4" href="javascript:void(0);"></li>
                    <li flag="5" href="javascript:void(0);"></li>
                    <li flag="6" href="javascript:void(0);"></li>
                </ol>
            </div>
            <a href="javascript:void(0);" class="show_next"><s></s></a><a href="javascript:void(0);"
                class="show_pre"><s></s></a>
        </div>
    </div>
    <div id="needLazyLoad">
        <div class="wrap mod_index_floor clearfix" id="floorSx" style="min-height: 414px">
            <div class="mod_floor_title shengxian">
                <div data-tpc="1">
                    <a class="bt" target="_blank">特价商品</a>
                </div>
            </div>
            <asp:Repeater ID="newRepeater" runat="server">
                <ItemTemplate>
                    <div class="e_con" data-tpc="8">
                        <a class="pic" target="_blank" href="<%# Eval("DetailUrl") %>">
                            <img width="200" height="180" original="<%# Eval("Photo") %>" src="/Images/blank.gif">
                            <h3>
                                <%# Eval("Name") %></h3>
                            <h4>
                                <%# Eval("Price") %></h4>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div class="wrap mod_index_floor clearfix" id="Div2" style="min-height: 414px">
        <div class="mod_floor_title shengxian">
            <div data-tpc="1">
                <a class="bt" target="_blank">新闻</a>
            </div>
        </div>
        <div class="news">
            <div class="newsboxbg">
                <div class="newsbox">
                    <div class="newsboxlist">
                        <ul>
                            <asp:Repeater ID="noticeRepeater" runat="server">
                                <ItemTemplate>
                                    <li><a href="NewsDetail.aspx?noticeid=<%# Eval("NoticeID") %>">
                                        <%# Eval("Title")%></a><b style="float: right">发布时间:<%# Eval("CreateTime", "{0:yyyy-MM-dd}")%></b></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="../js/global_index_top_new.js"></script>
    <script type="text/javascript" src="../js/index.js"></script>
    <Shopping:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
