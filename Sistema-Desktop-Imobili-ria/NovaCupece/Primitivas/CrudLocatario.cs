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
    class CrudLocatario
    {
        public StringConexao stringConexao = new StringConexao();
        DataSet ds;
        SqlDataAdapter dataAdapter;
        SqlCommand comando;
        public int id_Locatario_Do_Grid;

        static int id_locatario_Do_Editar;

        public home inicio;

        public CrudLocatario(home inicio)
        {
            this.inicio = inicio;
        }

        public CrudLocatario(int id_Locatario_Do_Grid)
        {
            this.id_Locatario_Do_Grid = id_Locatario_Do_Grid;
        }

       static int id_Atual_Locatario;

        public bool cadastrar(CadLocatario cadLocatario)
        {
            

            String telRes = "";
            telRes += cadLocatario.mtxtTelRes1.Text;
            telRes += cadLocatario.mtxtTelRel2.Text;

            String telCel = "";
            telCel += cadLocatario.mtxtTelCel1.Text;
            telCel += cadLocatario.mtxtTelCel2.Text;

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

            comando.CommandText = "insert into Locatario(nome, cpf, rg, dataNasc, telRes, telCel, email, endereco," +
                "id_User) values ('"+ cadLocatario.txtNome.Text + "', '" + cadLocatario.mtxtCpf.Text + "'," +
                "'" + cadLocatario.mtxtRg.Text + "', '" + cadLocatario.mtxtDataNasc.Text + "', '" + telRes + "'," +
                " '" + telCel + "', '" + cadLocatario.txtEmail.Text + "', '" + cadLocatario.txtEndereco.Text + "', " +
                "'" + cadLocatario.usuario + "')";

            try
            {
               comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro Realizado com sucesso", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                stringConexao.conn.Close();
                id_Atual_Locatario = getIdLocatarioByCpf(cadLocatario.mtxtCpf);
                return true;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Cadastro Falhou. Cheque se os campos estão " +
                    "preenchidos corretamente", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                stringConexao.conn.Close();
                return false;
            }

           

        }

        public int getIdLocatarioByCpf(MaskedTextBox txtCpf)
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

            dataAdapter = new SqlDataAdapter("select id from Locatario where cpf = '" + txtCpf.Text + "'" +
                "", stringConexao.conn);

            dataAdapter.Fill(ds);

            stringConexao.conn.Close();
            
            return Convert.ToInt16(ds.Tables[0].Rows[0][0]);

        }

        public bool cadastrarFonteDeRenda(CadLocatario2 cadLocatario2)
        {
            

            String horarioTrabalho = "";
            horarioTrabalho += cadLocatario2.txtHora1.Text;
            horarioTrabalho += " às ";
            horarioTrabalho += cadLocatario2.txtHora2.Text;


            String telComercial = "";
            telComercial += cadLocatario2.mtxtTelComercial1.Text;
            telComercial += cadLocatario2.mtxtTelComercial2.Text;



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

            comando.CommandText = "insert into FonteDeRenda(empresaFonte, cargo, salario, horarioTrabalho, telComercial," +
                "id_Locatario) values ('"+ cadLocatario2.txtEmpresa.Text + "', '" + cadLocatario2.txtCargo.Text + "'," +
                "'" + cadLocatario2.txtSalarioBruto.Text + "', '" + horarioTrabalho + "'," +
                "'" + telComercial + "', '" + Convert.ToInt16(id_Atual_Locatario) + "')";

            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro realizado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon
                    .Exclamation);
                stringConexao.conn.Close();
                return true;

            }
            catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível cadastrar. Cheque se os campos foram preenchidos " +
                    "corretamente", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stringConexao.conn.Close();
                return false;
            }

            

        }

        public bool cadastrarFonteDeRenda(int id_Locatario_Do_Grid, CadLocatario2 cadLocatario2)
        {                      

            String horarioTrabalho = "";
            horarioTrabalho += cadLocatario2.txtHora1.Text;
            horarioTrabalho += " às ";
            horarioTrabalho += cadLocatario2.txtHora2.Text;


            String telComercial = "";
            telComercial += cadLocatario2.mtxtTelComercial1.Text;
            telComercial += cadLocatario2.mtxtTelComercial2.Text;



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

            comando.CommandText = "insert into FonteDeRenda(empresaFonte, cargo, salario, horarioTrabalho, telComercial," +
                "id_Locatario) values ('" + cadLocatario2.txtEmpresa.Text + "', '" + cadLocatario2.txtCargo.Text + "'," +
                "'" + cadLocatario2.txtSalarioBruto.Text + "', '" + horarioTrabalho + "'," +
                "'" + telComercial + "', '" + id_Locatario_Do_Grid + "')";

            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro realizado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon
                    .Exclamation);
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

        public void exibir(VerLocatarios verLocatarios)
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

            dataAdapter = new SqlDataAdapter("select * from Locatario", stringConexao.conn);

            dataAdapter.Fill(ds);

            stringConexao.conn.Close();

            verLocatarios.dgvLocatario.DataSource = ds.Tables[0];

        }

        public int[] getIdFonteDeRendaByIdLocatario(int id)
        {

            int[] retorno;

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

            dataAdapter = new SqlDataAdapter("select id from FonteDeRenda where id_Locatario = '"+ id +"'", stringConexao.conn);

            int quantidade = dataAdapter.Fill(ds);
            retorno = new int[quantidade];

            for(int i = 0; i < quantidade; i++)
            {
                retorno[i] = Convert.ToInt16(ds.Tables[0].Rows[i][0]);
            }

            stringConexao.conn.Close();

            return retorno;


        }

        public void deletar(VerLocatarios verLocatarios)
        {
            DataGridViewRow selectedRow = verLocatarios.dgvLocatario.Rows[verLocatarios.linha];

            int id_Locatario = Convert.ToInt16(selectedRow.Cells[0].Value);

            int[] id_Fonte_De_Renda = getIdFonteDeRendaByIdLocatario(Convert.ToInt16(selectedRow.Cells[0].Value));

            

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

            for (int i = 0; i < id_Fonte_De_Renda.Length; i++)
            {
                int var = id_Fonte_De_Renda[i];
                comando.CommandText = "delete from FonteDeRenda where id = '" + var + "'";

                try
                {
                    comando.ExecuteNonQuery();
                }catch(SqlException ex)
                {
                    MessageBox.Show("Exclusão da fonte de renda falhou", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

            comando.CommandText = "delete from Locatario where id = '" + id_Locatario + "'";

            try
            {
                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Exclusão do locatario falhou", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            MessageBox.Show("Exlusão feita", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            stringConexao.conn.Close();

        }

        public void mostrarEditarLocatario(VerLocatarios verLocatarios, CadLocatario cadLocatario)
        {
            String telRes;
            String telCel;

           
            

            DataGridViewRow selectedRow = verLocatarios.dgvLocatario.Rows[verLocatarios.linha];

            int usuario = Convert.ToInt16(selectedRow.Cells[9].Value);

            

            id_locatario_Do_Editar = Convert.ToInt16(selectedRow.Cells[0].Value);

            cadLocatario.txtNome.Text = selectedRow.Cells[1].Value.ToString();
            cadLocatario.mtxtCpf.Text = selectedRow.Cells[2].Value.ToString();
            cadLocatario.mtxtRg.Text = selectedRow.Cells[3].Value.ToString();
            cadLocatario.mtxtDataNasc.Text = selectedRow.Cells[4].Value.ToString();

            telRes = selectedRow.Cells[5].Value.ToString();

            cadLocatario.mtxtTelRes1.Text = telRes.Substring(0, 3);
            cadLocatario.mtxtTelRel2.Text = telRes.Substring(3);

            telCel = selectedRow.Cells[6].Value.ToString();

            cadLocatario.mtxtTelCel1.Text = telCel.Substring(0, 3);
            cadLocatario.mtxtTelCel2.Text = telCel.Substring(3);

            cadLocatario.txtEmail.Text = selectedRow.Cells[7].Value.ToString();
            cadLocatario.txtEndereco.Text = selectedRow.Cells[8].Value.ToString();

            cadLocatario.Visible = true;

        }

        public void editar(CadLocatario cadLocatario)
        {
            comando = new SqlCommand();

            try
            {
                stringConexao.conn.Open();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Conexão falhou", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            comando.Connection = stringConexao.conn;

            string telRes = "";
            telRes += cadLocatario.mtxtTelRes1.Text;
            telRes += cadLocatario.mtxtTelRel2.Text;

            string telCel = "";
            telCel += cadLocatario.mtxtTelCel1.Text;
            telCel += cadLocatario.mtxtTelCel2.Text;

            MessageBox.Show(cadLocatario.usuario.ToString());

            comando.CommandText = "update Locatario set nome = '" + cadLocatario.txtNome.Text + "', " +
                "cpf = '" + cadLocatario.mtxtCpf.Text + "', rg = '" + cadLocatario.mtxtRg.Text + "', " +
                "dataNasc = '"+ cadLocatario.mtxtDataNasc.Text +"', telRes = '"+ telRes + "', " +
                "telCel = '" + telCel + "', email = '" + cadLocatario.txtEmail.Text + "'," +
                " endereco = '" + cadLocatario.txtEndereco.Text + "', id_User = '" + cadLocatario.usuario + "' where " +
                "id = '"+ id_locatario_Do_Editar +"'";

            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Atualização bem sucedida", "Mensagem", MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            stringConexao.conn.Close();


        }

    }
}
