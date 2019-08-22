using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Cantor
    {
        [Key]
        public int CantorID { get; set; }

        [Required]
        public string Nome { get; set; }

        public byte[] imgCantor { get; set; }

        public IList<Album> Albums {get; set; }

        public IList<Musica> Musicas { get; set; }

    }
}
