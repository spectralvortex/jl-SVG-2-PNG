using Microsoft.Win32;
using Svg;
using System.Drawing;
using System.Drawing.Imaging;

namespace jl_SVG_2_PNG_
{
    internal class SVG2PNG_converter
    {

        static internal void Convert2PNG(string strSVG)
        {
            // Check if the text is a valid SVG -> simple check if it starts with <svg and ends with </svg>.
            if (!strSVG.StartsWith("<svg") && !strSVG.EndsWith("</svg>"))
            {
                // Show a message box if the text is not a valid SVG.
                System.Windows.MessageBox.Show("The text is not a valid SVG.", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return;
            }

            // Load the SVG text to a SVG document
            SvgDocument svgDocument = SvgDocument.FromSvg<SvgDocument>(strSVG);

            // Get the output size from the SVG document
            int width = (int)svgDocument.Width.Value;
            int height = (int)svgDocument.Height.Value;

            // Create a bitmap to render the SVG
            Bitmap bitmap = new Bitmap(width, height);

            // Render the SVG to the bitmap
            svgDocument.Draw(bitmap);

            // Show a dialog box to save the PNG file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG files|*.png";
            saveFileDialog.Title = "Save the PNG file";
            saveFileDialog.ShowDialog();

            // Save the bitmap as a PNG file
            string pngFilePath = saveFileDialog.FileName;
            bitmap.Save(pngFilePath, ImageFormat.Png);

        }

    }
}
