using LifeDesignerOnAvalonia.Models;
using LifeDesignerOnAvalonia.ViewModels;
using LifeDesignerOnAvalonia.Views;
using ReactiveUI;
using Splat;

namespace LifeDesignerOnAvalonia.ViewModels
{
    public class AccountViewModel : ViewModelBase, IScreen
    {
        public RoutingState Router { get; private set; }

        public AccountViewModel()
        {
            Router = new RoutingState();
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));
            Locator.CurrentMutable.Register(() => new Login(), typeof(IViewFor<LoginViewModel>));
            Locator.CurrentMutable.Register(() => new Register(), typeof(IViewFor<RegisterViewModel>));
            Locator.CurrentMutable.Register(() => new UserPanel(), typeof(IViewFor<UserPanelViewModel>));
            NavigateStart();
        }

        void NavigateStart()
        {
            if(ItemsCollection.IdUser == 0)
            {
                Router.Navigate.Execute(new LoginViewModel(this));
            }
            else
            {
                Router.Navigate.Execute(new UserPanelViewModel(this));
            }
        }

    }
}
