using DevExpress.XtraEditors.ButtonPanel;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DXApplication7
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Class1 sdd = new Class1();
            sdd.mousee = dd;
            button2.Click +=sdd.mousee;
        }
        void dd(object sender, EventArgs e)
        {
            MessageBox.Show("s");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            e.Button.Properties.Tag = this.layoutControl2;

            if (e.Button.Properties.Tag != null)
            {
                
                windowsUIButtonPanel1.ShowPeekForm(e.Button);
            }
         
          
            //Control ss = this.layoutControl2 as Control;
            //windowsUIButtonPanel1.ShowPeekForm(ss as IBaseButton);
        }
           
              private void windowsUIButtonPanel1_QueryPeekFormContent(object sender, DevExpress.XtraBars.Docking2010.QueryPeekFormContentEventArgs e)
        {
            if (e.Button.Properties.Tag != null && e.Button.Properties.Tag is Control)
            {
                e.Control = e.Button.Properties.Tag as Control;
            }
        }

              private void button1_Click(object sender, EventArgs e)
              {
                  
              }
    }
}
