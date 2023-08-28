using LifeDesignerOnAvalonia.Models;
using LifeDesignerOnAvalonia.Services;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using System.Linq;
using System.Reactive;

namespace LifeDesignerOnAvalonia.ViewModels
{
    public class Del_categoryViewModel : ViewModelBase
    {

        #region private
        private ItemsCollectionService _service;
        private string text;
        private string errText;
        #endregion

        public Del_categoryViewModel(ItemsCollectionService service) 
        {
            _service = service;
            RemoveCategoryCommand = ReactiveCommand.Create(RemoveCategory);
            CloseWindowCommand = ReactiveCommand.Create(CloseWindow);
        }

        public ReactiveCommand<Unit, Unit> RemoveCategoryCommand { get; }
        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; }

        public string Text
        {
            get { return text; }
            set { this.RaiseAndSetIfChanged(ref text, value); }
        }
                
        public string ErrText
        {
            get { return errText; }
            set { this.RaiseAndSetIfChanged(ref errText, value); }
        }

        private void RemoveCategory()
        {
            if (Text == null || Text == "")
            {
                ErrText = "Обязательно для заполнения";
            }
            else
            {
                _service.RemoveCategory(Text);
            }
        }

        private void CloseWindow()
        {

           // Application.Current.Windows.OfType<Del_category>().FirstOrDefault()?.Close();
        }
    }
}

