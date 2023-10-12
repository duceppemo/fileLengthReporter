using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


/*
 * Track changes:
 *  0.1     -> 2017-07-11
 *          ->  initial release
 *  0.2     ->  2017-07-13
 *          ->  Chaged the carriage return
 *          ->  Bundle woring code in function
 *          ->  Changed the way to list all the files recursively to avoid stop on Access denied error.
 *          ->  Use backgroundworker to prevent UI to freeze when scanning a large location (e.g. C:\)
 *              This will also allow the progress bar and label to work properly
 *  0.3     ->  2017-07-14
 *          ->  Fixed Scan button available is filter checked, but threshold textbox empty
 *          ->  Disable Scan button on click. Enable once job done.
 *          ->  Added a textbox when done with stats.
 *
*/


namespace fileLengthReporter
{
    public partial class FLR : Form
    {
        int total_files = 0;
        int reported_files = 0;
        int denied_folders = 0;

        public FLR()
        {
            InitializeComponent();
        }

        private void button_folder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    textBox_folder.Text = folderBrowserDialog1.SelectedPath;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void button_report_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    textBox_report.Text = saveFileDialog1.FileName;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void writeToFile(StringBuilder stingBuilderObject)
        {
            //Write result to output file
            using (StreamWriter sw = new StreamWriter(textBox_report.Text))
            {
                sw.Write(stingBuilderObject.ToString());
            }
        }

        private List<string> get_all(string source_folder, List<string> retList)
        {
            try  // check if have access to requested folder for scan
            {
                foreach (string sub_folder in Directory.GetDirectories(source_folder, "*.*"))
                {
                    try  // check if have access to folder content
                    {
                        retList.AddRange(Directory.GetFiles(source_folder, "*.*"));
                        get_all(sub_folder, retList);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        retList.Add(ex.ToString());  // add to report the fact the access is denied for that folder
                    }
                }
            }
            catch (UnauthorizedAccessException ex)  //dont have access to folder in textBox_folder
            {
                string error = ex.Message.ToString();
                retList.Add(error);
            }

            return retList;
        }

        private void scan_folder()
        {
            List<string> all_files_list = new List<string>();

            string[] all_files;
            int filter_length = 1;  // Default Value: report all files

            if (checkBox_recursive.Checked == true)
            {
                get_all(textBox_folder.Text, all_files_list);
            }
            else
            {
                try  // check if have access to requested folder for scan
                {
                    all_files_list.AddRange(Directory.GetFiles(textBox_folder.Text, "*.*", SearchOption.TopDirectoryOnly));
                }
                catch (UnauthorizedAccessException ex)
                {
                    all_files_list.Add(ex.Message.ToString());
                }
            }

            if (checkBox_threshold.Checked == true)
            {
                filter_length = int.Parse(textBox_threshold.Text);
            }

            //convert list to array
            all_files = all_files_list.ToArray();
            total_files = all_files.Length;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < total_files; i++)
            {
                // Progressbar value over 100
                int progress = (i + 1) * 100 / total_files;  //bring back to percentage
                backgroundWorker1.ReportProgress(progress);

                string file = all_files[i];
                int len = all_files[i].Length;

                label_scanned.Invoke(new Action(() => { label_scanned.Text = (i + 1).ToString() + "/" + total_files; }));
                label_scanned.Invoke(new Action(() => { label_scanned.Refresh(); }));
                //label_scanned.Text = counter + "/" + total_file;
                    

                if(file.StartsWith("Access to the"))
                {
                    denied_folders++;
                    sb.Append(file + '\t' + "DENIED" + Environment.NewLine);
                }
                else if (len >= filter_length)
                {
                    reported_files++;
                    sb.Append(file + '\t' + len + Environment.NewLine);
                }
            }

