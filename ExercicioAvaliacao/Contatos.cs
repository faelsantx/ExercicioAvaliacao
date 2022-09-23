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
    public partial class Contatos : Form
    {
        public Contatos()
        {
            InitializeComponent();
            Mostrar();
            btnAlterar.Visible = false;
            btnDeletar.Visible = false;
        }
        string continua;
        private void btnInserir_Click(object sender, EventArgs e)
        {
            Data();
            verificaVazio();

            if (btnInserir.Text == "INSERIR" && continua == "yes")
            {

                if (rbMasculino.Checked)
                {
                    try
                    {
                        using (MySqlConnection cnn = new MySqlConnection())
                        {
                            cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306";
                            cnn.Open();
                            MessageBox.Show("Inserido com sucesso!");
                            string sql = "insert into contato (nome,email,CPF,Sexo,dataNascimento,numeroCasa,complemento) values ('" + txtNome.Text + "','" + txtEmail.Text + "','" + txtCPF.Text + "','" + "M" + "','" + ClasseData.DataNova + "','" + txtNumero.Text + "', '" + txtComplemento.Text + "')";
                            MySqlCommand cmd = new MySqlCommand(sql, cnn);
                            cmd.ExecuteNonQuery();

                        }

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    try
                    {
                        using (MySqlConnection cnn = new MySqlConnection())
                        {
                            cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306";
                            cnn.Open();
                            MessageBox.Show("Inserido com sucesso!");
                            string sql = "insert into contato (nome,email,CPF,Sexo,dataNascimento,numeroCasa,complemento) values ('" + txtNome.Text + "','" + txtEmail.Text + "','" + txtCPF.Text + "','" + "F" + "','" + ClasseData.DataNova + "','" + txtNumero.Text + "', '" + txtComplemento.Text + "')";
                            MySqlCommand cmd = new MySqlCommand(sql, cnn);
                            cmd.ExecuteNonQuery();

                        }

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                }

                Mostrar();
                limpar();
            }
        }
            private void btnCadastrarTelefone_Click(object sender, EventArgs e)
            {
                Telefones telefone = new Telefones();
                telefone.Show();
            }
            void verificaVazio()
            {
                if (txtNome.Text == "" || txtEmail.Text == "" || txtCPF.Text == "" || txtBairro.Text == "" || txtCEP.Text == "" || txtLogradouro.Text == "" || txtCidade.Text == "" || cmbEstado.Text == "" || txtNumero.Text == "")
                {
                    continua = "no";
                    MessageBox.Show("Preencha todos os campos");
                }
                else
                {
                    continua = "yes";
                }
            }
            void Mostrar()
            {
                try
                {
                    using (MySqlConnection cnx = new MySqlConnection())
                    {
                        cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                        cnx.Open();
                        string sql = "select * from contato";
                        DataTable table = new DataTable();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cnx);
                        adapter.Fill(table);
                        dgwContatos.DataSource = table;
                        dgwContatos.AutoGenerateColumns = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            void Data()
            {
                ClasseData.Data = dtpData.Value;
                string dataCurta = ClasseData.Data.ToShortDateString();
                string[] vetData = dataCurta.Split('/');
                ClasseData.DataNova = $"{vetData[2]}-{vetData[1]}-{vetData[0]}";
            }
            void limpar()
            {
                txtIdContato.Text = "";
                txtNome.Text = "";
                cmbEstado.Text = "";
                txtEmail.Text = "";
                txtCPF.Text = "";
                txtBairro.Text = "";
                txtCidade.Text = "";
                txtComplemento.Text = "";
                txtLogradouro.Text = "";
                txtNumero.Text = "";
                txtCEP.Text = "";
                rbMasculino.Enabled = false;
                rbFeminino.Enabled = false;
                btnInserir.Text = "INSERIR";
                btnAlterar.Visible = false;
                btnDeletar.Visible = false;
            }

        
    } }
