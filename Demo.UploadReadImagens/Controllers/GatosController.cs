using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo.UploadReadImagens.Data.Context;
using Demo.UploadReadImagens.Data.Models;

namespace Demo.UploadReadImagens.Controllers
{
    public class GatosController : Controller
    {
        SQLServerContext _context;

        public GatosController(SQLServerContext context)
        {
            _context = context;
        }

        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadImage(Gato data, IFormFile arquivo) 
        {
            if (arquivo != null)
            {
                MemoryStream ms = new MemoryStream();
                arquivo.OpenReadStream().CopyTo(ms);

                Image imagem = new Image()
                {
                    Dados = ms.ToArray(),
                    ContentType = arquivo.ContentType
                };

                _context.Imagens.Add(imagem);
                _context.SaveChanges();

                Gato gato = new Gato()
                {
                    Name = data.Name,
                    Idade = data.Idade,
                    Image = imagem
                };

                _context.Gatos.Add(gato);
                _context.SaveChanges();
            }
            return RedirectToAction("Form");
        }

        public IActionResult GatosList() {
            var gatos = _context.Gatos
                .Include(g => g.Image)
                .ToList();
            //TempData["GatosList"] = gatos;
            return PartialView("~/Views/Gatos/_ListGatos.cshtml", gatos);
        }

        public ActionResult RenderImage(int id)
        {
            Image img = _context.Imagens.FirstOrDefault(i => i.Id == id);
            byte[] byteData = img.Dados;
            return File(byteData, "image/jpg");
        }
    }
}
