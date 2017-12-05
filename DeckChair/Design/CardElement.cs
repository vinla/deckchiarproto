using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeckChair.Mvvm;

namespace DeckChair.Design
{
    public abstract class CardElement : ViewModel
    {
        public double Top
        {
            get { return GetValue<double>(nameof(Top)); }
            set { SetValue(nameof(Top), value); }
        }

        public double Left
        {
            get { return GetValue<double>(nameof(Left)); }
            set { SetValue(nameof(Left), value); }
        }

        public double Width
        {
            get { return GetValue<double>(nameof(Width)); }
            set { SetValue(nameof(Width), value); }
        }
        public double Height
        {
            get { return GetValue<double>(nameof(Height)); }
            set { SetValue(nameof(Height), value); }
        }

        public int ZIndex
        {
            get { return GetValue<int>(nameof(ZIndex)); }
            set { SetValue(nameof(ZIndex), value); }
        }
    }
}
