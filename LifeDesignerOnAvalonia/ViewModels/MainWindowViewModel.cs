using LifeDesignerOnAvalonia.Models;
using LifeDesignerOnAvalonia.Services;
using LifeDesignerOnAvalonia.Views;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;

namespace LifeDesignerOnAvalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Private
        private Item selectedCategory;
        private int selectedIndexAudioItem;
        private ItemsCollectionService _service;
        #endregion

        public ObservableCollection<Item> _ItemsCollection { get; set; }
        public ReactiveCommand<Unit, Unit> AccountCommand { get; }
        public ReactiveCommand<Unit, Unit> AddCategoryCommand { get; }
        public ReactiveCommand<Unit, Unit> RemoveCategoryCommand { get; }
        public ReactiveCommand<Unit, Unit> AddTaskCommand { get; }
        public ReactiveCommand<Unit, Unit> DelTaskCommand { get; }
        public ReactiveCommand<Unit, Unit> AddAudioCommand { get; }
        public ReactiveCommand<Unit, Unit> PlayAudioCommand { get; }

        public MainWindowViewModel(ItemsCollectionService service) 
        {
            _service = service;
            _ItemsCollection = _service.GetCollection();
            RemoveCategoryCommand = ReactiveCommand.Create(RemoveCategory);
            AddCategoryCommand = ReactiveCommand.Create(AddCategory);
            AddTaskCommand = ReactiveCommand.Create(AddTask);
            DelTaskCommand = ReactiveCommand.Create(DelTask);
            AccountCommand = ReactiveCommand.Create(Account);
            AddAudioCommand = ReactiveCommand.Create(AddAudio);
            PlayAudioCommand = ReactiveCommand.Create(PlayAudio);
        }

        
        
        public Item SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                this.RaiseAndSetIfChanged(ref selectedCategory, value);
                _service.SetSelectedCategory(value);
            }
        }

        
        
        public int SelectedIndexAudioItem
        {
            get { return selectedIndexAudioItem; }
            set
            {
                this.RaiseAndSetIfChanged(ref selectedIndexAudioItem, value);
            }
        }

        

        private void Account()
        {
            Account account = new Account() { DataContext = new AccountViewModel(_service) };
            account.Show();
        }


        private void AddCategory()
        {
            Add_category AC = new Add_category() { DataContext = new Add_categoryViewModel(_service) };
            AC.Show();  
        }



        private void RemoveCategory()
        {
            Del_category DC = new Del_category() { DataContext = new Del_categoryViewModel(_service) };
            DC.Show();
        }


        private void AddTask()
        {
            
            Add_task AT = new Add_task() { DataContext = new Add_taskViewModel(_service) };
            AT.Show();
        }


        private void DelTask()
        {
            
            Del_task DT = new Del_task() { DataContext = new Del_taskViewModel(_service) };
            DT.Show();
        }


        private void AddAudio()
        {
            
            Add_audio AA = new Add_audio() { DataContext = new Add_audioViewModel(_service) };
            AA.Show();
        }


        private void PlayAudio()
        {
            //SelectedIndexAudioItem = ItemsCollection.SelectedIndexAudioItem;
        }


        //в разработке
        //public void MenuItem_DelCat()
        //{
        //    using (var context = new DataBaseContext())
        //    {
        //        var category = context.Categorys.Where(c => c.Name == ItemsCollection.SelectedItem.Header).ExecuteDelete();
        //        foreach (var coll in ItemsCollection.Items)
        //        {
        //            if (coll.Header == ItemsCollection.SelectedItem.Header)
        //            {
        //                ItemsCollection.Items.Remove(coll);
        //                break;
        //            }
        //        }
        //    }
        //}

    }
}
