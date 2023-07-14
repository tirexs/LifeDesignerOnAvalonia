using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeDesignerOnAvalonia.Models
{
    [Table("AudioData")]
    public class AudioData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdCategory { get; set; }
        public int IdUser { get; set; }
        public string Name { get; set; }
        public byte[] Audio { get; set; }

        [ForeignKey("IdCategory")]
        public Category Category { get; set; }
        [ForeignKey("IdUser")]
        public UserLogin UserLogin { get; set; }
    }
}
