using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using NovaCupece.Interfaces;

namespace NovaCupece.Classes_Adicionais
{
    class ValidacaoGeral
    {
        public StringConexao stringConexao = new StringConexao();
        DataSet ds;
        SqlDataAdapter dataAdapter;
        SqlCommand comando;

        //************************************Atendimento*********************************//
        public bool checarVazio(Atendimento atendimento)
        {
            if(atendimento.txtCliente.Text == "" && atendimento.rtxtDescricao.Text == "")
            {
                
                return false;
            }
            return true;
        }


        //************************************Login e Usuário*********************************//
        public bool checarVazio(frmLogin login)
        {
            if (login.txtUsuario.Text == "" || login.txtSenha.Text == "")
            {
               
                return false;
            }
            return true;
        }

        public bool userCadastrado(frmLogin login)
        {
            
            ds = new DataSet();

            try
            {
                stringConexao.conn.Open();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar a base de dados. Contate o administrador do sistema", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            int linhasAfetadas = 0;

            try
            {
                dataAdapter = new SqlDataAdapter("select usuario from logar", stringConexao.conn);
                linhasAfetadas = dataAdapter.Fill(ds);
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar os usuários da base de dados", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            stringConexao.conn.Close();

            bool validaUsuario = false;

                
           
                foreach(DataTable table in ds.Tables)
                {
                    foreach(DataRow row in table.Rows)
                    {
                        foreach(DataColumn column in table.Columns)
                        {
                            string usuario = row[column].ToString();
                            if(usuario != login.txtUsuario.Text)
                            {
                                validaUsuario = false;
                            }
                        }
                    }
                }
                if (validaUsuario == false)
                {
                   
                    return false;
                }
                
            

            return true;

        }

        public bool checarUsuarioNoBanco(CadUsuario usuario)
        {
            ds = new DataSet();

            bool checagem = false;

            try
            {

                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar com a base de dados", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select usuario from Logar", stringConexao.conn);
                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar os usuários da base de dados", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            stringConexao.conn.Close();

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (usuario.txtUser.Text == row[column].ToString())
                        {
                            checagem = true;
                            
                        }
                    }
                }
            }
            
            if (checagem == true)
            {
                return false;
            }
            return true;

        }

        public bool validaSenha(CadUsuario usuario)
        {
            if (usuario.txtSenha.Text != usuario.txtSenha2.Text)
            {
                
                return false;
            }
            return true;
        }

        public bool checarVazio(CadUsuario usuario)
        {
            if (usuario.txtUser.Text == "" || usuario.txtSenha.Text == "" || usuario.txtSenha2.Text == "")
            {
               
                return false;
            }
            return true;
        }

        //************************************Imóveis*********************************//
        public bool imagemDescricaoVazios(cadLocImov2 imovel)
        {
            if (imovel.pbImovel.Location == null)
            {
                
                return false;
            }
            else if (imovel.rtxtDescricao.Text == "")
            {
                
                return false;
            }
            return true;
        }

        public bool checarCamposVaziosImoveisTela2(CadLocImov3 imovel)
        {
            if (imovel.txtBairro.Text != "" && imovel.txtNumero.Text != "" && imovel.txtRuaAvenida.Text != ""
                && imovel.txtValorAluguel.Text != "" && imovel.txtCidade.Text != "" &&
                imovel.cboStatus.SelectedItem != "" && imovel.cboUf.SelectedItem != "")
            {
                return true;
            }
            
            return false;
        }
        public bool checarCamposVaziosImoveisTela1(cadLocImov2 imovel)
        {
            if (imovel.txtBairro.Text != "" && imovel.txtNumero.Text != "" && imovel.txtRuaAvenida.Text != ""
                && imovel.txtValorAluguel.Text != "" && imovel.txtCidade.Text != "" ) 
            {
                
                return true;
            }

            return false;
        }

        //************************************FonteDeRenda*********************************//
        public bool checarCamposVazios(CadLocatario2 renda)
        {
            string telComercial = renda.mtxtTelComercial1.Text.Substring(1, 3);
            telComercial += renda.mtxtTelComercial2.Text.Substring(0, 4);
            telComercial += renda.mtxtTelComercial2.Text.Substring(5);

            if (renda.txtCargo.Text != "" && renda.txtEmpresa.Text != "" && renda.txtHora1.Text != "" &&
                renda.txtHora2.Text != "" && renda.txtSalarioBruto.Text != "" && telComercial != "")
            {
                return true;
            }
            
            return false;
            
        }


        //************************************Fiadores*********************************//
        public bool checarCamposVazios(cadFiador fiador)
        {
            if(fiador.txtNome.Text != "" && fiador.txtValorFianca.Text != "" && fiador.txtEmail.Text != "" 
                && fiador.txtEndereco.Text != "" && fiador.mtxtCpf.Text != "" && fiador.mtxtDataNasc.Text 
                != "" && fiador.mtxtRg.Text != "")
            {
                return true;
            }
            else
            {
                
                return false;
            }
            
        }

