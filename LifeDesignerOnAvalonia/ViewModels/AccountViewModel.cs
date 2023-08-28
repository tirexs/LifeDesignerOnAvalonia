using LifeDesignerOnAvalonia.Models;
using LifeDesignerOnAvalonia.Services;
using LifeDesignerOnAvalonia.Views;
using ReactiveUI;
using Splat;

namespace LifeDesignerOnAvalonia.ViewModels
{
    public class AccountViewModel : ViewModelBase, IScreen
    {
        #region private
        private ItemsCollectionService _service;
        #endregion
        
        public RoutingState Router { get; private set; }

        public AccountViewModel(ItemsCollectionService service)
        {
            _service = service;
            Router = new RoutingState();
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));
            Locator.CurrentMutable.Register(() => new Login(), typeof(IViewFor<LoginViewModel>));
            Locator.CurrentMutable.Register(() => new Register(), typeof(IViewFor<RegisterViewModel>));
            Locator.CurrentMutable.Register(() => new UserPanel(), typeof(IViewFor<UserPanelViewModel>));
            NavigateStart();
        }

        void NavigateStart()
        {
            if(_service.GetUserId() == 0)
            {
                Router.Navigate.Execute(new LoginViewModel(this, _service));
            }
            else
            {
                Router.Navigate.Execute(new UserPanelViewModel(this, _service));
            }
        }
    }
}
