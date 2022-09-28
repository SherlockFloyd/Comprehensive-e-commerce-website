var tab = null;
var accordion = null;
var tree = null;
$.fn.Onit = function () {
    $(function () {
        //布局
        $("#layout1").ligerLayout({ InWindow: true, leftWidth: 180, topHeight: 25, height: '100%', onHeightChanged: f_heightChanged });
        var height = $(".l-layout-center").height();
        //Tab
        $("#framecenter").ligerTab({ height: height, dblClickToClose: true });
        //面板'
        $("#accordion1").ligerAccordion({ height: height - 24, speed: 'slow' });
        $(".l-link").hover(function () {
            $(this).addClass("l-link-over");
        }, function () {
            $(this).removeClass("l-link-over");
        });
        //树
        $(".l-scroll ul").ligerTree({
            checkbox: false,
            nodeWidth: 190,
            slide: true,
            attribute: ['nodename', 'url'],
            onSelect: function (node) {
                if (!node.data.url) return;
                var tabid = $(node.target).attr("tabid");
                if (!tabid) {
                    tabid = new Date().getTime();
                    $(node.target).attr("tabid", tabid);
                }
                f_addTab(tabid, node.data.text, node.data.url);
            }
        });
        tab = $("#framecenter").ligerGetTabManager();
        accordion = $("#accordion1").ligerGetAccordionManager();
        tree = $(".l-scroll ul").ligerGetTreeManager();
        $("#pageloading").hide();
    });
};
function f_heightChanged(options) {
    if (tab)
        tab.addHeight(options.diff);
    if (accordion && options.middleHeight - 24 > 0)
        accordion.setHeight(options.middleHeight - 24);
}
//增加选项卡
function f_addTab(tabid, text, url) {
    tab.addTabItem({ tabid: tabid, text: text, url: url });
};


