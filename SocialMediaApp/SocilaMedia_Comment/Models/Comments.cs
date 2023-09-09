﻿using System.ComponentModel.DataAnnotations;

namespace SocilaMedia_Comment.Models
{
    public class Comments
    {
        [Key]
        public  Guid CommentId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public string Body { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string Tag { get; set; } = string.Empty;
       

    }
}
