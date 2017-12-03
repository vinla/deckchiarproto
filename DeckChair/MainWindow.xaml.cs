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

namespace DeckChair
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HighlightAdorner _adorner;
        private ResizeAdorner _resizeAdorner;
        private FrameworkElement _selection;

        public MainWindow()
        {
            InitializeComponent();
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

        private void SelectItem(FrameworkElement element)
        {
            Deselect();
            _resizeAdorner = new ResizeAdorner(element);
            AdornerLayer.GetAdornerLayer(element).Add(_resizeAdorner);
            _selection = element;
        }

        private void Deselect()
        {
            if (_selection != null)
                AdornerLayer.GetAdornerLayer(_selection).Remove(_resizeAdorner);
        }

        private void ItemMouseClick(object sender, MouseButtonEventArgs e)
        {
            SelectItem(sender as FrameworkElement);
        }

        private void CanvasClick(object sender, MouseButtonEventArgs e)
        {
            if(sender == e.OriginalSource)
                Deselect();
        }
    }
}
