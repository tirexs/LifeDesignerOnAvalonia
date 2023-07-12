using LifeDesignerOnAvalonia.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using System.Linq;
using System.Reactive;

namespace LifeDesignerOnAvalonia.ViewModels
{
    public class Del_categoryViewModel : ViewModelBase
    {

        public Del_categoryViewModel() 
        {
            RemoveCategoryCommand = ReactiveCommand.Create(RemoveCategory);
            CloseWindowCommand = ReactiveCommand.Create(CloseWindow);
        }

        private string text;
        public string Text
        {
            get { return text; }
            set { this.RaiseAndSetIfChanged(ref text, value); }
        }

        private string errText;
        public string ErrText
        {
            get { return errText; }
            set { this.RaiseAndSetIfChanged(ref errText, value); }
        }

        public ReactiveCommand<Unit, Unit> RemoveCategoryCommand { get; }

        private void RemoveCategory()
        {
            if (Text == null || Text == "")
            {
                ErrText = "Обязательно для заполнения";
            }
            else
            {
                using (var context = new DataBaseContext())
                {
                    var category = context.Categorys.Where(c => c.Name == Text).ExecuteDelete();
                    foreach (var coll in ItemsCollection.Items)
                    {
                        if (coll.Header == Text)
                        {
                            ItemsCollection.Items.Remove(coll);
                            break;
                        }
                    }
                    CloseWindowCommand.Execute();
                }
            }
        }

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; }

        private void CloseWindow()
        {

           // Application.Current.Windows.OfType<Del_category>().FirstOrDefault()?.Close();
        }
    }
}

