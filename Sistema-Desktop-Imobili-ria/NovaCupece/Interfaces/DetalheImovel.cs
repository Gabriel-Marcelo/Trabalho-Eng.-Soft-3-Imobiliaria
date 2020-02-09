using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NovaCupece.Primitivas;

namespace NovaCupece.Interfaces
{
    public partial class DetalheImovel : Form
    {
        public int id_imovel;
        public String picpath;
        public int usuario;
        public home inicio;

        public DetalheImovel(home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
        }

        public DetalheImovel(int id_imovel, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
            this.id_imovel = id_imovel;

        }
        public DetalheImovel(int id_imovel, int usuario, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
            this.id_imovel = id_imovel;
            this.usuario = usuario;
        }

        private void btnMudar_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "C:\\";
            open.Filter = "Image File(*.jpg)|*.jpg|(*.png)|*.png|All Files(*.*)|*.*";
            open.FilterIndex = 1;
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                picpath = open.FileName.ToString();
                pbImovel.ImageLocation = picpath;

            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            CrudImovel crudImovel = new CrudImovel(inicio);
            crudImovel.salvarEditar(this);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
