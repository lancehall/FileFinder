using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileFinder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton3.Checked = true;
            radioButton1.Checked = true;
            DateFilter.GlobalVar = "true";
            Date1.GlobalVar = dateTimePicker1.Value;
            Date2.GlobalVar = dateTimePicker1.Value;
            textBox1.Text = "Q:\\Music";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            textBox1.Text = fbd.SelectedPath;
        }

        static class Global
        {
            private static string _globalVar = "";

            public static string GlobalVar
            {
                get { return _globalVar; }
                set { _globalVar = value; }
            }
        }

        static class Global2
        {
            private static string _globalVar = "";

            public static string GlobalVar
            {
                get { return _globalVar; }
                set { _globalVar = value; }
            }
        }

        static class Global5
        {
            private static string _globalVar = "";

            public static string GlobalVar
            {
                get { return _globalVar; }
                set { _globalVar = value; }
            }
        }

        static class Date1
        {
            private static DateTime _globalVar;

            public static DateTime GlobalVar
            {
                get { return _globalVar; }
                set { _globalVar = value; }
            }
        }

        static class FilesWritten
        {
            private static int _globalVar;

            public static int GlobalVar
            {
                get { return _globalVar; }
                set { _globalVar = value; }
            }
        }

        static class Date2
        {
            private static DateTime _globalVar;

            public static DateTime GlobalVar
            {
                get { return _globalVar; }
                set { _globalVar = value; }
            }
        }

        static class Global3
        {
            private static string _globalVar = "";

            public static string GlobalVar
            {
                get { return _globalVar; }
                set { _globalVar = value; }
            }
        }

        static class DateFilter
        {
            private static string _globalVar = "";

            public static string GlobalVar
            {
                get { return _globalVar; }
                set { _globalVar = value; }
            }
        }

        static class Filtertype
        {
            private static string _globalVar = "";

            public static string GlobalVar
            {
                get { return _globalVar; }
                set { _globalVar = value; }
            }
        }

        public void TraverseTree(string root)
        {
            int i = 1;
            int j = 1;
            // Data structure to hold names of subfolders to be
            // examined for files.
            Stack<string> dirs = new Stack<string>(20);

            if (!System.IO.Directory.Exists(root))
            {
                throw new ArgumentException();
            }
            dirs.Push(root);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                string[] subDirs;
                try
                {
                    subDirs = System.IO.Directory.GetDirectories(currentDir);
                }
                // An UnauthorizedAccessException exception will be thrown if we do not have
                // discovery permission on a folder or file. It may or may not be acceptable 
                // to ignore the exception and continue enumerating the remaining files and 
                // folders. It is also possible (but unlikely) that a DirectoryNotFound exception 
                // will be raised. This will happen if currentDir has been deleted by
                // another application or thread after our call to Directory.Exists. The 
                // choice of which exceptions to catch depends entirely on the specific task 
                // you are intending to perform and also on how much you know with certainty 
                // about the systems on which this code will run.
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (System.IO.DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                string[] files = null;
                try
                {
                    files = System.IO.Directory.GetFiles(currentDir);
                }

                catch (UnauthorizedAccessException e)
                {

                    Console.WriteLine(e.Message);
                    continue;
                }

                catch (System.IO.DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                // Perform the required action on each file here.
                // Modify this block to perform your required task.
                foreach (string file in files)
                {
                    try
                    {
                        // Perform whatever action is required in your scenario.
                        System.IO.FileInfo fi = new System.IO.FileInfo(file);
                        if (DateFilter.GlobalVar == "false" && Filtertype.GlobalVar == "created")
                        {
                            String write = (i + ",  " + fi.CreationTime + ",  " + fi.Name + System.Environment.NewLine);
                            if (write.Contains(Global2.GlobalVar) && write.Contains(Global3.GlobalVar))
                            {
                                try
                                {
                                    label10.BeginInvoke((MethodInvoker)delegate () { label10.Text = "Files Scaned:" + (j - 1); });
                                    j++;
                                    System.IO.File.Copy(fi.FullName, Global5.GlobalVar + "\\" + fi.Name, true);
                                    File.SetAttributes(Global5.GlobalVar + "\\" + fi.Name, FileAttributes.Normal);
                                }
                                catch (Exception ex)
                                {
                                    
                                }

                                
                                label9.BeginInvoke((MethodInvoker)delegate () { label9.Text = "Files Written:" + i; });
                                if (File.Exists(Global5.GlobalVar + "\\" + fi.Name))
                                {
                                    i++;
                                }
                            }
                        }

                        if (DateFilter.GlobalVar == "false" && Filtertype.GlobalVar == "modified")
                        {
                            String write = (i + ",  " + fi.CreationTime + ",  " + fi.Name + System.Environment.NewLine);
                            if (write.Contains(Global2.GlobalVar) && write.Contains(Global3.GlobalVar))
                            {
                                try
                                {
                                    label10.BeginInvoke((MethodInvoker)delegate () { label10.Text = "Files Scaned:" + (j - 1); });
                                    j++;
                                    System.IO.File.Copy(fi.FullName, Global5.GlobalVar + "\\" + fi.Name, true);
                                    File.SetAttributes(Global5.GlobalVar + "\\" + fi.Name, FileAttributes.Normal);
                                }
                                catch (Exception ex)
                                {

                                }


                                label9.BeginInvoke((MethodInvoker)delegate () { label9.Text = "Files Written:" + i; });
                                if (File.Exists(Global5.GlobalVar + "\\" + fi.Name))
                                {
                                    i++;
                                }
                            }
                        }

                        if (DateFilter.GlobalVar == "true" && Filtertype.GlobalVar == "modified")
                        {
                            if (fi.LastWriteTime >= Date1.GlobalVar && fi.LastWriteTime <= Date2.GlobalVar) {
                                String write = (i + ",  " + fi.CreationTime + ",  " + fi.Name + System.Environment.NewLine);
                                if (write.Contains(Global2.GlobalVar) && write.Contains(Global3.GlobalVar))
                                {
                                    try
                                    {
                                        label10.BeginInvoke((MethodInvoker)delegate () { label10.Text = "Files Scaned:" + (j - 1); });
                                        j++;
                                        System.IO.File.Copy(fi.FullName, Global5.GlobalVar + "\\" + fi.Name, true);
                                        File.SetAttributes(Global5.GlobalVar + "\\" + fi.Name, FileAttributes.Normal);
                                    }
                                    catch (Exception ex)
                                    {

                                    }


                                    label9.BeginInvoke((MethodInvoker)delegate () { label9.Text = "Files Written:" + i; });
                                    if (File.Exists(Global5.GlobalVar + "\\" + fi.Name))
                                    {
                                        i++;
                                    }
                                }
                            }
                        }

                        if (DateFilter.GlobalVar == "true" && Filtertype.GlobalVar == "created")
                        {
                            if (fi.CreationTime >= Date1.GlobalVar && fi.CreationTime <= Date2.GlobalVar)
                            {
                                String write = (i + ",  " + fi.CreationTime + ",  " + fi.Name + System.Environment.NewLine);
                                if (write.Contains(Global2.GlobalVar) && write.Contains(Global3.GlobalVar))
                                {
                                    try
                                    {
                                        label10.BeginInvoke((MethodInvoker)delegate () { label10.Text = "Files Scaned:" + (j - 1); });
                                        j++;
                                        System.IO.File.Copy(fi.FullName, Global5.GlobalVar + "\\" + fi.Name, true);
                                        File.SetAttributes(Global5.GlobalVar + "\\" + fi.Name, FileAttributes.Normal);
                                    }
                                    catch (Exception ex)
                                    {

                                    }


                                    label9.BeginInvoke((MethodInvoker)delegate () { label9.Text = "Files Written:" + i; });
                                    if (File.Exists(Global5.GlobalVar + "\\" + fi.Name))
                                    {
                                        i++;
                                    }
                                }
                            }
                        }

                    }
                    catch (System.IO.FileNotFoundException e)
                    {
                        // If file was deleted by a separate application
                        //  or thread since the call to TraverseTree()
                        // then just continue.
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }

                // Push the subdirectories onto the stack for traversal.
                // This could also be done before handing the files.
                foreach (string str in subDirs)
                    dirs.Push(str);
            }
            if (dirs.Count == 0)
            {
                label9.BeginInvoke((MethodInvoker)delegate () { label9.Text = "(Done)   Files Written:" + (i - 1); });
            }
        }

        public void TraverseTree2(string root)
        {
            int i = 1;
            int j = 1;
            // Data structure to hold names of subfolders to be
            // examined for files.
            Stack<string> dirs = new Stack<string>(20);

            if (!System.IO.Directory.Exists(root))
            {
                throw new ArgumentException();
            }
            dirs.Push(root);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                string[] subDirs;
                try
                {
                    subDirs = System.IO.Directory.GetDirectories(currentDir);
                }
                // An UnauthorizedAccessException exception will be thrown if we do not have
                // discovery permission on a folder or file. It may or may not be acceptable 
                // to ignore the exception and continue enumerating the remaining files and 
                // folders. It is also possible (but unlikely) that a DirectoryNotFound exception 
                // will be raised. This will happen if currentDir has been deleted by
                // another application or thread after our call to Directory.Exists. The 
                // choice of which exceptions to catch depends entirely on the specific task 
                // you are intending to perform and also on how much you know with certainty 
                // about the systems on which this code will run.
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (System.IO.DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                string[] files = null;
                try
                {
                    files = System.IO.Directory.GetFiles(currentDir);
                }

                catch (UnauthorizedAccessException e)
                {

                    Console.WriteLine(e.Message);
                    continue;
                }

                catch (System.IO.DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                // Perform the required action on each file here.
                // Modify this block to perform your required task.
                foreach (string file in files)
                {
                    try
                    {
                        // Perform whatever action is required in your scenario.
                        System.IO.FileInfo fi = new System.IO.FileInfo(file);
                        if (DateFilter.GlobalVar == "false" && Filtertype.GlobalVar == "created")
                        {
                            label10.BeginInvoke((MethodInvoker)delegate () { label10.Text = "Files Scaned:" + (j-1); });
                            j++;
                            String write = (i + ",  " + fi.CreationTime + ",  " + fi.FullName + System.Environment.NewLine);
                            if (write.Contains(Global2.GlobalVar) && write.Contains(Global3.GlobalVar))
                            {
                                i++;
                                System.IO.File.AppendAllText(Global.GlobalVar, write);
                                label9.BeginInvoke((MethodInvoker)delegate () { label9.Text = "Files Written:" + (i - 1); });                                
                            }
                        }

                        if (DateFilter.GlobalVar == "false" && Filtertype.GlobalVar == "modified")
                        {
                            label10.BeginInvoke((MethodInvoker)delegate () { label10.Text = "Files Scaned:" + (j - 1); });
                            j++;
                            String write = (i + ",  " + fi.CreationTime + ",  " + fi.FullName + System.Environment.NewLine);
                            if (write.Contains(Global2.GlobalVar) && write.Contains(Global3.GlobalVar))
                            {
                                i++;
                                System.IO.File.AppendAllText(Global.GlobalVar, write);
                                label9.BeginInvoke((MethodInvoker)delegate () { label9.Text = "Files Written:" + (i - 1); });                    
                            }
                        }

                        if (DateFilter.GlobalVar == "true" && Filtertype.GlobalVar == "modified")
                        {
                            label10.BeginInvoke((MethodInvoker)delegate () { label10.Text = "Files Scaned:" + (j - 1); });
                            j++;
                            if (fi.LastWriteTime.Date >= Date1.GlobalVar && fi.LastWriteTime.Date <= Date2.GlobalVar)
                            {
                                String write = (i + ",  " + fi.CreationTime + ",  " + fi.FullName + System.Environment.NewLine);
                                if (write.Contains(Global2.GlobalVar) && write.Contains(Global3.GlobalVar))
                                {
                                    i++;
                                    System.IO.File.AppendAllText(Global.GlobalVar, write);
                                    label9.BeginInvoke((MethodInvoker)delegate () { label9.Text = "Files Written:" + (i - 1); });
                                }
                            }
                        }

                        if (DateFilter.GlobalVar == "true" && Filtertype.GlobalVar == "created")
                        {
                            label10.BeginInvoke((MethodInvoker)delegate () { label10.Text = "Files Scaned:" + (j - 1); });
                            j++;
                            if (fi.CreationTime.Date >= Date1.GlobalVar && fi.CreationTime.Date <= Date2.GlobalVar)
                            {
                                String write = (i + ",  " + fi.CreationTime + ",  " + fi.FullName + System.Environment.NewLine);
                                if (write.Contains(Global2.GlobalVar) && write.Contains(Global3.GlobalVar))
                                {
                                    i++;
                                    System.IO.File.AppendAllText(Global.GlobalVar, write);
                                    label9.BeginInvoke((MethodInvoker)delegate () { label9.Text = "Files Written:" + (i - 1); });
                                }
                            }
                        }

                    }
                    catch (System.IO.FileNotFoundException e)
                    {
                        // If file was deleted by a separate application
                        //  or thread since the call to TraverseTree()
                        // then just continue.
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }

                // Push the subdirectories onto the stack for traversal.
                // This could also be done before handing the files.
                foreach (string str in subDirs)
                    dirs.Push(str);
            }
            if(dirs.Count == 0)
            {
                label9.BeginInvoke((MethodInvoker)delegate () { label9.Text = "(Done)   Files Written:" + (i-1); });
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Filtertype.GlobalVar = "created";
            }
            else if (!radioButton1.Checked)
            {
                Filtertype.GlobalVar = "modified";
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            
            if (radioButton4.Checked)
            {
                DateFilter.GlobalVar = "false";
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
            }
            else if(!radioButton4.Checked)
            {
                DateFilter.GlobalVar = "true";
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Date1.GlobalVar = dateTimePicker1.Value.Date;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            Date2.GlobalVar = dateTimePicker2.Value.Date;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "CSV File|*.csv|Text File|*.txt";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs =
                 (System.IO.FileStream)saveFileDialog1.OpenFile();

                fs.Close();

                Global.GlobalVar = saveFileDialog1.FileName;
                Global2.GlobalVar = textBox2.Text;
                Global3.GlobalVar = textBox3.Text;

                ThreadPool.QueueUserWorkItem(o => TraverseTree2(textBox1.Text));

                label4.Text = "Saved to " + saveFileDialog1.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            Global5.GlobalVar = fbd.SelectedPath;



            Global.GlobalVar = fbd.SelectedPath;
            Global2.GlobalVar = textBox2.Text;
            Global3.GlobalVar = textBox3.Text;

            ThreadPool.QueueUserWorkItem(o => TraverseTree(textBox1.Text));

            label4.Text = "Copied to " + fbd.SelectedPath;
        }
    }
}
