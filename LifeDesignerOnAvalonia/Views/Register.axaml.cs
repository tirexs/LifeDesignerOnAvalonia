using Avalonia.Controls;
using Avalonia.ReactiveUI;
using LifeDesignerOnAvalonia.ViewModels;

namespace LifeDesignerOnAvalonia.Views
{
    public partial class Register : ReactiveUserControl<RegisterViewModel>
    {
        public Register()
        {
            InitializeComponent();
        }
    }
}
