/* SVN.committedRevision=1575792 */
(function () {
    function d() {
        if (typeof (g_trackerAdJson) == "undefined" || !g_trackerAdJson.from_trackers) {
            return
        } var a = getQueryStringRegExp("tracker_u") || $.cookie("unionKey");
        if (!a || !loli.util.isExistArray(g_trackerAdJson.from_trackers, a)) {
            return
        }
        var c = isWidescreen ? g_trackerAdJson.unfoldWideImage : g_trackerAdJson.unfoldImage;
        var o = isWidescreen ? g_trackerAdJson.foldWideImage : g_trackerAdJson.foldImage;
        var p = $("#topCurtain"); var b = $("#topbanner"); if (p && p.length > 0) {
            p.find(".big_topbanner").attr("href", g_trackerAdJson.unfoldUrl).attr("data-tc", "index.0.top.1.1");
            p.find(".big_topbanner img").attr("src", c).attr("wideimg", g_trackerAdJson.unfoldWideImage).attr("shortimg", g_trackerAdJson.unfoldImage);
            p.find(".small_topbanner").attr("href", g_trackerAdJson.foldUrl).attr("data-tc", "index.0.top.1.2");
            var l = p.find(".small_topbanner3");
            if (l.length > 0) {
                var n = '<a style="display: none;" href="' + g_trackerAdJson.foldUrl + '" id="smallTopBanner" class="small_topbanner" target="_blank" data-tc="index.0.top.1.2"><img alt="" src="' + o + '"  wideimg="' + g_trackerAdJson.foldWideImage + '" shortimg="' + g_trackerAdJson.foldImage + '"></a>';
                l.remove();
                p.find(".big_topbanner").after(n)
            }
            else {
                p.find(".small_topbanner img").attr("src", o).attr("wideimg", g_trackerAdJson.foldWideImage).attr("shortimg", g_trackerAdJson.foldImage); p.show()
            }
        } else { if (b && b.length > 0) { b.remove(); var m = f(c, o); $("#global_top_bar").after(m) } else { var m = f(c, o); $("#global_top_bar").after(m) } }
    } function f(a, b) {
        return '<div id="topCurtain" style="display: block;" class="wrap index_topbanner" data-tpa="GROUPON_GLOBAL_TOP_LAMU_ADV"><a class="big_topbanner" target="_blank" href="' + g_trackerAdJson.unfoldUrl + '" data-tc="index.0.top.1.1"><img alt="" src="' + a + '" wideimg="' + g_trackerAdJson.unfoldWideImage + '" shortimg="' + g_trackerAdJson.unfoldImage + '"></a><a style="display: none;" href="' + g_trackerAdJson.foldUrl + '" id="smallTopBanner" class="small_topbanner" target="_blank" data-tc="index.0.top.1.2"><img alt="" src="' + b + '"  wideimg="' + g_trackerAdJson.foldWideImage + '" shortimg="' + g_trackerAdJson.foldImage + '"></a><span title="??????-??????" class="index_topbanner_fold index_topbanner_unfold">??????<s></s></span></div>'
    } d(); 
})();