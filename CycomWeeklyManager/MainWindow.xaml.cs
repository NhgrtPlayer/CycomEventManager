using iText.Forms;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace CycomWeeklyManager
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string PDF_FILE = "template.pdf";
        public string OUTPUT_FILE = "output.pdf";
        public Event Event { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(PDF_FILE), new PdfWriter(OUTPUT_FILE));
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
            var map = form.GetFormFields();
            pdfDoc.Close();
        }
    }
}
