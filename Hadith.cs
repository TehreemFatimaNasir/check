using System.Text.Json.Serialization;

namespace WebApplication5.Models
{
    public class HadithApiResponse
    {
        public HadithData Hadiths { get; set; }
      
    }

    public class HadithData
    {
        public List<Hadith> Data { get; set; }
    }

    public class Hadith
    {
        public string HadithNumber { get; set; }
        public string EnglishNarrator { get; set; }
        public string HadithEnglish { get; set; }
        public string HadithUrdu { get; set; }
        public string HadithArabic { get; set; }
        public string HeadingEnglish { get; set; }

        public Book Book { get; set; }
        public Chapter Chapter { get; set; }
    }

    public class HadithBooksResponse
    {
        [JsonPropertyName("books")]
        public List<Book> Books { get; set; } 
    }

    public class HadithBooksData
    {
        public List<Book> Books { get; set; }
    }

    public class Book
    {
        public string BookName { get; set; }
        public string WriterName { get; set; }
        public string BookSlug { get; set; }
    }


    public class HadithChaptersResponse
    {
        [JsonPropertyName("chapters")]
        public List<Chapter> Chapters { get; set; } 


        public HadithChaptersData Data { get; set; }
    }

    public class HadithChaptersData
    {
        public List<Chapter> Chapters { get; set; }
    }

    public class Chapter
    {
        public int ChapterId { get; set; }
        public string ChapterNumber { get; set; }
        public string ChapterEnglish { get; set; }
        public string ChapterArabic { get; set; }
        public string BookSlug { get; set; }
    }
}
