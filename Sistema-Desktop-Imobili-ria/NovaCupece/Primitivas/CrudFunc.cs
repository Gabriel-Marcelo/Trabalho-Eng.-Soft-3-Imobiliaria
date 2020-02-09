using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using NovaCupece.Classes_Adicionais;

namespace NovaCupece
{
    class CrudFunc
    {
        StringConexao stringConexao = new StringConexao();
        DataSet ds;
        SqlDataAdapter dataAdapter;
        String select;
       
        public SqlCommand comando = new SqlCommand();
        public CadFunc cadfunc;
        public bool menuStrip;
        public DataGridView dataGrid;
        public int ultimoIdCadastro;

        public home inicio;

        public CrudFunc(CadFunc cadfunc, home inicio)
        {
            this.cadfunc = cadfunc;
            this.inicio = inicio;
        }

        public CrudFunc(home inicio)
        {
            this.inicio = inicio;
        }

        public CrudFunc(bool menuStrip, home inicio)
        {
            this.menuStrip = menuStrip;
            this.inicio = inicio;
        }

        
        public CrudFunc()
        {

        }
        

        public void exibir(DataGridView dataGridView1)
        {


            try
            {
                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Falha na conexão!Contate o administrador do sistema", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }


            dataAdapter = new SqlDataAdapter("select * from Funcionario where status_func = 'Ativo'", stringConexao.conn);
            ds = new DataSet();

            dataAdapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            stringConexao.conn.Close();
        }

        public bool cadastrar(TextBox txtNome, MaskedTextBox txtCpf, MaskedTextBox txtRg,
            MaskedTextBox txtDataNasc, MaskedTextBox txtTelRes1, MaskedTextBox txtTelRes2
            , MaskedTextBox txtCel1, MaskedTextBox txtCel2, TextBox txtEmail, TextBox txtCargo, TextBox txtSal, TextBox txtEnd)
        {
            String telRes = "";
            telRes += txtTelRes1.Text;
            telRes += txtTelRes2.Text;

            String telCel = "";
            telCel += txtCel1.Text;
            telCel += txtCel2.Text;

            int checar = 0;

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException)
            {
                MessageBox.Show("Não foi possível conectar a base de dados", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            comando.Connection = stringConexao.conn;

           
            try
            {
                comando.CommandText = "insert into Funcionario(nome, cpf, rg, datNasc, telRes, telCel, email, cargo, " +
               "sal, endereco, status_func) values ('" + txtNome.Text + "','" + txtCpf.Text + "', '" + txtRg.Text + "', '" + txtDataNasc.Text + "', " +
               "'" + telRes + "', '" + telCel + "', '" + txtEmail.Text + "','" + txtCargo.Text + "', '" + Convert.ToDecimal(txtSal.Text) + "', '" + txtEnd.Text + "', 'Ativo')";
                checar = comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro Realizado Com Sucesso!", "Cadastro",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                stringConexao.conn.Close();
                return true;

            } catch (SqlException ex)
            {
                
                MessageBox.Show("Não foi possível cadastrar o funcionário. Cheque se os campos foram " +
                    "preenchidos corretamente", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stringConexao.conn.Close();
                return false;
            }
           
        }

        public void MostrarEditar(int linha, DataGridView dataGrid, CadFunc cadFunc)
        {
            DataGridViewRow selectedRow = dataGrid.Rows[linha];
           
            cadFunc.Text = "Editar Funcionário";
            cadFunc.lblTitulo.Text = "Editar Funcionário";
            cadFunc.btnSalvar.Visible = false;


            String Res = "", Cel = "";

            cadFunc.txtNome.Text = selectedRow.Cells[1].Value.ToString();
            cadFunc.txtCpf.Text = selectedRow.Cells[2].Value.ToString();
            cadFunc.txtRg.Text = selectedRow.Cells[3].Value.ToString();
            cadFunc.txtDataNasc.Text = selectedRow.Cells[4].Value.ToString();

            Res = selectedRow.Cells[5].Value.ToString();
            cadFunc.txtTelRes1.Text = Res.Substring(0, 4);
            cadFunc.txtTelRes2.Text = Res.Substring(4);

            Cel = selectedRow.Cells[6].Value.ToString();
            cadFunc.txtTelCel1.Text = Cel.Substring(0, 4);
            cadFunc.txtTelCel2.Text = Cel.Substring(4);

            cadFunc.txtEmail.Text = selectedRow.Cells[7].Value.ToString();
            cadFunc.txtCargo.Text = selectedRow.Cells[8].Value.ToString();
            cadFunc.txtSal.Text = selectedRow.Cells[9].Value.ToString();
            cadFunc.txtEnd.Text = selectedRow.Cells[10].Value.ToString();

            cadFunc.Visible = true;
        }

        public void editar(int linha, DataGridView dataGrid, TextBox txtNome, MaskedTextBox txtCpf, MaskedTextBox txtRg,
            MaskedTextBox txtDataNasc, MaskedTextBox txtTelRes1, MaskedTextBox txtTelRes2
            , MaskedTextBox txtTelCel1, MaskedTextBox txtTelCel2, TextBox txtEmail, TextBox txtCargo, TextBox txtSal, TextBox txtEnd)
        {
            String telRes = "";
            telRes += txtTelRes1.Text;
            telRes += txtTelRes2.Text;

            String telCel = "";
            telCel += txtTelCel1.Text;
            telCel += txtTelCel2.Text;

            int checar = 0;

            DataGridViewRow selectedRow = dataGrid.Rows[linha];

            

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException)
            {
                MessageBox.Show("Não conectou");
            }

            comando.Connection = stringConexao.conn;

            comando.CommandText = "update funcionario set nome = '" + txtNome.Text + "', cpf = '" + txtCpf.Text + "', " +
                "rg = '" + txtRg.Text + "', datNasc = '" + txtDataNasc.Text + "', " +
                "telRes = '" + telRes + "', telCel = '" + telCel + "', " +
                "email = '" + txtEmail.Text + "', cargo = '" + txtCargo.Text + "', " +
                "sal = '" + txtSal.Text + "', endereco = '" + txtEnd.Text + "'" +
                " where id = '" + selectedRow.Cells[0].Value + "'";

            try
            {
                checar = comando.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível editar o funcionário", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (checar != 0)
            {
                MessageBox.Show("Edição Realizada Com Sucesso! Clique em Atualizar", "Cadastro",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            stringConexao.conn.Close();
            
        }


        public void Deletar(int linha, DataGridView dataGrid)
        {
            DataGridViewRow selectedRow = dataGrid.Rows[linha];

            int checar = 0;

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException)
            {
                MessageBox.Show("Não foi possível conectar a base de dados", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            comando.Connection = stringConexao.conn;

            comando.CommandText = "UPDATE Funcionario SET status_func = 'Inativo' where id = '" + selectedRow.Cells[0].Value + "'";

            try
            {
                checar = comando.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível deletar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

            if (checar != 0)
            {
                MessageBox.Show("O Registro foi Deletado! Clique em Atualizar", "Deletar",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            stringConexao.conn.Close();

        }

        public void deletarUsuario(int linha, DataGridView dataGrid)
        {
            DataGridViewRow selectedRow = dataGrid.Rows[linha];

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException)
            {
                MessageBox.Show("Não foi possível conectar a base de dados", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            comando.Connection = stringConexao.conn;

            comando.CommandText = "UPDATE Logar set status_User = 'Inativo' where id_Func = " +
                "'"+ selectedRow.Cells[0].Value +"'";

            try
            {
                comando.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível deletar um usuário", "Mensagem", MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
                
            }

            stringConexao.conn.Close();

        }

        public int guardaIdCadastro(String nome, String email)
        {

            
            try
            {
                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar a base de dados", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }


            dataAdapter = new SqlDataAdapter("select id from Funcionario where nome = '"+nome+"' and email = '"+email+"'", stringConexao.conn);
            ds = new DataSet();

            int cheq  = dataAdapter.Fill(ds);



            try
            {
                return Convert.ToInt16(ds.Tables[0].Rows[0].Field<int?>("id"));
            }
            catch(Exception ex)
            {
                return -1;
            }
            
        }

        public int getIdFuncDoGrid(VerFuncionarios verFuncionarios)
        {
            DataGridViewRow selectedRow = verFuncionarios.dataGridView1.Rows[verFuncionarios.linha];
            int id_func = Convert.ToInt16(selectedRow.Cells[0].Value);
            return id_func;
        }

        public string getCpfByRg(string rg)
        {
            ds = new DataSet();
            try
            {
                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar a base de dados", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            dataAdapter = new SqlDataAdapter("select cpf from Funcionario where rg = '" + rg + "'",
                stringConexao.conn);

            dataAdapter.Fill(ds);

            stringConexao.conn.Close();

            try
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string getRgByCpf(string cpf)
        {
            ds = new DataSet();

            try
            {
                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar a base de dados", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            dataAdapter = new SqlDataAdapter("select rg from Funcionario where cpf = '"+ cpf +"'", 
                stringConexao.conn);

            dataAdapter.Fill(ds);

            stringConexao.conn.Close();
            try
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }catch(Exception ex)
            {
                return "";
            }
            

        }
    }
}
