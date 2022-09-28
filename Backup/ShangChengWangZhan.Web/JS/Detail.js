$(function () {
    //$.tabs("tab-nav", "tab-content", "click");

    makeTabs($(".tabview"), "click");

    $("#buyBtn").click(function () {
        $.get("ajax/Ajax_ShoppingCart.aspx?action=buy&Commodityid=" + $("#txtCommodityid").val() + "&t=" + new Date(), function (data) {
            var responseText = data.toString();
            if (responseText != "") {
                fAlert(responseText);
            }
            else {
                location = "ShoppingCart.aspx";
            }
        });
    });

    $("#addcartBtn").click(function () {
        $.get("ajax/Ajax_ShoppingCart.aspx?action=addCommoditytocart&Commodityid=" + $("#txtCommodityid").val() + "&t=" + new Date(), function (data) {
            var responseText = data.toString();
            if (responseText != "") {
                fAlert(responseText);
            }
            else {
                sAlert("成功添加到购物车!");
            }
        });

    });


    GetRateList();

    getconsultlist();


    $("#addfavBtn").click(function () {
        $.get("ajax/Ajax_Detail.aspx?action=addfav&Commodityid=" + $("#txtCommodityid").val() + "&t=" + new Date(), function (data) {
            var responseText = data.toString();
            if (responseText == "5") {
                sAlert("成功加入收藏!");
            }
            else if (responseText == "exist") {
                sAlert("您已成功收藏该商品!");
            }
            else {
                fAlert("操作失败!");
            }
        });
    });


    layer.tips('点击加入收藏!', '#addfavBtn', 0, 150, 0);
});

function fAlert(msg) {
    layer.alert(msg, 8);
}

function sAlert(msg) {
    $.layer({
        area: ['auto', 'auto'],
        title: '信息',
        dialog: { msg: msg, type: 1 }
    });
}


//初始化数字值
var PageIndex = 1;
var PageCount;
var PageSize = 10;




function SetInnerHtmlmo(msg) {
    var result = msg.split('●');
    var infoArry = result[0].split('*');
    PageCount = infoArry[0];
    var record = infoArry[1];
    if (parseInt(record) > 0) {
        $('#t_CommentList').html(decodeURI(result[1]));
        $(".pager1").pager({ pagenumber: PageIndex, pagecount: PageCount, buttonClickCallback: PageClick });
    }
    else {
        $('#t_CommentList').html("<p align='center'>没有任何评价内容!</p>");
    }
}

//分页事件
PageClick = function (pageclickednumber) {
    $(".pager1").pager({ pagenumber: pageclickednumber, pagecount: PageCount, buttonClickCallback: PageClick });
    PageIndex = pageclickednumber;

    GetRateList();
};
function GetRateList() {
    var param = "action=getrate&P=" + PageIndex + "&S=" + PageSize + "&Commodityid=" + $("#txtCommodityid").val();
    $.ajax({
        url: "Ajax/Ajax_Detail.aspx",
        data: param,
        ifModified: true,
        success: function (msg) { SetInnerHtmlmo(msg); }
    });
}

var pi1 = 1, pc1, ps1 = 10;

function SetInnerHtmlmo1(msg) {
    var result = msg.split('●');
    var infoArry = result[0].split('*');
    pc1 = infoArry[0];
    var record = infoArry[1];

    if (parseInt(record) > 0) {

        $('#t_ConsultList').html(decodeURI(result[1]));
        $(".pager2").pager({ pagenumber: pi1, pagecount: pc1, buttonClickCallback: PageClick1 });
    }
    else {
        $('#t_ConsultList').html("<p align='center'>没有任何咨询内容!</p>");
    }
}

//分页事件
PageClick1 = function (pageclickednumber) {
    $(".pager2").pager({ pagenumber: pageclickednumber, pagecount: pc1, buttonClickCallback: PageClick1 });
    pi1 = pageclickednumber;

    getconsultlist();
};
function getconsultlist() {
    var param = "&P=" + pi1 + "&S=" + ps1 + "&Commodityid=" + $("#txtCommodityid").val() + "&action=getconsult";
    $.ajax({
        url: "Ajax/Ajax_Detail.aspx",
        data: param,
        ifModified: true,
        success: function (msg) {
            SetInnerHtmlmo1(msg);
        }
    });
}