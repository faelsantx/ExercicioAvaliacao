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
        }

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
                        string sql = "insert into agenda (nome,descricao,valor,dataVencimento,dataConclusao,pago_recebido,tipo) values ('" + txtNome.Text + "','" + txtDescricao.Text + "','" + txtValor + "','" + .Text + "')";
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

        void Data()
        {
            ClasseData.Data = dtpdataVencimento.Value;
            string dataCurta = ClasseData.Data.ToShortDateString();
            string[] vetData = dataCurta.Split('/');
            ClasseData.DataNova = $"{vetData[2]}-{vetData[1]}-{vetData[0]}";
        }



    }

    
}
