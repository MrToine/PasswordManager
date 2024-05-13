using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using PasswordClass;
using System.Windows.Controls;
using PasswordManager;
using System.Windows.Media;
using System.Windows;

namespace Generator
{
    public class PasswordGenerator
    {
        const string DATA_FILE = "data.json";

        private MainWindow main;

        public PasswordGenerator(MainWindow main)
        {
            this.main = main;
        }

        public string generate_password(int nbChars, bool withSpecial)
        {
            if(nbChars > 0) 
            {

                var random = new Random();
                string randomString = "";

                const string charsSinSpecials = "ABCDEFGHIJLKMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                const string charsWithSpecials = "ABCDEFGHIJLKMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789./*-+=)àç_è-('é&1234567890°+^$ù*!:;,?§%µ£";

                if(withSpecial)
                {
                    randomString = new string(Enumerable.Repeat(charsWithSpecials, nbChars).Select(s => s[random.Next(s.Length)]).ToArray());
                }
                else
                {
                    randomString = new string(Enumerable.Repeat(charsSinSpecials, nbChars).Select(s => s[random.Next(s.Length)]).ToArray());
                }

                return randomString;
            }
            return "Nombre de caractères invalide.";
        }

        public void save_password(string namePassword, string password)
        {
            List<Password> passwordList = new List<Password>();
            if(File.Exists(DATA_FILE))
            {
                string json = File.ReadAllText(DATA_FILE);
                passwordList = JsonConvert.DeserializeObject<List<Password>>(json);
            }

            if(passwordList != null)
            {
                passwordList.Add(new Password { SaveName = namePassword, SavePassword = password });
                string convert_file = JsonConvert.SerializeObject(passwordList, Formatting.Indented);
                File.WriteAllText(DATA_FILE, convert_file);
            }
        }

        public Dictionary<string, string> load_passwords()
        {
            Dictionary<string, string> passwordsList = new Dictionary<string, string>();

            if(File.Exists(DATA_FILE))
            {
                string file = File.ReadAllText(DATA_FILE);
                var passwordsFromFile = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(file);

                foreach(var pass in passwordsFromFile)
                {
                    string saveName = pass["SaveName"];
                    string savePassword = pass["SavePassword"];
                    passwordsList.Add(saveName, savePassword);
                }
            }

            return passwordsList;
        }

        public void print_passwords(Dictionary<string, string> list)
        {
            foreach(var pass in list) 
            {
                TextBlock NameBlock = new TextBlock();
                TextBlock PasswordBlock = new TextBlock();

                string return_name = pass.Key + " : ";
                NameBlock.Text = return_name;
                NameBlock.Foreground = Brushes.Gray;
                NameBlock.FontSize = 18;

                PasswordBlock.Text = pass.Value;
                PasswordBlock.Foreground = Brushes.White;
                PasswordBlock.FontSize = 18;


                Button clipBoardButtonListPanel = new Button();
                clipBoardButtonListPanel.Content = "Press papier";
                clipBoardButtonListPanel.Height = 16;
                clipBoardButtonListPanel.Width = 80;
                clipBoardButtonListPanel.Background = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF775519"));
                clipBoardButtonListPanel.Foreground = System.Windows.Media.Brushes.White;
                clipBoardButtonListPanel.Click += (sender, e) =>
                {
                    Button button = (Button)sender;
                    Clipboard.SetText(pass.Value);
                };
                clipBoardButtonListPanel.FontSize = 8;
                clipBoardButtonListPanel.Margin = new Thickness(0, 0, 0, 8);
                
                main.NameItemsPanel.Children.Add(NameBlock);
                main.PasswordItemsPanel.Children.Add(PasswordBlock);
                main.ButtonsItemPanel.Children.Add(clipBoardButtonListPanel);
            }
        }
    }
}
