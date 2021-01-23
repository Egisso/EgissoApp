using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public bool TestReason ()
        {
            return true;
        }
    }
}
