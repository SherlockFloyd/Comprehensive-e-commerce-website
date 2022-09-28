<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Shopping.Web.Controls.Header" %>
<div class="top">
    <div class="top-skin">
        <div class="top-skin-r">
            <asp:Literal ID="displayInfo" runat="server"></asp:Literal>&nbsp;&nbsp; <a href="/ShoppingCart.aspx"
                id="shoppingcartInfo" class="shoppingcart">购物车</a> | <a href="/member/Index.aspx"
                    class="userinfo">会员中心</a> | <a href="/member/OrderList.aspx">订单中心</a>
        </div>
    </div>
</div>
<style type="text/css">
    .tqyClass
    {
        padding-left: 210px;
    }
    .style1
    {
        font-size: 30pt;
        font-family: 宋体, Arial, Helvetica, sans-serif;
    }
    .style2
    {
        color: #990000;
    }
</style>
<link type="text/css" rel="stylesheet" href="../css/global_site_index_new.css" />
<link href="../CSS/Newcss.css" rel="stylesheet" type="text/css" />
<script src="../JS/common.js" type="text/javascript"></script>
<script type="text/javascript">
    var URLPrefix = {};
    var headerType = "base";
    var favorite = "";
    var hostUrl = "";
    var isIndex = 1;
    var indexFlag = 1;
    var currVersionNum = 1575792;
    var projectVersionNum = "1.0";
    var currDomain = "";
    var oppositeDomain = "";
    var lazyLoadImageObjArry = lazyLoadImageObjArry || [];
    var multiSearch = "true";
    var currProvinceId = 10;
    var isFixTopNav = true;
    var youFavorateICO = " ";
    var limitBuyCallFlag = 0;
    var globalShowMarketPrice = "0";
    var globalSearchSelectFlag = "1";
    var globalBaifendianFlag = "0";
    var globalSearchHotkeywordsFlag = "1";
    var globalTopPrismFlag = "1";
    var _globalSpmDataModelJson = {};
    var globalShowProWin = 1;
    var indexJbpPopFlag = "0";
    var indexFreshmanPopFlag = "0";
    var globalTpCheckFlag = "1";
</script>
<script type="text/javascript">
    var isWidescreen = screen.width >= 1280;
    if (isWidescreen) { document.getElementsByTagName("body")[0].className = "w1200"; }
    function recordCINTT() {
        var global = window["global"] || (window["global"] = {});
        var vars = global.vars = (global.vars || {});
        global.vars.customInteractTime = global.vars.customInteractTime || new Date().getTime();
    }
</script>
<div class="wrap hd_header clearfix hd_unify_logo" id="site_header">
    <div id="logo_areaID" class="hd_logo_area fl">
        <a class="style2">
            <span class="style1">购物商城</span></a>
    </div>


    <%--
    <div class="hd_head_search">
        <div class="hd_search_form clearfix">
            <div class="hd_serach_tab" id="hdSearchTab" data-type="1">
                <a href="javascript:;" data-type="1">商品</a> <i></i>
            </div>



            <div class="hd_search_wrap clearfix" data-tpa="YHD_GLOBAl_HEADER_SEARCH">
                <label for="keyword" style="display: none;">
                    请输入关键词</label>
                <input class="hd_input_test" name="keyword" id="keyword" type="text" original="请输入关键词"
                    url="" style="color: #333333;" maxlength="100" autocomplete="off" autofocus="true"
                    data-autofocus="true" x-webkit-speech="" onwebkitspeechchange="emptySearchBar();"
                    x-webkit-grammar="builtin:translate" runat="server" />
                <!--搜索提示 begin-->
                <button type="submit" class="hd_search_btn" id="hdSearchBtn" istrkcustom="1" runat="server"
                    onserverclick="serachBtn_Click">
                    搜 索</button>
            </div>



        </div>
    </div>

    ---%>

    <div class="hd_prism_wrap" id="hdPrismWrap">
        <div class="hd_prism hd_order" id="hdPrismOrder">
            <a href="/member/OrderList.aspx" class="hd_prism_tab"><em></em>
                <p>
                    订单查询</p>
                <i></i></a>
        </div>
        <div class="hd_mini_cart" id="miniCart">
            <i class="hd_c_arrow"></i><u class="hd_c_num none" id="in_cart_num"></u><a class="hd_prism_cart"
                href="/ShoppingCart.aspx"><em></em>购物车 </a>
        </div>
    </div>
</div>
<div class="newnav">
    <ul class="w1004">
        <li class="navSon"><a href="/Index.aspx" target="_self" title="网站首页">网站首页</a></li>
        <li class="navSon"><a href="/List.aspx" target="_self" title="商品列表">商品列表</a> </li>
        <li class="navSon"><a href="/NewsList.aspx" target="_self" title="新闻中心">新闻中心</a>
        </li>
        <li class="navSon"><a href="/NoticeList.aspx" target="_self" title="公告信息">公告信息</a></li>
        <li class="navSon"><a href="/Register.aspx" target="_self" title="会员注册">会员注册</a></li>
        <li class="navSon"><a href="/Login.aspx" target="_self" title="会员登录">会员登录</a></li>
    </ul>
</div>
