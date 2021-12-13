using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Paging.Models;

namespace Paging.Services
{


    public interface IColorService
    {
        ColorAdminFilter GetColorForAdmin(int pageid , int take , string filter);
    }

    public class ColorService:IColorService
    {
        private readonly coloreContext _context;

        public ColorService(coloreContext context)
        {
            _context = context;
        }


        public ColorAdminFilter GetColorForAdmin(int pageid , int take , string filter)
        {
            var result = _context.Clos.Select(c=>new ColorViewModel(){Code = c.Code , Name = c.Name});

            if (!string.IsNullOrWhiteSpace(filter))
            {
                result = result.Where(c => c.Name.Contains(filter));
            }

            var skip = (pageid - 1) * take;

          //  if (take < 1) take = 2;

            var model = new ColorAdminFilter()
            {
                Filter = filter,
                Colors = result.OrderByDescending(c=>c.Name).Skip(skip).Take(take).ToList()

            };

            model.GenaratPaging(result,pageid,take);
            return model;
        }


    }
}
