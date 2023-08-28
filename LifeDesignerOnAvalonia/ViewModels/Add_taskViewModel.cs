﻿using LifeDesignerOnAvalonia.Models;
using LifeDesignerOnAvalonia.Services;
using ReactiveUI;
using System.Linq;
using System.Reactive;

namespace LifeDesignerOnAvalonia.ViewModels
{
    public class Add_taskViewModel : ViewModelBase
    {

        #region private
        private ItemsCollectionService _service;
        private string text;
        private string errText;
        #endregion

        public Add_taskViewModel(ItemsCollectionService service)
        {
            _service = service;
            AddTaskCommand = ReactiveCommand.Create(AddTask);
            CloseWindowCommand = ReactiveCommand.Create(CloseWindow);
        }

        public ReactiveCommand<Unit, Unit> AddTaskCommand { get; }
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

        private void AddTask()
        {
            if (Text == null || Text == "")
            {
                ErrText = "Обязательно для заполнения";
            }
            else
            { 
                _service.AddTask(Text);
            }
        }

        private void CloseWindow()
        {
            //Application.Current.Windows.OfType<Add_category>().FirstOrDefault()?.Close();
        }
    }
}
