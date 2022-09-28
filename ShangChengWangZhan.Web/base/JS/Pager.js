function setPage(s, i) {
    return s + "page=" + i;
}
function pager(url, page, maxPage, total, per, countsIsVisible) {
    if (url.indexOf("?") == -1) {
        url += "?";
    }
    var first = "<img src=\"/base/images/default/grid/page-first.gif\" title=\"首页\"/>";
    var previous = "<img src=\"/base/images/default/grid/page-prev.gif\" title=\"前一页\"/>";
    var next = "<img src=\"/base/images/default/grid/page-next.gif\" title=\"下一页\" />";
    var last = "<img src=\"/base/images/default/grid/page-last.gif\" title=\"尾页\"/>";

    var first1 = "<img src=\"/base/images/default/grid/page-first-disabled.gif\" />";
    var previous1 = "<img src=\"/base/images/default/grid/page-prev-disabled.gif\" />";
    var next1 = "<img src=\"/base/images/default/grid/page-next-disabled.gif\" />";
    var last1 = "<img src=\"/base/images/default/grid/page-last-disabled.gif\" />";

    var s = "";
    if (countsIsVisible) {
        s += ("共:<span class='t2'>" + total + "</span>条记录  ");
    }
    if (page == 1) {
        s += (first1 + " " + previous1 + " <b>");
    }
    else {
        if (first1 != "") s += ("<a href='" + setPage(url, 1) + "'>" + first + "</a> ");
        s += ("<a href='" + setPage(url, (page - 1)) + "'>" + previous + "</a> <b>");
    }
    if (page == maxPage) {
        s += ("</b>" + next1 + " " + last1);
    }
    else {
        s += ("</b><a href='" + setPage(url, page + 1) + "'>" + next + "</a> ");
        if (last1 != "") s += ("<a href='" + setPage(url, maxPage) + "'>" + last + "</a>");
    }
    s += ("   页次：<span style='color:red'>" + page + "</span>/<span class='t2'>" + maxPage + "</span>   ");
    s += (per + "条信息/页");

    s += (" 转到：<select onchange='location=\"" + url + "page=\"+this.options[this.selectedIndex].value')>");
    for (var i = 1; i <= maxPage; i++) {
        s += ("<option value='" + i + "'")
        if (i == page) s += (" selected");
        s += (">第" + i + "页</option>");
    }
    s += ("</select>");
    return s;
}