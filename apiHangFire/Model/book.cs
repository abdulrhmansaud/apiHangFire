using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using apiHangFire.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace apiHangFire.Model
{
    public class book
    {
        public book()
        {
        }

        //public book(BooksType type)
        //{
        //    this.types = type;
        //}

        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public bool availability { get; set; }
      
        public BooksType types { get; set; }
    }
}
