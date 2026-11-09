using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Vektor.Views;

public partial class Besked : UserControl
{
    public Besked()
    {
        InitializeComponent();
    }

    public void VisOk(string tekst)
    {
        Ramme.Background = Brushes.White;
        Tekst.Foreground = Brushes.Black;
        Tekst.Text = "✓  " + tekst;
        Visibility = Visibility.Visible;
    }

    public void VisFejl(string tekst)
    {
        Ramme.Background = Brushes.Black;
        Tekst.Foreground = Brushes.White;
        Tekst.Text = "!  " + tekst;
        Visibility = Visibility.Visible;
    }

    public void Skjul()
    {
        Visibility = Visibility.Collapsed;
    }
}
