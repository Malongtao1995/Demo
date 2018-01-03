using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FormMain : Form
    {
        public delegate void SendEventHandler(string msg);
        public event SendEventHandler SendEvent;
        public FormMain()
        {
            InitializeComponent();
        }
        public int num = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            FormSub formSub = new FormSub(this);

            formSub.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.SendEvent != null)
            {
                this.SendEvent(this.textBox1.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
