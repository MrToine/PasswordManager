using System;
using Newtonsoft.Json;
using PasswordClass;

namespace Generator
{
    public class PasswordGenerator
    {
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

        public void save_password()
        {
            Password file = new Password { SaveName = "Test", SavePassword = "mot_de_passe" };
            System.IO.File.WriteAllText(@"data.json", file.ToString());
        }
    }
}
