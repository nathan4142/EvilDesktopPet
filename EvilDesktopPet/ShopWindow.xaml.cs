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

            #region Buttons
            // Food buttons
            Button catFood = new Button
            {
                Content = "Cat food - $1",
                BorderThickness = new Thickness(2),
                Width = 120,
                Height = 30,
                Background = Brushes.PaleVioletRed
            };
            Button chicken = new Button
            {
                Content = "Chicken - $10",
                BorderThickness = new Thickness(2),
                Width = 120,
                Height = 30,
                Background = Brushes.Orange
            };
            Button beef = new Button
            {
                Content = "BEEF - $100",
                BorderThickness = new Thickness(2),
                Width = 120,
                Height = 30,
                Background = Brushes.Purple
            };
            // Food Button events
            catFood.Click += (s, e) =>
            {
                MessageBox.Show("Hackcat doesn't really like cat food...");
            };
            chicken.Click += (s, e) =>
            {
                MessageBox.Show("Hackcat is content.");
            };
            beef.Click += (s, e) =>
            {
                MessageBox.Show("Hackcat is very satisfied!");
            };  
            //Drink buttons
            Button water = new Button
            {
                Content = "Water - $1",
                BorderThickness = new Thickness(2),
                Width = 120,
                Height = 30,
                Background = Brushes.LightBlue
            };
            Button soda = new Button
            {
                Content = "Soda - $50",
                BorderThickness = new Thickness(2),
                Width = 120,
                Height = 30,
                Background = Brushes.Yellow
            };

            Button milk = new Button
            {
                Content = "Milk - $100",
                BorderThickness = new Thickness(2),
                Width = 120,
                Height = 30,
                Background = Brushes.White
            };
            
            //Drink Button events

            //Toy buttons
            Button ball = new Button
            {
                Content = "Ball - $50",
                BorderThickness = new Thickness(2),
                Width = 120,
                Height = 30,
                Background = Brushes.Red
            };

            Button mouseToy = new Button
            {
                Content = "Mouse Toy - $200",
                BorderThickness = new Thickness(2),
                Width = 120,
                Height = 30,
                Background = Brushes.Gray
            };

            Button laserPointer = new Button
            {
                Content = "Laser Pointer - $1000",
                BorderThickness = new Thickness(2),
                Width = 120,
                Height = 30,
                Background = Brushes.Green
            };

            //Toy Button Events
            #endregion
            #region TextBlocks
            TextBlock prompt = new TextBlock
            {
                Text = "Welcome to the shop!",
                FontSize = 25,
                HorizontalAlignment = HorizontalAlignment.Center
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
            UniformGrid itemsList = new UniformGrid { Width = 800, Rows = 1, HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch };
            StackPanel foodItems = new StackPanel { VerticalAlignment = VerticalAlignment.Center, Orientation = Orientation.Vertical };
            StackPanel drinkItems = new StackPanel { VerticalAlignment = VerticalAlignment.Center, Orientation = Orientation.Vertical };
            StackPanel toyItems = new StackPanel { VerticalAlignment = VerticalAlignment.Center, Orientation = Orientation.Vertical };
            itemsList.Children.Add(foodItems);
            itemsList.Children.Add(drinkItems);
            itemsList.Children.Add(toyItems);

            //Adding to food items
            foodItems.Children.Add(catFood);
            foodItems.Children.Add(chicken);
            foodItems.Children.Add(beef);

            //Adding to drink items
            drinkItems.Children.Add(water);
            drinkItems.Children.Add(soda);
            drinkItems.Children.Add(milk);

            //Adding to toy items
            toyItems.Children.Add(ball);
            toyItems.Children.Add(mouseToy);
            toyItems.Children.Add(laserPointer);
            //Adding to stack panels
            panel.Children.Add(prompt);

            shopCategoriesTxt.Children.Add(foodTxt);
            shopCategoriesTxt.Children.Add(drinkTxt);
            shopCategoriesTxt.Children.Add(toysTxt);
            
            panel.Children.Add(shopCategoriesTxt);
            #endregion
            #region Other Controls

            #endregion



            panel.Children.Add(itemsList);
            ShopWindowGrid.Children.Add(panel);


        }
        
    }
}
