using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace EgissoApp
{
    public static class TextBoxExtention
    {
        /// <summary>
        /// Метод не позволит поставить первым небуквенный символ
        /// и позволяет вводить только буквы, пробел, тире.
        /// Использовать в событии KeyPress.
        /// </summary>
        /// <param name="e">Команда с клавиатуры (Просто поставь е).</param>
        public static void InputTexyOnly (this TextBox textBox, KeyPressEventArgs e)
        {
            if (textBox.SelectionStart == 0)
            {
                if (!Regex.Match(e.KeyChar.ToString(), @"[а-яА-Я]").Success)
                {
                    e.Handled = true;
                    textBox.BackColor = Color.Red;
                }
            }

            if (!Regex.Match(e.KeyChar.ToString(), @"[а-яА-Я]").Success &&
                e.KeyChar != 8 && e.KeyChar != 32 && e.KeyChar != 45 &&
                e.KeyChar != 127)
            {
                e.Handled = true;
                textBox.BackColor = Color.Red;
            }
        }

        public static void InputDigitOnly (this MaskedTextBox maskedTextBox, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar == 32) e.KeyChar = (char)8;
                e.Handled = true;
                maskedTextBox.BackColor = Color.Red;
            }

        }

        /// <summary>
        /// Метод меняет цвет с желтого на белый если введен > 1 символа.
        /// Использовать в событии KeyUp.
        /// </summary>
        public static void ChangeBackColor (this TextBox textBox)
        {
            if (textBox.Text.Length > 1) textBox.BackColor = Color.White;
            else textBox.BackColor = Color.Yellow;
        }
    }
}
