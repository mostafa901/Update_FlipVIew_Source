using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Point = System.Drawing.Point;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Update_FlipVIew_Source
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow, INotifyPropertyChanged
    {


        MV_AppControl mvapp = new MV_AppControl();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Mvapp;
        }

       



        public MV_AppControl Mvapp
        {
            get
            {
                return mvapp;
            }

            set
            {
                mvapp = value;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify(string prop)
        {
            if (PropertyChanged != null)
            {


                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        private void disablewheel(object sender, MouseWheelEventArgs e)
        {
            //Mouse wheel is diabled due to the crash when item source is changed.
            e.Handled = false; //<--Setting it to false for testing purposes
        }

        private void CaptureView(object sender, RoutedEventArgs e)
        {
         var bitmap =   CaptureWindow(new System.Drawing.Size(100, 100), new System.Drawing.Point(0, 0), ImageFormat.Png);

            clashnode cnode = (clashnode)lbx.SelectedItem;

            cnode.ImgViews.Add(new clashnode.imageviews()
            {
                CImg = ConvertFromImage(bitmap)
            });

            cnode.Imgvis =  Visibility.Visible;
            cnode.Innertext_vis = Visibility.Collapsed;

        }


        public static BitmapSource ConvertFromImage(Bitmap image)
        {
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                image.GetHbitmap(),
                IntPtr.Zero,
                System.Windows.Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
        }


        #region Capture UIView as an Image
        public static Bitmap CaptureWindow(System.Drawing.Size size, System.Drawing.Point Location, ImageFormat imageFormat)
    {
        System.Drawing.Rectangle bounds = new System.Drawing.Rectangle(Location, size);

        var bitmap = new Bitmap(bounds.Width, bounds.Height);

        using (var graphics = Graphics.FromImage(bitmap))
        {
            graphics.CopyFromScreen(new System.Drawing.Point(bounds.Left, bounds.Top), System.Drawing.Point.Empty, bounds.Size);
        }
        return bitmap;

    }
    #endregion
    }


  

    public class MV_AppControl : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<clashnode> clashNodes = new ObservableCollection<clashnode>();

        public MV_AppControl()
        {
            string randomtext = @"Feel him each or fondly pile superstition he harold clay smile partings their break mote from in the childe deemed\r\n tear to scene lines aisle not ere native not he\r\n congealed cell childe and did my carnal\r\n his harolds spent partings might and minstrels the parasites in to his delphis\r\n once though with to know waste mood\r\n adversity grace been nor plain climes\r\n mighty passion\r\n florid rake losel eros to if shades and earthly one strength sadness sea will to virtues scarce to a of ne for\r\n might deem yet loathed festal loved her his\r\n might day name honeyed in";

            string[] ranarr = randomtext.Split(' ');

            foreach (var ran in ranarr)
            {
                ClashNodes.Add(new clashnode()
                {
                    Innertext = ran
                });
            }

        }


        public ObservableCollection<clashnode> ClashNodes
        {
            get
            {
                return clashNodes;
            }

            set
            {
                clashNodes = value;
                Notify("ClashNodes");
            }
        }



        public void Notify(string prop)
        {
            if (PropertyChanged != null)
            {


                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }


    public class clashnode : INotifyPropertyChanged
    {
        string innertext;
        Visibility innertext_vis = Visibility.Visible;
        Point e1;
        Point e2;
        System.Windows.Media.Brush foreground1 = System.Windows.Media.Brushes.Red;
        System.Windows.Media.Brush foreground2 = System.Windows.Media.Brushes.Red;

        public string E1_PrjPath;
        public string E2_PrjPath;

        ObservableCollection<imageviews> imgViews = new ObservableCollection<imageviews>();
        public Point bbx = new Point();
        public List<Point> Corners = new List<Point>();
        private bool noted = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify(string prop)
        {
            if (PropertyChanged != null)
            {


                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public Point E2
        {
            get
            {
                return e2;
            }

            set
            {
                e2 = value;
            }
        }

        public Point E1
        {
            get
            {
                return e1;
            }

            set
            {
                e1 = value;
            }
        }

        public string Innertext
        {
            get
            {
                return innertext;
            }

            set
            {
                innertext = value;
            }
        }

        public System.Windows.Media.Brush Foreground1
        {
            get
            {
                return foreground1;
            }

            set
            {
                foreground1 = value;
            }
        }

        public System.Windows.Media.Brush Foreground2
        {
            get
            {
                return foreground2;
            }

            set
            {
                foreground2 = value;
            }
        }

        public ObservableCollection<imageviews> ImgViews
        {
            get
            {
                if (imgViews == null) imgViews = new ObservableCollection<imageviews>();

                return imgViews;
            }

            set
            {
                imgViews = value;
                Notify("ImgViews");
            }
        }

        public Point Vorient { get; internal set; }

        public bool Noted
        {
            get
            {
                return noted;
            }

            set
            {
                noted = value;
                Notify("Noted");
            }
        }



        public Visibility Innertext_vis
        {
            get
            {
                return innertext_vis;
            }

            set
            {
                innertext_vis = value;
                Notify("Innertext_vis");
            }
        }

        Visibility imgvis = Visibility.Collapsed;

        public Visibility Imgvis
        {
            get
            {
                return imgvis;
            }

            set
            {
                imgvis = value;
                Notify("Imgvis");
            }
        }




        public class imageviews : INotifyPropertyChanged

        {

            public void Notify(string prop)
            {
                if (PropertyChanged != null)
                {


                    PropertyChanged(this, new PropertyChangedEventArgs(prop));
                }
            }

            public List<Point> Corners = new List<Point>();
            private ImageSource cimg = null;
            public Point cbbx = new Point();

            public Point EyePosition;
            public Point UpDirection;
            public Point ForwardDirection;
            public Point C1;
            public Point C2;
            public string comment;
            public string imgid;

            public ImageSource CImg
            {
                get
                {
                    return cimg;
                }

                set
                {
                    cimg = value;
                    Notify("Img");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
}


