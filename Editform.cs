using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EgissoApp
{
    public partial class Editform : Form
    {
        public Dictionary<TextBox, PictureBox> selectPictBox;
        public Dictionary<MaskedTextBox, PictureBox> selectPictBoxSnils;
        public Dictionary<DateTimePicker, PictureBox> selectPictBoxDate;
        public Editform()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            label29.Visible = true;
            label29.ForeColor = Color.Black;
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            groupBox3.Enabled = true;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            label29.Visible = true;
            label29.ForeColor = Color.Black;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
        }

        

        private void Editform_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (label29.Visible == true) label29.Visible = false;
            else label29.Visible = true;
        }


        public class Check
        {
            public static bool FamilyName (TextBox textBox)
            {
                return Regex.Match(textBox.Text.ToString(),
                    @"^[а-яА-ЯёЁ][а-яА-ЯёЁ\-\s',.]{0,99}$").Success;
            }
            public static bool Snils (MaskedTextBox maskedTextBox)
            {
                return (maskedTextBox.Text.Length == 14 &&
                    SnilsValidator.SNILSValidate(maskedTextBox.Text));
            }
            public static bool PassSeries(TextBox textBox)
            {
                return Regex.Match(textBox.Text.ToString(),
                        @"^[0-9]{4}$").Success;
            }
            public static bool BirthCertSeries (TextBox textBox)
            {
                return Regex.Match(textBox.Text.ToString(),
                        @"^[IVXLCDM]{1,3}[\-][А-Я]{2}$").Success;
            }
            public static bool DocNumber (TextBox textBox)
            {
                return Regex.Match(textBox.Text.ToString(),
                        @"^[0-9]{6}$").Success;
            }
            public static bool DocIssuer (TextBox textBox)
            {
                return Regex.Match(textBox.Text.ToString(),
                    @"^[а-яА-ЯёЁ][а-яА-ЯёЁ\-\s',.0-9№()\\/]{0,99}$").Success;
            }
        }

        public class SetPict
        {
            public static void HidePictAndToolTip(PictureBox pictureBox)
            {
                ToolTip toolTip = new ToolTip();
                pictureBox.Image = null;
                toolTip.SetToolTip(pictureBox, "");
                toolTip.Active = false;
            }
            static void ShowPictAndToolTip (PictureBox pictureBox, string messageToolTip)
            {
                ToolTip toolTip = new ToolTip();
                pictureBox.Image = Properties.Resources.question;
                toolTip.ToolTipIcon = ToolTipIcon.Warning;
                toolTip.SetToolTip(pictureBox, messageToolTip);
            }
            public static void Checked (PictureBox pictureBox)
            {
                ToolTip toolTip = new ToolTip();
                pictureBox.Image = Properties.Resources.chek;
                toolTip.ToolTipIcon = ToolTipIcon.Info;
                toolTip.SetToolTip(pictureBox, "Поле проверено!");
            }
            public static void ErrorFamName(PictureBox pictureBox)
            {
                ShowPictAndToolTip(pictureBox, "Поле не дожно быть пустым" +
                    "\n и может содержать только \n" +
                    "русские буквы, пробелы, точки,\n" +
                    "тире и апострофы.");
            }
            public static void ErrorPatronymic(PictureBox pictureBox)
            {
                ShowPictAndToolTip(pictureBox, "Поле может быть пустым" +
                    "\n или должно содержать только \n" +
                    "русские буквы, пробелы, точки,\n" +
                    "тире и апострофы.");
            }
            public static void ErrorSnils (PictureBox pictureBox)
            {
                ShowPictAndToolTip(pictureBox, "Поле дожно содежать 11 цифр" +
                "\n или контрольное число СНИЛС не верно!");
            }
            public static void ErrorPassSeries (PictureBox pictureBox)
            {
                ShowPictAndToolTip(pictureBox, "Поле должно содержать только\n" +
                            "четыре цифры.");
            }
            public static void ErrorBirthSeries(PictureBox pictureBox)
            {
                ShowPictAndToolTip(pictureBox, "Поле должно содержать только:\n" +
                            "римская цифра из латинских символов (IVXLCDM)\n" +
                            "тире\n" +
                            "и две заглавные русские буквы!\n" +
                            "(например IV-РУ)");
            }
            public static void ErrorDocNumber(PictureBox pictureBox)
            {
                ShowPictAndToolTip(pictureBox, "Поле должно содержать только\n" +
                            "шесть цифр.");
            }
            public static void ErrorDocIssuer(PictureBox pictureBox)
            {
                ShowPictAndToolTip(pictureBox, "Поле должно содержать\n" +
                    "только русский текст, допускаются также\n" +
                    "пробелы, цифры, точки, запятые, тире,\n" +
                    "круглые скобки, знак №.");
            }
            public static void ErrorDate(PictureBox pictureBox)
            {
                ShowPictAndToolTip(pictureBox, "Проверьте дату!");
            }

        }
        private void FamilyName_recip_KeyUp(object sender, KeyEventArgs e)
        {
            if (Check.FamilyName(sender as TextBox)) SetPict.Checked(pict_Fam_Recip);
            else SetPict.ErrorFamName(pict_Fam_Recip);
        }

        private void Name_recip_KeyUp(object sender, KeyEventArgs e)
        {
            if (Check.FamilyName(sender as TextBox)) SetPict.Checked(pict_Name_Recip);
            else SetPict.ErrorFamName(pict_Name_Recip);
        }

        private void Patronymic_recip_KeyUp(object sender, KeyEventArgs e)
        {
            if (Check.FamilyName(sender as TextBox)
                || (sender as TextBox).Text == "")
                SetPict.Checked(pict_Patronymic_recip);
            else SetPict.ErrorPatronymic(pict_Patronymic_recip);
        }

        private void SNILS_recip_Click(object sender, EventArgs e)
        {
            SNILS_recip.SelectionStart = 0;
        }

        private void SNILS_recip_KeyUp(object sender, KeyEventArgs e)
        {
            if (Check.Snils(sender as MaskedTextBox))
                SetPict.Checked(pict_Snils_Recip);
            else SetPict.ErrorSnils(pict_Snils_Recip);
        }

        private void Gender_recip_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPict.Checked(pict_Gender_Recip);
        }

        private void Doctype_recip_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPict.Checked(pict_Doctype_Recip);
            bool active = true;
            if (doctype_recip.SelectedIndex == 0) active = false;
            doc_IssueDate_recip.Enabled = active;
            doc_IssueDate_recip.Value = new DateTime(1900, 01, 01);
            SetPict.HidePictAndToolTip(pict_doc_IssueDate_recip);
            doc_Series_recip.Enabled = active;
            doc_Series_recip.Text = "";
            SetPict.HidePictAndToolTip(pict_Doc_Series_Recip);
            doc_Number_recip.Enabled = active;
            doc_Number_recip.Text = "";
            SetPict.HidePictAndToolTip(pict_Doc_Number_Recip);
            doc_Issuer_recip.Enabled = active;
            doc_Issuer_recip.Text = "";
            SetPict.HidePictAndToolTip(pict_doc_Issuer_recip);
        }

        private void BirthDate_recip_ValueChanged(object sender, EventArgs e)
        {
            if (BirthDate_recip.Value > new DateTime(1910, 01, 01))
                SetPict.Checked(pict_BirthDate_recip);
            else SetPict.ErrorDate(pict_BirthDate_recip);
        }

        private void Doc_Series_recip_KeyUp(object sender, KeyEventArgs e)
        {
            if (doctype_recip.SelectedIndex == 1)
            {
                if (Check.PassSeries(sender as TextBox))
                    SetPict.Checked(pict_Doc_Series_Recip);
                else SetPict.ErrorPassSeries(pict_Doc_Series_Recip);
            }
            if (doctype_recip.SelectedIndex == 2)
            {
                if (Check.BirthCertSeries(sender as TextBox))
                    SetPict.Checked(pict_Doc_Series_Recip);
                else SetPict.ErrorBirthSeries(pict_Doc_Series_Recip);
            }
        }

        private void Doc_Number_recip_TextChanged(object sender, EventArgs e)
        {
            if (Check.DocNumber(sender as TextBox))
                SetPict.Checked(pict_Doc_Number_Recip);
            else SetPict.ErrorDocNumber(pict_Doc_Number_Recip);
        }

        private void Doc_Issuer_recip_KeyUp(object sender, KeyEventArgs e)
        {
            if (Check.DocIssuer(doc_Issuer_recip))
                SetPict.Checked(pict_doc_Issuer_recip);
            else SetPict.ErrorDocIssuer(pict_doc_Issuer_recip);
        }

        private void doc_IssueDate_recip_ValueChanged(object sender, EventArgs e)
        {
            if (doc_IssueDate_recip.Value > BirthDate_recip.Value)
                SetPict.Checked(pict_doc_IssueDate_recip);
            else SetPict.ErrorDate(pict_doc_IssueDate_recip);
        }



        private void FamilyName_reason_KeyUp(object sender, KeyEventArgs e)
        {
            if (Check.FamilyName(sender as TextBox)) SetPict.Checked(pict_FamilyName_reason);
            else SetPict.ErrorFamName(pict_FamilyName_reason);
        }

        private void Name_reason_KeyUp(object sender, KeyEventArgs e)
        {
            if (Check.FamilyName(sender as TextBox)) SetPict.Checked(pict_Name_reason);
            else SetPict.ErrorFamName(pict_Name_reason);
        }

        private void Patronymic_reason_KeyUp(object sender, KeyEventArgs e)
        {
            if (Check.FamilyName(sender as TextBox)
                || (sender as TextBox).Text == "")
                SetPict.Checked(pict_Patronymic_reason);
            else SetPict.ErrorPatronymic(pict_Patronymic_reason);
        }

        private void SNILS_reason_Click(object sender, EventArgs e)
        {
            SNILS_reason.SelectionStart = 0;
        }

        private void SNILS_reason_KeyUp(object sender, KeyEventArgs e)
        {
            if (Check.Snils(sender as MaskedTextBox))
                SetPict.Checked(pict_SNILS_reason);
            else SetPict.ErrorSnils(pict_SNILS_reason);
        }

        private void Gender_reason_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPict.Checked(pict_Gender_reason);
        }

        private void Doctype_reason_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPict.Checked(pict_doctype_reason);
            bool active = true;
            if (doctype_reason.SelectedIndex == 0) active = false;
            doc_IssueDate_reason.Enabled = active;
            doc_IssueDate_reason.Value = new DateTime(1900, 01, 01);
            SetPict.HidePictAndToolTip(pict_doc_IssueDate_reason);
            doc_Series_reason.Enabled = active;
            doc_Series_reason.Text = "";
            SetPict.HidePictAndToolTip(pict_doc_Series_reason);
            doc_Number_reason.Enabled = active;
            doc_Number_reason.Text = "";
            SetPict.HidePictAndToolTip(pict_doc_Number_reason);
            doc_Issuer_reason.Enabled = active;
            doc_Issuer_reason.Text = "";
            SetPict.HidePictAndToolTip(pict_doc_Issuer_reason);
        }

        private void BirthDate_reason_ValueChanged(object sender, EventArgs e)
        {
            if (BirthDate_reason.Value > new DateTime(1910, 01, 01))
                SetPict.Checked(pict_BirthDate_reason);
            else SetPict.ErrorDate(pict_BirthDate_reason);
        }

        private void doc_IssueDate_reason_ValueChanged(object sender, EventArgs e)
        {
            if (doc_IssueDate_reason.Value > BirthDate_reason.Value)
                SetPict.Checked(pict_doc_IssueDate_reason);
            else SetPict.ErrorDate(pict_doc_IssueDate_reason);
        }

        private void doc_Series_reason_KeyUp(object sender, KeyEventArgs e)
        {
            if (doctype_reason.SelectedIndex == 1)
            {
                if (Check.PassSeries(sender as TextBox))
                    SetPict.Checked(pict_doc_Series_reason);
                else SetPict.ErrorPassSeries(pict_doc_Series_reason);
            }
            if (doctype_reason.SelectedIndex == 2)
            {
                if (Check.BirthCertSeries(sender as TextBox))
                    SetPict.Checked(pict_doc_Series_reason);
                else SetPict.ErrorBirthSeries(pict_doc_Series_reason);
            }
        }

        private void doc_Number_reason_KeyUp(object sender, KeyEventArgs e)
        {
            if (Check.DocNumber(sender as TextBox))
                SetPict.Checked(pict_doc_Number_reason);
            else SetPict.ErrorDocNumber(pict_doc_Number_reason);
        }

        private void doc_Issuer_reason_KeyUp(object sender, KeyEventArgs e)
        {
            if (Check.DocIssuer(doc_Issuer_reason))
                SetPict.Checked(pict_doc_Issuer_reason);
            else SetPict.ErrorDocIssuer(pict_doc_Issuer_reason);
        }

       
    }
}
