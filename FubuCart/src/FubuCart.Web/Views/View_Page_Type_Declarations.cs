using FubuCart.Core.Web.Controllers;
using FubuCart.Core.Web.DisplayModels;
using FubuCart.Core.Web;

//Master Pages
public class SiteMasterView : FubuCartMasterPage{}


public class HomeIndexView : FubuCartPage<IndexViewModel> {}


public class ProductInfo : FubuCartUserControl<ProductDisplay> { }
