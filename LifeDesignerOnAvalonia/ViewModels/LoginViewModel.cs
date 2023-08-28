using LifeDesignerOnAvalonia.Commands;
using LifeDesignerOnAvalonia.Infrastructure;
using LifeDesignerOnAvalonia.Models;
using LifeDesignerOnAvalonia.Services;
using ReactiveUI;
using System.Linq;
using System.Reactive;
using System.Windows.Input;

namespace LifeDesignerOnAvalonia.ViewModels
{
    public class LoginViewModel : ViewModelBase, IRoutableViewModel
    {

        #region private
        private ItemsCollectionService _service;
        private string passText;
        private string emailText;
        private string errText;
        private string errNullText;
        private string errNulText;
        #endregion

        public LoginViewModel(IScreen screen, ItemsCollectionService service) 
        {
            _service = service;
            HostScreen = screen;
            LoginCommand = ReactiveCommand.Create(Login);
            NavigateToRegisterCommand = ReactiveCommand.Create(NavigateToRegister);
        }

        public string UrlPathSegment => "Login";
        public IScreen HostScreen { get; }

        public string EmailText
        {
            get { return emailText; }
            set { this.RaiseAndSetIfChanged(ref emailText, value); }
        }

        public string PassText
        {
            get { return passText; }
            set { this.RaiseAndSetIfChanged(ref passText, value); }
        }

        public string ErrText
        {
            get { return errText; }
            set { this.RaiseAndSetIfChanged(ref errText, value); }
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

        public ReactiveCommand<Unit, Unit> NavigateToRegisterCommand { get; }
        
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
                        _service.setUserId(CurrentUser.Id);
                        _service.initializeCollection();
                        HostScreen.Router.Navigate.Execute(new UserPanelViewModel(HostScreen, _service));
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
            HostScreen.Router.Navigate.Execute(new RegisterViewModel(HostScreen, _service));
        }


    }
}
