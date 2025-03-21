using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HadithController : Controller
    {
        private readonly HadithService _hadithService;

        public HadithController(HadithService hadithService)
        {
            _hadithService = hadithService;
        }

        public async Task<IActionResult> Books()
        {
            var books = await _hadithService.GetAllBooksAsync();
            return View(books);
        }

        public async Task<IActionResult> Chapters(string bookSlug)
        {
            var chapters = await _hadithService.GetChaptersAsync(bookSlug);

            if (chapters == null)
            {
                return NotFound();
            }

            return View(chapters);
        }


        public async Task<IActionResult> ChapterDetails(int chapterId)
        {
            var url = "https://hadithapi.com/public/api/hadiths?apiKey=$2y$10$tTgzpNXpSwtwxMUOVT92eoHI874cLvDLOJTDw1ICoHcS3aP8xnqi&chapterId=" + chapterId;
            var jsonData = await _hadithService.GetAsync(url);

            if (string.IsNullOrEmpty(jsonData))
            {
                return NotFound();
            }

            var result = JsonSerializer.Deserialize<HadithApiResponse>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(result.Hadiths.Data);
        }


    

    }
}
