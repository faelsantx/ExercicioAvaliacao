namespace ExercicioAvaliacao
{
    partial class ControleContas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgwContasPagar = new System.Windows.Forms.DataGridView();
            this.dgwContasReceber = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnReceber = new System.Windows.Forms.Button();
            this.btnContasPagar = new System.Windows.Forms.Button();
            this.btnContasReceber = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.labelPesquisa = new System.Windows.Forms.Label();
            this.labelIdConta = new System.Windows.Forms.Label();
            this.txtIdContas = new System.Windows.Forms.TextBox();
            this.txtPesquisa2 = new System.Windows.Forms.TextBox();
            this.labelPesquisa2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwContasPagar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwContasReceber)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwContasPagar
            // 
            this.dgwContasPagar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwContasPagar.Location = new System.Drawing.Point(33, 48);
            this.dgwContasPagar.Name = "dgwContasPagar";
            this.dgwContasPagar.Size = new System.Drawing.Size(500, 140);
            this.dgwContasPagar.TabIndex = 0;
            this.dgwContasPagar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwContasPagar_CellContentClick);
            // 
            // dgwContasReceber
            // 
            this.dgwContasReceber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwContasReceber.Location = new System.Drawing.Point(36, 251);
            this.dgwContasReceber.Name = "dgwContasReceber";
            this.dgwContasReceber.Size = new System.Drawing.Size(500, 140);
            this.dgwContasReceber.TabIndex = 1;
            this.dgwContasReceber.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwContasReceber_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Contas a Pagar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contas a receber";
            // 
            // btnPagar
            // 
            this.btnPagar.Location = new System.Drawing.Point(544, 75);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(119, 29);
            this.btnPagar.TabIndex = 4;
            this.btnPagar.Text = "PAGAR CONTA";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click_1);
            // 
            // btnReceber
            // 
            this.btnReceber.Location = new System.Drawing.Point(548, 279);
            this.btnReceber.Name = "btnReceber";
            this.btnReceber.Size = new System.Drawing.Size(119, 29);
            this.btnReceber.TabIndex = 4;
            this.btnReceber.Text = "RECEBER CONTA";
            this.btnReceber.UseVisualStyleBackColor = true;
            this.btnReceber.Click += new System.EventHandler(this.btnReceber_Click_1);
            // 
            // btnContasPagar
            // 
            this.btnContasPagar.Location = new System.Drawing.Point(669, 75);
            this.btnContasPagar.Name = "btnContasPagar";
            this.btnContasPagar.Size = new System.Drawing.Size(119, 29);
            this.btnContasPagar.TabIndex = 4;
            this.btnContasPagar.Text = "Contas a Pagar";
            this.btnContasPagar.UseVisualStyleBackColor = true;
            this.btnContasPagar.Click += new System.EventHandler(this.btnContasPagar_Click);
            // 
            // btnContasReceber
            // 
            this.btnContasReceber.Location = new System.Drawing.Point(673, 279);
            this.btnContasReceber.Name = "btnContasReceber";
            this.btnContasReceber.Size = new System.Drawing.Size(119, 29);
            this.btnContasReceber.TabIndex = 4;
            this.btnContasReceber.Text = "Contas a Receber";
            this.btnContasReceber.UseVisualStyleBackColor = true;
            this.btnContasReceber.Click += new System.EventHandler(this.btnContasReceber_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(36, 429);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(225, 28);
            this.btnPesquisar.TabIndex = 5;
            this.btnPesquisar.Text = "PESQUISAR";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(644, 124);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(144, 20);
            this.txtPesquisa.TabIndex = 6;
            // 
            // labelPesquisa
            // 
            this.labelPesquisa.AutoSize = true;
            this.labelPesquisa.Location = new System.Drawing.Point(588, 131);
            this.labelPesquisa.Name = "labelPesquisa";
            this.labelPesquisa.Size = new System.Drawing.Size(50, 13);
            this.labelPesquisa.TabIndex = 7;
            this.labelPesquisa.Text = "Pesquisa";
            // 
            // labelIdConta
            // 
            this.labelIdConta.AutoSize = true;
            this.labelIdConta.Location = new System.Drawing.Point(708, 19);
            this.labelIdConta.Name = "labelIdConta";
            this.labelIdConta.Size = new System.Drawing.Size(21, 13);
            this.labelIdConta.TabIndex = 8;
            this.labelIdConta.Text = "ID:";
            // 
            // txtIdContas
            // 
            this.txtIdContas.Location = new System.Drawing.Point(735, 12);
            this.txtIdContas.Name = "txtIdContas";
            this.txtIdContas.Size = new System.Drawing.Size(53, 20);
            this.txtIdContas.TabIndex = 9;
            // 
            // txtPesquisa2
            // 
            this.txtPesquisa2.Location = new System.Drawing.Point(644, 345);
            this.txtPesquisa2.Name = "txtPesquisa2";
            this.txtPesquisa2.Size = new System.Drawing.Size(144, 20);
            this.txtPesquisa2.TabIndex = 10;
            // 
            // labelPesquisa2
            // 
            this.labelPesquisa2.AutoSize = true;
            this.labelPesquisa2.Location = new System.Drawing.Point(588, 352);
            this.labelPesquisa2.Name = "labelPesquisa2";
            this.labelPesquisa2.Size = new System.Drawing.Size(50, 13);
            this.labelPesquisa2.TabIndex = 11;
            this.labelPesquisa2.Text = "Pesquisa";
            // 
            // ControleContas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 514);
            this.Controls.Add(this.labelPesquisa2);
            this.Controls.Add(this.txtPesquisa2);
            this.Controls.Add(this.txtIdContas);
            this.Controls.Add(this.labelIdConta);
            this.Controls.Add(this.labelPesquisa);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnReceber);
            this.Controls.Add(this.btnContasReceber);
            this.Controls.Add(this.btnContasPagar);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgwContasReceber);
            this.Controls.Add(this.dgwContasPagar);
            this.Name = "ControleContas";
            this.Text = "ControleContas";
            ((System.ComponentModel.ISupportInitialize)(this.dgwContasPagar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwContasReceber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwContasPagar;
        private System.Windows.Forms.DataGridView dgwContasReceber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnReceber;
        private System.Windows.Forms.Button btnContasPagar;
        private System.Windows.Forms.Button btnContasReceber;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Label labelPesquisa;
        private System.Windows.Forms.Label labelIdConta;
        private System.Windows.Forms.TextBox txtIdContas;
        private System.Windows.Forms.TextBox txtPesquisa2;
        private System.Windows.Forms.Label labelPesquisa2;
    }
}