
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
    public partial class ControleContas : Form
    {
        public ControleContas()
        {
            InitializeComponent();
            MostrarPagar();
            MostrarReceber();
        }

        private void btnContasPagar_Click(object sender, EventArgs e)
        {
            ContasPagar contasPagar = new ContasPagar();
            contasPagar.Show();
        }

        private void btnContasReceber_Click(object sender, EventArgs e)
        {
            ContasReceber contasreceber = new ContasReceber();
            contasreceber.Show();
        }

        void MostrarPagar()
        {
            try
            {
                using (MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                    cnx.Open();
                    string sql = "select * from contas where situacao = 'Pagar' and pago_recebido = 'N/E'";
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
        void MostrarReceber()
        {
            try
            {
                using (MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                    cnx.Open();
                    string sql = "select * from contas where situacao = 'Receber' and pago_recebido = 'N/E'";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cnx);
                    adapter.Fill(table);
                    dgwContasReceber.DataSource = table;
                    dgwContasReceber.AutoGenerateColumns = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnPagar_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja efetuar o pagamento?", "PAGAMENTO", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {


                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {

                        cnn.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                        cnn.Open();
                        string sql = "update contas set pago_recebido = '1', dataConclusao = NOW()  where idContasPagar = '" + txtIdContas.Text + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Pagamento efetuado com sucesso!");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



            }
            MostrarPagar();
        }

        private void btnReceber_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmar o recebimento?", "RECEBIMENTO", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {


                        cnn.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                        cnn.Open();
                        string sql = "update contas set pago_recebido = '1',dataConclusao = NOW() where idContasPagar = '" + txtIdContas.Text + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Dinheiro recebido com sucesso!");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            MostrarReceber();
        }

        private void dgwContasPagar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwContasPagar.CurrentRow.Index != -1)
            {
                txtIdContas.Text = dgwContasPagar.CurrentRow.Cells[0].Value.ToString();
            }
        }

        private void dgwContasReceber_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwContasReceber.CurrentRow.Index != -1)
            {
                txtIdContas.Text = dgwContasReceber.CurrentRow.Cells[0].Value.ToString();
            }
        }
    }
}