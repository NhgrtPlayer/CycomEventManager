using iText.Forms;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private void EventDescription_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Event.Description = EventDescription_TextBox.Text;
        }

        private void StudentsNB_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Event.StudentsNB = StudentsNB_TextBox.Text;
        }

        private void MembersNB_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Event.MembersNB = MembersNB_TextBox.Text;
        }

        private void ExternsNB_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Event.ExternsNB = ExternsNB_TextBox.Text;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void EventStuff_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Event.Stuff = EventStuff_TextBox.Text;
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(PDF_FILE), new PdfWriter(OUTPUT_FILE));
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
            var forms = form.GetFormFields();
            try
            {
                form.GetField("organizer").SetValue(Event.Organizer, pdfDoc.GetDefaultFont(), 14.0f);
                form.GetField("name").SetValue(Event.Name, pdfDoc.GetDefaultFont(), 10.0f);
                form.GetField("date").SetValue(Event.Date, pdfDoc.GetDefaultFont(), 10.0f);
                form.GetField("startHour").SetValue(Event.HourStart);
                form.GetField("startMin").SetValue(Event.MinStart);
                form.GetField("endHour").SetValue(Event.HourEnd);
                form.GetField("endMin").SetValue(Event.MinEnd);
                form.GetField("manager_name").SetValue(Event.ManagerName);
                form.GetField("manager_tel").SetValue(Event.ManagerTel);
                form.GetField("manager_school").SetValue(Event.ManagerSchool);
                form.GetField("tutor_name").SetValue(Event.TutorName);
                form.GetField("tutor_tel").SetValue(Event.TutorTel);
                form.GetField("tutor_school").SetValue(Event.TutorSchool);
                form.GetField("students_nb").SetJustification(1);
                form.GetField("students_nb").SetValue(Event.StudentsNB, pdfDoc.GetDefaultFont(), 14.0f);
                form.GetField("members_nb").SetJustification(1);
                form.GetField("members_nb").SetValue(Event.MembersNB, pdfDoc.GetDefaultFont(), 14.0f);
                form.GetField("extern_nb").SetJustification(1);
                form.GetField("extern_nb").SetValue(Event.ExternsNB, pdfDoc.GetDefaultFont(), 14.0f);
                form.GetField("description").SetValue(Event.Description, pdfDoc.GetDefaultFont(), 10.0f);
                if (RecurrentNo_RadioButton.IsChecked.Value)
                {
                    form.GetField("recurrent_no").SetValue("Yes");
                }
                if (RecurrentYes_RadioButton.IsChecked.Value)
                {
                    form.GetField("recurrent_yes").SetValue("Yes");
                }
                if (AssuranceNo_RadioButton.IsChecked.Value)
                {
                    form.GetField("assurance_no").SetValue("Yes");
                }
                if (AssuranceYes_RadioButton.IsChecked.Value)
                {
                    form.GetField("assurance_yes").SetValue("Yes");
                }
                if (KBRadioButton.IsChecked.Value)
                {
                    form.GetField("place_kb").SetValue("Yes");
                }
                if (VJRadioButton.IsChecked.Value)
                {
                    form.GetField("place_vj").SetValue("Yes");
                }
                if (OTRadioButton.IsChecked.Value)
                {
                    form.GetField("place_other").SetValue("Yes");
                    form.GetField("place_other_name").SetValue(EventOtherPlaceNameTextBox.Text);
                }
                form.GetField("rooms").SetValue(Event.Room, pdfDoc.GetDefaultFont(), 10.0f);
                form.GetField("stuff").SetValue(Event.Stuff, pdfDoc.GetDefaultFont(), 10.0f);
                if (DrinksNone_RadioButton.IsChecked.Value)
                {
                    form.GetField("drink_none").SetValue("Yes");
                }
                if (DrinksAlcoholNo_RadioButton.IsChecked.Value)
                {
                    form.GetField("drink_alcohol_no").SetValue("Yes");
                }
                if (DrinksAlcoholYes_RadioButton.IsChecked.Value)
                {
                    form.GetField("drink_alcohol_yes").SetValue("Yes");
                }
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
            EventManagerName_TextBox.Text = "";
            Event.ManagerName = "";
            EventManagerTel_TextBox.Text = "";
            Event.ManagerTel = "";
            EventManagerSchool_TextBox.Text = "";
            Event.ManagerSchool = "";
            EventTutorName_TextBox.Text = "";
            Event.TutorName = "";
            EventTutorTel_TextBox.Text = "";
            Event.TutorTel = "";
            EventTutorSchool_TextBox.Text = "";
            Event.TutorSchool = "";
            StudentsNB_TextBox.Text = "30";
            MembersNB_TextBox.Text = "20";
            ExternsNB_TextBox.Text = "50";
            EventStuff_TextBox.Text = "Écrans, Ordinateurs, Consoles, Frigo";

            DateTime date = DateTime.Today.AddDays(1);
            while (date.DayOfWeek != DayOfWeek.Friday)
                date = date.AddDays(1);
            EventDatePicker.SelectedDate = date;
        }
    }
}
