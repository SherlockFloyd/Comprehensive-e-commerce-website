$(function () {
    var webAddress = location.href;
    webAddress = webAddress.split("?")[0];
    webAddress = webAddress.split("/");
    webAddress = webAddress[webAddress.length - 1]
    webAddress = webAddress.split(".")[0];
    webAddress = webAddress.split("_")[0];
    $('.navSon').find("a").each(function () {
        var Address = $(this).attr('href');
        Address = Address.split("?")[0];
        Address = Address.split("/");
        Address = Address[Address.length - 1]
        Address = Address.split(".")[0];
        Address = Address.split("_")[0];
        if (webAddress == Address)
            $(this).parents(".navSon").addClass('hover1');
    });
    $('.navSon').each(function () {
        $(this).hover(
				function () {
				    $(this).addClass("hover");
				    $(this).find(".sub").show();
				},
				function () {
				    $(this).removeClass("hover");
				    $(this).find(".sub").hide();
				}
			);
    });
    $('#demo2p a').css("color", "#fff");
})
