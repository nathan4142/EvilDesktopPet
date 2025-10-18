using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EvilDesktopPet
{
    /// <summary>
    /// Interaction logic for ShopWindow.xaml
    /// </summary>
    public partial class ShopWindow : Window
    {
        public ShopWindow()
        {
            InitializeComponent();

            StackPanel panel = new StackPanel
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            #region TextBlocks
            TextBlock prompt = new TextBlock
            {
                Text = "Welcome to the shop!",
                FontSize = 25
            };


            TextBlock foodTxt = new TextBlock
            {
                Text = "Food",
                FontSize = 18,
                HorizontalAlignment = HorizontalAlignment.Center

            };

            TextBlock drinkTxt = new TextBlock
            {
                Text = "Drinks",
                FontSize = 18,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            TextBlock toysTxt = new TextBlock
            {
                Text = "Toys",
                FontSize = 18,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            #endregion
            #region StackPanels
            //Declarations
            UniformGrid shopCategoriesTxt = new UniformGrid { Width = 800, Rows = 1, HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch};

            //Adding to stack panels
            panel.Children.Add(prompt);

            shopCategoriesTxt.Children.Add(foodTxt);
            shopCategoriesTxt.Children.Add(drinkTxt);
            shopCategoriesTxt.Children.Add(toysTxt);

            panel.Children.Add(shopCategoriesTxt);
            #endregion
            #region Other Controls

            #endregion





            ShopWindowGrid.Children.Add(panel);
        }
    }
}
