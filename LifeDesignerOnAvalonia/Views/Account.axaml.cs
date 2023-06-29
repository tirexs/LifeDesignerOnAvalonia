using Avalonia.Controls;
using Avalonia.ReactiveUI;
using LifeDesignerOnAvalonia.ViewModels;

namespace LifeDesignerOnAvalonia.Views
{
    public partial class Account : ReactiveWindow<AccountViewModel>
    {
        public Account()
        {
            InitializeComponent();
        }
    }
}
