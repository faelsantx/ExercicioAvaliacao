
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
    public partial class Telefones : Form
    {
        public Telefones()
        {
            InitializeComponent();
            btnDeletar.Visible = false;
            btnAlterar.Visible = false;
        }

        string continua = "yes";

        private void btnInserir_Click(object sender, EventArgs e)
        {

            verificaVazio();
            if (btnInserir.Text == "INSERIR" && continua == "yes")
            {
                if (MessageBox.Show("Deseja realmente inserir?", "INSERIR", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        using (MySqlConnection cnx = new MySqlConnection())
                        {
                            cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306";
                            cnx.Open();
                            string ID = txtID.Text;
                            string sql = "insert into telefone (fkContato, operadora, ddd, numero) values  ('" + txtID.Text + "','" + cmbOperadora.Text + "','" + txtDDD.Text + "','" + txtNumero.Text + "')";
                            MySqlCommand cmd = new MySqlCommand(sql, cnx);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Telefone cadastrado!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

            }
            Mostrar();
            Limpar();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente Alterar?", "ALTERAR", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection cnx = new MySqlConnection())
                    {
                        cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306";
                        cnx.Open();
                        string ID = txtID.Text;
                        string sql = "update telefone set DDD = '" + txtDDD.Text + "', operadora = '" + cmbOperadora.Text + "', numero = '" + txtNumero.Text + "' where idTelefone = '" + txtID.Text + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, cnx);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Telefone alterado!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            Mostrar();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente deletar?", "Deletar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection cnx = new MySqlConnection())
                    {
                        cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306";
                        cnx.Open();
                        string ID = txtID.Text;
                        string sql = "delete from telefone where idTelefone = '" + txtID.Text + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, cnx);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Telefone cadastrado!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            Mostrar();
            Limpar();
        }

        void Mostrar()
        {
            try
            {
                using (MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306";
                    cnx.Open();
                    string sql = "select idTelefone,nome,cpf,operadora,DDD,numero from contato inner join telefone where contato.idContato = telefone.fkContato and fkContato = '" + txtID.Text + "'";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cnx);
                    adapter.Fill(table);
                    dgwTelefones.DataSource = table;
                    dgwTelefones.AutoGenerateColumns = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Telefones(string idContatos)
        {
            InitializeComponent();
            txtID.Text = idContatos;
            Mostrar();
        }

        private void dgwTelefones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwTelefones.CurrentRow.Index != -1)
            {
                txtID.Text = dgwTelefones.CurrentRow.Cells[0].Value.ToString();
                cmbOperadora.Text = dgwTelefones.CurrentRow.Cells[3].Value.ToString();
                txtDDD.Text = dgwTelefones.CurrentRow.Cells[4].Value.ToString();
                txtNumero.Text = dgwTelefones.CurrentRow.Cells[5].Value.ToString();

                btnInserir.Text = "ADD NEW";
                btnDeletar.Visible = true;
                btnAlterar.Visible = true;
            }
        }
        void verificaVazio()
        {
            if (cmbOperadora.Text == "" || txtDDD.Text == "" || txtNumero.Text == "")
            {
                continua = "no";
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                continua = "yes";
            }
        }
        void Limpar()
        {
            txtDDD.Text = "";
            txtNumero.Text = "";
            txtID.Text = "";
            txtID.Text = "";
            cmbOperadora.Text = " ";

            btnInserir.Text = "INSERIR";
            btnDeletar.Visible = false;
            btnAlterar.Visible = false;
        }
    }
}