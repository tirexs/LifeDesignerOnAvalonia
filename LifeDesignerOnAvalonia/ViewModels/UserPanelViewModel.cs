using LifeDesignerOnAvalonia.Models;
using ReactiveUI;
using Splat;
using System.Linq;
using System.Reactive;
using System.Windows.Input;

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
            set
            {
                emailText = value;
                OnPropertyChanged("EmailText");
            }
        }

        private string loginText;
        public string LoginText
        {
            get { return loginText; }
            set
            {
                loginText = value;
                OnPropertyChanged("LoginText");
            }
        }

        private string idText;
        public string IdText
        {
            get { return idText; }
            set
            {
                idText = value;
                OnPropertyChanged("IdText");
            }
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
