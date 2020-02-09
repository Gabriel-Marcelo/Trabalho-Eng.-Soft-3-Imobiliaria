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
    class CrudLocador
    {

        StringConexao stringConexao = new StringConexao();
        DataSet ds;
        SqlDataAdapter dataAdapter;
        public SqlCommand comando;

        public home inicio;

        public CrudLocador(home inicio)
        {
            this.inicio = inicio;
        }


        public bool cadastrar(TextBox txtNome, MaskedTextBox txtCpf, MaskedTextBox txtRg,
            MaskedTextBox txtDataNasc, MaskedTextBox txtTelRes1, MaskedTextBox txtTelRes2
            , MaskedTextBox txtCel1, MaskedTextBox txtCel2, TextBox txtEmail, TextBox txtEnd)
        {
            String telRes = "";
            telRes += txtTelRes1.Text;
            telRes += txtTelRes2.Text;

            String telCel = "";
            telCel += txtCel1.Text;
            telCel += txtCel2.Text;

            int checar = 0;

            comando = new SqlCommand();

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não conectou","Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            comando.Connection = stringConexao.conn;

            comando.CommandText = "insert into Locador(nome, cpf, rg, datNasc, telRes, telCel, email, endereco)" +
                " values ('" + txtNome.Text + "','" + txtCpf.Text + "', '" + txtRg.Text + "', '" + txtDataNasc.Text + "', " +
                "'" + telRes + "', '" + telCel + "', '" + txtEmail.Text + "', '" + txtEnd.Text + "')";
            try
            {
                checar = comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro Realizado Com Sucesso!", "Cadastro",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                stringConexao.conn.Close();
                return true;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível cadastrar. Verifique se os dados estão preenchidos " +
                    "corretamente", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stringConexao.conn.Close();
                return false;
            }




            
        }

        public int getId(MaskedTextBox txtCpf)
        {
            int checar = 0;

            
            ds = new DataSet();

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException)
            {
                MessageBox.Show("Não conectou! Contate o administrador do sistema", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            dataAdapter = new SqlDataAdapter("select id from Locador where cpf = '"+ txtCpf.Text +"'", stringConexao.conn);

            dataAdapter.Fill(ds);

            stringConexao.conn.Close();
            try
            {
                return (int)ds.Tables[0].Rows[0][0];
            }
            catch(Exception ex)
            {
                return -1;
            }

        }

        public int getId(DataGridView dataGrid, int linha)
        {
            DataGridViewRow selectedRow = dataGrid.Rows[linha];

            int id = Convert.ToInt16(selectedRow.Cells[0].Value);

            return id;
        }

        public void exibir(DataGridView dataGrid)
        {
            ds = new DataSet();

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException)
            {
                MessageBox.Show("Não conectou! Contate o administrador do sistema", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            dataAdapter = new SqlDataAdapter("select * from Locador", stringConexao.conn);

            dataAdapter.Fill(ds);

            dataGrid.DataSource = ds.Tables[0];

        }

        public String getNameById(int id)
        {
            ds = new DataSet();

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException)
            {
                MessageBox.Show("Não conectou! Contate o administrador do sistema", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            dataAdapter = new SqlDataAdapter("select nome from Locador where id = '" + id + "'", stringConexao.conn);

            dataAdapter.Fill(ds);
            try
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception ex)
            {
                return "";
            }

        }

        public void checarExclusao(VerLocadores locadores)
        {
            DataGridViewRow selectedRow = locadores.dgvLocadores.Rows[locadores.linha];
            int id_Locador = Convert.ToInt16(selectedRow.Cells[0].Value);

            ds = new DataSet();

            try
            {
                stringConexao.conn.Open();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar. Contate o administrador do sistema",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select id_Locador from imovel", stringConexao.conn);
                dataAdapter.Fill(ds);
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar os locadores do imóvel", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            stringConexao.conn.Close();

            bool verificar = false;

            foreach(DataTable table in ds.Tables)
            {
                foreach(DataRow row in table.Rows)
                {
                    foreach(DataColumn column in table.Columns)
                    {
                        int item = Convert.ToInt16(row[column]);
                        if(id_Locador == item)
                        {
                            verificar = true;
                        }
                    }
                }
            }
            if(verificar == true)
            {
                MessageBox.Show("Esse locador registrou um ou mais imóveis. " +
                    "Delete seu(s) imóvel(eis) e tente novamente", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                deletar(locadores);
            }
        }

        public void deletar(VerLocadores locadores)
        {
            DataGridViewRow selectedRow = locadores.dgvLocadores.Rows[locadores.linha];

            int id_Locador = Convert.ToInt16(selectedRow.Cells[0].Value);

            comando = new SqlCommand();

            try
            {
                stringConexao.conn.Open();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar a base de dados. Contate o administrador " +
                    "do sistema", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            comando.Connection = stringConexao.conn;

            comando.CommandText = "Delete from locador where id = '" + id_Locador + "'";

            try
            {
                comando.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível deletar este locador", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            stringConexao.conn.Close();
        }

        public void mostrarEditar(VerLocadores locadores, CadLocImov1 locador)
        {
            DataGridViewRow selecteRow = locadores.dgvLocadores.Rows[locadores.linha];
            int id_Locador = Convert.ToInt16(selecteRow.Cells[0].Value);

            locador.txtNome.Text = selecteRow.Cells[1].Value.ToString();
            locador.mtxtCpf.Text = selecteRow.Cells[2].Value.ToString();
            locador.mtxtRg.Text = selecteRow.Cells[3].Value.ToString();
            locador.mtxtDataNasc.Text = selecteRow.Cells[4].Value.ToString();

            string telRes = selecteRow.Cells[5].Value.ToString();
            locador.mtxtTelRes1.Text = telRes.Substring(0, 4);
            locador.mtxtTelRes2.Text = telRes.Substring(5);

            string TelCel = selecteRow.Cells[6].Value.ToString();
            locador.mtxtTelCel1.Text = TelCel.Substring(0, 4);
            locador.mtxtTelCel2.Text = telRes.Substring(5);
            locador.txtEmail.Text = selecteRow.Cells[7].Value.ToString();
            locador.txtEnd.Text = selecteRow.Cells[8].Value.ToString();

            locador.Visible = true;
        }

        public void editar(CadLocImov1 locador)
        {
            string telRes = locador.mtxtTelRes1.Text;
            telRes += locador.mtxtTelRes2.Text;

            string telCel = locador.mtxtTelCel1.Text;
            telCel += locador.mtxtTelCel2.Text;

            comando = new SqlCommand();

            try
            {
                stringConexao.conn.Open();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar a base de dados. Contate o administrador do" +
                    " sistema", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            comando.Connection = stringConexao.conn;

            comando.CommandText = "Update Locador set nome = '" + locador.txtNome.Text + "', " +
                "cpf = '" + locador.mtxtCpf.Text + "', rg = '" + locador.mtxtRg.Text + "', dataNasc = '" + locador.mtxtDataNasc.Text + "', " +
                "telRes = '" + telRes + "', telCel = '" + telCel + "', email = '" + locador.txtEmail.Text + "', " +
                "endereco =  '" + locador.txtEnd.Text + "' " +
                " where id = '" + locador.id_locador + "'";

            try
            {
                comando.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível editar o locador", "Mesagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            stringConexao.conn.Close();
        }

    }
}
