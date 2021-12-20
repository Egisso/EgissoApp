using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EgissoApp
{
    public class Mera
    {
        public string RecType = "";
        public string assignmentFactUuid = "";
        public string LMSZID = "";
        public string categoryID = "";
        public string ONMSZCode = "";
        public string LMSZProviderCode = "";
        public string providerCode = "";
        public string SNILS_recip = "";
        public string FamilyName_recip = "";
        public string Name_recip = "";
        public string Patronymic_recip = "";
        public string Gender_recip = "";
        public string BirthDate_recip = "";
        public string doctype_recip = "";
        public string doc_Series_recip = "";
        public string doc_Number_recip = "";
        public string doc_IssueDate_recip = "";
        public string doc_Issuer_recip = "";
        public string SNILS_reason = "";
        public string FamilyName_reason = "";
        public string Name_reason = "";
        public string Patronymic_reason = "";
        public string Gender_reason = "";
        public string BirthDate_reason = "";
        public string doctype_reason = "";
        public string doc_Series_reason = "";
        public string doc_Number_reason = "";
        public string doc_IssueDate_reason = "";
        public string doc_Issuer_reason = "";
        public string decision_date = "";
        public string dateStart = "";
        public string dateFinish = "";
        public string usingSign = "";
        public string criteria = "";
        public string criteriaCode = "";
        public string FormCode = "";
        public string amount = "";
        public string measuryCode = "";
        public string monetization = "";
        public string content = "";
        public string comment = "";
        public string equivalentAmount = "";

        public void SetField(string name, string value)
        {
            var field = typeof(Mera).GetField(name);
            field.SetValue(this, value);
        }

        public string[] MassivForWrite()
        {
            System.Reflection.FieldInfo[] fi = this.GetType().GetFields();
            string[] str = new string[fi.Length];
            int i = 0;
            while (i < fi.Length)
            {
                str[i] = fi[i].GetValue(this).ToString();
                i++;
            }
            return str;
        }

        public bool TestFact()
        {
            bool check = true;
            StringBuilder message = new StringBuilder();
            RecType = "Fact";
            assignmentFactUuid = "";
            if (!(LMSZID == "d8a8d780-d3b4-42f3-91f6-9fe7374ce1f9" &&
               categoryID == "2e89c6ec-0297-4620-9d56-cca14bbc799b" ||
               LMSZID == "4115e27f-bbd7-403e-bdf9-1f4027c9b8d0" &&
               categoryID == "e655dfc6-7492-46ed-ada3-fe4809e4da88"))
            {
                check = false;
                message.Append("Ошибка в полях LMSZID (Код меры), " +
                    "или categoryID (Категория меры)!\n");
            }
            ONMSZCode = "0963.000001";
            LMSZProviderCode = "";
            providerCode = "";
            if (SNILS_recip.Length != 14 || !SnilsValidator.SNILSValidate(SNILS_recip))
            {
                check = false;
                message.Append("Ошибка в поле SNILS_recip (Снилс получателя)!\n");
            }
            if (!Regex.Match(FamilyName_recip,
                @"^[а-яА-ЯёЁ][а-яА-ЯёЁ\-\s',.]{0,99}$").Success)
            {
                check = false;
                message.Append("Ошибка в поле FamilyName_recip (Фамилия получателя)!\n");
            }
            if (!Regex.Match(Name_recip,
                @"^[а-яА-ЯёЁ][а-яА-ЯёЁ\-\s',.]{0,99}$").Success)
            {
                check = false;
                message.Append("Ошибка в поле Name_recip (Имя получателя)!\n");
            }
            if (Patronymic_recip != "" && !Regex.Match(Patronymic_recip,
                @"^[а-яА-ЯёЁ][а-яА-ЯёЁ\-\s',.]{0,99}$").Success)
            {
                check = false;
                message.Append("Ошибка в поле Patronymic_recip (Отчество получателя)!\n");
            }
            if (Gender_recip != "М" && Gender_recip != "Ж")
            {
                check = false;
                message.Append("Ошибка в поле Gender_recip (Пол получателя)!\n");
            }
            if (!(DateTime.TryParse(BirthDate_recip, out DateTime BirthDate) &&
                BirthDate > new DateTime(1900, 1, 1) &&
                BirthDate < DateTime.Now))
            {
                check = false;
                message.Append("Ошибка в поле BirthDate_recip (Дата рождения получателя)!\n");
            }
            if (!(doctype_recip == "03" || doctype_recip == "05" ||
                doctype_recip == ""))
            {
                check = false;
                message.Append("Ошибка в поле doctype_recip (Тип документа получателя)!\n");
            }
            if (doctype_recip == "03")
            {
                if (!Regex.Match(doc_Series_recip, @"^[0-9]{4}$").Success)
                {
                    check = false;
                    message.Append("Ошибка в поле doc_Series_recip (Серия документа получателя)!\n");
                }
            }
            if (doctype_recip == "05")
            {
                if (!Regex.Match(doc_Series_recip, @"^[IVXLCDM]{1,3}[\-][А-Я]{2}$").Success)
                {
                    check = false;
                    message.Append("Ошибка в поле doc_Series_recip (Серия документа получателя)!\n");
                }
            }
            if (!(doc_Number_recip == "" ||
                Regex.Match(doc_Number_recip, @"^[0-9]{6}$").Success))
            {
                check = false;
                message.Append("Ошибка в поле doc_Number_recip (Номер документа получателя)!\n");
            }
            if (!(DateTime.TryParse(doc_IssueDate_recip, out DateTime doc_IssueDate) &&
                doc_IssueDate > new DateTime(1900, 1, 1) &&
                doc_IssueDate < DateTime.Now))
            {
                check = false;
                message.Append("Ошибка в поле doc_IssueDate_recip (Дата документа получателя)!\n");
            }
            if (DateTime.TryParse(BirthDate_recip, out DateTime BirthDate1) &&
                DateTime.TryParse(doc_IssueDate_recip, out DateTime doc_IssueDate1))
            {
                if (BirthDate1 >= doc_IssueDate1)
                {
                    check = false;
                    message.Append("Дата выдачи документа должна быть больше даты рождения!\n");
                }
            }
            if (!(doc_Issuer_recip == "" ||
                Regex.Match(doc_Issuer_recip,
                @"^[а-яА-ЯёЁ][а-яА-ЯёЁ\-\s',.0-9№()\\/]{0,99}$").Success))
            {
                check = false;
                message.Append("Ошибка в поле doc_Issuer_recip (Кем выдан документ получателя)!\n");
            }
            if (!((doctype_recip == "" &&
                doc_Series_recip == "" &&
                doc_Number_recip == "" &&
                doc_IssueDate_recip == "" &&
                doc_Issuer_recip == "") || (
                doctype_recip != "" &&
                doc_Series_recip != "" &&
                doc_Number_recip != "" &&
                doc_IssueDate_recip != "" &&
                doc_Issuer_recip != "")))
            {
                check = false;
                message.Append("Все поля документа получателя должны быть " +
                    "или пустыми или заполненными!\n");
            }

            if (!(DateTime.TryParse(decision_date, out DateTime dec_date) &&
                    dec_date > new DateTime(1900, 1, 1) &&
                    dec_date < DateTime.Now))
            {
                check = false;
                message.Append("Ошибка в поле decision_date (Дата принятия решения о назначении меры)!\n");
            }
            if (!(DateTime.TryParse(dateStart, out DateTime dateS) &&
                    dateS > new DateTime(1900, 1, 1) &&
                    dateS < DateTime.Now))
            {
                check = false;
                message.Append("Ошибка в поле dateStart (Дата начала периода выплаты)!\n");
            }
            if (!(DateTime.TryParse(dateFinish, out DateTime dateF) &&
                    dateF > new DateTime(1900, 1, 1) &&
                    dateF < DateTime.Now))
            {
                check = false;
                message.Append("Ошибка в поле dateFinish (Дата окончания периода выплаты)!\n");
            }
            if (DateTime.TryParse(decision_date, out DateTime dec_date1) &&
                DateTime.TryParse(dateStart, out DateTime dateS1) &&
                DateTime.TryParse(dateFinish, out DateTime dateF1))
            {
                if (!(dec_date1 <= dateS1 && dateS1 <= dateF1))
                {
                    check = false;
                    message.Append("Ошибка в последовательности дат периода выплаты!\n");
                }
            }
            usingSign = "Нет";
            criteria = "";
            criteriaCode = "";
            FormCode = "01";
            if (!Regex.Match(amount, @"^[0-9]{1,9},[0-9]{2}$").Success)
            {
                check = false;
                message.Append("Ошибка в поле amount (сумма)!\n");
            }
            measuryCode = "01";
            monetization = "Нет";
            content = "";
            comment = "";
            equivalentAmount = "";

            if (message.ToString() == "") message.Append("Ошибок нет!");
            return check;
        }

        public bool TestReason()
        {
            bool check = true;
            StringBuilder message = new StringBuilder();

            if (SNILS_reason.Length != 14 || !SnilsValidator.SNILSValidate(SNILS_reason))
            {
                check = false;
                message.Append("Ошибка в поле SNILS_reason (Снилс лица - основания меры)!\n");
            }
            if (!Regex.Match(FamilyName_reason,
                @"^[а-яА-ЯёЁ][а-яА-ЯёЁ\-\s',.]{0,99}$").Success)
            {
                check = false;
                message.Append("Ошибка в поле FamilyName_reason (Фамилия лица - основания меры)!\n");
            }
            if (!Regex.Match(Name_reason,
                @"^[а-яА-ЯёЁ][а-яА-ЯёЁ\-\s',.]{0,99}$").Success)
            {
                check = false;
                message.Append("Ошибка в поле Name_reason (Имя лица - основания меры)!\n");
            }
            if (Patronymic_reason != "" && !Regex.Match(Patronymic_reason,
                @"^[а-яА-ЯёЁ][а-яА-ЯёЁ\-\s',.]{0,99}$").Success)
            {
                check = false;
                message.Append("Ошибка в поле Patronymic_reason (Отчество лица - основания меры)!\n");
            }
            if (Gender_reason != "М" && Gender_reason != "Ж")
            {
                check = false;
                message.Append("Ошибка в поле Gender_reason (Пол лица - основания меры)!\n");
            }
            if (!(DateTime.TryParse(BirthDate_reason, out DateTime BirthDate) &&
                BirthDate > new DateTime(1900, 1, 1) &&
                BirthDate < DateTime.Now))
            {
                check = false;
                message.Append("Ошибка в поле BirthDate_reason (Дата рождения лица - основания меры)!\n");
            }
            if (!(doctype_reason == "03" || doctype_reason == "05" ||
                doctype_reason == ""))
            {
                check = false;
                message.Append("Ошибка в поле doctype_reason (Тип ДУЛ)!\n");
            }
            if (doctype_reason == "03")
            {
                if (!Regex.Match(doc_Series_reason, @"^[0-9]{4}$").Success)
                {
                    check = false;
                    message.Append("Ошибка в поле doc_Series_reason (Серия ДУЛ)!\n");
                }
            }
            if (doctype_reason == "05")
            {
                if (!Regex.Match(doc_Series_reason, @"^[IVXLCDM]{1,3}[\-][А-Я]{2}$").Success)
                {
                    check = false;
                    message.Append("Ошибка в поле doc_Series_reason (Серия ДУЛ)!\n");
                }
            }
            if (!(doc_Number_reason == "" ||
                Regex.Match(doc_Number_reason, @"^[0-9]{6}$").Success))
            {
                check = false;
                message.Append("Ошибка в поле doc_Number_reason (Номер ДУЛ)!\n");
            }
            if (!(DateTime.TryParse(doc_IssueDate_reason, out DateTime doc_IssueDate) &&
                doc_IssueDate > new DateTime(1900, 1, 1) &&
                doc_IssueDate < DateTime.Now))
            {
                check = false;
                message.Append("Ошибка в поле doc_IssueDate_recip (Дата ДУЛ)!\n");
            }
            if (DateTime.TryParse(BirthDate_reason, out DateTime BirthDate1) &&
                DateTime.TryParse(doc_IssueDate_reason, out DateTime doc_IssueDate1))
            {
                if (BirthDate1 >= doc_IssueDate1)
                {
                    check = false;
                    message.Append("Дата выдачи документа должна быть больше даты рождения!\n");
                }
            }
            if (!(doc_Issuer_reason == "" ||
                Regex.Match(doc_Issuer_reason,
                @"^[а-яА-ЯёЁ][а-яА-ЯёЁ\-\s',.0-9№()\\/]{0,99}$").Success))
            {
                check = false;
                message.Append("Ошибка в поле doc_Issuer_recip (Кем выдан ДУЛ)!\n");
            }
            if (!((doctype_reason == "" &&
                doc_Series_reason == "" &&
                doc_Number_reason == "" &&
                doc_IssueDate_reason == "" &&
                doc_Issuer_reason == "") || (
                doctype_reason != "" &&
                doc_Series_reason != "" &&
                doc_Number_reason != "" &&
                doc_IssueDate_reason != "" &&
                doc_Issuer_reason != "")))
            {
                check = false;
                message.Append("Все поля документа ДУЛ должны быть " +
                    "или пустыми или заполненными!\n");
            }
            return check;
        }
    }
}
