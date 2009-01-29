using System.Web.UI;

namespace FubuCart.Core.Web
{
    
    public class FubuCartMasterPage : MasterPage, IFubuCartPage
    {
        object IFubuCartPage.Model { get { return ((IFubuCartPage)Page).Model; } }

        public ViewModel Model { get { return ((IFubuCartPage)Page).Model as ViewModel; } }
        
        public void SetModel(object model)
        {
            throw new System.NotImplementedException();
        }
    }
}