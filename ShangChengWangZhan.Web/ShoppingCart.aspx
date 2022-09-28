<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="Shopping.Web.ShoppingCart" %>

<%@ Register Src="Controls/Header.ascx" TagName="Header" TagPrefix="Shopping" %>
<%@ Register Src="Controls/Footer.ascx" TagName="Footer" TagPrefix="Shopping" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>购物车</title>
    <link href="CSS/Common.css" rel="stylesheet" type="text/css" />
    <script src="JS/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="JS/layer/layer.min.js" type="text/javascript"></script>
    <style type="text/css">
        .xubox_layer
        {
            padding-top: 18px;
            width: 80px !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <Shopping:Header ID="Header1" runat="server" />
    <div class="w990">
        <div class="flow clearfix">
            <div class="flow_steps">
                <ul>
                    <li class="current">1.我的购物车</li>
                    <li>2.确认订单详情</li>
                    <li class="last">3.成功提交订单</li>
                </ul>
            </div>
        </div>
        <table class="shoppingcartlist clearfix">
            <colgroup>
                <col width='90' />
                <col />
                <col />
                <col />
                <col />
                <col />
                <col width="48" />
            </colgroup>
            <tr>
                <th>
                    <input type="checkbox" checked="checked" name="Commodityids" id="selectAll" runat="server" />
                </th>
                <th>
                    图片
                </th>
                <th>
                    名称
                </th>
                <th>
                    价格
                </th>
                <th>
                    数量
                </th>
                <th>
                    合计
                </th>
                <th>
                    操作
                </th>
            </tr>
            <asp:Repeater ID="repeater" runat="server" OnItemDataBound="repeater_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td style="padding: 0 10px;">
                            <input name="ShoppingCartID" type="checkbox" <%# Shopping.Common.Utils.StrToInt(Eval("Stock"))<=0?"disabled=\"disabled\"":"" %>
                                type="checkbox" <%# Shopping.Common.Utils.StrToInt(Eval("Stock"))<=0?"":"checked=\"checked\"" %>
                                value='<%# Eval("ShoppingCartID") %>' />
                            <asp:Literal ID="stockTip" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <a href="Detail.aspx?commodityid=<%# Eval("CommodityID") %>" title="<%# Eval("Name") %>">
                                <img width="50" height="50" src='<%# Eval("Photo") %>' /></a>
                        </td>
                        <td>
                            <a href="Detail.aspx?commodityid=<%# Eval("CommodityID") %>" title="<%# Eval("Name") %>">
                                <%#Shopping.Common.Utils.CutString(Eval("Name").ToString(), 0, 10)%></a>
                        </td>
                        <td id="price_<%# Eval("ShoppingCartID") %>">
                            <%# Eval("Price") %>
                        </td>
                        <td>
                            <a href="javascript:shoppingcartminus('<%# Eval("ShoppingCartID") %>');">
                                <img src="Images/decrease.gif" /></a>
                            <input type="text" name="quantity" onblur='changeQuantity(<%# Eval("ShoppingCartID") %>)'
                                id="quantity_<%# Eval("ShoppingCartID") %>" value='<%# Eval("Quantity") %>' style="width: 50px;
                                text-align: center;" />
                            <a href="javascript:shoppingcartadd('<%# Eval("ShoppingCartID") %>');">
                                <img src="Images/increase.gif" /></a>
                        </td>
                        <td>
                            <i id="p_<%# Eval("ShoppingCartID") %>">
                                <%# Eval("TotalPrice") %></i>
                        </td>
                        <td align="center">
                            <a href="javascript:shoppingremove('<%# Eval("ShoppingCartID") %>');" title="从购物车移除商品">
                                <img src="/icons/cart_remove.gif" /></a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder ID="errorMsg" Visible="false" runat="server">
                <tr class="errorMsg">
                    <td colspan="7" align="center">
                        <img src="/icons/cart_error.gif" />
                        <span style="height: 30px; line-height: 30px;">您的购物车没有任何商品。<a href="List.aspx">去选择商品</a></span>
                    </td>
                </tr>
            </asp:PlaceHolder>
            <tfoot>
                <tr>
                    <td colspan="3" align="left">
                        &nbsp;&nbsp;&nbsp;&nbsp;<img src="images/delete.gif" />&nbsp;<a id="batchDeleteBtn"
                            class="batch-delete" href="javascript:;">删除选中的商品</a>
                    </td>
                    <td colspan="4" class="totalInfo">
                        共<em id="txtTotal"></em>件商品&nbsp;&nbsp;&nbsp;&nbsp;总价：￥<em id="totalprice"></em>
                        元&nbsp;&nbsp;
                    </td>
                </tr>
            </tfoot>
        </table>
        <div class="clearfix">
            <div class="tfoot ">
                <a href="list.aspx">
                    <img src="/icons/cart_add.gif" />继续购物</a>
                <asp:Button ID="subitBtn" CssClass="btn2" Text="立即结算" runat="server" OnClick="subitBtn_Click" />
            </div>
        </div>
    </div>
    <Shopping:Footer ID="Footer1" runat="server" />
    </form>
    <script type="text/javascript">



        function shoppingcartminus(shoppingcartid) {

            var quantity = parseInt($("#quantity_" + shoppingcartid).val());

            if (quantity - 1 <= 0) {
                alert("购买数量必须大于0.");
                return;
            }
            $.get("ajax/Ajax_ShoppingCart.aspx?action=minus&q=" + quantity + "&s=" + shoppingcartid + "&t=" + new Date(), function (data) {
                var responseText = data.toString();

                if (responseText != "") {
                    alert(responseText);
                }
                else {
                    calculateTotal();
                }
            });
        }

        function changeQuantity(shoppingcartid) {
            var quantity = parseInt($("#quantity_" + shoppingcartid).val());

            if (quantity <= 0) {
                alert("购买数量必须大于0.");
                $("#quantity_" + shoppingcartid).val("1");
                calculateTotal();
                return;
            }

            $.get("ajax/Ajax_ShoppingCart.aspx?action=changequantity&q=" + quantity + "&s=" + shoppingcartid + "&t=" + new Date(), function (data) {
                var responseText = data.toString();

                if (responseText != "") {
                    alert(responseText);
                    $("#quantity_" + shoppingcartid).val("1");
                    calculateTotal();
                }
                else {
                    calculateTotal();
                }
            });
        }

        function shoppingcartadd(shoppingcartid) {

            $.get("ajax/Ajax_ShoppingCart.aspx?action=add" + "&s=" + shoppingcartid + "&t=" + new Date(), function (data) {
                var responseText = data.toString();

                if (responseText != "") {
                    alert(responseText);
                } else {
                    calculateTotal();
                }
            });
        }

        function shoppingremove(shoppingcartid) {
            if (confirm('确认要从购物车移除此商品吗?')) {
                $.get("ajax/Ajax_ShoppingCart.aspx?action=remove" + "&s=" + shoppingcartid + "&t=" + new Date(), function (data) {
                    var responseText = data.toString();

                    if (responseText != "") {
                        alert(responseText);
                    } else {
                        location.reload();
                    }
                });
            }
        }

        $(function () {

            calculateTotal();

            $("#selectAll").click(function () {
                var flag = $(this).is(":checked");
                if (flag) {
                    $("input[name=ShoppingCartID]").attr("checked", "checked");
                }
                else {
                    $("input[name=ShoppingCartID]").removeAttr("checked");
                }
                calculateTotal();
            });

            $("#batchDeleteBtn").click(function () {
                var ShoppingCartID = $("input[name=ShoppingCartID]");
                var ids = "";

                $(ShoppingCartID).each(function (i) {
                    if ($(ShoppingCartID[i]).is(":checked")) {
                        ids += "," + $(ShoppingCartID[i]).val();
                    }
                });


                if (ids == "") {
                    alert("请选择要删除的商品!");
                    return false;
                }

                if (confirm('确认要从购物车移除选中的商品吗?')) {
                    $.get("ajax/Ajax_ShoppingCart.aspx?action=batch" + "&ids=" + ids + "&t=" + new Date(), function (data) {
                        var responseText = data.toString();

                        if (responseText != "") {
                            alert(responseText);
                        } else {
                            calculateTotal();

                        }
                    });

                }

                location.href = 'ShoppingCart.aspx';
            });

            $("#subitBtn").click(function () {
                var ShoppingCommodity = $("input[name=ShoppingCartID]");
                var total = 0;
                ShoppingCommodity.each(function () {
                    if ($(this).is(":checked")) {
                        total += 1;
                    }
                });

                if (total <= 0) {
                    alert("请选择要结算的商品!");
                    return false;
                }
            });

            $("input[name=ShoppingCartID]").bind("click", function () {
                calculateTotal();
            });

        });

        function calculateTotal() {

            var ShoppingCommodity = $("input[name=ShoppingCartID]");
            var realpay = 0;
            var total = 0;
            ShoppingCommodity.each(function (data) {

                var isChecked = $(this).is(":checked") ? 1 : 0;
                var shoppingcartId = $(this).val();

                var quantity = 0;
                var price = 0;
                var totalprice = 0;


                var param = "action=gettotalprice" + "&s=" + shoppingcartId + "&ischecked=" + isChecked;
                $.ajax({
                    url: "ajax/Ajax_ShoppingCart.aspx",
                    data: param,
                    dataType: "json",
                    cache: false,
                    async: false,
                    ifModified: true,
                    success: function (msg) {
                        quantity = parseFloat(msg[0].quantity);
                        price = parseFloat(msg[0].price);
                        totalprice = quantity * price;
                        realpay += totalprice;
                        total += quantity;

                        $("#quantity_" + shoppingcartId).val(quantity);
                        $("#p_" + shoppingcartId).html(totalprice.toFixed(2));
                    }
                });
            });
            $("#txtTotal").html(total);
            $("#totalprice").html(realpay.toFixed("2"));
        }
    </script>
    <script type="text/javascript">
        $("#allSortOuterbox").hide();
        $("#global_menu").addClass("tqyClass");
    </script>
</body>
</html>
