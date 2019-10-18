using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIIK_CharCounter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OpenFileDialog ofd = new OpenFileDialog();
        public StreamReader sReader;
        public FileStream fStream;
        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Text|*.txt|All|*.*";
           if( ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxFilePath.Text = ofd.FileName;
                sReader = new StreamReader(File.OpenRead(ofd.FileName));
            }

        }

        void countTextData(string sRader)
        {
            var map = new Dictionary<char, double>();
            foreach(char c in sRader)
            {
                if (map.ContainsKey(c))
                {
                    map[c]++;
                }
                else
                {
                    int letterNumer = (int)c;
                    if((letterNumer >= 65 && letterNumer <= 90) || //duze litery
                       (letterNumer >= 97 && letterNumer <= 122) || //małe litery
                       (letterNumer >= 192 && letterNumer <= 687))  //znaki specjalne
                    {
                        map.Add(c, 1);
                    }
                    
                }
            }
            foreach (KeyValuePair<char, double> entry in map)
            {
                richTextBoxCountData.AppendText(entry.Key +"\t\t" + entry.Value.ToString() + "\n");
            }
            
        }

        private void buttonCount_Click(object sender, EventArgs e)
        { 
            string readFileText = sReader.ReadToEnd();
            countTextData(readFileText);

           
        }
    }
}
