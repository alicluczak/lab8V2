using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8p2.Model
{
    [Table("Studenci")]
    public class Student
    {
        [Key]
        public int IdStudent { get; set; }
        [Required]
        [MaxLength(30)]
        public string Imie { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nazwisko { get; set; }
        public double? Ocena { get; set; }
        public byte Wiek { get; set; }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko}, ID: {IdStudent}, wiek: {Wiek}, ocena: {Ocena}";
        }
    }
}
