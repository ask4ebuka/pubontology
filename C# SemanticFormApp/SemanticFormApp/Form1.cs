using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemanticFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           List<object> rdf= (List<object>)  rdfreader.rdfexec();
           List<string> rdfstr = new List<string>();
            foreach (object a in rdf)
            {
                rdfstr.Add(a.ToString());
            }

            richTextBox1.Lines = rdfstr.ToArray();
                   

        }
    }
}
