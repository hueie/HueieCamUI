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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HueieCamUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void Btn1Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to close this window?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        void Btn2Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to record this window?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                
                double scWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
                double scHeight = System.Windows.SystemParameters.PrimaryScreenHeight;

                MessageBox.Show("T : " + Grid1.Margin.Top + " B : " + (scHeight - Grid1.Margin.Bottom) + " L : " + Grid1.Margin.Left + " R : " + (scWidth-Grid1.Margin.Right));

                Grid3.Margin = new Thickness { Top = -(Grid3.ActualHeight), Bottom = scHeight };
            }
        }

        void Btn3Click(object sender, RoutedEventArgs e)
        {
            
        }



        void Grid1ME(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.SizeAll;
        }
        void Grid1ML(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
        }
        bool _isGrid1DragInProg = false;
        double preposX, preposY, gapX, gapY;
        void Grid1MM(object sender, RoutedEventArgs e)
        {
            if (_isGrid1DragInProg)
            {
                var pos = (Mouse.GetPosition(Application.Current.MainWindow)); //position relative to screen
                gapX = pos.X - preposX;
                gapY = pos.Y - preposY;

                guideline1.Margin = new Thickness { Top = guideline1.Margin.Top + gapY, Bottom = guideline1.Margin.Bottom - gapY, Left = guideline1.Margin.Left + gapX, Right = guideline1.Margin.Right - gapX };
                guideline2.Margin = new Thickness { Top = guideline2.Margin.Top + gapY, Bottom = guideline2.Margin.Bottom - gapY, Left = guideline2.Margin.Left + gapX, Right = guideline2.Margin.Right - gapX };
                guideline3.Margin = new Thickness { Top = guideline3.Margin.Top + gapY, Bottom = guideline3.Margin.Bottom - gapY, Left = guideline3.Margin.Left + gapX, Right = guideline3.Margin.Right - gapX };
                guideline4.Margin = new Thickness { Top = guideline4.Margin.Top + gapY, Bottom = guideline4.Margin.Bottom - gapY, Left = guideline4.Margin.Left + gapX, Right = guideline4.Margin.Right - gapX };
                Grid1.Margin = new Thickness { Top = Grid1.Margin.Top + gapY, Bottom = Grid1.Margin.Bottom - gapY, Left = Grid1.Margin.Left + gapX, Right = Grid1.Margin.Right - gapX };

                btn1.Margin = new Thickness { Top = btn1.Margin.Top + gapY, Bottom = btn1.Margin.Bottom - gapY, Left = btn1.Margin.Left + gapX, Right = btn1.Margin.Right - gapX };
                btn2.Margin = new Thickness { Top = btn2.Margin.Top + gapY, Bottom = btn2.Margin.Bottom - gapY, Left = btn2.Margin.Left + gapX, Right = btn2.Margin.Right - gapX };
                btn3.Margin = new Thickness { Top = btn3.Margin.Top + gapY, Bottom = btn3.Margin.Bottom - gapY, Left = btn3.Margin.Left + gapX, Right = btn3.Margin.Right - gapX };

                preposX = pos.X;
                preposY = pos.Y;
            }
        }
        void Grid1MU(object sender, RoutedEventArgs e)
        {
            _isGrid1DragInProg = false;
            Grid1.ReleaseMouseCapture();
        }
        void Grid1MD(object sender, RoutedEventArgs e)
        {
            var pos = (Mouse.GetPosition(Application.Current.MainWindow)); //position relative to screen
            preposX = pos.X;
            preposY = pos.Y;

            _isGrid1DragInProg = true;
            Grid1.CaptureMouse();
        }


        void Guideline1ME(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.SizeNS;
        }
        void Guideline1ML(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        bool _isRect1DragInProg = false;
        void Guideline1MM(object sender, RoutedEventArgs e)
        {
            if (_isRect1DragInProg)
            {
                var pos = (Mouse.GetPosition(Application.Current.MainWindow)); //position relative to screen
                guideline1.Margin = new Thickness { Top = (pos.Y) - (this.ActualHeight / 2), Bottom = (Grid2.ActualHeight - pos.Y) - (this.ActualHeight / 2), Left = guideline1.Margin.Left, Right = guideline1.Margin.Right };
                Grid1.Margin = new Thickness { Top = (pos.Y), Bottom = Grid1.Margin.Bottom, Left = Grid1.Margin.Left, Right = Grid1.Margin .Right};
            }
        }
        void Guideline1MU(object sender, RoutedEventArgs e)
        {
            _isRect1DragInProg = false;
            guideline1.ReleaseMouseCapture();
        }
        void Guideline1MD(object sender, RoutedEventArgs e)
        {
            _isRect1DragInProg = true;
            guideline1.CaptureMouse();
        }


        bool _isRect2DragInProg = false;
        void Guideline2ME(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.SizeNS;
        }
        void Guideline2ML(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
        }
        void Guideline2MM(object sender, RoutedEventArgs e)
        {
            if (_isRect2DragInProg)
            {
                var pos = (Mouse.GetPosition(Application.Current.MainWindow)); //position relative to screen
                guideline2.Margin = new Thickness { Top = (pos.Y) - (this.ActualHeight / 2), Bottom = (Grid2.ActualHeight - pos.Y) - (this.ActualHeight / 2), Left = guideline2.Margin.Left, Right = guideline2.Margin.Right };
                Grid1.Margin = new Thickness { Top = Grid1.Margin.Top, Bottom = (Grid2.ActualHeight - pos.Y), Left = Grid1.Margin.Left, Right = Grid1.Margin.Right };
            }

        }
        void Guideline2MU(object sender, RoutedEventArgs e)
        {
            _isRect2DragInProg = false;
            guideline2.ReleaseMouseCapture();
        }
        void Guideline2MD(object sender, RoutedEventArgs e)
        {
            _isRect2DragInProg = true;
            guideline2.CaptureMouse();
        }


        bool _isRect3DragInProg = false;
        void Guideline3ME(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.SizeWE;
        }
        void Guideline3ML(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
        }
        void Guideline3MM(object sender, RoutedEventArgs e)
        {
            if (_isRect3DragInProg)
            {
                var pos = (Mouse.GetPosition(Application.Current.MainWindow)); //position relative to screen
                guideline3.Margin = new Thickness { Top = guideline3.Margin.Top, Bottom = guideline3.Margin.Bottom, Left = (pos.X) - (this.ActualWidth / 2), Right = (Grid2.ActualWidth - pos.X) - (this.ActualWidth / 2) };
                Grid1.Margin = new Thickness { Top = Grid1.Margin.Top, Bottom = Grid1.Margin.Bottom, Left = (pos.X), Right = Grid1.Margin.Right };
            }
        }
        void Guideline3MU(object sender, RoutedEventArgs e)
        {
            _isRect3DragInProg = false;
            guideline3.ReleaseMouseCapture();
        }
        void Guideline3MD(object sender, RoutedEventArgs e)
        {
            _isRect3DragInProg = true;
            guideline3.CaptureMouse();
        }

        bool _isRect4DragInProg = false;
        void Guideline4ME(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.SizeWE;
        }
        void Guideline4ML(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
        }
        void Guideline4MM(object sender, RoutedEventArgs e)
        {
            if (_isRect4DragInProg)
            {
                var pos = (Mouse.GetPosition(Application.Current.MainWindow)); //position relative to screen
                guideline4.Margin = new Thickness { Top = guideline4.Margin.Top, Bottom = guideline4.Margin.Bottom, Left = (pos.X) - (this.ActualWidth / 2), Right = (Grid2.ActualWidth - pos.X) - (this.ActualWidth / 2) };
                Grid1.Margin = new Thickness { Top = Grid1.Margin.Top, Bottom = Grid1.Margin.Bottom, Left = Grid1.Margin.Left, Right = (Grid2.ActualWidth - pos.X) };
            }
        }
        void Guideline4MU(object sender, RoutedEventArgs e)
        {
            _isRect4DragInProg = false;
            guideline4.ReleaseMouseCapture();
        }
        void Guideline4MD(object sender, RoutedEventArgs e)
        {
            _isRect4DragInProg = true;
            guideline4.CaptureMouse();
        }



        bool _isGrid3ShowProg = true;
        void Grid3ME(object sender, RoutedEventArgs e)
        {
            double scWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double scHeight = System.Windows.SystemParameters.PrimaryScreenHeight;

            Grid3.Margin = new Thickness { Top = 0, Bottom = scHeight - (Grid3.ActualHeight) };
            
        }
        void Grid3ML(object sender, RoutedEventArgs e)
        {
            double scWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double scHeight = System.Windows.SystemParameters.PrimaryScreenHeight;

            Grid3.Margin = new Thickness { Top = -(Grid3.ActualHeight), Bottom = scHeight };
            
        }
        void Grid3MM(object sender, RoutedEventArgs e)
        {
        }
        void Grid3MU(object sender, RoutedEventArgs e)
        {
        }
        void Grid3MD(object sender, RoutedEventArgs e)
        {
        }

    }
}
