using LifeDesignerOnAvalonia.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeDesignerOnAvalonia.Commands
{
    public class СollectionInitializationCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            using (var context = new DataBaseContext())
            {
                ItemsCollection.Items.Clear();
                var category = context.Categorys.Where(i => i.IdUser == ItemsCollection.IdUser).Select(n => n.Name).ToList();

                foreach (var Cname in category)
                {
                    var id = context.Categorys.Where(n => n.Name == Cname).Select(n => n.Id);
                    var contents = context.datas.Include(t => t.Category).Where(t => t.IdCategory == id.First()).Select(x => x.Text).ToList();
                    ItemsCollection.Items.Add(new Item { Header = Cname, Content = new ObservableCollection<string>(contents) });
                }
            }
        }
    }
}
