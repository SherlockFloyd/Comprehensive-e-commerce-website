(function ($) {
    window['Seral'] = {};

    //添加时判断
    Seral.AlertError = function (msg) {
        switch (msg) {
            case "0":
                $.ligerDialog.warn("已经存在相同的项了.");
                break;
            case "2":
                $.ligerDialog.error("添加失败");
                break;
            case "3":
                $.ligerDialog.error("你没有权限");
                break;
        }
    };
    /*
    点击按钮时跳转到指定的页面
    */
    Seral.LocationHerf = function (url, object) {
        $(function () {
            $("#" + object).click(function () {
                location.href = url;
            });
        });
    };
    /*
    警告[专用于判断表单是否为空]
    */
    Seral.Warning = function (message, object) {
        $.ligerDialog.alert(message, "格式错误", function (r) {
            if (r) {
                object.focus();
                return false;
            }
        });
    };
    /*
    删除提示
    */
    Seral.dell = function () {
        if (confirm('确认要删除吗?')) {
            return true;
        }
        return false;
    };
    /*
    是否数字格式
    */
    Seral.IsNum = function (s) {
        try {
            return /^\d+$/.test(s);
        } catch (e) {
            return false;
        }
    }
    Seral.IsEmail = function (email) {
        if (email.search(/[_a-zA-Z\d\-\.]+@[_a-zA-Z\d\-]+(\.[_a-zA-Z\d\-]+)+$/) != -1) {
            return true;
        } else {
            return false;
        }
    }
    Seral.IsHttp = function (s) {
        try {
            return /(http:\/\/)?([\w-]+\.)+[\w-]+(\/[\w-\.\/?%&=]*)?/.test(s);
        } catch (e) {
            return false;
        }
    },
    /*
    全选
    */
    Seral.SelectAll = function (object, attribute, attributevalue) {
        $("#" + object).click(function () {
            var objectvalue = $(this).is(":checked");
            if (objectvalue) {
                $("input[" + attribute + "=" + attributevalue + "]").attr("checked", true);
            } else {
                $("input[" + attribute + "=" + attributevalue + "]").attr("checked", false);
            }
        });
    };
    /*
    全选
    */
    Seral.SelectAll = function (object, namevalue) {
        $("#" + object).click(function () {
            var objectvalue = $(this).is(":checked");
            if (objectvalue) {
                $("input[name=" + namevalue + "]").attr("checked", true);
            }
            else {
                $("input[name=" + namevalue + "]").attr("checked", false);
            }
        });
    };
    Seral.Query = Query;
    Seral.QueryArray = QueryArray;
    Seral.QueryIndex = QueryIndex;
})(jQuery);

/*
获取QueryString的数组
*/
function QueryArray() {
    var result = location.search.match(new RegExp("[\?\&][^\?\&]+=[^\?\&]+", "g"));
    if (result == null) {
        return "";
    }
    for (var i = 0; i < result.length; i++) {
        result[i] = result[i].substring(1);
    }
    return result;
}
/* 
根据QueryString参数名称获取值
*/
function Query(name) {
    var result = location.search.match(new RegExp("[\?\&]" + name + "=([^\&]+)", "i"));
    if (result == null || result.length < 1) {
        return "";
    }
    return result[1];
}
/*
根据QueryString参数索引获取值
*/
function QueryIndex(index) {
    if (index == null) {
        return "";
    }
    var queryStringList = QueryArray();
    if (index >= queryStringList.length) {
        return "";
    }
    var result = queryStringList[index];
    var startIndex = result.indexOf("=") + 1;
    result = result.substring(startIndex);
    return result;
}
/*
加载列表JS
*/
$(function () {
    var result = $(".list-table>tbody>tr:last td").html();
    if (result == "") {
        $(".list-table>tbody>tr:last").remove();
    }
    var dd = $("input[xz=xx]");
    for (var i = 0; i < dd.length; i++) {
        var dd2 = $(dd[i]).is(":checked");
        if (dd2) {
            $(dd[i]).parent("td").parent("tr").addClass("list-row-selected");
        }
    }
    $("#selectall").click(function () {
        var result = $(this).is(":checked");
        if (result) {
            $("input[xz=xx]").attr("checked", true);
            $(".grid-wrap table tbody tr").addClass("list-row-selected");
        }
        else {
            $("input[xz=xx]").attr("checked", false);
            $(".grid-wrap table tbody tr").removeClass("list-row-selected");
        }
    });
    $(".list-table:eq(1) input[type=checkbox]:gt(0)").attr("xz", "xx");
    //$(".list-table:eq(1)").addClass("list-table");
    //$(".list-table:eq(1)").attr("rules", "all");
    $("input[xz=xx]").click(function () {
        var res = $(this).is(":checked");
        if (res) {
            $(this).parent("td").parent("tr").addClass("list-row-selected");
            $(this).attr("checked", false);
        } else {
            $(this).attr("checked", true);
        }
    });
    $(".grid-wrap .list-table tbody tr").click(function () {
        var thisresul = $(this).find("input[xz=xx]").is(":checked");
        if (!thisresul) {
            $(this).find("input[xz=xx]").attr("checked", true);
            $(this).addClass("list-row-selected");
        }
        else {
            $(this).find("input[xz=xx]").attr("checked", false);
        }
    });
    $(".list-table tbody tr").hover(function () {
        $(this).addClass("list-row-over");
    }, function () {
        var tr_check = $(this).find("input[xz=xx]").is(":checked");
        if (!tr_check) {
            $(this).removeClass("list-row-selected");
        }
        $(this).removeClass("list-row-over");
    });
});




