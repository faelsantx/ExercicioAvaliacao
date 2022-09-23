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
    public partial class ContasPagar : Form
    {
        public ContasPagar()
        {
            InitializeComponent();
            MostrarPagar();
            btnAlterar.Visible = false;
            btnDeletar.Visible = false;
        }

        string continua = "yes";
        private void btnInserir_Click(object sender, EventArgs e)
        {
            verificaVazio();
            Data();

            if (btnInserir.Text == "INSERIR" && continua == "yes")
            {
                if (MessageBox.Show("Deseja realmente inserir?", "INSERIR", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        using (MySqlConnection cnx = new MySqlConnection())
                        {
                            cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306; Convert Zero DateTime = true";
                            cnx.Open();
                            string sql = "insert into contas (nome,descricao,valor,dataVencimento,situacao,pago_recebido,tipo) values ('" + txtNome.Text + "','" + txtDescricao.Text + "','" + txtValor.Text + "','" + ClasseData.DataNova + "','Pagar','N/E','" + txtTipo.Text + "')";
                            MessageBox.Show("Inserido com sucesso!");
                            MySqlCommand cmd = new MySqlCommand(sql, cnx);
                            cmd.ExecuteNonQuery();


                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }


            }
            MostrarPagar();
            Limpar();


        }


        private void btnAlterar_Click(object sender, EventArgs e)
        {
            verificaVazio();
            Data();

            if (MessageBox.Show("Deseja realmente Alterar?", "ALTERAR", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                        cnn.Open();
                        string sql = "update contas set nome = '" + txtNome.Text + "',descricao = '" + txtDescricao.Text + "',valor = '" + txtValor.Text + "',tipo = '" + txtTipo.Text + "', dataVencimento = '" + ClasseData.DataNova + "' where idContasPagar = '" + txtIdContas.Text + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Atualizado com sucesso");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            txtIdContas.Clear();
            txtDescricao.Clear();
            txtNome.Clear();
            txtTipo.Clear();
            txtValor.Clear();

        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente deletar?", "Deletar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                        cnn.Open();
                        string sql = "delete from contas where idContasPagar = '" + txtIdContas.Text + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Deletado com sucesso!");

                    }
                    Limpar();
                    MostrarPagar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        void MostrarPagar()
        {
            try
            {
                using (MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                    cnx.Open();
                    string sql = "select * from contas where situacao = 'Pagar'";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cnx);
                    adapter.Fill(table);
                    dgwContasPagar.DataSource = table;
                    dgwContasPagar.AutoGenerateColumns = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgwContas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgwContasPagar.CurrentRow.Index != -1)
            {
                txtIdContas.Text = dgwContasPagar.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dgwContasPagar.CurrentRow.Cells[1].Value.ToString();
                txtDescricao.Text = dgwContasPagar.CurrentRow.Cells[2].Value.ToString();
                txtValor.Text = dgwContasPagar.CurrentRow.Cells[3].Value.ToString();
                dtpDataVencimento.Value = Convert.ToDateTime(dgwContasPagar.CurrentRow.Cells[4].Value.ToString());
                cbPago.Text = dgwContasPagar.CurrentRow.Cells[7].Value.ToString();
                txtTipo.Text = dgwContasPagar.CurrentRow.Cells[8].Value.ToString();

                string pago = cbPago.Text;

                if (pago == "Pago")
                {
                    cbPago.Checked = true;

                }
                else if (pago == "N/E")
                {
                    cbPago.Text = "Pago";
                    cbPago.Checked = false;
                }
                btnInserir.Text = "ADD NEW";
                btnDeletar.Visible = true;
                btnAlterar.Visible = true;
            }
        }
        void Data()
        {
            ClasseData.Data = dtpDataVencimento.Value;
            string dataCurta = ClasseData.Data.ToShortDateString();
            string[] vetData = dataCurta.Split('/');
            ClasseData.DataNova = $"{vetData[2]}-{vetData[1]}-{vetData[0]}";
        }
        void Limpar()
        {
            txtIdContas.Clear();
            txtDescricao.Clear();
            txtNome.Clear();
            txtTipo.Clear();
            txtValor.Clear();


            btnInserir.Text = "INSERIR";
            btnDeletar.Visible = false;
            btnAlterar.Visible = false;
        }
        void verificaVazio()
        {
            if (txtNome.Text == "" || txtDescricao.Text == "" || txtValor.Text == "" || txtTipo.Text == "")
            {
                continua = "no";
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                continua = "yes";
            }
        }

        private void ContasPagar_Load(object sender, EventArgs e)
        {

        }
    }
}