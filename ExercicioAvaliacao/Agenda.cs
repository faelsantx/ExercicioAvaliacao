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
                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306";
                        cnn.Open();
                        MessageBox.Show("Inserido com sucesso!");
                        string sql = "insert into agenda (titulo,hora,data,descricao) values ('" + txtTitulo.Text + "','" + cmbHora.Text + "','" + ClasseData.DataNova + "','" + rtbDescricao.Text + "')";
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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Data();
            verificaVazio();

            if (continua == "yes")
            {
                if (DialogResult.Yes == MessageBox.Show("Deseja realmente alterar?", "Confirmação", MessageBoxButtons.YesNo))

                    try
                    {
                        using (MySqlConnection cnn = new MySqlConnection())
                        {
                            cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306";
                            cnn.Open();
                            string sql = "update agenda set hora = '" + cmbHora.Text + "',titulo = '" + txtTitulo.Text + "', descricao = '" + rtbDescricao.Text + "', data = '" + ClasseData.DataNova + "' where idAgenda = '" + txtIdAgenda.Text + "'";
                            MySqlCommand cmd = new MySqlCommand(sql, cnn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Alterado com sucesso!");

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
            }
                Mostrar();
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
                        string sql = "Delete from agenda where idAgenda = '" + txtIdAgenda.Text + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Deletado com sucesso!");
                    }
                    limpar();
                    Mostrar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            
        }

       
        void limpar()
        {
            txtIdAgenda.Text = "";
            txtTitulo.Text = "";
            cmbHora.Text = "";          
            txtPesquisar.Text = "";
            rtbDescricao.Text = "";
            btnInserir.Text = "INSERIR";
            btnAlterar.Visible = false;
            btnDeletar.Visible = false;
        }

        void verificaVazio()
        {
            if (txtTitulo.Text == "" || rtbDescricao.Text == "" || cmbHora.Text == "")
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
                    string sql = "select * from agenda";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cnx);
                    adapter.Fill(table);
                    dgwAgenda.DataSource = table;
                    dgwAgenda.AutoGenerateColumns = false;
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

        private void dgwAgenda_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwAgenda.CurrentRow.Index != -1)
            {
                txtIdAgenda.Text = dgwAgenda.CurrentRow.Cells[0].Value.ToString();
                txtTitulo.Text = dgwAgenda.CurrentRow.Cells[1].Value.ToString();
                cmbHora.Text = dgwAgenda.CurrentRow.Cells[2].Value.ToString();
                dtpData.Value = Convert.ToDateTime(dgwAgenda.CurrentRow.Cells[3].Value.ToString());
                rtbDescricao.Text = dgwAgenda.CurrentRow.Cells[4].Value.ToString();

                btnInserir.Text = "NOVO";
                btnDeletar.Visible = true;
                btnAlterar.Visible = true;
                txtPesquisar.Clear();


            }
        }
    
    
    
    
    
    
    
    
    
    }
  



}
    
