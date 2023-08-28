using LifeDesignerOnAvalonia.Services;
using ReactiveUI;
using System.Reactive;

namespace LifeDesignerOnAvalonia.ViewModels
{
    public class Add_categoryViewModel : ViewModelBase
    {

        #region private
        private ItemsCollectionService _service;
        private string text;
        private string errText;
        #endregion

        public Add_categoryViewModel(ItemsCollectionService service)
        {
            _service = service;
            AddCategoryCommand = ReactiveCommand.Create(AddCategory);
            CloseWindowCommand = ReactiveCommand.Create(CloseWindow);
        }

        public ReactiveCommand<Unit, Unit> AddCategoryCommand { get; }
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


        private void AddCategory()
        {
            if (Text == null || Text == "")
            {
                ErrText = "Обязательно для заполнения";
            }
            else
            {
                _service.AddCategory(Text);
            }        
        }
        
        private void CloseWindow()
        {            
            //Application.Current.Windows.OfType<Add_category>().FirstOrDefault()?.Close();
        }
    }
}
