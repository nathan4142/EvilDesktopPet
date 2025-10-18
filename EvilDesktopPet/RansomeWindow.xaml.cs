using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EvilDesktopPet
{
    /// <summary>
    /// Interaction logic for RansomeWindow.xaml
    /// </summary>
    public partial class RansomeWindow : Window
    {
        public RansomeWindow()
        {
            // First Name
            // Last Name
            // Expiration Date (MM/YY)
            // CVC
            // Billing Address
            // City
            // State
            // Zipcode
            InitializeComponent();

            StackPanel panel = new StackPanel
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            TextBlock prompt = new TextBlock
            {
                Text = "I will not close unless you give me $3.00",
                FontSize = 18
            };
            #region CreditCard Info
            StackPanel ccPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5, 0, 5) };

            TextBlock cc = new TextBlock
            {
                FontSize = 16,
                Text = "Card Number"
            };
            
            TextBox creditNum = new TextBox
            {
                Width = 200,
                Height = 30,
                FontSize = 16,
                VerticalContentAlignment = VerticalAlignment.Center,
                MaxLength = 19,
            };
            creditNum.TextChanged += (sender, e) =>
            {
                TextBox tb = sender as TextBox;
                string text = tb.Text.Replace("-", ""); // remove existing slash

                if (text.Length > 16)
                    text = text.Substring(0, 16);
                string formatted = "";
                for (int i = 0; i < text.Length; i++)
                {
                    if (i > 0 && i % 4 == 0)
                    {
                        formatted += "-";
                    }
                    formatted += text[i];
                }
                tb.Text = formatted;
                tb.CaretIndex = tb.Text.Length;
            };

            ccPanel.Children.Add(cc);
            ccPanel.Children.Add(creditNum);

            #endregion
            TextBox validThrough = new TextBox
            {
                Width = 60,
                Height = 30,
                FontSize = 16,
                VerticalContentAlignment = VerticalAlignment.Center,
                MaxLength = 5
            };
            validThrough.TextChanged += (sender, e) =>
            {
                TextBox tb = sender as TextBox;
                string text = tb.Text.Replace("/", ""); // remove existing slash

                if (text.Length > 4)
                    text = text.Substring(0, 4);

                if (text.Length >= 3)
                    tb.Text = text.Insert(2, "/"); // insert slash after 2 digits
                else
                    tb.Text = text;

                tb.CaretIndex = tb.Text.Length; // move cursor to end
            };
            //for push
            TextBox wackyNum = new TextBox
            {
                Width = 60,
                Height = 30,
                FontSize = 16,
                VerticalContentAlignment = VerticalAlignment.Center,
                MaxLength = 3
            };

            creditNum.PreviewTextInput += OnlyNum;
            validThrough.PreviewTextInput += OnlyNum;
            wackyNum.PreviewTextInput += OnlyNum;


            panel.Children.Add(prompt);
            panel.Children.Add(ccPanel);
            panel.Children.Add(validThrough);
            panel.Children.Add(wackyNum);
            MainGrid.Children.Add(panel);
        }

        private void OnlyNum(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[0-9]+$");
        }

    }
}
