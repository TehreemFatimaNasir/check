using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebApplication5.Models;

namespace WebApplication5.Models
{
    public class HadithService
    {
        private readonly HttpClient _httpClient;

        public HadithService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            var response = await _httpClient.GetAsync("https://hadithapi.com/api/books?apiKey=$2y$10$0KsokUuNkmO6xXsXLWCjue6JEVE6olfFFO3wosGGeRUlNBOPsfW");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<HadithBooksResponse>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return result?.Books ?? new List<Book>();
            }

            return new List<Book>();
        }

        public async Task<List<Chapter>> GetChaptersAsync(string bookSlug)
        {
            var response = await _httpClient.GetAsync($"https://hadithapi.com/api/{bookSlug}/chapters?apiKey=$2y$10$0KsokUuNkmO6xXsXLWCjue6JEVE6olfFFO3wosGGeRUlNBOPsfW");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<HadithChaptersResponse>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return result?.Chapters ?? new List<Chapter>(); 
            }

            return new List<Chapter>();
        }

        public async Task<List<Hadith>> GetHadithsByChapterAsync(string bookSlug, int chapterId)
        {
            var response = await _httpClient.GetAsync($"https://hadithapi.com/api/{bookSlug}/chapters/{chapterId}/hadiths?apiKey=$2y$10$0KsokUuNkmO6xXsXLWCjue6JEVE6olfFFO3wosGGeRUlNBOPsfW");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<HadithApiResponse>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return result?.Hadiths?.Data ;
            }

            return new List<Hadith>();
        }


        public async Task<string> GetAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return string.Empty;
        }
    }
}
