<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="Shopping.Web.Controls.Footer" %>
<div class="footer">
    <div class="w990 clr">
        <div class="ft">
            <div>
                本站支持以下浏览器：IE8.0、Firefox、Opera浏览器、Chrome浏览器  
            </div>
            <div>
                您的IP是：<%= Shopping.Common.Requests.GetIP() %>&nbsp;<a class="admin" href="/Manage/Login.aspx">管理员登录</a>
            </div>
        </div>
    </div>
</div>
<div style="display: none; background: #E9F2Fb; border: 1px solid #AACCEF; position: absolute;
    width: auto; line-height: 32px; padding: 10px; word-spacing: 1px;" id="shoppingcart">
</div>
