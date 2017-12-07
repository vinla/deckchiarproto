using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckChair.ViewModels.CardTypes
{
    public class IndexViewModel
    {
        public IEnumerable<object> CardTypes
        {
            get
            {
                return new[]
                {
                    new { Name = "New type..."},
                    new { Name = "Creature" },
                    new { Name = "Land" },
                    new { Name = "Hero" },
                    new { Name = "Item" },
                    new { Name = "Instant" }
                };
            }
        }
        
    }
}
