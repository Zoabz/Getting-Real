using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Markup;
using Vektor.Data;

namespace Vektor;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // Danske datoer og tal
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("da-DK");
        FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement),
            new FrameworkPropertyMetadata(XmlLanguage.GetLanguage("da-DK")));

        string mappe = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Vektor");
        Værksted værksted = new Værksted(new Datafil(Path.Combine(mappe, "data.json")));

        new MainWindow(værksted).Show();
    }
}
