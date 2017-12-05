using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DeckChair
{
    public class CardTemplateViewModel : Mvvm.ViewModel
    {
        private readonly List<Design.CardElement> _elements;

        public CardTemplateViewModel()
        {
            _elements = new List<Design.CardElement>();
            CreateDefaultData();
        }

        private void CreateDefaultData()
        {
            var textElement = new Design.TextElement
            {
                Text = "This is a test",
                Top = 50,
                Left = 50,
                Width = 100,
                Height = 24,
                ZIndex = 2
            };

            _elements.Add(textElement);

            _elements.Add(new Design.RectangleElement
            {
                Top = 50,
                Left = 50,
                Width = 100,
                Height = 24,
                ZIndex = 1,
                Background = Brushes.Green,
                Border = Brushes.Black,
                BorderWidth = 2f
            });

            _elements.Add(new Design.EllipseElement
            {
                Top = 50,
                Left = 50,
                Width = 100,
                Height = 24,
                ZIndex = 1,
                Background = Brushes.Green,
                Border = Brushes.Red,
                BorderWidth = 1f
            });
        }

        public IEnumerable<Design.CardElement> Elements => _elements;        

        public Design.CardElement SelectedElement
        {
            get { return GetValue<Design.CardElement>(nameof(SelectedElement)); }
            set { SetValue(nameof(SelectedElement), value); }
        }
    }
}
