using System.Windows.Controls;

namespace Vekto.Views
{
    // Midlertidig side til de sider, der ikke er lavet endnu
    public partial class KommerSenere : UserControl
    {
        public KommerSenere(string title)
        {
            InitializeComponent();
            tbTitle.Text = title;
        }
    }
}
