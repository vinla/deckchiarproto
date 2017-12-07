using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckChair.ViewModels
{
    public class ApplicationViewModel
    {
        private readonly CardTypes.IndexViewModel _cardTypesViewModel;

        public ApplicationViewModel()
        {
            _cardTypesViewModel = new ViewModels.CardTypes.IndexViewModel();
        }

        public CardTypes.IndexViewModel CardTypes => _cardTypesViewModel;        
    }
}
