using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MusicaController : Controller
    {
        private readonly Context _context;

        public MusicaController(Context context)
        {
            _context = context;
        }

        // GET: Musica
        public async Task<IActionResult> Index(int id )
        {
            //if (id == 0)
            //{
            //    var musicas = _context.Cantores
            //        .Include(c => c.Musicas)
            //        .Where(c => c.CantorID == c.CantorID)
            //        .ToList();
            //    return View(musicas);

            //}

            //else
            //{
                var musicas = await _context.Cantores
                    .Include(c => c.Musicas)
                    .Where(c => c.CantorID == id)
                    .ToListAsync();
                return View(musicas);
            //}
                

        }



        // GET: Musica/Create
        public IActionResult Create(int id = 0, int idCantor = 0)
        {
            var cantor = _context.Cantores.Find(idCantor);
            ViewBag.cantor = cantor.CantorID;

            if (id == 0)
                return View(new Musica());

            else
                return View(_context.Musicas.Find(id));
        }

        // POST: Musica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MusicaID,Nome,CantorID,imgMusica")] Musica musica, IFormFile imgMusica)
        {
            if (ModelState.IsValid)
            {
                musica.imgMusica = GetByteArrayFromImage(imgMusica);

                if (musica.MusicaID == 0)
                    _context.Add(musica);
                else
                    _context.Update(musica);

                await _context.SaveChangesAsync();
                int id = musica.CantorID;
                return RedirectToAction("Index", new { id });
            }
            return View(musica);
        }

        private byte[] GetByteArrayFromImage(IFormFile file)
        {
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                return target.ToArray();
            }
        }


        // GET: Musica/Delete/5
        public async Task<IActionResult> Delete(int? idMusica)
        {
            var musica = await _context.Musicas.FindAsync(idMusica);
            int id = musica.CantorID;

            _context.Musicas.Remove(musica);
            await _context.SaveChangesAsync();
            return base.RedirectToAction("Index", new { id });

        }

    }
}
