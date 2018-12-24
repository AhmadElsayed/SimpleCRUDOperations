using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaskResolution.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [StringLength(450)]
        [Index(IsUnique =true)]
        public string Number { set; get; }

        [Required]
        public string FirstName { set; get; }

        public string MidName { set; get; }

        public string LastName { set; get; }

        [Required]
        public DateTime Birthdate { set; get; }
        
        public ICollection<Subject> Subjects { set; get; }
        
    }
}