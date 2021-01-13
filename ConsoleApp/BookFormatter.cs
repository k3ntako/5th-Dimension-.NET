using System;
namespace ConsoleApp
{
    public class BookFormatter
    {
        public BookFormatter()
        {
        }

        public string FormatAsString(Book book)
        {
            try
            {
                var bookStr = FormatField(book.Title ?? "[No Title]");
                bookStr += FormatField("Authors", book.Authors);
                bookStr += FormatField("Publisher", book.Publisher);
                bookStr += FormatField("Description", book.Description, 150);
                bookStr += FormatField("Page Count", book.PageCount.ToString());
                bookStr += FormatField("Publish Date", book.PublishedDate);
                bookStr += FormatField("Categories", book.Categories);

                //Dictionary<string, string>[] industryIdentifiers;

                return bookStr;
            }
            catch (Exception ex)
            {
                Logger.WriteError(ex);
                return null;
            }
        }

        public string FormatAsShortString(Book book)
        {
            try
            {
                var bookStr = FormatField(book.Title ?? "[No Title]");
                bookStr += FormatField("Authors", book.Authors);
                bookStr += FormatField("Publisher", book.Publisher);
                bookStr += FormatField("Publish Date", book.PublishedDate);

                return bookStr;
            }
            catch (Exception ex)
            {
                Logger.WriteError(ex);
                return null;
            }
        }

        static string FormatField(string fieldVal)
        {
            if (fieldVal is null)
            {
                return "";
            }

            return $"{fieldVal}{Environment.NewLine}";
        }

        static string FormatField(string fieldTitle, string fieldVal)
        {
            if (fieldVal is null)
            {
                return "";
            }

            return $"{fieldTitle}: {fieldVal}{Environment.NewLine}";
        }

        static string FormatField(string fieldTitle, string[] fieldVal)
        {
            if (fieldVal is null)
            {
                return "";
            }

            return $"{fieldTitle}: {string.Join(", ", fieldVal)}{Environment.NewLine}";
        }

        static string FormatField(string fieldTitle, string fieldVal, int maxLength)
        {
            if (fieldVal is null)
            {
                return "";
            }
            else if (fieldVal.Length <= maxLength)
            {
                return $"{fieldTitle}: {fieldVal}{Environment.NewLine}";
            }

            var shortVal = fieldVal.Substring(0, Math.Min(fieldVal.Length, maxLength));
            return $"{fieldTitle}: {shortVal}...{Environment.NewLine}";
        }
    }
}
