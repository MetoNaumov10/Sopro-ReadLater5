﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Bookmark
    {
        [Key]
        public int ID { get; set; }

        [StringLength(maximumLength: 500)]
        public string URL { get; set; }

        public string ShortDescription { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(maximumLength: 450)]
        public string UserId { get; set; }
    }
}
