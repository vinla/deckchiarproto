using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckChair.Design
{
    public class TextElement : CardElement
    {
        public string Text
        {
            get
            {
                return GetValue<string>(nameof(Text));
            }
            set
            {
                SetValue(nameof(Text), value);
            }
        }
    }
}
