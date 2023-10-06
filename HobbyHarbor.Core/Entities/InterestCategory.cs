using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyHarbor.Core.Entities
{
    public class InterestCategory
    {
        public int InterestCategoryId {  get; set; }

        public string CategoryName { get; set; }

        public IEnumerable<Interest> Interests { get; set; }
    }
}
