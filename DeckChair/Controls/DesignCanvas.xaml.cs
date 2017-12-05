using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeckChair.Controls
{    
    public partial class DesignCanvas : UserControl
    {
        private HighlightAdorner _adorner;
        private ResizeAdorner _resizeAdorner;
        private FrameworkElement _selection;

        public DesignCanvas()
        {
            InitializeComponent();
        }

        public DependencyProperty ElementsProperty = DependencyProperty.Register(nameof(Elements), typeof(IEnumerable<Design.CardElement>), typeof(DesignCanvas));

        public IEnumerable<Design.CardElement> Elements
        {
            get { return (IEnumerable<Design.CardElement>)GetValue(ElementsProperty); }
            set { SetValue(ElementsProperty, value); }
        }

        public DependencyProperty SelectedElementProperty = DependencyProperty.Register(nameof(SelectedElement), typeof(Design.CardElement), typeof(DesignCanvas));

        public Design.CardElement SelectedElement
        {
            get { return (Design.CardElement)GetValue(SelectedElementProperty); }
            set { SetValue(SelectedElementProperty, value); UpdateSelection();  }
        }

        private void ItemMouseEnter(object sender, MouseEventArgs e)
        {
            var item = sender as FrameworkElement;
            _adorner = new HighlightAdorner(item);
            AdornerLayer.GetAdornerLayer(item).Add(_adorner);
        }

        private void ItemMouseLeave(object sender, MouseEventArgs e)
        {
            var item = sender as FrameworkElement;
            AdornerLayer.GetAdornerLayer(item).Remove(_adorner);
        }

        private void UpdateSelection()
        {
            Deselect();

            for (int i = 0; i < itemsHost.Items.Count; i++)
            {
                var uiElement = (FrameworkElement)itemsHost.ItemContainerGenerator.ContainerFromIndex(i);
                if(uiElement.DataContext == SelectedElement)
                {
                    _resizeAdorner = new ResizeAdorner(uiElement);
                    AdornerLayer.GetAdornerLayer(uiElement).Add(_resizeAdorner);
                    _selection = uiElement;
                }
            }                        
        }

        private void Deselect()
        {
            if (_selection != null)
                AdornerLayer.GetAdornerLayer(_selection).Remove(_resizeAdorner);
        }

        private void ItemMouseClick(object sender, MouseButtonEventArgs e)
        {
            var frameworkElement = (sender as FrameworkElement);
            if(frameworkElement != null && _selection != frameworkElement)
                SelectedElement = frameworkElement.DataContext as Design.CardElement;
        }

        private void CanvasClick(object sender, MouseButtonEventArgs e)
        {
            if (sender == e.OriginalSource)
                Deselect();
        }
    }
}
