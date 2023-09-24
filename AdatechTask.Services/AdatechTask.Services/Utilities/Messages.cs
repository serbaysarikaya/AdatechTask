namespace AdatechTask.Services.Utilities
{
    public class Messages
    {
        public static class Book
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir Kitap bulunamadı.";
                return "Böyle bir Kitap bulunamadı.";
            }

            public static string Add(string bookName)
            {

                return $"{bookName} adlı Kitap başarıyla eklenmiştir.";
            }

            public static string Update(string bookName)
            {
                return $"{bookName} adlı Kitap başarıyla güncellenmiştir.";
            }
            public static string Delete(string bookName)
            {
                return $"{bookName} adlı Kitap başarıyla silinmiştir.";
            }

            public static string HardDelete(string bookName)
            {
                return $"{bookName} adlı Kitap başarıyla veritabanından silinmiştir.";
            }
        }
    }
}
