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
using NovaCupece.Classes_Adicionais;

namespace NovaCupece
{
    public partial class Locacao : Form
    {
        public int id_Imovel;
        public int id_Locador;
        public int id_Locatario;
        public int id_Fiador;
        public string path;
        public bool editar = false;
        public string detalheOk;

        public home inicio;

        public Locacao(home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
        }

        public Locacao(string detalheOk, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.detalheOk = detalheOk;
            this.inicio = inicio;
        }

        public Locacao(bool editar, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.editar = editar;
            this.inicio = inicio;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CrudLocacao crudLocacao = new CrudLocacao(inicio);
            crudLocacao.popLocatario(this);
        }

        private void btnSelecionarFiador_Click(object sender, EventArgs e)
        {
            CrudLocacao crudLocacao = new CrudLocacao(inicio);
            crudLocacao.popFiador(this);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bool validacao = true;
            if(txtLocatario.Text == "")
            {
                MessageBox.Show("Selecione um Locatário para essa locação", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                validacao = false;
            }
            if(txtFiador.Text == "")
            {
                MessageBox.Show("Selecione um fiador para essa locação", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                validacao = false;
            }
            CrudLocacao crud = new CrudLocacao();
            if (!crud.validaCadLocacao(this))
            {
                MessageBox.Show("Este imóvel já está locado, escolha outro imóvel", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                validacao = false;
            }
            if (validacao)
            {
                CrudLocacao crudLocacao = new CrudLocacao(inicio);

                if (editar == true)
                {
                    crudLocacao.editar(this);

                }
                else
                {
                    crudLocacao.salvar(this);
                }
            }
             
        }

        private void Locacao_Load(object sender, EventArgs e)
        {
            if(detalheOk != "Ok")
            {
                btnOk.Visible = false;
            }

            CrudLocacao crudLocacao = new CrudLocacao(inicio);
            crudLocacao.setCurrentDate(this);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dtpLocacao_ValueChanged(object sender, EventArgs e)
        {
            mtxDataFinal.Text = dtpLocacao.Value.ToString().Substring(0, 10);
        }

        
    }
}
