using LifeDesignerOnAvalonia.Infrastructure;
using LifeDesignerOnAvalonia.Models;
using LifeDesignerOnAvalonia.Services;
using ReactiveUI;
using System.Linq;
using System.Reactive;

namespace LifeDesignerOnAvalonia.ViewModels
{
    public class RegisterViewModel : ViewModelBase, IRoutableViewModel
    {

        #region private
        private ItemsCollectionService _service;
        private string errText;
        private string emailText;
        private string loginText;
        private string passText;
        private string errNulllText;
        private string errNullText;
        private string errNulText;
        #endregion

        public RegisterViewModel(IScreen screen, ItemsCollectionService service)
        {
            _service = service;
            HostScreen = screen;
            RegisterCommand = ReactiveCommand.Create(Register);
            NavigateToLoginCommand = ReactiveCommand.Create(NavigateToLogin);
            

        }

        public string UrlPathSegment => "UserPanel";
        public IScreen HostScreen { get; }

        public string ErrText
        {
            get { return errText; }
            set { this.RaiseAndSetIfChanged(ref errText, value); }
        }

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

        public string PassText
        {
            get { return passText; }
            set { this.RaiseAndSetIfChanged(ref passText, value); }
        }

        public string ErrNulllText
        {
            get { return errNulllText; }
            set { this.RaiseAndSetIfChanged(ref errNulllText, value); }
        }

        public string ErrNullText
        {
            get { return errNullText; }
            set { this.RaiseAndSetIfChanged(ref errNullText, value); }
        }

        public string ErrNulText
        {
            get { return errNulText; }
            set { this.RaiseAndSetIfChanged(ref errNulText, value); }
        }

        public ReactiveCommand<Unit, Unit> RegisterCommand { get; }

        public ReactiveCommand<Unit, Unit> NavigateToLoginCommand { get; }

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

        void NavigateToLogin()
        {
            HostScreen.Router.Navigate.Execute(new LoginViewModel(HostScreen, _service));
        }
    }
}
