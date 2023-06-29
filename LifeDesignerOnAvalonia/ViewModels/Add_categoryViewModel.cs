using LifeDesignerOnAvalonia.Commands;
using LifeDesignerOnAvalonia.Models;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows.Input;

namespace LifeDesignerOnAvalonia.ViewModels
{
    public class Add_categoryViewModel : ViewModelBase
    {

        public Add_categoryViewModel()
        {
            AddCategoryCommand = ReactiveCommand.Create(AddCategory);
            CloseWindowCommand = ReactiveCommand.Create(CloseWindow);
        }
        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }

        private string errText;
        public string ErrText
        {
            get { return errText; }
            set
            {
                errText = value;
                OnPropertyChanged("ErrText");
            }
        }

        public ReactiveCommand<Unit, Unit> AddCategoryCommand { get; }

        private void AddCategory()
        {
            if (Text == null || Text == "")
            {
                ErrText = "Обязательно для заполнения";
            }
            else
            {
                using (var context = new DataBaseContext())
                {

                    var category = new Category()
                    {
                        Name = Text,
                        IdUser = ItemsCollection.IdUser
                    };

                    context.Categorys.Add(category);
                    context.SaveChanges();
                    ItemsCollection.Items.Add(new Item { Header = Text, Content = new ObservableCollection<string>() });
                    CloseWindowCommand.Execute();
                }
            }        
        }
        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; }
        
        private void CloseWindow()
        {            
            //Application.Current.Windows.OfType<Add_category>().FirstOrDefault()?.Close();
        }
    }
}
