using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeDesignerOnAvalonia.Models
{
    [Table("Data")]
    public class Data
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdCategory { get; set; }
        public int IdUser { get; set; }
        public string Text { get; set; }

        [ForeignKey("IdCategory")]
        public Category Category { get; set; }
        [ForeignKey("IdUser")]
        public UserLogin UserLogin { get; set; }
    }
}