            try
            {
                writeToFile(sb);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_scan_Click(object sender, EventArgs e)
        {
            //check if report file exists
            if (File.Exists(textBox_report.Text))
            {
                string filename = Path.GetFileName(textBox_report.Text);
                if(MessageBox.Show(filename + " already exists." + '\n' + "Do you want to replace it?", 
                    "Confrim Save As", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }

            button_scan.Enabled = false;
            progressBar1.Visible = true;
            label_scanned.Text = "";
            label_scanned.Visible = true;

            backgroundWorker1.RunWorkerAsync();
        }

        // only numbers can be entered in the threshod textBox
        private void textBox_threshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void checkBox_threshold_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_threshold.Checked == true)
            {
                label_threshold.Visible = true;
                textBox_threshold.Enabled = true;
                textBox_threshold.Visible = true;

                check_scan_ready();
            }
            else
            {
                label_threshold.Visible = false;
                textBox_threshold.Enabled = false;
                textBox_threshold.Visible = false;

                if (check_folder_text(textBox_folder.Text) == true
                    && check_report_text(textBox_report.Text) == true)
                {
                    button_scan.Enabled = true;
                }
                else
                {
                    button_scan.Enabled = false;
                }
            }
        }

        // Textbox content checks

        private bool check_report_text (string textBoxValue)
        {
            bool test = false;  //Default value

            // if somthing is entered
            if (String.IsNullOrWhiteSpace(textBoxValue) == false
                    && String.IsNullOrEmpty(textBoxValue) == false)
            {
                // Check if file is to be saved in an existing location
                // Mainly if path typed in manually
                string report_directory = Path.GetDirectoryName(textBoxValue);

                // Check if entered a directory instead of a file name
                if (Directory.Exists(textBoxValue) == true)
                {
                    throw new InvalidDataException("Please input a file, not a folder location!");
                }
                else if (Directory.Exists(report_directory) == false)
                {
                    throw new InvalidDataException("The selected folder to save the report file does not exist!");
                }
                else
                {
                    test = true;
                }
            }
            return test;
        }

        private bool check_folder_text (string textBoxValue)
        {
            bool test = false;  //Default value

            // If something entered
            if (String.IsNullOrWhiteSpace(textBoxValue) == false
                    && String.IsNullOrEmpty(textBoxValue) == false)
            {
                if (Directory.Exists(textBoxValue) == true)
                {
                    test = true;
                }
            }

            return test;
        }

        private bool check_filter_text(string textBoxValue)
        {
            bool test = false;  //Default value

            if (checkBox_threshold.Checked == true)
            {
                int result;
                if (textBox_threshold.Text != "")
                {
                    if (!int.TryParse(textBox_threshold.Text, out result))
                    {
                        textBox_threshold.Text = "";
                        MessageBox.Show("Invalid Integer");
                    }
                    else
                    {
                        test = true;
                    }
                }
            }
            else
            {
                test = true;
            }

            return test;
        }

        private void check_scan_ready ()
        {
            if (check_folder_text(textBox_folder.Text) == true
                    && check_report_text(textBox_report.Text) == true
                    && check_filter_text(textBox_threshold.Text) == true)
            {
                button_scan.Enabled = true;
            }
            else
            {
                button_scan.Enabled = false;
            }
        }

        // Text changed

        private void textBox_folder_TextChanged(object sender, EventArgs e)
        {
            try
            {
                check_scan_ready();
            }
            catch (InvalidDataException)
            {
                // Do nothing
            }
        }

        private void textBox_report_TextChanged(object sender, EventArgs e)
        {
            try
            {
                check_scan_ready();
            }
            catch (InvalidDataException)
            {
                // Do nothing
            }
        }

        private void textBox_threshold_TextChanged(object sender, EventArgs e)
        {
            try
            {
                check_scan_ready();
            }
            catch
            {
                //Do nothing
            }
        }

        // Textbox drag and drop

        private void textBox_folder_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBox_folder_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files != null && files.Length != 0)
            {
                textBox_folder.Text = files[0];
            }
        }

        private void textBox_report_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBox_report_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files != null && files.Length != 0)
            {
                textBox_report.Text = files[0];
            }
        }

        //MouseHover tips

        private void textBox_folder_MouseHover(object sender, EventArgs e)
        {
            toolTip_folder.SetToolTip(textBox_folder, "The folder you want to scan.");
        }

        private void textBox_report_MouseHover(object sender, EventArgs e)
        {
            toolTip_report.SetToolTip(textBox_report, "The output file. Format is two tab-separated columns:" + '\n' + '\n' +
                "File/absolute/path    length");
        }

        private void checkBox_threshold_MouseHover(object sender, EventArgs e)
        {
            toolTip_filter.SetToolTip(checkBox_threshold, "Enable minimum length filtering to reduce size of report file.");
        }

        private void textBox_threshold_MouseHover(object sender, EventArgs e)
        {
            toolTip_length.SetToolTip(textBox_threshold, "Only report files with an absolute path length above the threshold value." + '\n' + 
                "Only positive numbers are allowed.");
        }

        private void checkBox_recursive_MouseHover(object sender, EventArgs e)
        {
            toolTip_recursive.SetToolTip(checkBox_recursive, "Also scan all subfolders.");
        }

        // Backgroundworker

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            scan_folder();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string done_text;

            if (checkBox_threshold.Checked == true)
            {
                done_text = "Total files scanned in " + textBox_folder.Text + ": " + total_files + '\n' +
                        "Number of file paths longer than " + textBox_threshold.Text + " characters: " + reported_files + '\n' +
                        "Number of folders with denied access: " + denied_folders + '\n' + '\n' +
                        "See report file " + textBox_report.Text + " for length details.";
            }
            else
            {
                done_text = "Total files scanned in " + textBox_folder.Text + ": " + total_files + '\n' +
                        "Number of folders with denied access: " + denied_folders + '\n' + '\n' +
                        "See report file " + textBox_report.Text + " for length details.";
            }
            

            DialogResult result = MessageBox.Show(done_text, "Scan completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            if (result == DialogResult.OK)
            {
                progressBar1.Value = 0;  // clear the progress bar if want to scan another folder without restarting the app
                progressBar1.Visible = false;
                label_scanned.Visible = false;
                button_scan.Enabled = true;

                // Reset counter if want to scan another folder without restarting the app
                reported_files = 0;
                denied_folders = 0;
            }
            
        }
    }
}
