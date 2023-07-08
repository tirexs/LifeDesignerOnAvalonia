using LifeDesignerOnAvalonia.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using System.Linq;
using System.Reactive;

namespace LifeDesignerOnAvalonia.ViewModels
{
    public class Del_taskViewModel: ViewModelBase
    {


        public Del_taskViewModel() 
        {
            DelTaskCommand = ReactiveCommand.Create(DelTask);
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

        public ReactiveCommand<Unit, Unit> DelTaskCommand { get; }

        private void DelTask()
        {
            if (Text == null || Text == "")
            {
                ErrText = "Обязательно для заполнения";
            }
            else
            {
                using (var context = new DataBaseContext())
                {
                    var data = context.datas.Where(c => c.Text == Text).ExecuteDelete();

                    var item = ItemsCollection.Items.FirstOrDefault(i => i.Header == ItemsCollection.SelectedItem.Header);
                    if (item != null)
                    {
                        item.Content.Remove(Text);
                    }
                    //CloseWindowCommand.Execute();
                }
            }
        }

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; }

        private void CloseWindow()
        {
          //  Application.Current.Windows.OfType<Del_task>().FirstOrDefault()?.Close();
        }


    }
}
