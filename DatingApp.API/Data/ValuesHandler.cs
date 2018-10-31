using System.Collections.Generic;
using System.Linq;
using DatingApp.API.Models;
namespace DatingApp.API.Data
{
    public class ValuesHandler
    {
        public List<Values> GetValues()
        {
            using (DataContext context = new DataContext())
            {
                return (from m in context.Values
                        select m).ToList();
            }
        }
    }
}