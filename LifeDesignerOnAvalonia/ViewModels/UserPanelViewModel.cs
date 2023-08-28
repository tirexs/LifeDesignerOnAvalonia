using LifeDesignerOnAvalonia.Models;
using LifeDesignerOnAvalonia.Services;
using ReactiveUI;
using System.Linq;
using System.Reactive;

namespace LifeDesignerOnAvalonia.ViewModels
{
    public class UserPanelViewModel : ViewModelBase, IRoutableViewModel
    {

        #region private
        private ItemsCollectionService _service;
        private string emailText;
        private string loginText;
        private string idText;
        #endregion

        public UserPanelViewModel(IScreen screen, ItemsCollectionService service)
        {
            HostScreen = screen;
            _service = service;
            LogOutCommand = ReactiveCommand.Create(LogOut);
            Data();
        }

        public string UrlPathSegment => "UserPanel";
        public IScreen HostScreen { get; }

        public string EmailText
        {
            get { return emailText; }
            set { this.RaiseAndSetIfChanged(ref emailText, value); }
        }

        public string LoginText
        {
            get { return loginText; }
            set { this.RaiseAndSetIfChanged(ref loginText, value); }
        }

        public string IdText
        {
            get { return idText; }
            set { this.RaiseAndSetIfChanged(ref idText, value); }
        }

        
        public ReactiveCommand<Unit, Unit> LogOutCommand { get; }

        private void LogOut()
        {
            _service.setUserId(0);
            _service.ClearCollection();
            HostScreen.Router.Navigate.Execute(new LoginViewModel(HostScreen, _service));
        }

        void Data()
        {
            using (var Context = new DataBaseContext())
            {
                var CurrentUser = Context.userLogins.FirstOrDefault(i => i.Id == _service.GetUserId());
                if(CurrentUser != null)
                {
                    EmailText = CurrentUser.Email;
                    LoginText = CurrentUser.UserName;
                    IdText = CurrentUser.Id.ToString();
                }
            }
        }
    }
}
