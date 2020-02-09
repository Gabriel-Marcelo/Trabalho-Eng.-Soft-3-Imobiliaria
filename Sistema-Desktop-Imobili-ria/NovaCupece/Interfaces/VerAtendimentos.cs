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
using NovaCupece.Classes_Adicionais;

namespace NovaCupece
{
    public partial class VerAtendimentos : Form
    {
        public int usuario;
        public int linha;
        public home inicio;
        public Atendimento atendimento;
        public Atendimento atendimentoEdit;

        public VerAtendimentos(home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
        }

        public VerAtendimentos(int usuario, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
            this.usuario = usuario;
        }

        private void VerAtendimentos_Load(object sender, EventArgs e)
        {
            CrudAtendimento crudAtendimento = new CrudAtendimento(inicio);
            crudAtendimento.exibir(dgvAtendimentos);
            rbCrescente.Checked = true;
        }

        //btnCadastrar
        private void button4_Click(object sender, EventArgs e)
        {
                atendimento = new Atendimento(usuario, inicio);
                CrudAtendimento crudAtendimento = new CrudAtendimento(inicio);
                LoginSistema sistema = new LoginSistema();

                atendimento.txtUsuario.Text = sistema.getUser(usuario);
                atendimento.txtData.Text = crudAtendimento.getData().ToString().Substring(0, 10);
                atendimento.txtHorario.Text = crudAtendimento.getData().ToString().Substring(11);
                atendimento.btnEditar.Visible = false;
                atendimento.Visible = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrudAtendimento crudAtendimento = new CrudAtendimento(inicio);
            crudAtendimento.exibir(dgvAtendimentos);
            
        }

        private void dgvAtendimentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            linha = e.RowIndex;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);
            if (checar)
            {
                CrudAtendimento crudAtendimento = new CrudAtendimento(usuario, dgvAtendimentos, linha, inicio);
                atendimentoEdit = new Atendimento(usuario, dgvAtendimentos, linha, inicio);
                crudAtendimento.mostrarEditar(dgvAtendimentos, usuario, linha, atendimentoEdit);
            }
        }

        //btnDeletar
        private void button5_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);
            if (checar)
            {
                DataGridViewRow selectedRow = dgvAtendimentos.Rows[linha];
                int id_User = -1;
                try
                {
                    id_User = Convert.ToInt16(selectedRow.Cells[5].Value);
                }catch(Exception ex)
                {
                    MessageBox.Show("Ops! Erro na conversão do Id_User pra inteiro", "Mensagem",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if(id_User != inicio.usuario)
                {
                    MessageBox.Show("Não é possível excluir o atendimento de outro funcionário", "Mensagem",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CrudAtendimento crudAtendimento = new CrudAtendimento(inicio);
                    crudAtendimento.deletar(dgvAtendimentos, linha);
                }
                
            }
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            OutrasFuncionalidades funcionalidades = new OutrasFuncionalidades();
            funcionalidades.ordenar(this);
        }

        private void btnDesfazer_Click(object sender, EventArgs e)
        {
            CrudAtendimento crudAtendimento = new CrudAtendimento(inicio);
            crudAtendimento.exibir(dgvAtendimentos);
        }

        private void VerAtendimentos_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(this.atendimento != null)
            {
                this.atendimento.Visible = false;
                if (this.atendimentoEdit != null) this.atendimentoEdit.Visible = false;
            }
            else if(this.atendimentoEdit != null)
            {
                this.atendimentoEdit.Visible = false;
                if (this.atendimento != null) this.atendimento.Visible = false;
            }
            
        }
    }
}
