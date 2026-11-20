namespace muzeumok
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBeolvasottAllapot = new System.Windows.Forms.Label();
            this.lblFajlUtvonal = new System.Windows.Forms.Label();
            this.btnFajlBetoltes = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblJegyEredmeny = new System.Windows.Forms.Label();
            this.btnJegyKereses = new System.Windows.Forms.Button();
            this.txtJegyAzonosito = new System.Windows.Forms.TextBox();
            this.lblJegySegitseg = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvStatisztika = new System.Windows.Forms.DataGridView();
            this.lblStatAllapot = new System.Windows.Forms.Label();
            this.btnStatMentese = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblNapijegyKastely = new System.Windows.Forms.Label();
            this.lblTeljesBevetel = new System.Windows.Forms.Label();
            this.lblZarasigIdo = new System.Windows.Forms.Label();
            this.lblUtolsoBelepo = new System.Windows.Forms.Label();
            this.lblElsoBelepo = new System.Windows.Forms.Label();
            this.lblOsszesLatogatas = new System.Windows.Forms.Label();
            this.ofdNapiFajl = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatisztika)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBeolvasottAllapot);
            this.groupBox1.Controls.Add(this.lblFajlUtvonal);
            this.groupBox1.Controls.Add(this.btnFajlBetoltes);
            this.groupBox1.Location = new System.Drawing.Point(12, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 151);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. Napi adatfájl beolvasása";
            // 
            // lblBeolvasottAllapot
            // 
            this.lblBeolvasottAllapot.AutoSize = true;
            this.lblBeolvasottAllapot.Location = new System.Drawing.Point(19, 129);
            this.lblBeolvasottAllapot.Name = "lblBeolvasottAllapot";
            this.lblBeolvasottAllapot.Size = new System.Drawing.Size(161, 16);
            this.lblBeolvasottAllapot.TabIndex = 2;
            this.lblBeolvasottAllapot.Text = "Állapot: várakozás a fájlra";
            // 
            // lblFajlUtvonal
            // 
            this.lblFajlUtvonal.AutoSize = true;
            this.lblFajlUtvonal.Location = new System.Drawing.Point(19, 78);
            this.lblFajlUtvonal.Name = "lblFajlUtvonal";
            this.lblFajlUtvonal.Size = new System.Drawing.Size(303, 16);
            this.lblFajlUtvonal.TabIndex = 1;
            this.lblFajlUtvonal.Text = "Még nincs fájl betöltve (várható: napi .txt állomány)";
            // 
            // btnFajlBetoltes
            // 
            this.btnFajlBetoltes.Location = new System.Drawing.Point(19, 35);
            this.btnFajlBetoltes.Name = "btnFajlBetoltes";
            this.btnFajlBetoltes.Size = new System.Drawing.Size(181, 23);
            this.btnFajlBetoltes.TabIndex = 0;
            this.btnFajlBetoltes.Text = "Napi .txt fájl betöltése...";
            this.btnFajlBetoltes.UseVisualStyleBackColor = true;
            this.btnFajlBetoltes.Click += new System.EventHandler(this.btnFajlBetoltes_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblJegyEredmeny);
            this.groupBox2.Controls.Add(this.btnJegyKereses);
            this.groupBox2.Controls.Add(this.txtJegyAzonosito);
            this.groupBox2.Controls.Add(this.lblJegySegitseg);
            this.groupBox2.Location = new System.Drawing.Point(12, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(425, 182);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "4. Jegy sorszámának keresése";
            // 
            // lblJegyEredmeny
            // 
            this.lblJegyEredmeny.AutoSize = true;
            this.lblJegyEredmeny.Location = new System.Drawing.Point(22, 140);
            this.lblJegyEredmeny.Name = "lblJegyEredmeny";
            this.lblJegyEredmeny.Size = new System.Drawing.Size(87, 16);
            this.lblJegyEredmeny.TabIndex = 3;
            this.lblJegyEredmeny.Text = "Eredmény: ---";
            // 
            // btnJegyKereses
            // 
            this.btnJegyKereses.Location = new System.Drawing.Point(19, 101);
            this.btnJegyKereses.Name = "btnJegyKereses";
            this.btnJegyKereses.Size = new System.Drawing.Size(103, 23);
            this.btnJegyKereses.TabIndex = 2;
            this.btnJegyKereses.Text = "Lekérdezés";
            this.btnJegyKereses.UseVisualStyleBackColor = true;
            this.btnJegyKereses.Click += new System.EventHandler(this.btnJegyKereses_Click);
            // 
            // txtJegyAzonosito
            // 
            this.txtJegyAzonosito.Location = new System.Drawing.Point(22, 73);
            this.txtJegyAzonosito.Name = "txtJegyAzonosito";
            this.txtJegyAzonosito.Size = new System.Drawing.Size(100, 22);
            this.txtJegyAzonosito.TabIndex = 1;
            // 
            // lblJegySegitseg
            // 
            this.lblJegySegitseg.AutoSize = true;
            this.lblJegySegitseg.Location = new System.Drawing.Point(22, 37);
            this.lblJegySegitseg.Name = "lblJegySegitseg";
            this.lblJegySegitseg.Size = new System.Drawing.Size(303, 16);
            this.lblJegySegitseg.TabIndex = 0;
            this.lblJegySegitseg.Text = "Adja meg a jegy azonosítóját (egész szám, pl. 12):";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvStatisztika);
            this.groupBox3.Controls.Add(this.lblStatAllapot);
            this.groupBox3.Controls.Add(this.btnStatMentese);
            this.groupBox3.Location = new System.Drawing.Point(12, 401);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(918, 186);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "8. Kastély óránkénti statisztika (10:00–18:00)";
            // 
            // dgvStatisztika
            // 
            this.dgvStatisztika.AllowUserToAddRows = false;
            this.dgvStatisztika.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatisztika.Location = new System.Drawing.Point(558, 21);
            this.dgvStatisztika.Name = "dgvStatisztika";
            this.dgvStatisztika.ReadOnly = true;
            this.dgvStatisztika.RowHeadersVisible = false;
            this.dgvStatisztika.RowHeadersWidth = 51;
            this.dgvStatisztika.RowTemplate.Height = 24;
            this.dgvStatisztika.Size = new System.Drawing.Size(354, 126);
            this.dgvStatisztika.TabIndex = 2;
            // 
            // lblStatAllapot
            // 
            this.lblStatAllapot.AutoSize = true;
            this.lblStatAllapot.Location = new System.Drawing.Point(25, 72);
            this.lblStatAllapot.Name = "lblStatAllapot";
            this.lblStatAllapot.Size = new System.Drawing.Size(47, 16);
            this.lblStatAllapot.TabIndex = 1;
            this.lblStatAllapot.Text = "Fájl: ---";
            // 
            // btnStatMentese
            // 
            this.btnStatMentese.Location = new System.Drawing.Point(19, 42);
            this.btnStatMentese.Name = "btnStatMentese";
            this.btnStatMentese.Size = new System.Drawing.Size(75, 23);
            this.btnStatMentese.TabIndex = 0;
            this.btnStatMentese.Text = "Statisztika mentése (+stat.txt)";
            this.btnStatMentese.UseVisualStyleBackColor = true;
            this.btnStatMentese.Click += new System.EventHandler(this.btnStatMentese_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblNapijegyKastely);
            this.groupBox4.Controls.Add(this.lblTeljesBevetel);
            this.groupBox4.Controls.Add(this.lblZarasigIdo);
            this.groupBox4.Controls.Add(this.lblUtolsoBelepo);
            this.groupBox4.Controls.Add(this.lblElsoBelepo);
            this.groupBox4.Controls.Add(this.lblOsszesLatogatas);
            this.groupBox4.Location = new System.Drawing.Point(443, 29);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(487, 295);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "2–7. Napi elemzések";
            // 
            // lblNapijegyKastely
            // 
            this.lblNapijegyKastely.AutoSize = true;
            this.lblNapijegyKastely.Location = new System.Drawing.Point(21, 273);
            this.lblNapijegyKastely.Name = "lblNapijegyKastely";
            this.lblNapijegyKastely.Size = new System.Drawing.Size(248, 16);
            this.lblNapijegyKastely.TabIndex = 5;
            this.lblNapijegyKastely.Text = "7. Napijegyesek Kastélyban kezdése: ---";
            // 
            // lblTeljesBevetel
            // 
            this.lblTeljesBevetel.AutoSize = true;
            this.lblTeljesBevetel.Location = new System.Drawing.Point(18, 220);
            this.lblTeljesBevetel.Name = "lblTeljesBevetel";
            this.lblTeljesBevetel.Size = new System.Drawing.Size(150, 16);
            this.lblTeljesBevetel.TabIndex = 4;
            this.lblTeljesBevetel.Text = "6. Napi teljes bevétel: ---";
            // 
            // lblZarasigIdo
            // 
            this.lblZarasigIdo.AutoSize = true;
            this.lblZarasigIdo.Location = new System.Drawing.Point(18, 171);
            this.lblZarasigIdo.Name = "lblZarasigIdo";
            this.lblZarasigIdo.Size = new System.Drawing.Size(273, 16);
            this.lblZarasigIdo.TabIndex = 3;
            this.lblZarasigIdo.Text = "5. Utolsó jegyvásárlás és 18:00 közötti idő: ---";
            // 
            // lblUtolsoBelepo
            // 
            this.lblUtolsoBelepo.AutoSize = true;
            this.lblUtolsoBelepo.Location = new System.Drawing.Point(18, 129);
            this.lblUtolsoBelepo.Name = "lblUtolsoBelepo";
            this.lblUtolsoBelepo.Size = new System.Drawing.Size(123, 16);
            this.lblUtolsoBelepo.TabIndex = 2;
            this.lblUtolsoBelepo.Text = "3. Utolsó belépő: ---";
            // 
            // lblElsoBelepo
            // 
            this.lblElsoBelepo.AutoSize = true;
            this.lblElsoBelepo.Location = new System.Drawing.Point(18, 78);
            this.lblElsoBelepo.Name = "lblElsoBelepo";
            this.lblElsoBelepo.Size = new System.Drawing.Size(111, 16);
            this.lblElsoBelepo.TabIndex = 1;
            this.lblElsoBelepo.Text = "3. Első belépő: ---";
            // 
            // lblOsszesLatogatas
            // 
            this.lblOsszesLatogatas.AutoSize = true;
            this.lblOsszesLatogatas.Location = new System.Drawing.Point(18, 38);
            this.lblOsszesLatogatas.Name = "lblOsszesLatogatas";
            this.lblOsszesLatogatas.Size = new System.Drawing.Size(142, 16);
            this.lblOsszesLatogatas.TabIndex = 0;
            this.lblOsszesLatogatas.Text = "2. Összes látogatás: ---";
            // 
            // ofdNapiFajl
            // 
            this.ofdNapiFajl.FileName = "openFileDialog1";
            this.ofdNapiFajl.Filter = "Szöveges fájl (*.txt)|*.txt|Minden fájl (*.*)|*.*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 613);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Múzeumok látogatottsági és jegyeladási elemző";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatisztika)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblBeolvasottAllapot;
        private System.Windows.Forms.Label lblFajlUtvonal;
        private System.Windows.Forms.Button btnFajlBetoltes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblJegyEredmeny;
        private System.Windows.Forms.Button btnJegyKereses;
        private System.Windows.Forms.TextBox txtJegyAzonosito;
        private System.Windows.Forms.Label lblJegySegitseg;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnStatMentese;
        private System.Windows.Forms.DataGridView dgvStatisztika;
        private System.Windows.Forms.Label lblStatAllapot;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblOsszesLatogatas;
        private System.Windows.Forms.Label lblNapijegyKastely;
        private System.Windows.Forms.Label lblTeljesBevetel;
        private System.Windows.Forms.Label lblZarasigIdo;
        private System.Windows.Forms.Label lblUtolsoBelepo;
        private System.Windows.Forms.Label lblElsoBelepo;
        private System.Windows.Forms.OpenFileDialog ofdNapiFajl;
    }
}

