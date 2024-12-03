namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private ComboBox comboBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private System.Windows.Forms.Timer timer1;
        private Button button1;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button button2;
        private ProgressBar progressBar1;
        private TextBox textBox3;
        private TextBox textBox4;
        private DataGridView dataGridView1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            button2 = new Button();
            progressBar1 = new ProgressBar();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();

            // comboBox1
            comboBox1.FlatStyle = FlatStyle.Popup;
            comboBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(452, 17);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(318, 29);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

            // textBox1
            textBox1.BackColor = SystemColors.Menu;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Enabled = false;
            textBox1.Location = new Point(1433, 604);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(61, 16);
            textBox1.TabIndex = 1;
            textBox1.Text = "Version 2.1";

            // textBox2
            textBox2.BackColor = SystemColors.Menu;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Enabled = false;
            textBox2.Font = new Font("Segoe UI", 13F);
            textBox2.Location = new Point(12, 604);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(66, 24);
            textBox2.TabIndex = 2;
            textBox2.Text = "00:00:00";

            // timer1
            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;

            // button1
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(871, 17);
            button1.Name = "button1";
            button1.Size = new Size(84, 29);
            button1.TabIndex = 4;
            button1.Text = "Analyse";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Knopf;

            // button2
            button2.AllowDrop = true;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button2.Location = new Point(776, 17);
            button2.Name = "button2";
            button2.Size = new Size(89, 29);
            button2.TabIndex = 6;
            button2.Text = "Explorer";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;

            // progressBar1
            progressBar1.Location = new Point(871, 604);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(510, 18);
            progressBar1.TabIndex = 7;
            progressBar1.Click += progressBar1_Click;

            // textBox3
            textBox3.BackColor = SystemColors.Menu;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Enabled = false;
            textBox3.Location = new Point(747, 604);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(117, 16);
            textBox3.TabIndex = 8;
            textBox3.Text = "Aktueller Fortschritt:";

            // textBox4
            textBox4.BackColor = SystemColors.Menu;
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Enabled = false;
            textBox4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox4.Location = new Point(301, 24);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(145, 18);
            textBox4.TabIndex = 9;
            textBox4.Text = "zuletzt geöffnete Logs";

            // dataGridView1
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(196, 128);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1061, 347);
            dataGridView1.TabIndex = 10;

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1506, 632);
            Controls.Add(dataGridView1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(progressBar1);
            Controls.Add(textBox1);
            Controls.Add(textBox2);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "Form1";
            Text = "DpuLogViewer";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
