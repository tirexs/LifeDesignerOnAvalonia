using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace LifeDesignerOnAvalonia.Models
{
    public class Item
    {
        public string Category { get; set; }
        public ObservableCollection<string> Tasks { get; set; }
        public ObservableCollection<string> AudioNames { get; set; }
    }
}
