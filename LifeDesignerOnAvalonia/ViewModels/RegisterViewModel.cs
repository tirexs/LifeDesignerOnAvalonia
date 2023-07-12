using LifeDesignerOnAvalonia.Infrastructure;
using LifeDesignerOnAvalonia.Models;
using ReactiveUI;
using System.Linq;
using System.Reactive;

namespace LifeDesignerOnAvalonia.ViewModels
{
    public class RegisterViewModel : ViewModelBase, IRoutableViewModel
    {

        public RegisterViewModel(IScreen screen)
        {
            HostScreen = screen;
            RegisterCommand = ReactiveCommand.Create(Register);
            NavigateToLoginCommand = ReactiveCommand.Create(NavigateToLogin);
            

        }

        public string UrlPathSegment => "UserPanel";
        public IScreen HostScreen { get; }

        private string errText;
        public string ErrText
        {
            get { return errText; }
            set { this.RaiseAndSetIfChanged(ref errText, value); }
        }

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

        private string passText;
        public string PassText
        {
            get { return passText; }
            set { this.RaiseAndSetIfChanged(ref passText, value); }
        }

        private string errNulllText;
        public string ErrNulllText
        {
            get { return errNulllText; }
            set { this.RaiseAndSetIfChanged(ref errNulllText, value); }
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

        
        public ReactiveCommand<Unit, Unit> RegisterCommand { get; }

        private void Register()
        {

            if (LoginText == null || PassText == null || EmailText == null || LoginText == "" || PassText == "" || EmailText == "")
            {
                if (LoginText == null || LoginText == "")
                    ErrNullText = "Обязательно для заполнения";
                if (EmailText == null || EmailText == "")
                    ErrNulllText = "Обязательно для заполнения";
                if (PassText == null || PassText == "")
                    ErrNulText = "Обязательно для заполнения";
            }
            else
            {
                using (var context = new DataBaseContext())
                {
                    var CurrentUser = context.userLogins.FirstOrDefault(e => e.Email == EmailText);
                    if (CurrentUser != null)
                    {
                        ErrText = "Пользователь с таким Email уже зарегистрирован";
                    }
                    else
                    {
                        var userLogin = new UserLogin()
                        {
                            UserName = LoginText,
                            Email = EmailText,
                            Password = MD5Hash.hashPassword(PassText)
                        };
                        context.userLogins.Add(userLogin);
                        context.SaveChanges();
                        NavigateToLogin();
                    }
                }
            }
        }

        public ReactiveCommand<Unit, Unit> NavigateToLoginCommand { get; }
        void NavigateToLogin()
        {
            HostScreen.Router.Navigate.Execute(new LoginViewModel(HostScreen));
        }
    }
}
