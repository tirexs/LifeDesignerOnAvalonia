using LifeDesignerOnAvalonia.Commands;
using LifeDesignerOnAvalonia.Infrastructure;
using LifeDesignerOnAvalonia.Models;
using ReactiveUI;
using System.Linq;
using System.Reactive;
using System.Windows.Input;

namespace LifeDesignerOnAvalonia.ViewModels
{
    public class LoginViewModel : ViewModelBase, IRoutableViewModel
    {

        public LoginViewModel(IScreen screen) 
        {
            HostScreen = screen;
            LoginCommand = ReactiveCommand.Create(Login);
            CICommand = new СollectionInitializationCommand();
            NavigateToRegisterCommand = ReactiveCommand.Create(NavigateToRegister);
        }

        public string UrlPathSegment => "Login";
        public IScreen HostScreen { get; }

        private string emailText;
        public string EmailText
        {
            get { return emailText; }
            set { this.RaiseAndSetIfChanged(ref emailText, value); }
        }

        private string passText;
        public string PassText
        {
            get { return passText; }
            set { this.RaiseAndSetIfChanged(ref passText, value); }
        }

        private string errText;
        public string ErrText
        {
            get { return errText; }
            set { this.RaiseAndSetIfChanged(ref errText, value); }
        }

        private string errNullText;
        public string ErrNullText
        {
            get { return errNullText; }
            set { this.RaiseAndSetIfChanged(ref errNullText, value); }
        }

        private string errNulText;
        public string ErrNulText
        {
            get { return errNulText; }
            set { this.RaiseAndSetIfChanged(ref errNulText, value); }
        }

        public ReactiveCommand<Unit, Unit> NavigateToRegisterCommand { get; }

        public ICommand CICommand { get; }
        
        public ReactiveCommand<Unit, Unit> LoginCommand { get; }

        private void Login()
        {
            if (PassText == null || EmailText == null || PassText == "" || EmailText == "")
            {
                if (EmailText == null || EmailText == "")
                    ErrNullText = "Обязательно для заполнения";
                if (PassText == null || PassText == "")
                    ErrNulText = "Обязательно для заполнения";
            }
            else
            {
                using (var context = new DataBaseContext())
                {
                    var CurrentUser = context.userLogins.FirstOrDefault(u => u.Email == EmailText && u.Password == MD5Hash.hashPassword(PassText));
                    if (CurrentUser != null)
                    {
                        ItemsCollection.IdUser = CurrentUser.Id;
                        CICommand.Execute(null);
                        HostScreen.Router.Navigate.Execute(new UserPanelViewModel(HostScreen));
                    }
                    else
                    {
                        ErrText = "Неверный логин или пароль";
                        EmailText = "";
                        PassText = "";
                    }
                }
            }
        }

        void NavigateToRegister()
        {
            HostScreen.Router.Navigate.Execute(new RegisterViewModel(HostScreen));
        }


    }
}
