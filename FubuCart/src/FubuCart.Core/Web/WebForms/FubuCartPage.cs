using System.Web.UI;
using FubuMVC.Core.View;

namespace FubuCart.Core.Web
{
    public class FubuCartPage<MODEL> : Page, IFubuCartPage, IFubuView<MODEL>
        where MODEL : ViewModel
    {
        public void SetModel(object model)
        {
            Model = (MODEL)model;
        }

        public ViewModel GetModel()
        {
            return Model;
        }

        public MODEL Model { get; set; }

        object IFubuCartPage.Model { get { return Model; } }
    }
}