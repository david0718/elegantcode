using FubuMVC.Core.View;

namespace FubuCart.Core.Web
{
    public interface IFubuCartPage : IFubuViewWithModel
    {
        object Model { get; }
    }
}