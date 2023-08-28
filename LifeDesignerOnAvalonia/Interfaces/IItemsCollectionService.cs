using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeDesignerOnAvalonia.Interfaces
{
    public interface IItemsCollectionService
    {
        int GetUserId();
        void initializeCollection();
        void ClearCollection();
        void AddCategory(string name);
        void RemoveCategory(string name);
        void AddTask(string name);
        void RemoveTask(string name);
        void AddAudio(string nameRecord, byte[] audioBytes);
        void RemoveAudio();

    }
}
