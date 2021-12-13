using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paging.Models
{
    public class ColorViewModel
    {

        public string Name { get; set; }
        public string Code { get; set; }

    }


    public class BasePaging
    {
        public int DataCount { get; set; }
        public int PageId { get; set; }
        public int PageCount { get; set; }
        public int Take { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public void GenaratPaging(IQueryable<object> data , int pageId , int take)
        {
            DataCount = data.Count();
            PageId = pageId;
            PageCount = data.Count() / take;
            if (data.Count() % take >0)
                PageCount += 1;

            Take = take;
            StartPage = ((pageId - 2 <= 0) ? 1 : pageId - 2);
            EndPage = ((pageId + 2 > PageCount) ? PageCount : pageId + 2);

        }
    }

    public class ColorAdminFilter : BasePaging
    {
        public List<ColorViewModel> Colors { get; set; }
        public string Filter { get; set; }

    }

}
