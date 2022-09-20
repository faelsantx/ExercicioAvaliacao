using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercicioAvaliacao
{
    public partial class Agenda : Form
    {
        public Agenda()
        {
            InitializeComponent();
            mostrar();
            btnAlterar.Visible = false;
            btnDeletar.Visible = false;
        }

        string continua;
        private void btnInserir_Click(object sender, EventArgs e)
        {
            verificaVazio();

            try
            {
                using (MySqlConnection cnn = new MySqlConnection())
                {
                    cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306";
                    cnn.Open();
                    MessageBox.Show("Inserido com sucesso!");
                    string sql = "insert into agenda (titulo,data,hora) values ('" + txtTitulo.Text + "' , '" + dtpData.Text + "' , '" + cmbHora.Text + "')";
                    MySqlCommand cmd = new MySqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            mostrar();
            limpar();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            verificaVazio();

            if (DialogResult.Yes == MessageBox.Show("Deseja realmente alterar?", "Confirmação", MessageBoxButtons.YesNo))

                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306";
                        cnn.Open();
                        string sql = "Update controle set titulo='" + txtTitulo.Text + "', data'" + dtpData.Text + "' hora='" + cmbHora.Text + "' where id ='" + txtIdAgenda.Text + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Alterado com sucesso!");

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            mostrar();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {

            if (DialogResult.Yes == MessageBox.Show("Deseja realmente excluir?", "Confirmação", MessageBoxButtons.YesNo))
            {
                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306";
                        cnn.Open();
                        string sql = "Delete from agenda where id = '" + txtIdAgenda.Text + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Deletado com sucesso!");
                    }
                    limpar();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            mostrar();
        }

        private void dgwAgenda_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwAgenda.CurrentRow.Index != -1)
            {
                txtIdAgenda.Text = dgwAgenda.CurrentRow.Cells[0].Value.ToString();
                txtTitulo.Text = dgwAgenda.CurrentRow.Cells[1].Value.ToString();
                dtpData.Text = dgwAgenda.CurrentRow.Cells[2].Value.ToString();
                cmbHora.Text = dgwAgenda.CurrentRow.Cells[3].Value.ToString();

                btnDeletar.Visible = true;
                btnAlterar.Visible = true;
                btnInserir.Text = "Novo";
                txtPesquisar.Clear();


            }
        }
        void limpar()
        {
            txtIdAgenda.Text = "";
            txtTitulo.Text = "";
            cmbHora.Text = "";
            dtpData.Text = "";
            txtPesquisar.Text = "";
            btnInserir.Text = "Inserir";
            btnAlterar.Visible = false;
            btnDeletar.Visible = false;
        }

        void verificaVazio()
        {
            if (txtTitulo.Text == "" || dtpData.Text == "" || cmbHora.Text == "")
            {
                continua = "no";
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                continua = "yes";
            }
        }
        void mostrar()
        {
            try
            {
                using (MySqlConnection cnn = new MySqlConnection())
                {
                    cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306";
                    cnn.Open();
                    string sql = "Select * from agenda";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(sql, cnn);
                    adpter.Fill(table);
                    dgwAgenda.DataSource = table;

                    dgwAgenda.AutoGenerateColumns = false;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

    }
  
        void pegaData()
        {
            DateTime data = dtpData.Value;
            string dataCurta = data.ToShortDateString();
            string[] vetData = dataCurta.Split('/');
            string dataNova = vetData[2] + "-" + vetData[1] + "-" + vetData[0];    
            
            MessageBox.Show(dataNova);
        }



}
    
