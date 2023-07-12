using LifeDesignerOnAvalonia.Models;
using ReactiveUI;
using System.Linq;
using System.Reactive;

namespace LifeDesignerOnAvalonia.ViewModels
{
    public class UserPanelViewModel : ViewModelBase, IRoutableViewModel
    {

        public UserPanelViewModel(IScreen screen)
        {
            HostScreen = screen;
            LogOutCommand = ReactiveCommand.Create(LogOut);
            Data();
        }

        public string UrlPathSegment => "UserPanel";
        public IScreen HostScreen { get; }

        private string emailText;
        public string EmailText
        {
            get { return emailText; }
            set { this.RaiseAndSetIfChanged(ref emailText, value); }
        }

        private string loginText;
        public string LoginText
        {
            get { return loginText; }
            set { this.RaiseAndSetIfChanged(ref loginText, value); }
        }

        private string idText;
        public string IdText
        {
            get { return idText; }
            set { this.RaiseAndSetIfChanged(ref idText, value); }
        }

        
        public ReactiveCommand<Unit, Unit> LogOutCommand { get; }

        private void LogOut()
        {
            ItemsCollection.IdUser = 0;
            ItemsCollection.Items.Clear();
            HostScreen.Router.Navigate.Execute(new LoginViewModel(HostScreen));
        }

        void Data()
        {
            using (var Context = new DataBaseContext())
            {
                var CurrentUser = Context.userLogins.FirstOrDefault(i => i.Id == ItemsCollection.IdUser);
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
