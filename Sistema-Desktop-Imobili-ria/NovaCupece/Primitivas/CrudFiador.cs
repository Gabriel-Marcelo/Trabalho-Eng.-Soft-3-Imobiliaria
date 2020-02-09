using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using NovaCupece.Classes_Adicionais;

namespace NovaCupece.Primitivas
{
    class CrudFiador
    {
        public StringConexao stringConexao = new StringConexao();
        DataSet ds;
        SqlDataAdapter dataAdapter;
        SqlCommand comando;

        public home inicio;

        public CrudFiador(home inicio)
        {
            this.inicio = inicio;
        }

        public bool cadastrar(cadFiador fiador)
        {


            String telRes = "";
            telRes += fiador.mtxtTelRes1.Text;
            telRes += fiador.mtxtTelRel2.Text;

            String telCel = "";
            telCel += fiador.mtxtTelCel1.Text;
            telCel += fiador.mtxtTelCel2.Text;

            comando = new SqlCommand();

            try
            {
                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Falha na conexão!Contate o administrador do sistema", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            comando.Connection = stringConexao.conn;

            comando.CommandText = "insert into Fiador(nome, cpf, rg, dataNasc, telRes, telCel, email, endereco, valorFianca," +
                "id_User) values ('" + fiador.txtNome.Text + "', '" + fiador.mtxtCpf.Text + "'," +
                "'" + fiador.mtxtRg.Text + "', '" + fiador.mtxtDataNasc.Text + "', '" + telRes + "'," +
                " '" + telCel + "', '" + fiador.txtEmail.Text + "', '" + fiador.txtEndereco.Text + "'," +
                "'"+ fiador.txtValorFianca.Text +"', " +
                "'" + fiador.usuario + "')";

            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro do realizado com sucesso", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                stringConexao.conn.Close();
                return true;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível cadastrar. Cheque se os campos foram preenchidos " +
                    "corretamente", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stringConexao.conn.Close();
                return false;
            }
          
        }

        public void exibir(verFiadores fiador)
        {
            ds = new DataSet();

            try
            {
                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Falha na conexão!Contate o administrador do sistema", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            dataAdapter = new SqlDataAdapter("select * from Fiador", stringConexao.conn);

            dataAdapter.Fill(ds);

            stringConexao.conn.Close();

            fiador.dgvFiadores.DataSource = ds.Tables[0];

        }

        public void deletar(verFiadores fiadores)
        {
            DataGridViewRow selectedRow = fiadores.dgvFiadores.Rows[fiadores.linha];
            int id_fiador = Convert.ToInt16(selectedRow.Cells[0].Value);

            comando = new SqlCommand();

            try{

                stringConexao.conn.Open();

            }catch(SqlException ex)
            {
                MessageBox.Show("Conexão falhou! Contate o administrador do sistema.", "Mensagem", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }

            comando.Connection = stringConexao.conn;

            comando.CommandText = "Delete from Fiador where id = '" + id_fiador + "'";

            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Comando executado com sucesso.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Este fiador está vinculado à uma locação, delete a " +
                    "locação a qual ele pertence e tente novamente.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            stringConexao.conn.Close();
        }

        

        public void mostrarEditar(verFiadores fiadores, cadFiador fiador)
        {
            DataGridViewRow selectedRow = fiadores.dgvFiadores.Rows[fiadores.linha];

            int id_Fiador = Convert.ToInt16(selectedRow.Cells[0].Value);

            

            fiador.txtNome.Text = selectedRow.Cells[1].Value.ToString();
            fiador.mtxtCpf.Text  = selectedRow.Cells[2].Value.ToString();
            fiador.mtxtRg.Text = selectedRow.Cells[3].Value.ToString();
            fiador.mtxtDataNasc.Text = selectedRow.Cells[4].Value.ToString();

            String telRes = selectedRow.Cells[5].Value.ToString();
            fiador.mtxtTelRes1.Text = telRes.Substring(0, 4);
            fiador.mtxtTelRel2.Text = telRes.Substring(4);

            String telCel = selectedRow.Cells[6].Value.ToString();
            fiador.mtxtTelCel1.Text = telCel.Substring(0, 4);
            fiador.mtxtTelCel2.Text = telCel.Substring(4);

            fiador.txtEmail.Text = selectedRow.Cells[7].Value.ToString();

            fiador.txtEndereco.Text = selectedRow.Cells[8].Value.ToString();

            fiador.txtValorFianca.Text = selectedRow.Cells[9].Value.ToString();

            fiador.Visible = true;
        }

        public void editar(cadFiador fiador)
        {
            comando = new SqlCommand();

            try
            {
                stringConexao.conn.Open();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Conexão falhou! Contate o administrador do sistema.", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            comando.Connection = stringConexao.conn;

            String telRes = fiador.mtxtTelRes1.Text;
            telRes += fiador.mtxtTelRel2.Text;

            String telCel = fiador.mtxtTelCel1.Text;
            telCel += fiador.mtxtTelCel2.Text;


            comando.CommandText = "Update Fiador set nome = '" + fiador.txtNome.Text + "', cpf = '" + fiador.mtxtCpf.Text + "'," +
                "rg = '" + fiador.mtxtRg.Text + "', dataNasc = '" + fiador.mtxtDataNasc.Text + "', telRes = '" + telRes + "'," +
                "telCel = '" + telCel + "', email = '" + fiador.txtEmail.Text + "', endereco = '" + fiador.txtEndereco.Text + "'," +
                "valorFianca = '" + fiador.txtValorFianca.Text + "', id_User = '" + fiador.usuario + "' where id = '"+ fiador.id_Fiador +"'";

            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Comando executado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível editar o registro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            stringConexao.conn.Close();

        }
    }
}
