using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovaCupece
{
    public partial class CadMulta : Form
    {
        public CadMulta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CadMulta2 multa2 = new CadMulta2();
            multa2.Visible = true;
            this.Visible = true;
        }
    }
}
