using System;
using System.Windows;
using System.Collections.Generic;

namespace PasswordGenerator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnGenerator_Click(object sender, RoutedEventArgs e)
        {
            List<char> chars = new List<char>();

            var rd = new Random();

            // Getting password length
            int length = Int32.Parse(PasswdLength.Text);
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
            PasswdDisplay.Text = pwdStr;
        }
    }
}
