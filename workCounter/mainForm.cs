using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workCounter
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
        getWorkRegisterClass _getWorkRegisterClass = new getWorkRegisterClass();
        formControllerClass _formControllerClass;
        void loadRegisters()
        {
            listViewRegisters.Items.Clear();
            foreach (List<string> i in _getWorkRegisterClass.get())
            {
                try
                {
                    ListViewItem item = new ListViewItem();
                    for (int j = 0; j < i.Count; ++j)
                    {
                        if(j==0)
                            item = new ListViewItem(i[0]);
                        else
                            item.SubItems.Add(i[j]);
                        
                    }
                    if(item.SubItems.Count>0)
                        listViewRegisters.Items.Add(item);
                }
                catch
                {
                    //
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _formControllerClass = new formControllerClass(this);
            loadRegisters();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            _formControllerClass.start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            _formControllerClass.stop();
            loadRegisters();
        }
    }
}
