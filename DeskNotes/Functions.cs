using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DeskNotes
{
    static class Functions
    {
        //Regex patterns for the functions
        private static string[] functions = {
            @"(D{2}|M{2}|Y{2}|Y{4})[,.|\\\/:](D{2}|M{2}|Y{2}|Y{4})[,.|\\\/:](D{2}|M{2}|Y{2}|Y{4});",  // Date in DD/MM/YY format : $DD.MM.YY; or $MM.DD.YY; and any combination between
            @"[Dd][Aa][Tt][Ee];",                                                                     // Full date               : $date;
            @"[Tt][Ii][Mm][Ee];",                                                                     // Full time               : $time;
            //@"(\-?\d+(?:[.,]\d+)?) *([\+\-\*\/\^]) *(\-?\d+(?:[.,]\d+)?);",                         // Basic Calculations      : $ NUM1 OP NUM2; where NUMX = 0 - 9 and OP = +,-,*,/,^
            @"[0123456789( )+-\/*^,.]+;",                                                             // Numeric expression calculation
            @"\/([bBiIuUpPsS])(.*);",                                                                 // Style text              : $/OP TEXT; where OP = i, b or u             
            @"([pP]:)(.*);"                                                                           // Open process            : $P:PROCESS; where process an executable
        };

        #region -------- Public Methods --------
        public static string CommandSymbol; //The symbol that commands have to start with
        //Pass any text be refference and get it back with the function changes
        public static void CheckAndExecute(ref string text, int StartingFunctionIndex = 0) { //Checks and executes found 
            TextBox tmpTB = new TextBox();                                                  //functions starting from
            tmpTB.Text = text;                                                             //'StartingFunctionIndex' index
            Control C = tmpTB;
            CheckAndExecute(ref C, StartingFunctionIndex);
            text = ((TextBox)C).Text;
        }
        //Pass Control with Select method (richtextbox, textbox, ...) to keep formating
        public static Control CheckAndExecute(ref Control text, int StartingFunctionIndex = 0)
        {                                                                    //Checks and executes found 
            string s;                                                       //functions starting from
            for (int i = StartingFunctionIndex; i < functions.Length; i++) //'StartingFunctionIndex' index
            {
                if (CommandSymbol == " ") CommandSymbol = "";
                s = Regex.Escape(CommandSymbol) + functions[i];
                MatchCollection matches = null;

                matches = Tools.GetRegexMatches(s, Tools.GetControlProperty(text, "Text").ToString());

                if (matches.Count > 0)
                {
                    string[] results = execute(functions[i], matches, text);
                    if (results != null)
                        for (int j = 0; j < results.Length; j++)
                        {

                            if (results[j] == null) continue;
                            Tools.ExecuteControlMethod(text, "Select", new object[] { matches[j].Index, matches[j].Length });
                            Tools.SetControlProperty(text, "SelectedText", results[j]);
                        }
                }
            }
            return text;
        }
        public static int FunctionFound(string text)   //Checks if there are functions in text
        {                                             //and returns the index of the function
            int found = -1;
            string s;
            for (int i = 0; i < functions.Length; i++)
            {
                if (CommandSymbol == null) CommandSymbol = "";
                if (CommandSymbol.Contains('\r') || CommandSymbol == " " || CommandSymbol.Contains('\n')) CommandSymbol = "";
                s = Regex.Escape(CommandSymbol) + functions[i];
                MatchCollection matches = Tools.GetRegexMatches(s, text);
                if (matches.Count > 0)
                {
                    found = i;
                    break;
                }
            }
            return found;
        }
        #endregion ---------------------------------------

        #region -------- Function Implimentations --------
        private static string[] execute(string func, MatchCollection matches, Control text = null)
        {
            if (matches.Count == 0) return null;
            string[] results = new string[matches.Count];
            int i = 0;
            foreach (Match match in matches)
            {
                if (func == functions[0]) //Format Date
                {
                    results[i] = getDate(match);
                }
                else if (func == functions[1]){ //Full Date
                    results[i] = DateTime.Now.Date.ToShortDateString();
                }
                else if (func == functions[2]) //Full Time
                {
                    results[i] = DateTime.Now.ToString("HH:mm:ss");
                }
                //else if (func == functions[3]) //Basic calculations (+,-,/,*,^)
                //{
                //    double result = getCalculations(match);
                //    results[i] = result.ToString();
                //}
                else if (func == functions[3]) //Numeric expresion
                {
                    string Match = match.Value;
                    if (Match.StartsWith(CommandSymbol) && CommandSymbol != "") Match = Match.Substring(1, Match.Length - 1);
                    string operants = "+-/*^";
                    if (Match.Length > 3 && Match.Any(char.IsDigit) && Match.Any(c => operants.Contains(c)))
                    {
                        try
                        {
                            double result = Tools.calculateExpression(Match);
                            if (result.ToString() != "NaN")
                                results[i] = result.ToString();
                            else
                                results[i] = null;
                        }
                        catch
                        {
                            results[i] = null;
                        }
                    }
                    else results[i] = null;
                }
                else if (func == functions[4]) //Stylize Text
                {
                    results[i] = null;
                    try
                    {
                        stylizeText(match, text);
                    }
                    catch { break; }
                }
                else if (func == functions[5]) //Open process
                {
                    results[i] = "";
                    openProcess(match);
                }
                i++;
            }
            return results;
        }

        private static string getDate(Match match)
        {
           return match.Value.
                        Replace(match.Groups[1].Value,
                        Tools.formatDate(match.Groups[1].Value)).
                        Replace(match.Groups[2].Value,
                        Tools.formatDate(match.Groups[2].Value)).
                        Replace(
                        match.Groups[3].Value,
                        Tools.formatDate(match.Groups[3].Value)).
                        Replace((CommandSymbol == "")?" ":CommandSymbol, "").Replace(";", "");
        }
        
        //private static double getCalculations(Match match)
        //{
        //    return Tools.culculate(
        //                new double[] {
        //                    double.Parse(match.Groups[1].Value.Replace(",","."), System.Globalization.CultureInfo.InvariantCulture),
        //                    double.Parse(match.Groups[3].Value.Replace(",","."), System.Globalization.CultureInfo.InvariantCulture)
        //                },
        //                match.Groups[2].Value
        //            );
        //}

        private static void stylizeText(Match match, Control text)
        {
            Tools.ExecuteControlMethod(text, "Select", new object[] { match.Index, match.Length });
            try { //Check if selection is protected to avoid crashes
                if((bool)Tools.GetControlProperty(text, "SelectionProtected"))
                {
                    return;
                }
            } catch { }
            //Changes the selected text to remove the different command symbols
            Tools.SetControlProperty(text, "SelectedText", match.Groups[2].ToString());
            //Select the text again as it has changed
            Tools.ExecuteControlMethod(text, "Select", new object[] { match.Index, match.Groups[2].Value.Length });
            //Check the operant and perform appropriate changes
            string operant = match.Groups[1].ToString().ToLower();
            if (operant == "i" || operant == "b" || operant == "u" || operant == "s")
            {
                System.Drawing.Font font = (System.Drawing.Font)Tools.GetControlProperty(text, "SelectionFont");

                System.Drawing.FontStyle style = new System.Drawing.FontStyle();
                style = font.Style;
                switch (match.Groups[1].ToString().ToLower())
                {
                    case "i":
                        style = style | System.Drawing.FontStyle.Italic;
                        break;
                    case "u":
                        style = style | System.Drawing.FontStyle.Underline;
                        break;
                    case "b":
                        style = style | System.Drawing.FontStyle.Bold;
                        break;
                    case "s":
                        style = style | System.Drawing.FontStyle.Strikeout;
                        break;
                }
                Tools.SetControlProperty(text, "SelectionFont",new System.Drawing.Font(font, style));
            }
            if ( operant == "p")
            {
                Tools.SetControlProperty(text, "SelectionProtected", true);
            }

        }

        private static void openProcess(Match match)
        {
            if (match.Groups[2].Value.Contains("?"))
            {
                MessageBox.Show("Process name can not contain ?");
                return;
            }

            string processName = match.Groups[2].Value;
            string process;
            bool found = false;
            System.Collections.Specialized.StringCollection stringCollection = Properties.Settings.Default.processes;
            int i = 0;
            foreach (string s in stringCollection)
            {
                if (s.StartsWith(processName.Replace(" ", "").Trim().ToLower() + "?"))
                {
                    process = stringCollection[i];
                    System.Diagnostics.Process.Start(process.Split('?').GetValue(1).ToString());
                    found = true;
                    break;
                }
                i++;
            }
            if (!found)
                AddToProcessList(match, processName, stringCollection);
        }
        public static void AddToProcessList(System.Text.RegularExpressions.Match match, string processName, System.Collections.Specialized.StringCollection stringCollection)
        {
            MessageBox.Show("Select a process to start");
            string process;
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Title = "Choose a process to start";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                process = OFD.FileName;
                stringCollection.Add(processName + "?" + process);
                Properties.Settings.Default.processes = stringCollection;
                Properties.Settings.Default.Save();
                MessageBox.Show("Process name has been saved!");
            }
        }
        #endregion ---------------------------------------

    }
}
