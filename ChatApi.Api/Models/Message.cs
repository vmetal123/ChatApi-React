using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.Api.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Column(TypeName = "nvarchar(1028)")]
        public string Text { get; set; }
        public Guid UserId { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string UserName { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string To { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
    }
}
