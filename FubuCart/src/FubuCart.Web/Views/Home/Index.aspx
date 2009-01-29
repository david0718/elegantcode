<%@ Page Inherits="HomeIndexView" MasterPageFile="~/Views/Shared/Site.Master"%>
<%@ Import Namespace="FubuMVC.Core.Html"%>
<%@ Import Namespace="FubuCart.Core.Domain"%>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="sections">
    <div class="primary">
         <%= this.RenderPartial().Using<ProductInfo>().ForEachOf(Model.Products) %>
    </div>
</div>
</asp:Content>
