using System.Collections.Generic;
using System.Linq;

namespace Assessment
{
    public class PaginationString : IPagination<string>
    {
        private readonly IEnumerable<string> data;
        private readonly int pageSize;
        private int currentPage;

        public PaginationString(string source, int pageSize, IElementsProvider<string> provider)
        {
            data = provider.ProcessData(source);
            currentPage = 1;
            this.pageSize = pageSize;
        }
        public void FirstPage()
        {
            currentPage = 1;
        }

        public void GoToPage(int page)
        {
            currentPage = page;
        }

        public void LastPage()
        {
            currentPage = data.Count()/pageSize;
        }

        public void NextPage()
        {
            currentPage = currentPage+1;
            if(pageSize*currentPage > data.Count())
            {
            throw new System.InvalidOperationException();
            }
            
        }

        public void PrevPage()
        {
            currentPage = currentPage-1;
            if(pageSize*currentPage == 0)
            {
            throw new System.InvalidOperationException();
            }
        }

        public IEnumerable<string> GetVisibleItems()
        { 
            //IEnumerable<string> auxiliar = new string[]{};
            //auxiliar = data;
            /*if (data.Count()/pageSize == currentPage){
                if((data.Count()% 2) == 0)
                {
                    auxiliar = data.Skip(((currentPage-1)*pageSize)).Take(pageSize);
                }
                else
                {
                    auxiliar = data.Skip(((currentPage-1)*pageSize)+1).Take(pageSize);
                }
                
            }
            else{
                auxiliar=data.Skip((currentPage-1)*pageSize).Take(pageSize);
            }*/
            return data.Skip((currentPage-1)*pageSize).Take(pageSize);
        }

        public int CurrentPage()
        {
            throw new System.NotImplementedException();
        }

        public int Pages()
        {
            throw new System.NotImplementedException();
        }
    }
}