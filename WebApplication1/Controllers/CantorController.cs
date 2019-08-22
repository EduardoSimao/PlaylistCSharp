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
    public class CantorController : Controller
    {
        private readonly Context _context;

        public CantorController(Context context)
        {
            _context = context;
        }

        // GET: Cantor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cantores.ToListAsync());
        }

        // GET: Cantor/Create
        public IActionResult Create(int id = 0)
        {
            if (id == 0)
            {
                return View(new Cantor());
            }
            else
            {
                var cantor = _context.Cantores.Find(id);
                return View(cantor);

            }
        }

        // POST: Cantor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CantorID,Nome")] Cantor cantor, IFormFile imgCantor)
        {
            if (ModelState.IsValid)
            {
                cantor.imgCantor = GetByteArrayFromImage(imgCantor);

                if (cantor.CantorID == 0)
                    _context.Add(cantor);
                else
                    _context.Update(cantor);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(cantor);
        }
        private byte[] GetByteArrayFromImage(IFormFile file)
        {
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                return target.ToArray();
            }
        }
        // GET: Cantor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var cantor = await _context.Cantores.FindAsync(id);
            _context.Cantores.Remove(cantor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public JsonResult GetDados(int id = 0)
        {
            if (id != 0)
            { 
                var cantor = _context.Cantores.Find(id);

                var base64 = Convert.ToBase64String(cantor.imgCantor);
                var imgSrc = String.Format("data:image/png;base64,{0}", base64);

                return Json(cantor);

            }
            return Json(new Cantor());
        }
    }
}
