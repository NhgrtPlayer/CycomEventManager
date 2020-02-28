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
        public Event Event = new Event();

        public MainWindow()
        {
            InitializeComponent();
            EventDatePicker.SelectedDate = DateTime.Today;
        }

        private void OtherPlaceRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            EventOtherPlaceNameTextBox.IsEnabled = true;
        }

        private void OtherPlaceRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            EventOtherPlaceNameTextBox.IsEnabled = false;
        }

        private void CheckRoomsButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://chronos.epita.net/");
        }

        private void EventOrganizerTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EventOrganizerTextBox.Text = EventOrganizerTextBox.Text.ToUpper();
            Event.Organizer = EventOrganizerTextBox.Text;
        }

        private void EventNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           Event.Name = EventNameTextBox.Text;
        }

        private void EventDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Event.Date = EventDatePicker.SelectedDate.GetValueOrDefault().Date.ToString("d");
        }

        private void EventRoomTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Event.Room = EventRoomTextBox.Text;
        }

        private void EventHourStart_TextChanged(object sender, TextChangedEventArgs e)
        {
            Event.HourStart = EventHourStart.Text;
        }

        private void EventMinStart_TextChanged(object sender, TextChangedEventArgs e)
        {
            Event.MinStart = EventMinStart.Text;
        }

        private void EventHourEnd_TextChanged(object sender, TextChangedEventArgs e)
        {
            Event.HourEnd = EventHourEnd.Text;
        }

        private void EventMinEnd_TextChanged(object sender, TextChangedEventArgs e)
        {
            Event.MinEnd = EventMinEnd.Text;
        }

        private void EventManagerName_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Event.ManagerName = EventManagerName_TextBox.Text;
        }

        private void EventManagerTel_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Event.ManagerTel = EventManagerTel_TextBox.Text;
        }

        private void EventManagerSchool_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Event.ManagerSchool = EventManagerSchool_TextBox.Text;
        }

        private void EventTutorName_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Event.TutorName = EventTutorName_TextBox.Text;
        }

        private void EventTutorTel_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Event.TutorTel = EventTutorTel_TextBox.Text;
        }

        private void EventTutorSchool_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Event.TutorSchool = EventTutorSchool_TextBox.Text;
        }
        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            /*
             * organizer
             * name
             * date
             * startHour
             * startMin
             * endHour
             * endMin
             * recurrent_yes
             * recurrent_no
             * manager_name
             * manager_tel
             * manager_school
             * tutor_name
             * tutor_tel
             * tutor_school
             * students_nb
             * members_nb
             * extern_nb
             * description
             * assurance_yes
             * assurance_no
             */
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(PDF_FILE), new PdfWriter(OUTPUT_FILE));
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
            var forms = form.GetFormFields();
            try
            {
                form.GetField("organizer").SetValue(Event.Organizer, pdfDoc.GetDefaultFont(), 14.0f);
                form.GetField("name").SetValue(Event.Name);
                form.GetField("date").SetValue(Event.Date);
                form.GetField("startHour").SetValue(Event.HourStart);
                form.GetField("startMin").SetValue(Event.MinStart);
                form.GetField("endHour").SetValue(Event.HourEnd);
                form.GetField("endMin").SetValue(Event.MinEnd);
                form.GetField("recurrent_no").SetValue("Yes");
                form.GetField("description").SetValue(Event.Description, pdfDoc.GetDefaultFont(), 10.0f);
                form.GetField("assurance_yes").SetValue("Yes");
                pdfDoc.Close();
                MessageBox.Show("Génération finie ! Y'a plus qu'à imprimer et signer");
                System.Diagnostics.Process.Start(OUTPUT_FILE);
            }
            catch (Exception)
            {
                MessageBox.Show("Une erreur s'est produite :'(\nREMBOURSEZ !!!");
                throw;
            }
        }

        private void PrefillButton_Click(object sender, RoutedEventArgs e)
        {
            EventOrganizerTextBox.Text = "CYCOM";
            EventNameTextBox.Text = "Cycom Weekly";
            EventDescription_TextBox.Text = "Tournoi Smash";
            KBRadioButton.IsChecked = true;
            EventRoomTextBox.Text = "Amphi 1, 2A et 2B";
            EventHourStart.Text = "17";
            EventMinStart.Text = "00";
            EventHourEnd.Text = "02";
            EventMinEnd.Text = "00";
            EventTutorName_TextBox.Text = "";
            EventTutorTel_TextBox.Text = "";
            EventTutorSchool_TextBox.Text = "";

            DateTime date = DateTime.Today.AddDays(1);
            while (date.DayOfWeek != DayOfWeek.Friday)
                date = date.AddDays(1);
            EventDatePicker.SelectedDate = date;
        }

        private void EventDescription_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Event.Description = EventDescription_TextBox.Text;
        }
    }
}