        public bool validaCpf(cadFiador fiador)
        {
            ds = new DataSet();

            bool checagem = false;

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar com a base de dados", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select cpf from Fiador", stringConexao.conn);

                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o Cpf dos fiadores", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }          

            stringConexao.conn.Close();

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (row[column].ToString() == fiador.mtxtCpf.Text)
                        {
                            checagem = true;
                        }
                    }
                }
            }
          
            if (checagem)
            {
               
                return false;
            }
            return true;
        }

        public bool validaRg(cadFiador fiador)
        {
            ds = new DataSet();
           
            bool checagem = false;

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar com a base de dados", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select rg from Fiador", stringConexao.conn);

                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o rg dos fiadores", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

           

            stringConexao.conn.Close();

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (row[column].ToString() == fiador.mtxtRg.Text)
                        {
                            checagem = true;
                        }
                    }
                }
            }

            
            if (checagem)
            {
                
                return false;
            }
            return true;
        }

        public bool validaEmail(cadFiador fiador)
        {
            char[] email = fiador.txtEmail.Text.ToCharArray();
            bool arroba = false;

            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == '@')
                {
                    arroba = true;
                }
            }

            if (arroba == false)
            {
               
                return false;
            }
            return true;
        }

        public bool checaEmail(cadFiador fiador)
        {
            ds = new DataSet();
            
            bool checagem = true;

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar com a base de dados", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select email from Fiador", stringConexao.conn);

                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o e-mail dos fiadores", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
           

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if(row[column].ToString() == fiador.txtEmail.Text)
                        {
                            checagem = false;
                        }
                    }
                }
            }
          

            return checagem;

        }

        public bool contaCpf(cadFiador fiador)
        {
            ds = new DataSet();
           
            int contador = 0;

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar.Contate o administrador do sistema",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select cpf from Fiador", stringConexao.conn);
                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o cpf dos fiadores. Tente novamente ou contate" +
                    " o administrador do sistema.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

          

            stringConexao.conn.Close();

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (row[column].ToString() == fiador.mtxtCpf.Text)
                        {
                            contador++;
                        }
                    }
                }
            }           

            if (fiador.mtxtCpf.Text == fiador.cpf) return true;
            else if ((fiador.mtxtCpf.Text != fiador.cpf) && contador == 0) return true;
            else return false;
        }

        public bool contaRg(cadFiador fiador)
        {
            ds = new DataSet();
           

            int contador = 0;
            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar.Contate o administrador do sistema",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select rg from Fiador", stringConexao.conn);
                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o rg dos fiadores. Tente novamente ou contate" +
                    " o administrador do sistema.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            

            stringConexao.conn.Close();

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (row[column].ToString() == fiador.mtxtRg.Text)
                        {
                            contador++;
                        }
                    }
                }
            }

            

            if (fiador.mtxtRg.Text == fiador.rg) return true;
            else if ((fiador.mtxtRg.Text != fiador.rg) && contador == 0) return true;
            else return false;
        }

        public bool contaEmail(cadFiador fiador)
        {
            ds = new DataSet();
            int contador = 0;
            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar.Contate o administrador do sistema",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select email from Fiador", stringConexao.conn);
                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o email dos fiadores. Tente novamente ou contate" +
                    " o administrador do sistema.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            

            stringConexao.conn.Close();

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (row[column].ToString() == fiador.txtEmail.Text)
                        {
                            contador++;
                        }
                    }
                }
            }

            if (fiador.txtEmail.Text == fiador.email) return true;
            else if ((fiador.txtEmail.Text != fiador.email) && contador == 0) return true;
            else return false;
        }

        //************************************Funcionários*********************************//
        public bool checarCamposVazios(CadFunc funcionario)
        {
            
            if (funcionario.txtNome.Text != ""  && funcionario.txtEmail.Text != ""
                && funcionario.txtEnd.Text != "" && funcionario.txtCpf.Text != "" && funcionario.txtDataNasc.Text
                != "" && funcionario.txtRg.Text != "" && funcionario.txtCargo.Text != "" && funcionario.txtSal.Text != "" 
                )
            {

                return true;
            }
            else
            {
               
                return false;
            }

        }

        public bool validaCpf(CadFunc funcionario)
        {
            ds = new DataSet();
            bool checagem = false;

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar com a base de dados", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select cpf from Funcionario", stringConexao.conn);

                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o Cpf dos funcionários", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            

            stringConexao.conn.Close();
            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (row[column].ToString() == funcionario.txtCpf.Text)
                        {
                            checagem = true;                          
                        }
                    }
                }
            }           
            if (checagem)
            {
                
                return false;
            }
            return true;
        }

        public bool validaRg(CadFunc funcionario)
        {
            ds = new DataSet();
            bool checagem = false;

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar com a base de dados", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select rg from Funcionario", stringConexao.conn);

                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o rg dos Funcionario", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            

            stringConexao.conn.Close();

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (row[column].ToString() == funcionario.txtRg.Text)
                        {
                            checagem = true;
                        }
                    }
                }
            }
            if (checagem)
            {
                
                return false;
            }
            return true;
        }

        public bool validaEmail(CadFunc funcionario)
        {
            char[] email = funcionario.txtEmail.Text.ToCharArray();
            bool arroba = false;

            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == '@')
                {
                    arroba = true;
                }
            }

            if (arroba == false)
            {
                
                return false;
            }
            return true;
        }

        public bool checaEmail(CadFunc funcionario)
        {
            ds = new DataSet();

            bool checagem = true;

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar com a base de dados", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select email from Funcionario", stringConexao.conn);

                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o e-mail dos funcionários", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (row[column].ToString() == funcionario.txtEmail.Text)
                        {
                            checagem = false;
                        }
                    }
                }
            }


            return checagem;

        }

        public bool contaCpf(CadFunc funcionario)
        {
            ds = new DataSet();
            int contador = 0;
            try
            {
                stringConexao.conn.Open();
            }catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar.Contate o administrador do sistema",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select cpf from Funcionario", stringConexao.conn);
                dataAdapter.Fill(ds);
            }catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o cpf dos funcionário. Tente novamente ou contate" +
                    " o administrador do sistema.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            

            stringConexao.conn.Close();

            foreach(DataTable table in ds.Tables)
            {
                foreach(DataRow row in table.Rows)
                {
                    foreach(DataColumn column in table.Columns)
                    {
                        if(row[column].ToString() == funcionario.txtCpf.Text)
                        {
                            contador++;
                            
                        }
                    }
                }
            }

            if (funcionario.txtCpf.Text == funcionario.cpf) return true;
            else if ((funcionario.txtCpf.Text != funcionario.cpf) && contador == 0) return true;
            else return false;
        }

        public bool contaRg(CadFunc funcionario)
        {
            ds = new DataSet();
            int contador = 0;
            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar.Contate o administrador do sistema",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select rg from Funcionario", stringConexao.conn);
                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o rg dos funcionário. Tente novamente ou contate" +
                    " o administrador do sistema.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            

            stringConexao.conn.Close();

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (row[column].ToString() == funcionario.txtRg.Text)
                        {
                            contador++;

                        }
                    }
                }
            }

            if (funcionario.txtRg.Text == funcionario.rg) return true;
            else if ((funcionario.txtRg.Text != funcionario.rg) && contador == 0) return true;
            else return false;

        }

        public bool contaEmail(CadFunc funcionario)
        {
            ds = new DataSet();
            int contador = 0;
            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar.Contate o administrador do sistema",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select email from Funcionario", stringConexao.conn);
                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o email dos funcionários. Tente novamente ou contate" +
                    " o administrador do sistema.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            stringConexao.conn.Close();

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (row[column].ToString() == funcionario.txtEmail.Text)
                        {
                            contador++;
                        }
                    }
                }
            }

            if (funcionario.txtEmail.Text == funcionario.email) return true;
            else if ((funcionario.txtEmail.Text != funcionario.email) && contador == 0) return true;
            else return false;

        }

        //************************************Locatários*********************************//
        public bool checarCamposVazios(CadLocatario locatario)
        {
            if (locatario.txtNome.Text != "" && locatario.txtEmail.Text != ""
                && locatario.txtEndereco.Text != "" && locatario.mtxtCpf.Text != "" && locatario.mtxtDataNasc.Text
                != "" && locatario.mtxtRg.Text != "")
            {

                return true;
            }
            else
            {
                
                return false;
            }

        }

        public bool validaCpf(CadLocatario locatario)
        {

            ds = new DataSet();
            bool checagem = false;

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar com a base de dados", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select cpf from Locatario", stringConexao.conn);

                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o Cpf dos locatarios", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            stringConexao.conn.Close();

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (row[column].ToString() == locatario.mtxtCpf.Text)
                        {
                            checagem = true;
                        }
                    }
                }
            }
            if (checagem)
            {
               
                return false;
            }
            return true;
        }

        public bool validaRg(CadLocatario locatario)
        {
            ds = new DataSet();
            bool checagem = false;

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar com a base de dados", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select rg from Locatario", stringConexao.conn);

                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o rg dos locatarios", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            stringConexao.conn.Close();

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (row[column].ToString() == locatario.mtxtRg.Text)
                        {
                            checagem = true;
                        }
                    }
                }
            }
            if (checagem)
            {
               
                return false;
            }
            return true;
        }

        public bool checaEmail(CadLocatario locatario)
        {
            ds = new DataSet();

            bool checagem = true;

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar com a base de dados", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select email from Locatario", stringConexao.conn);

                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o e-mail dos locatários", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (row[column].ToString() == locatario.txtEmail.Text)
                        {
                            checagem = false;
                        }
                    }
                }
            }


            return checagem;

        }

        public bool validaEmail(CadLocatario locatario)
        {
            char[] email = locatario.txtEmail.Text.ToCharArray();
            bool arroba = false;

            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == '@')
                {
                    arroba = true;
                }
            }

            if (arroba == false)
            {
               
                return false;
            }
            return true;
        }

        public bool contaCpf(CadLocatario locatario)
        {
            ds = new DataSet();
            int contador = 0;
            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar.Contate o administrador do sistema",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select cpf from Locatario", stringConexao.conn);
                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o cpf dos locatários. Tente novamente ou contate" +
                    " o administrador do sistema.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            stringConexao.conn.Close();

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (row[column].ToString() == locatario.mtxtCpf.Text)
                        {
                            contador++;
                        }
                    }
                }
            }

            if (locatario.mtxtCpf.Text == locatario.cpf) return true;
            else if ((locatario.mtxtCpf.Text != locatario.cpf) && contador == 0) return true;
            else return false;
        }

        public bool contaRg(CadLocatario locatario)
        {
            ds = new DataSet();
            int contador = 0;
            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar.Contate o administrador do sistema",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select rg from Locatario", stringConexao.conn);
                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o rg dos locatários. Tente novamente ou contate" +
                    " o administrador do sistema.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            stringConexao.conn.Close();

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (row[column].ToString() == locatario.mtxtRg.Text)
                        {
                            contador++;
                        }
                    }
                }
            }

            if (locatario.mtxtRg.Text == locatario.rg) return true;
            else if ((locatario.mtxtRg.Text != locatario.rg) && contador == 0) return true;
            else return false;
        }

        public bool contaEmail(CadLocatario locatario)
        {
            ds = new DataSet();
            int contador = 0;
            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar.Contate o administrador do sistema",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select email from Locatario", stringConexao.conn);
                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o email dos locatários. Tente novamente ou contate" +
                    " o administrador do sistema.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            stringConexao.conn.Close();

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (row[column].ToString() == locatario.txtEmail.Text)
                        {
                            contador++;
                        }
                    }
                }
            }

            if (locatario.txtEmail.Text == locatario.email) return true;
            else if ((locatario.txtEmail.Text != locatario.email) && contador == 0) return true;
            else return false;
        }

        //************************************Locador*********************************//
        public bool checarCamposVazios(CadLocImov1 locador)
        {
            if (locador.txtNome.Text != "" && locador.txtEmail.Text != ""
                && locador.txtEnd.Text != "" && locador.mtxtCpf.Text != "" && locador.mtxtDataNasc.Text
                != "" && locador.mtxtRg.Text != "")
            {

                return true;
            }
            else
            {
                
                return false;
            }

        }

        public bool validaCpf(CadLocImov1 locador)
        {

            ds = new DataSet();
            bool checagem = false;

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar com a base de dados", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select cpf from Locador", stringConexao.conn);

                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o Cpf dos locadores", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            stringConexao.conn.Close();

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (row[column].ToString() == locador.mtxtCpf.Text)
                        {
                            checagem = true;
                        }
                    }
                }
            }
            if (checagem)
            {
                return false;
            }
            return true;
        }

        public bool validaRg(CadLocImov1 locador)
        {
            ds = new DataSet();
            bool checagem = false;

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar com a base de dados", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select rg from Locador", stringConexao.conn);

                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o rg dos locador", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            stringConexao.conn.Close();

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (row[column].ToString() == locador.mtxtRg.Text)
                        {
                            checagem = true;
                        }
                    }
                }
            }
            if (checagem)
            {
                return false;
            }
            return true;
        }

        public bool validaEmail(CadLocImov1 locador)
        {
            
            
                char[] email = locador.txtEmail.Text.ToCharArray();
                bool arroba = false;

                for (int i = 0; i < email.Length; i++)
                {
                    if (email[i] == '@')
                    {
                        arroba = true;
                    }
                }

                if (arroba == false)
                {
                    return false;
                }
                return true;
            
            
            
        }

        public bool checaEmail(CadLocImov1 locador)
        {
            ds = new DataSet();

            bool checagem = true;

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar com a base de dados", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select email from Locador", stringConexao.conn);

                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o e-mail dos locadores", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (row[column].ToString() == locador.txtEmail.Text)
                        {
                            checagem = false;
                        }
                    }
                }
            }


            return checagem;

        }

        public bool contaCpf(CadLocImov1 locador)
        {
            ds = new DataSet();
            int contador = 0;
            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar.Contate o administrador do sistema",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select cpf from Locador", stringConexao.conn);
                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o cpf dos locadores. Tente novamente ou contate" +
                    " o administrador do sistema.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            stringConexao.conn.Close();

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (row[column].ToString() == locador.mtxtCpf.Text)
                        {
                            contador++;
                        }
                    }
                }
            }

            if (locador.mtxtCpf.Text == locador.cpf) return true;
            else if ((locador.mtxtCpf.Text != locador.cpf) && contador == 0) return true;
            else return false;
        }

        public bool contaRg(CadLocImov1 locador)
        {
            ds = new DataSet();
            int contador = 0;
            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar.Contate o administrador do sistema",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select rg from Locador", stringConexao.conn);
                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o rg dos locadores. Tente novamente ou contate" +
                    " o administrador do sistema.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            stringConexao.conn.Close();

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (row[column].ToString() == locador.mtxtRg.Text)
                        {
                            contador++;
                        }
                    }
                }
            }

            if (locador.mtxtRg.Text == locador.rg) return true;
            else if ((locador.mtxtRg.Text != locador.rg) && contador == 0) return true;
            else return false;
        }

        public bool contaEmail(CadLocImov1 locador)
        {
            ds = new DataSet();
            int contador = 0;
            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar.Contate o administrador do sistema",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select email from Locador", stringConexao.conn);
                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o email dos locadores. Tente novamente ou contate" +
                    " o administrador do sistema.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            stringConexao.conn.Close();

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (row[column].ToString() == locador.txtEmail.Text)
                        {
                            contador++;
                        }
                    }
                }
            }

            if (locador.txtEmail.Text == locador.email) return true;
            else if ((locador.txtEmail.Text != locador.email) && contador == 0) return true;
            else return false;
        }


        //************************************Salários*********************************//

        public bool validaValorLocacao (Locacao locacao)
        {
            Encoding enc = Encoding.GetEncoding("us-ascii",
                                          new EncoderExceptionFallback(),
                                          new DecoderExceptionFallback());

            char[] c = locacao.txtValorLocacao.Text.ToCharArray();

            byte[] b = enc.GetBytes(c);

            for (int i = 0; i < ((b.Length)/2); i++)
            {
                string st = b[i].ToString();
                st += b[i+1].ToString();
                int val = Convert.ToInt16(st);

                if(val >= 33 && val <= 47 || val >= 58 && val <= 185 || val >= 251 && val <= 255 )
                {
                    return false;
                }
               
            }
            return true;         
        }

        public bool validaSalario(CadLocatario2 renda)
        {
            Encoding enc = Encoding.GetEncoding("us-ascii",
                                          new EncoderExceptionFallback(),
                                          new DecoderExceptionFallback());

            char[] c = renda.txtSalarioBruto.Text.ToCharArray();

            byte[] b = enc.GetBytes(c);

            for (int i = 0; i < ((b.Length) / 2); i++)
            {
                string st = b[i].ToString();
                st += b[i + 1].ToString();
                int val = Convert.ToInt16(st);

                if (val >= 33 && val <= 47 || val >= 58 && val <= 185 || val >= 251 && val <= 255)
                {
                   
                    return false;
                }

            }
            return true;
        }

        public bool validaSalario(CadFunc funcionario)
        {
            Encoding enc = Encoding.GetEncoding("us-ascii",
                                          new EncoderExceptionFallback(),
                                          new DecoderExceptionFallback());

            char[] c = funcionario.txtSal.Text.ToCharArray();

            byte[] b = enc.GetBytes(c);

            for (int i = 0; i < ((b.Length) / 2); i++)
            {
                string st = b[i].ToString();
                st += b[i + 1].ToString();
                long val = Convert.ToInt64(st);

                if (val >= 33 && val <= 47 || val >= 58 && val <= 185 || val >= 251 && val <= 255)
                {
                    return false;
                }

            }
            return true;
        }

        //************************************VerAtendimentos*********************************//
        public bool validaDatagrid(VerAtendimentos atendimentos)
        {
            DataGridViewRow selectedRow = atendimentos.dgvAtendimentos.Rows[atendimentos.linha];

            try
            {
                string id_Atendimentos = selectedRow.Cells[0].Value.ToString();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            

            
        }

        //************************************VerFiadores*********************************//
        public bool validaDatagrid(verFiadores fiadores)
        {
            DataGridViewRow selectedRow = fiadores.dgvFiadores.Rows[fiadores.linha];

            try
            {
                string id_Fiadores = selectedRow.Cells[0].Value.ToString();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            

            
        }

        //************************************VerFontesDeRenda*********************************//
        public bool validaDatagrid(VerFontesDeRenda renda)
        {
            DataGridViewRow selectedRow = renda.dgvFonteDeRenda.Rows[renda.linha];

            try
            {
                string id_renda = selectedRow.Cells[0].Value.ToString();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

            
        }

        //************************************VerFuncionários*********************************//
        public bool validaDatagrid(VerFuncionarios funcionarios)
        {
            DataGridViewRow selectedRow = funcionarios.dataGridView1.Rows[funcionarios.linha];

            try
            {
                string id_funcionarios = selectedRow.Cells[0].Value.ToString();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

            
        }

        //************************************VerImóveis*********************************//
        public bool validaDatagrid(VerImoveis imoveis)
        {
            DataGridViewRow selectedRow = imoveis.dgvImovel.Rows[imoveis.linha];

            try
            {
                string id_imoveis = selectedRow.Cells[0].Value.ToString();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

            
        }

        //************************************VerLocacoes*********************************//
        public bool validaDatagrid(VerLocacoes locacoes)
        {
            DataGridViewRow selectedRow = locacoes.dgvLocacoes.Rows[locacoes.linha];

            try
            {
                string id_locacoes = selectedRow.Cells[0].Value.ToString();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

           
        }

        //************************************VerLocadores*********************************//
        public bool validaDatagrid(VerLocadores locadores)
        {
            DataGridViewRow selectedRow = locadores.dgvLocadores.Rows[locadores.linha];

            try
            {
                string id_locadores = selectedRow.Cells[0].Value.ToString();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

            
        }

        //************************************VerLocatarios*********************************//
        public bool validaDatagrid(VerLocatarios locatarios)
        {
            DataGridViewRow selectedRow = locatarios.dgvLocatario.Rows[locatarios.linha];

            try
            {
                string id_locatarios = selectedRow.Cells[0].Value.ToString();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

            
        }


        //************************************Métodos para limpar campos*****************************//
        public void limpar(Atendimento atendimento)
        {
            atendimento.txtCliente.Clear();
            atendimento.rtxtDescricao.Clear();
            atendimento.txtCliente.Focus();
        }

        public void limpar(cadFiador fiador)
        {
            fiador.txtEmail.Clear();
            fiador.txtEndereco.Clear();
            fiador.txtNome.Clear();
            fiador.txtValorFianca.Clear();
            fiador.mtxtCpf.Clear();
            fiador.mtxtDataNasc.Clear();
            fiador.mtxtRg.Clear();
            fiador.mtxtTelCel1.Clear();
            fiador.mtxtTelCel2.Clear();
            fiador.mtxtTelRel2.Clear();
            fiador.mtxtTelRes1.Clear();
            fiador.txtNome.Focus();
        }

        public void limpar(CadFunc funcionario)
        {
            funcionario.txtCpf.Clear();
            funcionario.txtCargo.Clear();
            funcionario.txtDataNasc.Clear();
            funcionario.txtEmail.Clear();
            funcionario.txtEnd.Clear();
            funcionario.txtNome.Clear();
            funcionario.txtRg.Clear();
            funcionario.txtSal.Clear();
            funcionario.txtTelCel1.Clear();
            funcionario.txtTelCel2.Clear();
            funcionario.txtTelRes1.Clear();
            funcionario.txtTelRes2.Clear();
            funcionario.txtNome.Focus();
        }

        public void limpar(CadLocatario locatario)
        {
            locatario.txtEmail.Clear();
            locatario.txtEndereco.Clear();
            locatario.txtNome.Clear();
            locatario.mtxtCpf.Clear();
            locatario.mtxtDataNasc.Clear();
            locatario.mtxtRg.Clear();
            locatario.mtxtTelCel1.Clear();
            locatario.mtxtTelCel2.Clear();
            locatario.mtxtTelRel2.Clear();
            locatario.mtxtTelRes1.Clear();
            locatario.txtNome.Focus();
        }

        public void limpar(CadLocatario2 renda)
        {
            renda.txtCargo.Clear();
            renda.txtEmpresa.Clear();
            renda.txtHora1.Clear();
            renda.txtHora2.Clear();
            renda.txtSalarioBruto.Clear();
            renda.mtxtTelComercial1.Clear();
            renda.mtxtTelComercial2.Clear();
            renda.txtEmpresa.Focus();
        }

        public void limpar(CadLocImov1 locador)
        {
            locador.txtEmail.Clear();
            locador.txtEnd.Clear();
            locador.txtNome.Clear();
            locador.mtxtCpf.Clear();
            locador.mtxtDataNasc.Clear();
            locador.mtxtRg.Clear();
            locador.mtxtTelCel1.Clear();
            locador.mtxtTelCel2.Clear();
            locador.mtxtTelRes1.Clear();
            locador.mtxtTelRes2.Clear();
            locador.txtNome.Focus();
        }

        public void limpar(cadLocImov2 imovel2)
        {
            imovel2.rtxtDescricao.Clear();
            imovel2.pbImovel.ImageLocation = null;
            imovel2.txtBairro.Clear();
            imovel2.txtComplemento.Clear();
            imovel2.txtNumero.Clear();
            imovel2.txtRuaAvenida.Clear();
            imovel2.txtCidade.Text = "";
            imovel2.cboStatus.SelectedItem = "";
            imovel2.cboUf.SelectedItem = "";
            imovel2.txtValorAluguel.Clear();
            imovel2.rtxtDescricao.Focus();
        }

        //************************************Definir tamanho dos campos*****************************//

        public void tamanho(CadFunc funcionario)
        {
            funcionario.txtNome.MaxLength = 95;
            funcionario.txtEmail.MaxLength = 95;
            funcionario.txtCargo.MaxLength = 95;
            funcionario.txtEnd.MaxLength = 95;
            funcionario.txtSal.MaxLength = 10;
        }

        public void tamanho(CadUsuario usuario)
        {
            usuario.txtUser.MaxLength = 10;
            usuario.txtSenha.MaxLength = 20;
            usuario.txtSenha2.MaxLength = 20;
        }

        public void tamanho(Atendimento atendimento)
        {
            atendimento.txtCliente.MaxLength = 100;
            atendimento.txtData.MaxLength = 13;
            atendimento.txtHorario.MaxLength = 13;
            atendimento.rtxtDescricao.MaxLength = 200;
        }

        public void tamanho(CadLocImov1 locador)
        {
            locador.txtNome.MaxLength = 98;
            locador.txtEmail.MaxLength = 98;
            locador.txtEnd.MaxLength = 98;
        }

        public void tamanho(CadLocatario locatario)
        {
            locatario.txtNome.MaxLength = 100;
            locatario.txtEmail.MaxLength = 100;
            locatario.txtEndereco.MaxLength = 100;
        }

        public void tamanho(cadFiador fiador)
        {
            fiador.txtNome.MaxLength = 100;
            fiador.txtEmail.MaxLength = 100;
            fiador.txtEndereco.MaxLength = 100;
            fiador.txtValorFianca.MaxLength = 15;
        }

        public void tamanho(CadLocatario2 renda)
        {
            renda.txtEmpresa.MaxLength = 200;
            renda.txtCargo.MaxLength = 100;
            renda.txtSalarioBruto.MaxLength = 15;
        }

        public void tamanho(CadLocImov3 imovel2)
        {
            imovel2.txtRuaAvenida.MaxLength = 200;
            imovel2.txtComplemento.MaxLength = 100;
            imovel2.txtBairro.MaxLength = 100;

        }

        public void tamanho(cadLocImov2 imovel2)
        {
            imovel2.rtxtDescricao.MaxLength = 190;
            imovel2.txtBairro.MaxLength = 90;
            imovel2.txtComplemento.MaxLength = 90;
            imovel2.txtNumero.MaxLength = 3;
            imovel2.txtRuaAvenida.MaxLength = 190;
            imovel2.txtCidade.MaxLength = 90;
            imovel2.txtValorAluguel.MaxLength = 15;
        }
      

        /////////////////O validando o número do imóvel//////////////

        public bool validaNumeroImovel(CadLocImov3 imovel2)
        {
            Encoding enc = Encoding.GetEncoding("us-ascii",
                                          new EncoderExceptionFallback(),
                                          new DecoderExceptionFallback());

            char[] c = imovel2.txtNumero.Text.ToCharArray();

            byte[] b = enc.GetBytes(c);

            for (int i = 0; i < ((b.Length) / 2); i++)
            {
                string st = b[i].ToString();
                st += b[i + 1].ToString();
                int val = Convert.ToInt16(st);

                if (val >= 33 && val <= 47 || val >= 58 && val <= 185 || val >= 251 && val <= 255)
                {
                    
                    return false;
                }

            }
            return true;
        }

        /////////////******************Checar Telefones*********************///////////////////////
        public bool checarTelefone(TextBox txtR1, TextBox txtR2, TextBox txtC1, TextBox txtC2)
        {
            string telR1 = txtR1.Text.Substring(1, 3);
            string telR2 = txtR2.Text.Substring(0, 4);
            telR2 += txtR2.Text.Substring(5);

            string telC1 = txtC1.Text.Substring(1, 3);
            string telC2 = txtC2.Text.Substring(0, 5);
            telC2 += txtC2.Text.Substring(6);

            int tamTelR1 = telR1.Length;
            int tamTelR2 = telR2.Length;

            int tamTelC1 = telC1.Length;
            int tamTelC2 = telC2.Length;

            if (telR1 != "" && telR2 != "" && tamTelR1 == 2 && tamTelR2 == 8)
            {
                if (telC1 != "" && telC2 != "" && tamTelC1 == 2 && tamTelC2 == 9)
                {
                    return true;
                }
                else
                {
                    return true;
                }
            }
            else if (telC1 != "" && telC2 != "" && tamTelC1 == 2 && tamTelC2 == 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool validaTelefone(MaskedTextBox txtR1, MaskedTextBox txtR2, MaskedTextBox txtC1, MaskedTextBox txtC2)
        {
            Encoding enc = Encoding.GetEncoding("us-ascii",
                                         new EncoderExceptionFallback(),
                                         new DecoderExceptionFallback());

            string telR1 = txtR1.Text;
            string telR2 = txtR2.Text;
            

            string telC1 = txtC1.Text;
            string telC2 = txtC2.Text;
           

            int contR1 = 0, contR2 = 0, contC1 = 0, contC2 = 0;

            for(int i = 0; i < telR1.Length; i++)
            {
                
                byte[] b = enc.GetBytes(telR1.Substring(i));
                string aux = b[0].ToString();
                    
                int num = Convert.ToInt16(aux);

                if (num >= 48 && num <= 57) contR1++;

            }

            for (int i = 0; i < telR2.Length; i++)
            {
                    byte[] c = enc.GetBytes(telR2.Substring(i));
                    string aux2 = c[0].ToString();

                    int num2 = Convert.ToInt16(aux2);

                    if (num2 >= 48 && num2 <= 57) contR2++;
 
            }

            for (int i = 0; i < telC1.Length; i++)
            {
                  byte[] b = enc.GetBytes(telC1.Substring(i));
                  string aux = b[0].ToString();

                  int num = Convert.ToInt16(aux);

                  if (num >= 48 && num <= 57) contC1++;
                
                

            }

            for (int i = 0; i < telC2.Length; i++)
            {
                
                byte[] c = enc.GetBytes(telC2.Substring(i));
                string aux2 = c[0].ToString();
                    

                int num2 = Convert.ToInt16(aux2);

                if (num2 >= 48 && num2 <= 57) contC2++;
                
                
            }
            if ((contR1 + contR2) == 12)
            {
                if ((contC1 + contC2) == 13) return true;
                else return true;
            }
            else if ((contC1 + contC2) == 13) return true;
            else return false;

        }

        public bool validaTelefone(TextBox txtR1, TextBox txtR2, TextBox txtC1, TextBox txtC2)
        {
            Encoding enc = Encoding.GetEncoding("us-ascii",
                                         new EncoderExceptionFallback(),
                                         new DecoderExceptionFallback());

            string telR1 = txtR1.Text;
            string telR2 = txtR2.Text;


            string telC1 = txtC1.Text;
            string telC2 = txtC2.Text;


            int contR1 = 0, contR2 = 0, contC1 = 0, contC2 = 0;

            for (int i = 0; i < telR1.Length; i++)
            {

                byte[] b = enc.GetBytes(telR1.Substring(i));
                string aux = b[0].ToString();

                int num = Convert.ToInt16(aux);

                if (num >= 48 && num <= 57) contR1++;

            }

            for (int i = 0; i < telR2.Length; i++)
            {
                byte[] c = enc.GetBytes(telR2.Substring(i));
                string aux2 = c[0].ToString();

                int num2 = Convert.ToInt16(aux2);

                if (num2 >= 48 && num2 <= 57) contR2++;

            }

            for (int i = 0; i < telC1.Length; i++)
            {
                byte[] b = enc.GetBytes(telC1.Substring(i));
                string aux = b[0].ToString();

                int num = Convert.ToInt16(aux);

                if (num >= 48 && num <= 57) contC1++;



            }

            for (int i = 0; i < telC2.Length; i++)
            {

                byte[] c = enc.GetBytes(telC2.Substring(i));
                string aux2 = c[0].ToString();


                int num2 = Convert.ToInt16(aux2);

                if (num2 >= 48 && num2 <= 57) contC2++;


            }
            if ((contR1 + contR2) == 12)
            {
                if ((contC1 + contC2) == 13) return true;
                else return true;
            }
            else if ((contC1 + contC2) == 13) return true;
            else return false;

        }

        /////////////******************Contar campos CPF e RG*********************///////////////////////
        public bool contarCamposCpf(MaskedTextBox mtxtCpf)
        {
            int tam = mtxtCpf.Text.Length;
            if (tam == 14) return true;
            else return false;
        }
        public bool contarCamposRg(MaskedTextBox mtxtRg)
        {
            int tam = mtxtRg.Text.Length;
            if (tam == 12) return true;
            else return false;
        }

        /////////////******************Validar Data*********************///////////////////////
        public bool validaData(MaskedTextBox mtxtData)
        {

            DateTime localDate = DateTime.Now;
            string data = localDate.ToString().Substring(6, 6);
            string aux = data.Substring(0, 4);
            int anoAtual = Convert.ToInt16(aux);
            int anoEscolhido;
            try
            {
                anoEscolhido = Convert.ToInt16(mtxtData.Text.Substring(6));
            }
            catch(Exception ex)
            {
                return false;
            }

            int diferenca = anoAtual - anoEscolhido;

            if(diferenca < 18)
            {
                return false;
            }
            return true;
        }

        /////////////******************Validar Salário*********************///////////////////////
        public bool validaSalario(TextBox txtSal)
        {
            int numero = 0;
            int ch = 0;

            Encoding enc = Encoding.GetEncoding("us-ascii",
                                         new EncoderExceptionFallback(),
                                         new DecoderExceptionFallback());
            string aux = txtSal.Text;
            for(int i = 0; i < aux.Length; i++)
            {
                byte[] b = enc.GetBytes(aux);
                string s = b[i].ToString();
                int num = Convert.ToInt16(s);

                if ((num >= 48 && num <= 57)) numero++;
                if ((num < 48 || num > 57) && num != 46 && num != 44) ch++;

            }

            if (ch != 0 && numero == 0) return false;
            else if (ch != 0 && numero != 0) return false;
            else return true;
            
        }
    }
}

    

    
