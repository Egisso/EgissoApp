using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            selectPictBox = new Dictionary<TextBox, PictureBox>
            {
                {FamilyName_recip, pictFamRecip},
                {Name_recip, pictNameRecip},
                {Patronymic_recip, pictPatronymic_recip},
                {doc_Series_recip, pictDocSeriesRecip},
                {doc_Number_recip, pictNumberRecip},
                {doc_Issuer_recip, pictIssuerRecip}
            };
            selectPictBoxSnils = new Dictionary<MaskedTextBox, PictureBox>
            {
                {SNILS_recip, pictSnilsRecip}
            };
            selectPictBoxDate = new Dictionary<DateTimePicker, PictureBox>
            {
                {BirthDate_recip, pictBirthdateRecip},
                {doc_IssueDate_recip, pict_IssueDate_recip}
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            label29.Visible = true;
            label29.ForeColor = Color.Black;
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            groupBox3.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            label29.Visible = true;
            label29.ForeColor = Color.Black;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
        }

        private void doctype_recip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (doctype_recip.SelectedIndex == 0)
            {
                doc_IssueDate_recip.Enabled = false;
                doc_IssueDate_recip.Value = new DateTime(01,01,1900);
                doc_Series_recip.Enabled = false;
                doc_Series_recip.Text = "";
                doc_Number_recip.Enabled = false;
                doc_Number_recip.Text = "";
                doc_Issuer_recip.Enabled = false;
                doc_Issuer_recip.Text = "";
            }
            else
            {
                doc_IssueDate_recip.Enabled = true;
                doc_Series_recip.Enabled = true;
                doc_Number_recip.Enabled = true;
                doc_Issuer_recip.Enabled = true;
            }

        }

        private void Editform_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label29.Visible == true) label29.Visible = false;
            else label29.Visible = true;
        }

        private void doctype_reason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (doctype_recip.SelectedIndex == 0)
            {
                doc_IssueDate_reason.Enabled = false;
                doc_Series_reason.Enabled = false;
                doc_Number_reason.Enabled = false;
                doc_Issuer_reason.Enabled = false;
            }
            else
            {
                doc_IssueDate_reason.Enabled = true;
                doc_Series_reason.Enabled = true;
                doc_Number_reason.Enabled = true;
                doc_Issuer_reason.Enabled = true;
            }
        }

        private void amount_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        bool CtrlV = false;

        private void FIO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V)) CtrlV = true;
        }

        private void FIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            string symbol = e.KeyChar.ToString();
            if (CtrlV) CtrlV = false;
            else if (!Regex.Match(symbol, @"[а-яА-ЯёЁ\-\s\b',.]").Success)
            {
                e.Handled = true;
                TextBox tb = sender as TextBox;
                tb.BackColor = Color.Red;
            }
        }

        private void FIO_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.BackColor = Color.Empty;
        }


        private void FIO_Leave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            PictureBox pb = selectPictBox [tb];
            if (tb == Patronymic_recip && tb.Text == "")
            {
                pb.Image = Properties.Resources.chek;
                toolTip1.SetToolTip(pb, "Поле проверено!");
                return;
            }
            if (Regex.Match(tb.Text.ToString(),
                    @"^[а-яА-ЯёЁ][а-яА-ЯёЁ\-\s',.]*$").Success)
            {
                pb.Image = Properties.Resources.chek;
                toolTip1.SetToolTip(pb, "Поле проверено!");
            }
                
            else
            {
                pb.Image = Properties.Resources.question;
                if (tb == Patronymic_recip)
                toolTip1.SetToolTip(pb, "Поле может быть пустым" +
                    "\n или должно содержать только \n" +
                    "русские буквы, пробелы, точки,\n" +
                    "тире и апострофы.");
                else
                    toolTip1.SetToolTip(pb, "Поле не дожно быть пустым" +
                    "\n и может содержать только \n" +
                    "русские буквы, пробелы, точки,\n" +
                    "тире и апострофы.");
            }
        }

        private void FIO_Enter(object sender, EventArgs e)
        {
            selectPictBox[sender as TextBox].Image = null;
        }

        private void SNILS_Click(object sender, EventArgs e)
        {
            SNILS_recip.SelectionStart = 0;
            if (Patronymic_recip.Text == "")
            {
                pictPatronymic_recip.Image = Properties.Resources.chek;
                toolTip1.SetToolTip(pictPatronymic_recip, "Поле проверено!");
                return;
            }
        }

        private void SNILS_KeyPress(object sender, KeyPressEventArgs e)
        {
            string symbol = e.KeyChar.ToString();
            if (CtrlV) CtrlV = false;
            else if (!Regex.Match(symbol, @"[0-9]").Success)
            {
                e.Handled = true;
                MaskedTextBox mtb = sender as MaskedTextBox;
                mtb.BackColor = Color.Red;
            }
        }

        private void SNILS_Enter(object sender, EventArgs e)
        {
            selectPictBoxSnils[sender as MaskedTextBox].Image = null;
        }

        private void SNILS_KeyUp(object sender, KeyEventArgs e)
        {
            MaskedTextBox mtb = sender as MaskedTextBox;
            mtb.BackColor = Color.Empty;
        }

        private void SNILS_Leave(object sender, EventArgs e)
        {
            try
            {
                MaskedTextBox mtb = sender as MaskedTextBox;
                PictureBox pb = selectPictBoxSnils[mtb];
                if (mtb.Text.Length == 14 && 
                    SnilsValidator.SNILSValidate(mtb.Text))
                {
                    pb.Image = Properties.Resources.chek;
                    toolTip1.SetToolTip(pb, "Поле проверено!");
                }
                else
                {
                    pb.Image = Properties.Resources.question;
                    toolTip1.SetToolTip(pb, "Поле дожно содежать 11 цифр" +
                    "\n или СНИЛС не прошел проверку!");
                }
            }
            catch
            {
                MessageBox.Show("Неизвестная ошибка ошибка!\n" +
                    "Удалите номер СНИЛС и введите заново.");
            }
            
        }

        private void SNILS_KeyDown (object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V)) CtrlV = true;
        }

        private void Gender_recip_SelectionChangeCommitted(object sender, EventArgs e)
        {
            pictGenderRecip.Image = Properties.Resources.chek;
        }

        private void doctype_recip_SelectedValueChanged(object sender, EventArgs e)
        {
            pictDocTypeRecip.Image = Properties.Resources.chek;
        }

        private void Dates_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dt = sender as DateTimePicker;
            PictureBox pb = selectPictBoxDate[dt];
            if(dt.Value > new DateTime(1920,01,01))
                pb.Image = Properties.Resources.chek;
            else
            {
                pb.Image = Properties.Resources.question;
                toolTip1.SetToolTip(pb, 
                    "Исправьте дату!");
            }
        }

        private void doc_Series_recip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V)) CtrlV = true;
        }

        private void doc_Series_recip_KeyPress(object sender, KeyPressEventArgs e)
        {
            string symbol = e.KeyChar.ToString();
            TextBox tb = sender as TextBox;
            if (CtrlV) CtrlV = false;
            else if (doctype_recip.SelectedIndex == 1)
            {
                if (!Regex.Match(symbol, @"[\b0-9]").Success)
                {
                    e.Handled = true;
                    tb.BackColor = Color.Red;
                }
            }
            else if (doctype_recip.SelectedIndex == 2)
            {
                if (!Regex.Match(symbol, @"[IVXLCDM\-А-Я\b]").Success)
                {
                    e.Handled = true;
                    tb.BackColor = Color.Red;
                }
            }
                
        }

        private void doc_Series_recip_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.BackColor = Color.Empty;
        }

        private void doc_Series_recip_Leave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            PictureBox pb = selectPictBox[tb];
            if (doctype_recip.SelectedIndex == 1)
            {
                if (Regex.Match(tb.Text.ToString(),
                        @"^[0-9]{4}$").Success)
                {
                    pb.Image = Properties.Resources.chek;
                    toolTip1.SetToolTip(pb, "Поле проверено!");
                }
                else
                {
                    pb.Image = Properties.Resources.question;
                    toolTip1.SetToolTip(pb, "Поле должно содержать только\n" +
                            "четыре цифры.");
                }
            }

            if (doctype_recip.SelectedIndex == 2)
            {
                if (Regex.Match(tb.Text.ToString(),
                        @"^[IVXLCDM]{1,3}[\-][А-Я]{2}$").Success)
                {
                    pb.Image = Properties.Resources.chek;
                    toolTip1.SetToolTip(pb, "Поле проверено!");
                }
                else
                {
                    pb.Image = Properties.Resources.question;
                    toolTip1.SetToolTip(pb, "Поле должно содержать только\n" +
                            "до трех латинских символов (IVXLCDM)\n" +
                            "тире\n" +
                            " и две заглавные русские буквы.");
                }
            }

        }

        private void Doc_Series_recip_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            PictureBox pb = selectPictBox[tb];
            pb.Image = null;
        }

        private void Gender_recip_SelectedValueChanged(object sender, EventArgs e)
        {
            pictGenderRecip.Image = Properties.Resources.chek;
        }

        private void doc_Number_recip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V)) CtrlV = true;
        }

        private void doc_Number_recip_KeyPress(object sender, KeyPressEventArgs e)
        {
            string symbol = e.KeyChar.ToString();
            TextBox tb = sender as TextBox;
            if (!Regex.Match(symbol, @"[\b0-9]").Success)
            {
                e.Handled = true;
                tb.BackColor = Color.Red;
            }
        }

        private void doc_Number_recip_Leave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            PictureBox pb = selectPictBox[tb];
            if (Regex.Match(tb.Text.ToString(),
                    @"^[0-9]{6}$").Success)
            {
                pb.Image = Properties.Resources.chek;
                toolTip1.SetToolTip(pb, "Поле проверено!");
            }
            else
            {
                pb.Image = Properties.Resources.question;
                toolTip1.SetToolTip(pb, "Поле должно содержать только 6 цифр.");
            }
        }

        private void doc_Number_recip_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            PictureBox pb = selectPictBox[tb];
            pb.Image = null;
        }

        private void doc_Issuer_recip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V)) CtrlV = true;
        }

        private void doc_Issuer_recip_KeyPress(object sender, KeyPressEventArgs e)
        {
            string symbol = e.KeyChar.ToString();
            if (CtrlV) CtrlV = false;
            else if (!Regex.Match(symbol, @"[а-яА-ЯёЁ\-\s\b',.()0-9№\\/]").Success)
            {
                e.Handled = true;
                TextBox tb = sender as TextBox;
                tb.BackColor = Color.Red;
            }
        }

        private void doc_Issuer_recip_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.BackColor = Color.Empty;
        }

        private void doc_Issuer_recip_Leave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            PictureBox pb = selectPictBox[tb];
            if (Regex.Match(tb.Text.ToString(),
                    @"^[а-яА-ЯёЁ\-\s',.()0-9№\\/]+$").Success)
            {
                pb.Image = Properties.Resources.chek;
                toolTip1.SetToolTip(pb, "Поле проверено!");
            }
            else
            {
                pb.Image = Properties.Resources.question;
                toolTip1.SetToolTip(pb, "Поле должно содержать\n" +
                    "только русский текст, допускаются также\n" +
                    "пробелы, цифры, точки, запятые, тире,\n" +
                    "круглые скобки, знак №.");
            }
        }

        private void doc_Issuer_recip_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            PictureBox pb = selectPictBox[tb];
            pb.Image = null;
        }
    }
}
