using System;
using System.Windows;
using System.Collections.Generic;
using System.IO;

namespace PasswordGenerator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           InitializeComponent();
        }
        
        // Global variables
        public string passwdn;

        // Method for button
        private void BtnGenerator_Click(object sender, RoutedEventArgs e)
        {
            int startAscii;
            int endAscii;
            if (All.IsChecked == false && OnlyCapChars.IsChecked == false && OnlyNumbers.IsChecked == true)
            {
                startAscii = 48;
                endAscii = 57;
            }
            else if(All.IsChecked == false && OnlyCapChars.IsChecked == true && OnlyNumbers.IsChecked == false)
            {
                startAscii = 65;
                endAscii = 90;
            }
            else if(All.IsChecked == true && OnlyCapChars.IsChecked == false && OnlyNumbers.IsChecked == false)
            {
                startAscii = 33;
                endAscii = 126;
            }
            List<char> chars = new List<char>();

            var rd = new Random();

            // Getting password length
            int length = int.Parse(PasswdLength.Text);
            char[] pwd = new char[length];

            // Getting symbols from ascii codes
            for (int i = 33; i < 123; i++)
            {
                chars.Add(Convert.ToChar(i));
            }

            // Adding random symbols to variable pwd
            for (int i = 0; i < length; i++)
            {
                pwd[i] = chars[rd.Next(0, chars.Count)];
            }

            // Joining symbols from pwd and displaying them
            string pwdStr = new string(pwd);
            passwdn = pwdStr;
            PasswdDisplay.Text = passwdn;

            // Check to save to file
            if (FileSaveCheck.IsChecked == true)
            {
                File.WriteAllText(@"C:/Users/" + Environment.UserName + "/Desktop/Nigga.txt",passwdn);
            }

        }
    }
}
