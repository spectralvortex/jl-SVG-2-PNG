using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace jl_SVG_2_PNG_
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


        private void txtSVG_GotFocus(object sender, RoutedEventArgs e)
        {
            txtSVG.CaretIndex = txtSVG.Text.Length;
        }


        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            SVG2PNG_converter.Convert2PNG(txtSVG.Text);
        }


        private void txtSVG_PreviewDragOverOrEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // If the data is a file drop, check if it is an SVG file, and only allow one file to be dropped.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                // Allow only one file and it must be an SVG file.
                if (files != null && files.Length == 1 && System.IO.Path.GetExtension(files[0]).ToLower() == ".svg")
                {
                    e.Effects = DragDropEffects.Copy;
                }
                else
                {
                    e.Effects = DragDropEffects.None;
                }
            }
            else if (e.Data.GetDataPresent(DataFormats.Text)) // If the data is text, allow it to be dropped. This probably works by deault, but it is good to be explicit.
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = true;
        }


        private void txtSVG_HandleDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null && files.Length > 0 && System.IO.Path.GetExtension(files[0]).ToLower() == ".svg")
                {
                    txtSVG.Text = File.ReadAllText(files[0]);
                }
            }
            else if (e.Data.GetDataPresent(DataFormats.Text))
            {
                txtSVG.Text = (string)e.Data.GetData(DataFormats.Text);
            }

            e.Handled = true;

        }


    }
}