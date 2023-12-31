﻿using LifeDesignerOnAvalonia.Models;
using ReactiveUI;
using System.Linq;
using System.Reactive;

namespace LifeDesignerOnAvalonia.ViewModels
{
    public class Add_taskViewModel : ViewModelBase
    {


        public Add_taskViewModel()
        {
            AddTaskCommand = ReactiveCommand.Create(AddTask);
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

        public ReactiveCommand<Unit, Unit> AddTaskCommand { get; }

        private void AddTask()
        {
            if (Text == null || Text == "")
            {
                ErrText = "Обязательно для заполнения";
            }
            else
            { 
                using (var context = new DataBaseContext())
                {
                    var id = context.Categorys.Where(n => n.Name == ItemsCollection.SelectedItem.Header).Select(n => n.Id).FirstOrDefault();
                    var data = new Data()
                    {
                        Text = Text,
                        IdCategory = id,
                        IdUser = ItemsCollection.IdUser
                    };
                    context.datas.Add(data);
                    context.SaveChanges();

                    var item = ItemsCollection.Items.FirstOrDefault(i => i.Header == ItemsCollection.SelectedItem.Header);
                    if (item != null)
                    {
                        item.Content.Add(Text);
                    }
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
