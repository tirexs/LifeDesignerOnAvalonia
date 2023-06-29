using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LifeDesignerOnAvalonia.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Name { get; set; }

        [ForeignKey("IdUser")]
        public UserLogin UserLogin { get; set; }
        public List<Data> Datas { get; set; }
    }
}
