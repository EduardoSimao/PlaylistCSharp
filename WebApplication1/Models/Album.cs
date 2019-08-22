using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public Cantor cantor { get; set; }

        public IList<Musica> Musicas { get; set; }


    }
}
