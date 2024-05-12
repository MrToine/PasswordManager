using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Generator;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PasswordGenerator generator;
        int nbChars = 0;
        bool withSpecials = false;

        public MainWindow()
        {
            InitializeComponent();
            generator = new PasswordGenerator();
        }

        private void SideMenuButtonGenerator(object sender, RoutedEventArgs e)
        {

        }

        private void SideMenuButtonList(object sender, RoutedEventArgs e)
        {

        }

        private void MainCheckPassword6(object sender, RoutedEventArgs e)
        {
            nbChars = 6;
        }

        private void MainCheckPassword8(object sender, RoutedEventArgs e)
        {
            nbChars = 8;
        }

        private void MainCheckPassword12(object sender, RoutedEventArgs e)
        {
            nbChars = 12;
        }

        private void MainCheckPassword16(object sender, RoutedEventArgs e)
        {
            nbChars = 16;
        }

        private void MainCheckPassword18(object sender, RoutedEventArgs e)
        {
            nbChars = 18;
        }

        private void MainCheckSpecialChars(object sender, RoutedEventArgs e)
        {
            withSpecials = true;
        }

        private void MainButtonGenerator(object sender, RoutedEventArgs e)
        {
            ErrorMessage.Content = "";
            if(nbChars >= 6)
            {
                PasswordGenerated.Content = generator.generate_password(nbChars, withSpecials);
                SaveButton.Visibility = Visibility.Visible;
                clipBoard.Visibility = Visibility.Visible;
            }
            else
            {
                ErrorMessage.Content = "Nombre de caractères non valide";
            }
        }

        private void MainButtonSave(object sender, RoutedEventArgs e)
        {
            generator.save_password();
        }
    }
}