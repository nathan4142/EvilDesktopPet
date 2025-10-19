using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace EvilDesktopPet
{
    /// <summary>
    /// Interaction logic for PetCareWindow.xaml
    /// </summary>
    public partial class PetCareWindow : Window
    {
        private readonly DispatcherTimer tickTimer = new DispatcherTimer();

        ProgressBar foodBar;
        ProgressBar waterBar;
        ProgressBar energyBar;
        TextBlock pps;
        int shopPoints = 0;
        public PetCareWindow()
        {
            InitializeComponent();
            tickTimer.Interval = TimeSpan.FromMilliseconds(1000);
            tickTimer.Tick += AdvanceTick;
            tickTimer.Start();
            Grid mainContainer = new Grid { Margin = new Thickness(0, 70, 0, 5) };

            mainContainer.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            mainContainer.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            mainContainer.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            for (int i = 0; i < 3; i++)
            {
                mainContainer.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            #region TextBlocks


            TextBlock food = new TextBlock
            {
                FontSize = 16,
                Text = "Hunger",
                HorizontalAlignment = HorizontalAlignment.Center
            };
            TextBlock water = new TextBlock
            {
                FontSize = 16,
                Text = "Thirst",
                HorizontalAlignment = HorizontalAlignment.Center
            };
            TextBlock energy = new TextBlock
            {
                FontSize = 16,
                Text = "Energy",
                HorizontalAlignment = HorizontalAlignment.Center
            };

            pps = new TextBlock
            {
                FontSize = 16,
                Text = $"Points per second: {shopPoints}\t\t",
                HorizontalAlignment = HorizontalAlignment.Right
            };

            #endregion

            #region Other Controls
            foodBar = new ProgressBar()
            {
                FlowDirection = FlowDirection.RightToLeft,
                Orientation = Orientation.Vertical,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 80,
                Height = 150,
                Value = 100
            };

            waterBar = new ProgressBar()
            {
                FlowDirection = FlowDirection.RightToLeft,
                Orientation = Orientation.Vertical,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 80,
                Height = 150,
                Value = 100,
                Foreground = new SolidColorBrush(Colors.Blue)
            };

            energyBar = new ProgressBar()
            {
                FlowDirection = FlowDirection.RightToLeft,
                Orientation = Orientation.Vertical,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 80,
                Height = 150,
                Value = 100,
                Foreground = new SolidColorBrush(Colors.Yellow)
            };

            Button shopButton = new Button()
            {
                Width = 100,
                Height = 20,
                Content = "Shop",
                VerticalAlignment = VerticalAlignment.Top
            };
            shopButton.Click += (sender, e) =>
            {
                ShopWindow window = new ShopWindow();
                window.Show();
            };

            #endregion

            #region SettingGrid
            //Top of grid
            Grid.SetRow(shopButton, 0);

            Grid.SetColumn(shopButton, 1);

            // Middle of grid
            Grid.SetRow(foodBar, 1);
            Grid.SetRow(waterBar, 1);
            Grid.SetRow(energyBar, 1);
            Grid.SetColumn(foodBar, 0);
            Grid.SetColumn(waterBar, 1);
            Grid.SetColumn(energyBar, 2);
            // Bottom of the grid
            Grid.SetRow(food, 2);
            Grid.SetRow(water, 2);
            Grid.SetRow(energy, 2);
            Grid.SetColumn(food, 0);
            Grid.SetColumn(water, 1);
            Grid.SetColumn(energy, 2);

            #endregion

            // Add to the Grid
            MainGrid.Children.Add(shopButton);
            mainContainer.Children.Add(food);
            mainContainer.Children.Add(water);
            mainContainer.Children.Add(energy);
            mainContainer.Children.Add(foodBar);
            mainContainer.Children.Add(waterBar);
            mainContainer.Children.Add(energyBar);
            //mainContainer.Children.Add(shopButton);
            MainGrid.Children.Add(mainContainer);
            //MainGrid.Children.Add(points);

        }

        private void AdvanceTick(object? sender, EventArgs e)
        {
            foodBar.Value -= 1;
            waterBar.Value -= 1;
            energyBar.Value -= 1;
            UpdatePoints();
        }

        private void UpdatePoints()
        {
            shopPoints += 1;
            //points.Text = $"Points: {shopPoints}\t\t";
        }

        private void MainGrid_Click(object sender, RoutedEventArgs e)
        {

        }
        /*
        private void catFood(Object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button button && button.Name == "catFood")
            { 
                foodBar.Value += 100;
            }
        }
        */
    }
}
