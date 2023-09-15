using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReader
{
    class Book
    {
        public string Title { get; }
        public string Author { get; }

        private int pageCount;
        private Page[] pages;
        private int currentPageIndex;

        public Book(string title, string author, string[] text)
        {
            Title = title;
            Author = author;
            pageCount = text.Length;
            pages = new Page[pageCount];
            InitPage(text);
        }

        public void InitPage(string[] value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                pages[i] = new Page(value[i], i + 1);
            }
        }

        public string StartReading()
        {
            currentPageIndex = 0;
            return pages[currentPageIndex].Content;
        }

        public string GetNextPage()
        {
            if (currentPageIndex < pages.Length - 1)
            {
                currentPageIndex++;
                return pages[currentPageIndex].Content;
            }

            return pages[currentPageIndex].Content;
        }

        public string GetPreviousPage()
        {
            if (currentPageIndex > 0)
            {
                currentPageIndex--;
                return pages[currentPageIndex].Content;
            }

            return pages[currentPageIndex].Content;
        }

        public int GetPageNumber()
        {
            return pages[currentPageIndex].Number;
        }

        public string GetAllContent()
        {
            string text = string.Empty;

            foreach (Page page in pages)
            {
                if (page is not null)
                {
                    text += page.Content + "\n";
                }
            }

            return text;
        }

        public void AddPage()
        {
            Array.Resize(ref pages, pages.Length + 1);
            pageCount++;
        }

        public void SavePage(string content)
        {
            AddPage();
            pages[pageCount - 1] = new Page(content, pageCount);
        }
    }
}
