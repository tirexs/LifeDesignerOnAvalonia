using LifeDesignerOnAvalonia.Models;
using LifeDesignerOnAvalonia.Views;
using ReactiveUI;
using System.Reactive;

namespace LifeDesignerOnAvalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {


        public MainWindowViewModel() 
        {
            RemoveCategoryCommand = ReactiveCommand.Create(RemoveCategory);
            AddCategoryCommand = ReactiveCommand.Create(AddCategory);
            AddTaskCommand = ReactiveCommand.Create(AddTask);
            DelTaskCommand = ReactiveCommand.Create(DelTask);
            AccountCommand = ReactiveCommand.Create(Account);
            AddAudioCommand = ReactiveCommand.Create(AddAudio);
            PlayAudioCommand = ReactiveCommand.Create(PlayAudio);
        }

        
        private Item selectedItems;
        public Item SelectedItems
        {
            get { return selectedItems; }
            set
            {
                this.RaiseAndSetIfChanged(ref selectedItems, value);
            }
        }

        
        private int selectedIndexAudioItem;
        public int SelectedIndexAudioItem
        {
            get { return selectedIndexAudioItem; }
            set
            {
                this.RaiseAndSetIfChanged(ref selectedIndexAudioItem, value);
            }
        }

        public ReactiveCommand<Unit, Unit> AccountCommand { get; }

        private void Account()
        {
            Account account = new Account();
            account.Show();
        }

        public ReactiveCommand<Unit, Unit> AddCategoryCommand { get; }

        private void AddCategory()
        {
            Add_category AC = new Add_category();
            AC.Show();  
        }


        public ReactiveCommand<Unit, Unit> RemoveCategoryCommand { get; }

        private void RemoveCategory()
        {
            Del_category DC = new Del_category();
            DC.Show();
        }

        public ReactiveCommand<Unit, Unit> AddTaskCommand { get; }

        private void AddTask()
        {
            ItemsCollection.SelectedItem = SelectedItems;
            Add_task AT = new Add_task();
            AT.Show();
        }

        public ReactiveCommand<Unit, Unit> DelTaskCommand { get; }

        private void DelTask()
        {
            ItemsCollection.SelectedItem = SelectedItems;
            Del_task DT = new Del_task();
            DT.Show();
        }

        public ReactiveCommand<Unit, Unit> AddAudioCommand { get; }

        private void AddAudio()
        {
            ItemsCollection.SelectedItem = SelectedItems;
            Add_audio AA = new Add_audio();
            AA.Show();
        }

        public ReactiveCommand<Unit, Unit> PlayAudioCommand { get; }

        private void PlayAudio()
        {
            SelectedIndexAudioItem = ItemsCollection.SelectedIndexAudioItem;
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
