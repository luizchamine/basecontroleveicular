using BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace UIPrincipal
{
    public partial class FormConsultaUsuario : Form
    {
        public FormConsultaUsuario()
        {
            InitializeComponent();
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormConsultaUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                buttonSair_Click(null, null);
            }
        }

        private void buttonNovo_Click(object sender, EventArgs e)
        {
            using (FormCadastroUsuario frm  = new FormCadastroUsuario())
            {
                frm.ShowDialog();
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            usuarioBindingSource.DataSource = usuarioBLL.Buscar(textBoxBuscar.Text);
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir este registro?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            UsuarioBLL usuarioBLL = new UsuarioBLL();
            int id;
            id = Convert.ToInt32(((DataRowView)usuarioBindingSource.Current).Row["Id"]);

            usuarioBLL.Excluir(id);
            usuarioBindingSource.RemoveCurrent();
            MessageBox.Show("Registro excluído com sucesso!");
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            using (FormCadastroUsuario frm = new FormCadastroUsuario(usuarioBindingSource.Current))
            {
                frm.ShowDialog();
            }
        }
    }
}
