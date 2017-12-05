using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DeckChair.Design
{
    public abstract class ShapeElement : CardElement
    {
        public Brush Background
        {
            get
            {
                return GetValue<Brush>(nameof(Background));
            }
            set
            {
                SetValue(nameof(Background), value);
            }
        }

        public Brush Border
        {
            get
            {
                return GetValue<Brush>(nameof(Border));
            }
            set
            {
                SetValue(nameof(Border), value);
            }
        }

        public float BorderWidth
        {
            get
            {
                return GetValue<float>(nameof(BorderWidth));
            }
            set
            {
                SetValue(nameof(BorderWidth), value);
            }
        }
    }
}
