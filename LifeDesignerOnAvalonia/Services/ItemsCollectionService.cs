using LifeDesignerOnAvalonia.Interfaces;
using LifeDesignerOnAvalonia.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;

namespace LifeDesignerOnAvalonia.Services
{
    public class ItemsCollectionService : IItemsCollectionService
    {

        #region Private
        private ObservableCollection<Item> _ItemsCollection { get; set; } = new ObservableCollection<Item>();
        private Item SelectedCategory { get; set; }
        private int UserId { get; set; }
        #endregion

        public ItemsCollectionService() 
        {

        }

        public ObservableCollection<Item> GetCollection() => _ItemsCollection;

        public int GetUserId() => UserId;

        public void SetSelectedCategory(Item item)
        {
            SelectedCategory = item;
        }

        public void setUserId(int  userId) 
        {
            UserId = userId;
        }

        public void initializeCollection()
        {
            using (var context = new DataBaseContext())
            {
                _ItemsCollection.Clear();
                var category = context.Categorys.Where(i => i.IdUser == UserId).Select(n => n.Name).ToList();

                foreach (var Cname in category)
                {
                    var id = context.Categorys.Where(n => n.Name == Cname).Select(n => n.Id);
                    var Tasks = context.datas.Include(t => t.Category).Where(t => t.IdCategory == id.First()).Select(x => x.Text).ToList();
                    var AudioNames = context.audioData.Include(t => t.Category).Where(t => t.IdCategory == id.First()).Select(x => x.Name).ToList();
                    _ItemsCollection.Add(new Item { Category = Cname, Tasks = new ObservableCollection<string>(Tasks), AudioNames = new ObservableCollection<string>(AudioNames) });
                }
            }
        }

        public void ClearCollection()
        {
            _ItemsCollection.Clear();
        }

        public void AddCategory(string name) 
        {
            using (var context = new DataBaseContext())
            {

                var category = new Category()
                {
                    Name = name,
                    IdUser = UserId
                };

                context.Categorys.Add(category);
                context.SaveChanges();
                _ItemsCollection.Add(new Item { Category = name, Tasks = new ObservableCollection<string>() });
                
            }
        }

        public void RemoveCategory(string name)
        {
            using (var context = new DataBaseContext())
            {
                var category = context.Categorys.Where(c => c.Name == name).ExecuteDelete();
                foreach (var coll in _ItemsCollection)
                {
                    if (coll.Category == name)
                    {
                        _ItemsCollection.Remove(coll);
                        break;
                    }
                }
            }
        }

        public void AddTask(string name)
        {
            using (var context = new DataBaseContext())
            {
                var id = context.Categorys.Where(n => n.Name == SelectedCategory.Category).Select(n => n.Id).FirstOrDefault();
                var data = new Data()
                {
                    Text = name,
                    IdCategory = id,
                    IdUser = UserId
                };
                context.datas.Add(data);
                context.SaveChanges();

                var item = _ItemsCollection.FirstOrDefault(i => i.Category == SelectedCategory.Category);
                if (item != null)
                {
                    item.Tasks.Add(name);
                }
            }
        }

        public void RemoveTask(string name)
        {
            using (var context = new DataBaseContext())
            {
                var data = context.datas.Where(c => c.Text == name).ExecuteDelete();

                var item = _ItemsCollection.FirstOrDefault(i => i.Category == SelectedCategory.Category);
                if (item != null)
                {
                    item.Tasks.Remove(name);
                }
            }
        }

        public void AddAudio(string nameRecord, byte[] audioBytes)
        {
            using (var context = new DataBaseContext())
            {
                var id = context.Categorys.Where(n => n.Name == SelectedCategory.Category).Select(n => n.Id).FirstOrDefault();
                var audioData = new AudioData()
                {
                    Name = nameRecord,
                    IdCategory = id,
                    IdUser = UserId,
                    Audio = audioBytes
                };

                context.audioData.Add(audioData);
                context.SaveChanges();

                var item = _ItemsCollection.FirstOrDefault(i => i.Category == SelectedCategory.Category);
                if (item != null)
                {
                    item.AudioNames.Add(nameRecord);
                }
            }
        }

        public void RemoveAudio()
        {

        }

    }
}
