using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Musica
    {
        [Key]
        public int MusicaID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public int CantorID { get; set; }

        public byte[] imgMusica { get; set; }


        public Album album { get; set; }
        
    }
}
