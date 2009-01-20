using System.Web.UI;
using FubuMVC.Core.View;

namespace FubuCart.Core.Web
{
    public class FubuCartUserControl<MODEL> : UserControl, IFubuCartPage, IFubuView<MODEL>
        where MODEL : class
    {
        public void SetModel(object model)
        {
            Model = (MODEL)model;
        }

        public object GetModel()
        {
            return Model;
        }

        public MODEL Model { get; set; }

        object IFubuCartPage.Model { get { return Model; } }
    }
}
