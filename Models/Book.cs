using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksMicroservice.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        [MaxLength(13)]
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
