$.tabs = function (nav, content, e) {
    var tabNav = $("." + nav);
    var tabContent = $("." + content);
    $(tabContent).find("div.tab_div").hide();
    $(tabNav).find("li:first").addClass("active").show();
    $(tabContent).children("div.tab_div").eq(0).show();
    $(tabNav).find("li").bind(e, function () {
        $(this).addClass("active").siblings("li").removeClass("active");
        var index = $(tabNav).find("li").index(this);
        $(tabContent).children().eq(index).show().siblings().hide();
    });
};


function makeTabs(obj, event) {
    var tabcontent = $(obj).find("div.tab-content").hide();

    $(obj).find("li:first").addClass("active").show();
    $(obj).find("div.tab-content:first").show();

    $(obj).find("li").bind(event, function () {
        var index = $(this).index();

        $(this).addClass("active").siblings("li").removeClass("active");

        $("div.tab-content").eq(index).show().siblings("div.tab-content").hide();
    });
}

$.extend({
    Onit_GetGrade: function (obj, hiddenobj) {

        var length = obj.length;
        var index = obj.length;

        $(obj).mouseover(function () {
            $._mouseover(obj, $(this).index());
        });
        $(obj).mouseout(function () {
            $._mouseout(obj, $(this).index());
            $._enter(obj, index);
        });
        $(obj).click(function () {
            index = $(this).index();
            $(hiddenobj).val(length - index);
        });
        $(hiddenobj).val(index);
    },
    _mouseover: function (obj, index) {
        for (var i = obj.length; i > index - 1; i--) {
            $(obj).eq(i).addClass("bg");
        }
    },
    _mouseout: function (obj, index) {
        for (var i = obj.length; i > index - 1; i--) {
            $(obj).eq(i).removeClass("bg");
        }
    },
    _enter: function (obj, index) {
        $(obj).removeClass("bg");
        for (var i = obj.length; i > index - 1; i--) {
            $(obj).eq(i).addClass("bg");
        }
    }
});    