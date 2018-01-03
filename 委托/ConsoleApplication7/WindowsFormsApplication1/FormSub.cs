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
    public partial class FormSub : Form
    { 
        FormMain formMain;
        public FormSub(FormMain formain)
        {
            InitializeComponent();
            this.formMain = formain;
            this.formMain.SendEvent += new WindowsFormsApplication1.FormMain.SendEventHandler(formMain_SendEvent);
        }
    
        void formMain_SendEvent(string msg)
        {
            this.textBox1.Text = msg;
        }

        private void FormSub_Load(object sender, EventArgs e)
        {

        }
    }
}
