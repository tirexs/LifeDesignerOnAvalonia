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
            
        }

        
        private Item selectedItems;
        public Item SelectedItems
        {
            get { return selectedItems; }
            set
            {
                ItemsCollection.SelectedItem = SelectedItems;
                this.RaiseAndSetIfChanged(ref selectedItems, value);
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
