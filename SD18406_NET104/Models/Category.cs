using System.ComponentModel.DataAnnotations;

namespace SD18406_NET104.Models
{
    public class Category
    {
        //id, name, displayorder
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
