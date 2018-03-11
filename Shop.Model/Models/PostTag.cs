using Shop.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model.Models
{
    [Table("PostTags")]
    public class PostTag:Auditable
    {
        [Required]
        [Key]
        [Column(Order = 1)]
        public int PostID { set; get; }
        [Required]
        [Key]
        [Column(Order = 2)]
        [MaxLength(50)]
        public string TagID { set; get; }
        [ForeignKey("PostID")]
        public virtual Post Post { set; get; }
        [ForeignKey("TagID")]
        public virtual Tag Tag { set; get; }
    }
}
