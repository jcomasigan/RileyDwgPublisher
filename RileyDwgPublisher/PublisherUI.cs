using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RileyDwgPublisher
{

    public partial class PublisherUI  : Form
    {
        string[] dwgsSelected;
        //date
        string dateDD = "";
        string dateMM = "";
        string dateYY = "";

        public PublisherUI()
        {
            InitializeComponent();
            SignatureDDYYMM dates = new SignatureDDYYMM();
            dates = SignatureUpdate.GetDateSignatureFormat();
            dayTextBox.Text = dates.Day;
            monthTextBox.Text = dates.Month;
            yearTextBox.Text = dates.Year;
            DateTime datePicked = dateTimePicker1.Value;
            GetDateSignatureFormat(datePicked);
        }

        private void selectFilesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            open.Filter = "Dwg Files (*.dwg)|*.dwg";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dwgsSelected = open.FileNames;
                dwgsListBox.DataSource = dwgsSelected;
                foreach (string file in dwgsSelected)
                {
                    string dir = System.IO.Path.GetDirectoryName(file);
                    GlobalVariables.caddCurrentLoc = dir;
                    curCadTxtBox.Text = dir;
                }
            }
        }
        private void TxtBoxToVar()
        {
            GlobalVariables.dayBox = dayTextBox.Text;
            GlobalVariables.monthBox = monthTextBox.Text;
            GlobalVariables.yearBox = yearTextBox.Text;
        }

        private void okUpdateButton_Click(object sender, EventArgs e)
        {

            GlobalVariables.DwgDets.Clear();
            GlobalVariables.outputPDFs = updatePdfCheckBox.Checked;
            GlobalVariables.saveDwgs = saveDwgCheckBox.Checked;
            if (dwgsSelected != null)
            {
                SignatureData sigValues = new SignatureData();
                sigValues = SigDataFromTextBox(sigValues);
                if (!GlobalVariables.FreezeSignatures)
                {
                    SignatureUpdate.UpdateAttributeInFiles(sigValues);
                    int dwgAmount = sigValues.Dwgs.Count;
                    if (System.IO.Directory.Exists(GlobalVariables.pdfDirectory))
                    {
                        System.Diagnostics.Process.Start(@GlobalVariables.pdfDirectory);
                    }
                }
                else
                {
                    SignatureUpdate.FreezeSigDwgs(sigValues);
                }
            }
            MessageBox.Show("Completed. See command line for details");
        }


        private SignatureData SigDataFromTextBox(SignatureData sigData)
        {
            //Update Object Signature Data from textbox
            sigData.DesignedBy = designedTextBox.Text;
            sigData.CheckedBy = checkedTextBox.Text;
            sigData.DirectorSigned = directorTextBox.Text;
            sigData.DaySigned = dateDD;
            sigData.MonthSigned = dateMM;
            sigData.YearSigned = dateYY;
            if (GlobalVariables.dateOverride == true)
            {
                sigData.DaySigned = dayTextBox.Text;
                sigData.MonthSigned = monthTextBox.Text;
                sigData.YearSigned = yearTextBox.Text;
            }
            sigData.Dwgs = dwgsSelected.ToList<string>();
            return sigData;
        }

        private void updatePdfCheckBox_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime datePicked = dateTimePicker1.Value;
            GetDateSignatureFormat(datePicked);
        }

        private void GetDateSignatureFormat(DateTime now)
        {
            //Puts current date in signature format
            int day = now.Day;
            int month = now.Month;
            int year = now.Year;
            //format
            string dayTxt = day.ToString();
            string monthTxt = month.ToString();
            if (day < 10)
            {
                dayTxt = "0" + dayTxt;
            }
            if (month < 10)
            {
                monthTxt = "0" + monthTxt;
            }
            string yearTxt = year.ToString();
            yearTxt = yearTxt.Substring(2, 2);
            dateDD = dayTxt;
            dateMM = monthTxt;
            dateYY = yearTxt;
        }

        private void freezeDwgs_CheckedChanged(object sender, EventArgs e)
        {
            if (freezeDwgs.Checked == true)
            {
                GlobalVariables.FreezeSignatures = true;
                designedTextBox.Enabled = false;
                checkedTextBox.Enabled = false;
                directorTextBox.Enabled = false;
                dateTimePicker1.Enabled = false;
                overrideDateChkBox.Enabled = false;
                updatePdfCheckBox.Enabled = false;
                appendRegisterCheckBox.Enabled = false;
            }
            else
            {
                GlobalVariables.FreezeSignatures = false;
                designedTextBox.Enabled = true;
                checkedTextBox.Enabled = true;
                directorTextBox.Enabled = true;
                dateTimePicker1.Enabled = true;
                overrideDateChkBox.Enabled = true;
                updatePdfCheckBox.Enabled = true;
                appendRegisterCheckBox.Enabled = true;
            }
        }

        private void appendRegisterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (appendRegisterCheckBox.Checked == true)
            {
                GlobalVariables.ommitRegisterEntry = true;
            }
            else
            {
                GlobalVariables.ommitRegisterEntry = false;
            }
        }

        private void freezeAfterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (freezeAfterCheckBox.Checked == true)
            {
                GlobalVariables.freezeAfter = true;
            }
            else
            {
                GlobalVariables.freezeAfter = false;
            }
        }

        private void overrideDateChkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (overrideDateChkBox.Checked == true)
            {
                GlobalVariables.dateOverride = true;
                dayTextBox.Enabled = true;
                monthTextBox.Enabled = true;
                yearTextBox.Enabled = true;
            }
            else
            {
                GlobalVariables.dateOverride = false;
                dayTextBox.Enabled = false;
                monthTextBox.Enabled = false;
                yearTextBox.Enabled = false;
            }


        }





    }
}
