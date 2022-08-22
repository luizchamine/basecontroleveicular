using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIPrincipal
{
    public partial class FormLogin : Form
    {
        public bool Logou { get; set; }
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            BindingSource usuarioBindingSource = new BindingSource();
            try
            {
                usuarioBindingSource.DataSource = usuarioBLL.Buscar(textBoxUsuario.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (usuarioBindingSource.Count != 0)
            {
                string ativo = ((DataRowView)usuarioBindingSource.Current).Row["Ativo"].ToString();
                string nome = ((DataRowView)usuarioBindingSource.Current).Row["NomeUsuario"].ToString();
                string senha = ((DataRowView)usuarioBindingSource.Current).Row["Senha"].ToString();
                if ((nome == textBoxUsuario.Text) && (senha == textBoxSenha.Text) && ativo == "True")
                {
                    Usuario UsuarioLogado = new Usuario();
                    //.ToString()
                    UsuarioLogado.Id = Convert.ToInt32(((DataRowView)usuarioBindingSource.Current).Row["Id"]);
                    UsuarioLogado.NomeUsuario = ((DataRowView)usuarioBindingSource.Current).Row["NomeUsuario"].ToString();
                    Logou = true;
                    this.Hide();
                    using (FormPrincipal frm = new FormPrincipal())
                    {
                        frm.ShowDialog();
                    }
                    this.Close();
                }
                else if (ativo == "False")
                {
                    MessageBox.Show("USUARIO DESATIVADO!");
                    textBoxSenha.Text = "";
                    textBoxUsuario.Focus();
                }
                else if (senha != textBoxSenha.Text)
                {
                    MessageBox.Show("SENHA INCORRETA!");
                    textBoxSenha.Text = "";
                    textBoxSenha.Focus();
                }
                else if(nome != textBoxUsuario.Text)
                {
                    MessageBox.Show("USUARIO INCORRETO!");
                    textBoxSenha.Text = "";
                    textBoxSenha.Focus();
                }
            }
            else
            {
                MessageBox.Show("ERRO!");
                textBoxSenha.Text = "";
                textBoxSenha.Focus();
            }
        }
        private void textBoxSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttonLogin_Click(null, null);
        }

    }
}
