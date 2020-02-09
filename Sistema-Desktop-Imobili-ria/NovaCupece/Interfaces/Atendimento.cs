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
    public partial class Atendimento : Form
    {
        public int id_user;
        public bool menuStrip = false;
        public home inicio;

        public DataGridView dataGrid;
        public int linha;

        public Atendimento()
        {
            InitializeComponent();
        }

        public Atendimento(home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.inicio = inicio;
        }

        public Atendimento(int id_user, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.inicio = inicio;
            this.id_user = id_user;
        }

        public Atendimento(int id_user, bool menuStrip, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.inicio = inicio;
            this.id_user = id_user;
            this.menuStrip = menuStrip;
        }

        public Atendimento(int id_User, DataGridView dataGrid, int linha, home inicio)
        {

            InitializeComponent();
            this.MaximizeBox = false;

            this.id_user = id_user;
            this.dataGrid = dataGrid;
            this.linha = linha;
            this.inicio = inicio;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.checarVazio(this);
            if (checar)
            {
                CrudAtendimento crudAtendimento = new CrudAtendimento(inicio);
                crudAtendimento.cadastrar(txtCliente, txtData, txtHorario, rtxtDescricao, id_user);
            }
            else
            {
                MessageBox.Show("Campo(s) vazio(s)", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Atendimento_Load(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            validacaoGeral.tamanho(this);

            if (menuStrip)
            {
                CrudAtendimento crudAtendimento = new CrudAtendimento(inicio);

                String horaData = crudAtendimento.getData().ToString();
                txtData.Text = horaData.Substring(0, 10);
                txtHorario.Text = horaData.Substring(11);
            }

           
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.checarVazio(this);
            if (checar)
            {
                CrudAtendimento crudAtendimento = new CrudAtendimento(id_user, dataGrid, linha, inicio);
                crudAtendimento.editar(txtCliente, rtxtDescricao, id_user, dataGrid, linha);
            }
            else
            {
                MessageBox.Show("Campo(s) vazio(s)", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            validacaoGeral.limpar(this);
        }
    }

        
    
}
