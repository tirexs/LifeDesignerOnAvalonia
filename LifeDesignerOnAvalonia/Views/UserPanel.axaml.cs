using Avalonia.Controls;
using Avalonia.ReactiveUI;
using LifeDesignerOnAvalonia.ViewModels;

namespace LifeDesignerOnAvalonia.Views
{
    public partial class UserPanel : ReactiveUserControl<UserPanelViewModel>
    {
        public UserPanel()
        {
            InitializeComponent();
        }
    }
}
