using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace VNN_WEBEXTRACTOR
{
    public class textFileOperator
    {
        public void file_write(String filename, String fileContent)
        {
            FileInfo file1 = new FileInfo(filename);
            StreamWriter sw = file1.CreateText();
            sw.WriteLine(fileContent); // Writing a string directly to the file
            sw.Close();
        }

        //private void file_read()
        //{
        //    string path = "D:\\Temp\\My Documents\\";           // Parent Directory
        //    string name = TextBox1.Text;
        //    string ext = ".txt";
        //    string fname = path + name + ext;
        //    string readcontent;

        //    FileInfo file1 = new FileInfo(fname);

        //    StreamReader sr = new StreamReader(file1);
        //    readcontent = sr.ReadToEnd(); 	      // Reading content from the file and storing to a string	
        //    sr.Close();
        //    TextBox2.Text = readcontent;                        // Display contents in a textbox in the form
        //}

        //private void file_append()  {
        //   string path="D:\\Temp\\My Documents\\";           // Parent Directory
        //   string name=TextBox1.Text;
        //   string ext=".txt";
        //   string fname=path+name+ext;
        //   FileInfo file1=new FileInfo(fname);
        //   StreamWriter sw=File.AppendText(file1)
        //   sw.WriteLine("This is a demo for appending text content to a  file");       
        //                                                                                      // Writing a string directly to the file
        //   sw.WriteLine(TextBox2.Text);		 // Writing content read from the textbox in the form
        //   sw.Close();
        // }	
    }
}