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
        private int nbChars = 0;
        private string password = "";
        bool withSpecials = false;

        public MainWindow()
        {
            InitializeComponent();
            GeneratorPanel.Visibility = Visibility.Visible;
            PasswordsList.Visibility = Visibility.Hidden;

            generator = new PasswordGenerator(this);
        }

        private void SideMenuButtonGenerator(object sender, RoutedEventArgs e)
        {
            GeneratorPanel.Visibility = Visibility.Visible;
            PasswordsList.Visibility = Visibility.Hidden;
            FormPanel.Visibility = Visibility.Hidden;
            ErrorMessage.Visibility = Visibility.Hidden;
            PasswordGenerated.Visibility = Visibility.Hidden;
        }

        private void SideMenuButtonList(object sender, RoutedEventArgs e)
        {
            GeneratorPanel.Visibility = Visibility.Hidden;

            FormPanel.Visibility = Visibility.Hidden;
            ErrorMessage.Visibility = Visibility.Hidden;
            ErrorMessage.Visibility = Visibility.Hidden;
            PasswordGenerated.Visibility = Visibility.Hidden;

            PasswordsList.Visibility = Visibility.Visible;
            generator.print_passwords(generator.load_passwords());
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
                password = generator.generate_password(nbChars, withSpecials);
                PasswordGenerated.Content = password;
                SaveButton.Visibility = Visibility.Visible;
                clipBoard.Visibility = Visibility.Visible;
            }
            else
            {
                ErrorMessage.Content = "Nombre de caractères non valide";
            }
        }

        private void MainButtonClipBoard(object sender, RoutedEventArgs e)
        {
            
        }

        private void MainButtonSave(object sender, RoutedEventArgs e)
        {
            GeneratorPanel.Visibility = Visibility.Hidden;
            FormPanel.Visibility = Visibility.Visible;
        }

        private void FormButtonSave(object sender, RoutedEventArgs e)
        {
            generator.save_password(FormNamePassword.Text, password);
            MessageBox.Show("Le mot de passe a été enregistré avec succès.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
            PasswordGenerated.Content = "Mot de passe sauvegardé !";
            GeneratorPanel.Visibility = Visibility.Visible;
            PasswordsList.Visibility = Visibility.Hidden;
            FormPanel.Visibility = Visibility.Hidden;
            PasswordGenerated.Visibility = Visibility.Hidden;
            ErrorMessage.Visibility = Visibility.Hidden;
        }
    }
}