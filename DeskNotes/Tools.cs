using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DeskNotes
{
    static class Tools
    {
        #region --- Dynamic Controls (Get, Set and Execute dynamicaly from/to a control) ---
        private delegate void SetControlPropertyDelegate(Control control, string propertyName, object propertyValue);
        private delegate object GetControlPropertyDelegate(Control control, string propertyName);
        private delegate object ExecuteControlMethodDelegate(Control control, string methodName, object[] parameters);
        public static void SetControlProperty(Control control, string propertyName, object propertyValue)
        {// Sets a property of a control even from a parallel thread
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyDelegate(SetControlProperty),
                new object[] { control, propertyName, propertyValue });
            }
            else
            {
                if (propertyName == "Self") //Copy the whole control
                {
                    Control ctr = (Control)propertyValue;
                    foreach (System.Reflection.PropertyInfo prt in control.GetType().GetProperties())
                    {
                        control.GetType().InvokeMember(prt.Name,
                                System.Reflection.BindingFlags.SetProperty,
                                null,
                                control,
                                new object[] {
                                    ctr.GetType().GetProperty(prt.Name).GetValue(prt,null)
                                });
                    }
                }
                else
                    control.GetType().InvokeMember(propertyName,
                        System.Reflection.BindingFlags.SetProperty,
                        null,
                        control,
                        new object[] { propertyValue });
            }
        }
        public static object GetControlProperty(Control control, string propertyName)
        {//Gets a property from a control even from a parallel thread
            if (control.InvokeRequired)
            {
                return control.Invoke(new GetControlPropertyDelegate(GetControlProperty),
                    new object[] { control, propertyName });
            }
            else
            {
                if (propertyName == "Self") //Get the whole control
                    return control;
                else
                    return control.GetType().GetProperty(propertyName).GetValue(control, null);
            }
        }
        public static object ExecuteControlMethod(Control control, string methodName, object[] parameters)
        {
            if (control.InvokeRequired)
            {
                return control.Invoke(new ExecuteControlMethodDelegate(ExecuteControlMethod), 
                    new object[] { control, methodName, parameters });
            }else
            {
                
                return control.GetType().InvokeMember(
                    methodName,
                    System.Reflection.BindingFlags.InvokeMethod |
                    System.Reflection.BindingFlags.Public       |
                    System.Reflection.BindingFlags.Static       |
                    System.Reflection.BindingFlags.Instance,
                    null,
                    control,
                    parameters
                    );
            }
        }
        #endregion -------------------------------------------------------

        public static double calculateExpression(string expression)
        {
            MatchCollection matches;
            do
            {
                matches = Tools.GetRegexMatches(@"\((?: *-?\+?\d+(?:[,.]\d+)? *[+\-\/*^]?)+ *\)", expression);
                foreach (Match m in matches)
                {
                    expression = expression.Replace(m.Value, calculateExpression(m.Value.Substring(1, m.Value.Length - 2)).ToString());
                }
            }
            while (matches.Count != 0);

            MatchCollection M = null;
            do
            {
                //Power
                M = Tools.GetRegexMatches(@"(-?\d+(?:[,.]\d+)?) *\^ *(\d+(?:[,.]\d+)?)", expression);
                foreach (Match m in M)
                    expression = expression.Replace(m.Value, Tools.culculate(new double[] {
                        double.Parse(m.Groups[1].Value.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture),
                        double.Parse(m.Groups[2].Value.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
                    }, 
                    "^").ToString());
            }
            while (expression.Contains("^") && M.Count != 0);
            do
            {
                //Division
                M = Tools.GetRegexMatches(@"(-?\d+(?:[,.]\d+)?) *\/ *(\d+(?:[,.]\d+)?)", expression);
                foreach (Match m in M)
                    expression = expression.Replace(m.Value, Tools.culculate(new double[] {
                        double.Parse(m.Groups[1].Value.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture),
                        double.Parse(m.Groups[2].Value.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
                    },
                    "/").ToString());
            }
            while (expression.Contains("/") && M.Count != 0);
            do
            {
                //Multiply
                M = Tools.GetRegexMatches(@"(-?\d+(?:[,.]\d+)?) *\* *(\d+(?:[,.]\d+)?)", expression);
                foreach (Match m in M)
                    expression = expression.Replace(m.Value, Tools.culculate(new double[] {
                        double.Parse(m.Groups[1].Value.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture),
                        double.Parse(m.Groups[2].Value.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
                    },
                    "*").ToString());
            }
            while (expression.Contains("*") && M.Count != 0);
            //Addition
            do
            {
                M = Tools.GetRegexMatches(@"(-?\d+(?:[,.]\d+)?) *\+ *(\d+(?:[,.]\d+)?)", expression);
                foreach (Match m in M)
                    expression = expression.Replace(m.Value, Tools.culculate(new double[] {
                        double.Parse(m.Groups[1].Value.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture),
                        double.Parse(m.Groups[2].Value.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
                    },
                    "+").ToString());
            }
            while (expression.Contains("+") && M.Count != 0);
            //Subtraction
            do
            {
                M = Tools.GetRegexMatches(@"(-?\d+(?:[,.]\d+)?) *\- *(\d+(?:[,.]\d+)?)", expression);
                foreach (Match m in M)
                    expression = expression.Replace(m.Value, Tools.culculate(new double[] {
                        double.Parse(m.Groups[1].Value.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture),
                        double.Parse(m.Groups[2].Value.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
                    },
                    "-").ToString());
            }
            while (expression.Contains("-") && !expression.StartsWith("-") && M.Count != 0);
            if (expression.EndsWith(";"))
                expression = expression.Substring(0, expression.Length - 1);
            try
            {
                return double.Parse(expression.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                return double.NaN;
            }
        }
        public static double culculate(double[] Nums, string operant)
        {
            double result = 0;
            switch (operant)
            {
                case ("+"):
                    foreach (double d in Nums)
                        result = result + d;
                    break;
                case ("-"):
                    result = Nums[0];
                    for (int i = 1; i < Nums.Length; i++)
                        result = result - Nums[i];
                    break;
                case ("*"):
                    result = Nums[0];
                    for (int i = 1; i < Nums.Length; i++)
                        result = result * Nums[i];
                    break;
                case ("/"):
                    result = Nums[0];
                    for (int i = 1; i < Nums.Length; i++)
                        result = result / Nums[i];
                    break;
                case ("^"):
                    result = Nums[0];
                    for (int i = 1; i < Nums.Length; i++)
                        result = Math.Pow(result, Nums[i]);
                    break;
            }
            return result;
        }
        public static System.Text.RegularExpressions.MatchCollection GetRegexMatches(string rex, string text)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(rex);
            System.Text.RegularExpressions.MatchCollection matches = regex.Matches(text);
            return matches;
        }
        public static string formatDate(string date)
        {
            return date.Replace("MM", DateTime.Now.Month.ToString("00"))
                                         .Replace("DD", DateTime.Now.Day.ToString("00"))
                                         .Replace("YYYY", DateTime.Now.ToString("yyyy"))
                                         .Replace("YY", DateTime.Now.ToString("yy"));
        }

    }
}
