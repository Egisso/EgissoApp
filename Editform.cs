using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EgissoApp
{
    public partial class Editform : Form
    {
        public Editform()
        {
            InitializeComponent();
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

            static ToolTip toolTip = new ToolTip();

            static void ShowPictAndToolTip (PictureBox pictureBox, string messageToolTip)
            {
                //ToolTip toolTip = new ToolTip();
                pictureBox.Image = Properties.Resources.question;
                toolTip.ToolTipIcon = ToolTipIcon.Warning;
                toolTip.SetToolTip(pictureBox, messageToolTip);
            }

            public static void Checked (PictureBox pictureBox)
            {
                //ToolTip toolTip = new ToolTip();
                pictureBox.Image = Properties.Resources.chek;
                toolTip.ToolTipIcon = ToolTipIcon.Info;
                toolTip.SetToolTip(pictureBox, "Поле проверено!");
                pictureBox.Tag = 1;
            }
            public static void ErrorFamName(PictureBox pictureBox)
            {
                ShowPictAndToolTip(pictureBox, "Поле не дожно быть пустым" +
                    "\n и может содержать только \n" +
                    "русские буквы, пробелы, точки,\n" +
                    "тире и апострофы.");
                pictureBox.Tag = 0;
            }
            public static void ErrorPatronymic(PictureBox pictureBox)
            {
                ShowPictAndToolTip(pictureBox, "Поле может быть пустым" +
                    "\n или должно содержать только \n" +
                    "русские буквы, пробелы, точки,\n" +
                    "тире и апострофы.");
                pictureBox.Tag = 0;
            }
            public static void ErrorSnils (PictureBox pictureBox)
            {
                ShowPictAndToolTip(pictureBox, "Поле дожно содежать 11 цифр" +
                "\n или контрольное число СНИЛС не верно!");
                pictureBox.Tag = 0;
            }

            public static void ErrorGenderAndDoctype(PictureBox pictureBox)
            {
                ShowPictAndToolTip(pictureBox, "Выберите значение из списка!");
                pictureBox.Tag = 0;
            }

            public static void ErrorPassSeries (PictureBox pictureBox)
            {
                ShowPictAndToolTip(pictureBox, "Поле должно содержать только\n" +
                            "четыре цифры.");
                pictureBox.Tag = 0;
            }
            public static void ErrorBirthSeries(PictureBox pictureBox)
            {
                ShowPictAndToolTip(pictureBox, "Поле должно содержать только:\n" +
                            "римская цифра из латинских символов (IVXLCDM)\n" +
                            "тире\n" +
                            "и две заглавные русские буквы!\n" +
                            "(например IV-РУ)");
                pictureBox.Tag = 0;
            }
            public static void ErrorDocNumber(PictureBox pictureBox)
            {
                ShowPictAndToolTip(pictureBox, "Поле должно содержать только\n" +
                            "шесть цифр.");
                pictureBox.Tag = 0;
            }
            public static void ErrorDocIssuer(PictureBox pictureBox)
            {
                ShowPictAndToolTip(pictureBox, "Поле должно содержать\n" +
                    "только русский текст, допускаются также\n" +
                    "пробелы, цифры, точки, запятые, тире,\n" +
                    "круглые скобки, знак №.");
                pictureBox.Tag = 0;
            }
            public static void ErrorDate(PictureBox pictureBox)
            {
                ShowPictAndToolTip(pictureBox, "Проверьте дату!");
                pictureBox.Tag = 0;
            }

            public static void ErrorAmount(PictureBox pictureBox)
            {
                ShowPictAndToolTip(pictureBox, "Проверьте сумму!");
                pictureBox.Tag = 0;
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
            if (Patronymic_recip.Text == "") SetPict.Checked(pict_Patronymic_recip);
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
            if (Patronymic_reason.Text == "") SetPict.Checked(pict_Patronymic_reason);
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

        private void decision_date_ValueChanged(object sender, EventArgs e)
        {
            if (decision_date.Value > BirthDate_recip.Value)
                SetPict.Checked(pict_decision_date);
            else SetPict.ErrorDate(pict_decision_date);
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            if (dateStart.Value > BirthDate_recip.Value)
                SetPict.Checked(pict_dateStart);
            else SetPict.ErrorDate(pict_dateStart);
        }

        private void dateFinish_ValueChanged(object sender, EventArgs e)
        {
            if (dateFinish.Value > dateStart.Value)
                SetPict.Checked(pict_dateFinish);
            else SetPict.ErrorDate(pict_dateFinish);
        }

        private void amount_ValueChanged(object sender, EventArgs e)
        {
            if (amount.Value >= 0) SetPict.Checked(pict_amount);
            else SetPict.ErrorAmount(pict_amount);
        }



        private void Button1_Click(object sender, EventArgs e)
        {
            bool error = false;

            if(radioButton1.Checked == true || radioButton2.Checked == true)
            {
                if (pict_Fam_Recip.Tag.ToString() == "0") { SetPict.ErrorFamName(pict_Fam_Recip); error = true; }
                if (pict_Name_Recip.Tag.ToString() == "0") { SetPict.ErrorFamName(pict_Name_Recip); error = true; }
                if (pict_Patronymic_recip.Tag.ToString() == "0") { SetPict.ErrorPatronymic(pict_Patronymic_recip); error = true; }
                if (pict_Snils_Recip.Tag.ToString() == "0") { SetPict.ErrorSnils(pict_Snils_Recip); error = true; }
                if (pict_Gender_Recip.Tag.ToString() == "0") { SetPict.ErrorGenderAndDoctype(pict_Gender_Recip); error = true; }
                if (pict_BirthDate_recip.Tag.ToString() == "0") { SetPict.ErrorDate(pict_BirthDate_recip); error = true; }
                if (pict_Doctype_Recip.Tag.ToString() == "0") { SetPict.ErrorGenderAndDoctype(pict_Doctype_Recip); error = true; }
                if(doctype_recip.SelectedIndex != 0)
                {
                    if (pict_doc_IssueDate_recip.Tag.ToString() == "0") { SetPict.ErrorDate(pict_doc_IssueDate_recip); error = true; }
                    if (pict_Doc_Series_Recip.Tag.ToString() == "0") 
                    { 
                        if(doctype_recip.SelectedIndex == 1) SetPict.ErrorPassSeries(pict_Doc_Series_Recip); error = true;
                        if (doctype_recip.SelectedIndex == 2) SetPict.ErrorBirthSeries(pict_Doc_Series_Recip); error = true;
                    }
                    if (pict_Doc_Number_Recip.Tag.ToString() == "0") { SetPict.ErrorDocNumber(pict_Doc_Number_Recip); error = true; }
                    if (pict_doc_Issuer_recip.Tag.ToString() == "0") { SetPict.ErrorDocIssuer(pict_doc_Issuer_recip); error = true; }
                }
                if (pict_decision_date.Tag.ToString() == "0") { SetPict.ErrorDate(pict_decision_date); error = true; }
                if (pict_dateStart.Tag.ToString() == "0") { SetPict.ErrorDate(pict_dateStart); error = true; }
                if (pict_dateFinish.Tag.ToString() == "0") { SetPict.ErrorDate(pict_dateFinish); error = true; }
                if (pict_amount.Tag.ToString() == "0") { SetPict.ErrorAmount(pict_amount); error = true; }

                if (radioButton2.Checked == true)
                {
                    if (pict_FamilyName_reason.Tag.ToString() == "0") { SetPict.ErrorFamName(pict_FamilyName_reason); error = true; }
                    if (pict_Name_reason.Tag.ToString() == "0") { SetPict.ErrorFamName(pict_Name_reason); error = true; }
                    if (pict_Patronymic_reason.Tag.ToString() == "0") { SetPict.ErrorPatronymic(pict_Patronymic_reason); error = true; }
                    if (pict_SNILS_reason.Tag.ToString() == "0") { SetPict.ErrorSnils(pict_SNILS_reason); error = true; }
                    if (pict_Gender_reason.Tag.ToString() == "0") { SetPict.ErrorGenderAndDoctype(pict_Gender_reason); error = true; }
                    if (pict_BirthDate_reason.Tag.ToString() == "0") { SetPict.ErrorDate(pict_BirthDate_reason); error = true; }
                    if (pict_doctype_reason.Tag.ToString() == "0") { SetPict.ErrorGenderAndDoctype(pict_doctype_reason); error = true; }
                    if (doctype_reason.SelectedIndex != 0)
                    {
                        if (pict_doc_IssueDate_reason.Tag.ToString() == "0") { SetPict.ErrorDate(pict_doc_IssueDate_reason); error = true; }
                        if (pict_doc_Series_reason.Tag.ToString() == "0")
                        {
                            if (doctype_reason.SelectedIndex == 1) SetPict.ErrorPassSeries(pict_doc_Series_reason); error = true;
                            if (doctype_reason.SelectedIndex == 2) SetPict.ErrorBirthSeries(pict_doc_Series_reason); error = true;
                        }
                        if (pict_doc_Number_reason.Tag.ToString() == "0") { SetPict.ErrorDocNumber(pict_doc_Number_reason); error = true; }
                        if (pict_doc_Issuer_reason.Tag.ToString() == "0") { SetPict.ErrorDocIssuer(pict_doc_Issuer_reason); error = true; }
                    }
                    if (pict_decision_date.Tag.ToString() == "0") { SetPict.ErrorDate(pict_decision_date); error = true; }
                    if (pict_dateStart.Tag.ToString() == "0") { SetPict.ErrorDate(pict_dateStart); error = true; }
                    if (pict_dateFinish.Tag.ToString() == "0") { SetPict.ErrorDate(pict_dateFinish); error = true; }
                    if (pict_amount.Tag.ToString() == "0") { SetPict.ErrorAmount(pict_amount); error = true; }

                }

                if (error) MessageBox.Show("Есть ошибки! Исправьте!");
                else MessageBox.Show("Ошибок нет!");
            }

        }

    }
}
