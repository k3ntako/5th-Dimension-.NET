using System;
namespace FifthDimension
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
                var bookStr = FormatField(book.title ?? "[No Title]");
                bookStr += FormatField("Authors", book.authors);
                bookStr += FormatField("Publisher", book.publisher);
                bookStr += FormatField("Description", book.description, 150);
                bookStr += FormatField("Page Count", book.pageCount.ToString());
                bookStr += FormatField("Publish Date", book.publishedDate);
                bookStr += FormatField("Categories", book.categories);

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
                var bookStr = FormatField(book.title ?? "[No Title]");
                bookStr += FormatField("Authors", book.authors);
                bookStr += FormatField("Publisher", book.publisher);
                bookStr += FormatField("Publish Date", book.publishedDate);

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
