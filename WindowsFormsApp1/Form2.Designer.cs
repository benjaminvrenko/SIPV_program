namespace WindowsFormsApp1
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cobissListView = new System.Windows.Forms.ListView();
            this.gradivoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tipHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.avtorjiHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.letoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viriHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.stRezultatovCBox = new System.Windows.Forms.ComboBox();
            this.naslovgradivaBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CobissButton = new System.Windows.Forms.Button();
            this.CobissSearchtextbox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 480);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cobissListView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(697, 480);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rezultati s Cobiss-a";
            // 
            // cobissListView
            // 
            this.cobissListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.gradivoHeader,
            this.tipHeader,
            this.avtorjiHeader,
            this.letoHeader,
            this.viriHeader});
            this.cobissListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cobissListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cobissListView.GridLines = true;
            this.cobissListView.Location = new System.Drawing.Point(3, 18);
            this.cobissListView.Name = "cobissListView";
            this.cobissListView.Size = new System.Drawing.Size(691, 459);
            this.cobissListView.TabIndex = 0;
            this.cobissListView.UseCompatibleStateImageBehavior = false;
            // 
            // gradivoHeader
            // 
            this.gradivoHeader.Text = "Naslov gradiva";
            this.gradivoHeader.Width = 230;
            // 
            // tipHeader
            // 
            this.tipHeader.Text = "Avtor";
            this.tipHeader.Width = 150;
            // 
            // avtorjiHeader
            // 
            this.avtorjiHeader.Text = "Tip";
            this.avtorjiHeader.Width = 120;
            // 
            // letoHeader
            // 
            this.letoHeader.Text = "Jezik";
            this.letoHeader.Width = 80;
            // 
            // viriHeader
            // 
            this.viriHeader.Text = "Leto izdaje";
            this.viriHeader.Width = 85;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CobissSearchtextbox);
            this.groupBox2.Controls.Add(this.CobissButton);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.stRezultatovCBox);
            this.groupBox2.Controls.Add(this.naslovgradivaBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(697, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 480);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtri";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "Št. prikazanih rezultatov:";
            // 
            // stRezultatovCBox
            // 
            this.stRezultatovCBox.FormattingEnabled = true;
            this.stRezultatovCBox.Items.AddRange(new object[] {
            "10",
            "25",
            "50",
            "100"});
            this.stRezultatovCBox.Location = new System.Drawing.Point(157, 79);
            this.stRezultatovCBox.Name = "stRezultatovCBox";
            this.stRezultatovCBox.Size = new System.Drawing.Size(70, 24);
            this.stRezultatovCBox.TabIndex = 27;
            // 
            // naslovgradivaBox
            // 
            this.naslovgradivaBox.Location = new System.Drawing.Point(9, 47);
            this.naslovgradivaBox.Name = "naslovgradivaBox";
            this.naslovgradivaBox.Size = new System.Drawing.Size(218, 22);
            this.naslovgradivaBox.TabIndex = 25;
            this.naslovgradivaBox.TextChanged += new System.EventHandler(this.naslovgradivaBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Po ključni besedi";
            // 
            // CobissButton
            // 
            this.CobissButton.Location = new System.Drawing.Point(152, 219);
            this.CobissButton.Name = "CobissButton";
            this.CobissButton.Size = new System.Drawing.Size(75, 23);
            this.CobissButton.TabIndex = 29;
            this.CobissButton.Text = "Isci";
            this.CobissButton.UseVisualStyleBackColor = true;
            this.CobissButton.Click += new System.EventHandler(this.CobissButton_Click);
            // 
            // CobissSearchtextbox
            // 
            this.CobissSearchtextbox.Location = new System.Drawing.Point(9, 191);
            this.CobissSearchtextbox.Name = "CobissSearchtextbox";
            this.CobissSearchtextbox.Size = new System.Drawing.Size(215, 22);
            this.CobissSearchtextbox.TabIndex = 30;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 480);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Iskalnik gradiv";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView cobissListView;
        private System.Windows.Forms.ColumnHeader gradivoHeader;
        private System.Windows.Forms.ColumnHeader tipHeader;
        private System.Windows.Forms.ColumnHeader avtorjiHeader;
        private System.Windows.Forms.ColumnHeader letoHeader;
        private System.Windows.Forms.ColumnHeader viriHeader;
        private System.Windows.Forms.TextBox naslovgradivaBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox stRezultatovCBox;
        private System.Windows.Forms.Button CobissButton;
        private System.Windows.Forms.TextBox CobissSearchtextbox;
    }
}