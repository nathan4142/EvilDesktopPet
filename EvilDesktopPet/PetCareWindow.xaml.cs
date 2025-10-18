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

        ProgressBar energyBar;
        public PetCareWindow()
        {
            InitializeComponent();
            tickTimer.Interval = TimeSpan.FromMilliseconds(1000);
            tickTimer.Tick += AdvanceTick;
            tickTimer.Start();
            Grid mainContainer = new Grid { Margin = new Thickness(0, 70, 0, 5) };

            mainContainer.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            mainContainer.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            #region TextBlocks
            for (int i = 0; i < 3; i++)
            {
                mainContainer.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            TextBlock food = new TextBlock
            {
                FontSize = 16,
                Text = "Food",
                HorizontalAlignment = HorizontalAlignment.Center
            };
            TextBlock water = new TextBlock
            {
                FontSize = 16,
                Text = "Water",
                HorizontalAlignment = HorizontalAlignment.Center
            };
            TextBlock energy = new TextBlock
            {
                FontSize = 16,
                Text = "Energy",
                HorizontalAlignment = HorizontalAlignment.Center
            };

            #endregion

            #region Other Controls
            ProgressBar foodBar = new ProgressBar()
            {
                FlowDirection = FlowDirection.RightToLeft,
                Orientation = Orientation.Vertical,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 80,
                Height = 150,
                Value = 75
            };

            ProgressBar waterBar = new ProgressBar()
            {
                FlowDirection = FlowDirection.RightToLeft,
                Orientation = Orientation.Vertical,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 80,
                Height = 150,
                Value = 75,
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

            #endregion

            #region SettingGrid
            // Top of grid
            Grid.SetRow(foodBar, 0);
            Grid.SetRow(waterBar, 0);
            Grid.SetRow(energyBar, 0);
            Grid.SetColumn(foodBar, 0);
            Grid.SetColumn(waterBar, 1);
            Grid.SetColumn(energyBar, 2);
            // Bottom of the grid
            Grid.SetRow(food, 1);
            Grid.SetRow(water, 1);
            Grid.SetRow(energy, 1);
            Grid.SetColumn(food, 0);
            Grid.SetColumn(water, 1);
            Grid.SetColumn(energy, 2);

            #endregion

            // Add to the Grid
            mainContainer.Children.Add(food);
            mainContainer.Children.Add(water);
            mainContainer.Children.Add(energy);
            mainContainer.Children.Add(foodBar);
            mainContainer.Children.Add(waterBar);
            mainContainer.Children.Add(energyBar);

            MainGrid.Children.Add(mainContainer);

        }

        private void AdvanceTick(object? sender, EventArgs e)
        {
            energyBar.Value -= 1;
        }
    }
}
