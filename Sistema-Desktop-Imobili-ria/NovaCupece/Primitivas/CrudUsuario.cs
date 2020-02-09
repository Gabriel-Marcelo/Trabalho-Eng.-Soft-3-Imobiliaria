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
    class CrudUsuario
    {
        StringConexao stringConexao = new StringConexao();
        
        public SqlCommand comando;

        public void cadastrar(TextBox txtUser, TextBox txtSenha, int idFunc)
        {
            try
            {
                stringConexao.conn.Open();
            }catch(SqlException ex)
            {
                MessageBox.Show("Falha ao conectar a base de dados! Contate o administrador do sistema", 
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            comando = new SqlCommand();
            comando.Connection = stringConexao.conn;
            comando.CommandText = "insert into logar(usuario, senha, id_func, status_User) values ('" + txtUser.Text + "'," +
                " '" + txtSenha.Text + "', '" + idFunc + "', 'Ativo')";
            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro realizado com sucesso", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }catch(SqlException ex)
            {
                MessageBox.Show("Falha no Cadastro de Usuário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            stringConexao.conn.Close();
        }    
    }
}
