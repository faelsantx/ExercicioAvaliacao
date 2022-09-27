

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            MostrarTelefone();
            btnAlterar.Visible = false;
            btnDeletar.Visible = false;

        }
        string continua = "yes";
        private void btnInserir_Click(object sender, EventArgs e)
        {

            Data();
            verificaVazio();

            if (btnInserir.Text == "INSERIR" && continua == "yes")
            {
                if (MessageBox.Show("Deseja realmente inserir?", "INSERIR", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        try
                        {
                            addEndereco();
                            using (MySqlConnection cnx = new MySqlConnection())
                            {
                                cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero datetime = true";
                                cnx.Open();
                                string sql;
                                if (rbMasculino.Checked)
                                {
                                    sql = "insert into contato (nome,cpf,dataNascimento,email,sexo,numeroCasa,complemento,fkEndereco) values ('" + txtNome.Text + "','" + txtCPF.Text + "','" + ClasseData.DataNova + "','" + txtEmail.Text + "','" + rbMasculino.Text + "','" + txtNumeroCasa.Text + "','" + txtComplemento.Text + "',( select idEndereco from endereco where  CEP = " + txtCEP.Text + " limit 1))";

                                }
                                else
                                {
                                    sql = "insert into contato (nome,cpf,dataNascimento,email,sexo,numeroCasa,complemento,fkEndereco) values ('" + txtNome.Text + "','" + txtCPF.Text + "','" + ClasseData.DataNova + "','" + txtEmail.Text + "','" + rbFeminino.Text + "','" + txtNumeroCasa.Text + "','" + txtComplemento.Text + "',( select idEndereco from endereco where  CEP =  " + txtCEP.Text + " limit 1))";

                                }
                                MessageBox.Show("Dados inseridos com sucesso!!!");
                                MySqlCommand cmd = new MySqlCommand(sql, cnx);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

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

        private void btnCadastrarTelefone_Click(object sender, EventArgs e)
        {
            Telefones telefone = new Telefones(txtID.Text);
            telefone.Show();


        }

        void Data()
        {
            ClasseData.Data = dtpData.Value;
            string dataCurta = ClasseData.Data.ToShortDateString();
            string[] vetData = dataCurta.Split('/');
            ClasseData.DataNova = $"{vetData[2]}-{vetData[1]}-{vetData[0]}";
        }
        void addEndereco()
        {

            try
            {
                using (MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306; Convert Zero Datetime = true";
                    cnx.Open();
                    string sql = "insert into endereco (logradouro,cidade,bairro,UF,cep) values ('" + txtLogradouro.Text + "','" + txtCidade.Text + "','" + txtBairro.Text + "','" + cmbUF.Text + "','" + txtCEP.Text + "')";
                    MySqlCommand cmd = new MySqlCommand(sql, cnx);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

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
                    string sql = "select idContato,nome,cpf,dataNascimento,email,sexo,cep,logradouro,numeroCasa,complemento,bairro,cidade,uf from endereco inner join contato on endereco.idEndereco = contato.fkEndereco";
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



        private void txtCEP_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cep = txtCEP.Text;


                using (MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306; Convert Zero DateTime = true";
                    cnx.Open();
                    string sql = "select logradouro,bairro,cidade,uf from endereco where cep = '" + cep + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, cnx);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {

                        string logradouro = reader["logradouro"].ToString();
                        txtLogradouro.Text = logradouro;
                        string bairro = reader["bairro"].ToString();
                        txtBairro.Text = bairro;
                        string cidade = reader["cidade"].ToString();
                        txtCidade.Text = cidade;
                        string uf = reader["uf"].ToString();
                        cmbUF.Text = uf;

                        txtLogradouro.Enabled = false;
                        txtBairro.Enabled = false;
                        txtCidade.Enabled = false;
                        cmbUF.Enabled = false;
                        txtNumeroCasa.Clear();
                    }
                    else
                    {
                        txtLogradouro.Clear();
                        txtBairro.Clear();
                        txtCidade.Clear();
                        cmbUF.Text = null;
                        txtLogradouro.Enabled = true;
                        txtBairro.Enabled = true;
                        txtCidade.Enabled = true;
                        cmbUF.Enabled = true;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Limpar()
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            txtCPF.Text = "";
            txtCEP.Text = "";
            txtLogradouro.Text = "";
            txtCidade.Text = "";
            txtBairro.Text = "";
            cmbUF.Text = null;
            rbMasculino.Checked = false;
            rbFeminino.Checked = false;
            txtNumeroCasa.Text = "";
            txtID.Text = "";
            txtComplemento.Text = "";

            btnInserir.Text = "INSERIR";
            btnDeletar.Visible = false;
            btnAlterar.Visible = false;
        }

        void verificaVazio()
        {
            if (txtNome.Text == "" || txtEmail.Text == "" || txtCPF.Text == "" || txtCEP.Text == "" || txtLogradouro.Text == "" || txtCidade.Text == "" || cmbUF.Text == "" || txtBairro.Text == "" || txtNumeroCasa.Text == "")
            {
                continua = "no";
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                continua = "yes";
            }
        }


        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            try
            {

                using (MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306; Convert Zero DateTime = true";
                    cnx.Open();
                    string sql = "select * from contato where nome like '" + txtPesquisar.Text + "%'";
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
        void MostrarTelefone()
        {
            try
            {
                using (MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                    cnx.Open();
                    string sql = "select DDD,numero,operadora from telefone inner join contato where contato.idContato = telefone.fkContato and idContato = '" + txtID.Text + "'";
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

        private void dgwContatos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwContatos.CurrentRow.Index != -1)
            {
                txtID.Text = dgwContatos.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dgwContatos.CurrentRow.Cells[1].Value.ToString();
                txtCPF.Text = dgwContatos.CurrentRow.Cells[2].Value.ToString();
                dtpData.Value = Convert.ToDateTime(dgwContatos.CurrentRow.Cells[3].Value.ToString());
                txtEmail.Text = dgwContatos.CurrentRow.Cells[4].Value.ToString();
                rbMasculino.Text = dgwContatos.CurrentRow.Cells[5].Value.ToString();
                string masculino = rbMasculino.Text;

                if (masculino == "Masculino")
                {
                    rbMasculino.Checked = true;
                    rbFeminino.Checked = false;

                }
                else
                {
                    rbMasculino.Text = "Masculino";
                    rbFeminino.Checked = true;
                    rbMasculino.Checked = false;
                }
                txtCEP.Text = dgwContatos.CurrentRow.Cells[6].Value.ToString();
                txtLogradouro.Text = dgwContatos.CurrentRow.Cells[7].Value.ToString();
                txtNumeroCasa.Text = dgwContatos.CurrentRow.Cells[8].Value.ToString();
                txtComplemento.Text = dgwContatos.CurrentRow.Cells[9].Value.ToString();
                txtBairro.Text = dgwContatos.CurrentRow.Cells[10].Value.ToString();
                txtCidade.Text = dgwContatos.CurrentRow.Cells[11].Value.ToString();
                cmbUF.Text = dgwContatos.CurrentRow.Cells[12].Value.ToString();

                btnInserir.Text = "NOVO";
                btnDeletar.Visible = true;
                btnAlterar.Visible = true;

            }
            MostrarTelefone();
        
    }

        private void btnAlterar_Click_1(object sender, EventArgs e)
        {
            Data();

            if (MessageBox.Show("Deseja realmente Alterar?", "ALTERAR", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection cnx = new MySqlConnection())
                    {
                        cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                        cnx.Open();
                        string sql = "insert into endereco (logradouro,cidade,bairro,UF,cep) values ('" + txtLogradouro.Text + "','" + txtCidade.Text + "','" + txtBairro.Text + "','" + cmbUF.Text + "','" + txtCEP.Text + "')";
                        txtLogradouro.Enabled = false;
                        txtBairro.Enabled = false;
                        txtCidade.Enabled = false;
                        cmbUF.Enabled = false;
                        string sql3 = "update contato set nome = '" + txtNome.Text + "',email = '" + txtEmail.Text + "', CPF = '" + txtCPF.Text + "', dataNascimento = '" + ClasseData.DataNova + "', numeroCasa = '" + txtNumeroCasa.Text + "', complemento = '" + txtComplemento.Text + "', fkEndereco = ( select idEndereco from endereco where  CEP = '" + txtCEP.Text + "' limit 1) where idContato = '" + txtID.Text + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, cnx);
                        cmd.ExecuteNonQuery();
                        MySqlCommand cmd3 = new MySqlCommand(sql3, cnx);
                        cmd3.ExecuteNonQuery();
                        MessageBox.Show("Atualizado com sucesso");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Mostrar();
        }

        private void btnDeletar_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente deletar?", "Deletar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                        cnn.Open();
                        string sql = "delete from contato where idContato = '" + txtID.Text + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Deletado com sucesso!");

                    }
                    Limpar();
                    Mostrar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}