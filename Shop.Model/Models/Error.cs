using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model.Models
{
    /// <summary>
    /// Log errors
    /// </summary>
    [Table("Errors")]
    public class Error
    {
        /// <summary>
        /// Key
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        /// <summary>
        /// Message error
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Stacktrace error
        /// </summary>
        public string StackTrace { get; set; }
        /// <summary>
        /// CreatedDate error
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
