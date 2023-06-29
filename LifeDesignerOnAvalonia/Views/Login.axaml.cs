using Avalonia.Controls;
using Avalonia.ReactiveUI;
using LifeDesignerOnAvalonia.ViewModels;

namespace LifeDesignerOnAvalonia.Views
{
    public partial class Login : ReactiveUserControl<LoginViewModel>
    {
        public Login()
        {
            InitializeComponent();
        }
    }
}
