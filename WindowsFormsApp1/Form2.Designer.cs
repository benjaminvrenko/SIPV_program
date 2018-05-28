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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cobissListView = new System.Windows.Forms.ListView();
            this.gradivoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tipHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.avtorjiHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.letoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viriHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.naslovBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.authorBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CobissSearchtextbox = new System.Windows.Forms.TextBox();
            this.CobissButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.stRezultatovCBox = new System.Windows.Forms.ComboBox();
            this.naslovgradivaBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cobissListView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(674, 480);
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
            this.cobissListView.Size = new System.Drawing.Size(668, 459);
            this.cobissListView.TabIndex = 0;
            this.cobissListView.UseCompatibleStateImageBehavior = false;
            this.cobissListView.View = System.Windows.Forms.View.Details;
            this.cobissListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.cobissListView_ItemSelectionChanged);
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
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.naslovBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.authorBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.CobissSearchtextbox);
            this.groupBox2.Controls.Add(this.CobissButton);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.stRezultatovCBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 307);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Iskanje po Cobiss-u";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "Iskanje po naslovu:";
            // 
            // naslovBox
            // 
            this.naslovBox.Location = new System.Drawing.Point(20, 134);
            this.naslovBox.Name = "naslovBox";
            this.naslovBox.Size = new System.Drawing.Size(215, 22);
            this.naslovBox.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 16);
            this.label4.TabIndex = 33;
            this.label4.Text = "Iskanje po avtorju:";
            // 
            // authorBox
            // 
            this.authorBox.Location = new System.Drawing.Point(20, 90);
            this.authorBox.Name = "authorBox";
            this.authorBox.Size = new System.Drawing.Size(215, 22);
            this.authorBox.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 16);
            this.label3.TabIndex = 31;
            this.label3.Text = "Iskanje po ključni besedi:";
            // 
            // CobissSearchtextbox
            // 
            this.CobissSearchtextbox.Location = new System.Drawing.Point(20, 46);
            this.CobissSearchtextbox.Name = "CobissSearchtextbox";
            this.CobissSearchtextbox.Size = new System.Drawing.Size(215, 22);
            this.CobissSearchtextbox.TabIndex = 30;
            // 
            // CobissButton
            // 
            this.CobissButton.Location = new System.Drawing.Point(168, 177);
            this.CobissButton.Name = "CobissButton";
            this.CobissButton.Size = new System.Drawing.Size(75, 27);
            this.CobissButton.TabIndex = 29;
            this.CobissButton.Text = "Išči";
            this.CobissButton.UseVisualStyleBackColor = true;
            this.CobissButton.Click += new System.EventHandler(this.CobissButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 224);
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
            this.stRezultatovCBox.Location = new System.Drawing.Point(173, 221);
            this.stRezultatovCBox.Name = "stRezultatovCBox";
            this.stRezultatovCBox.Size = new System.Drawing.Size(70, 24);
            this.stRezultatovCBox.TabIndex = 27;
            // 
            // naslovgradivaBox
            // 
            this.naslovgradivaBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.naslovgradivaBox.Location = new System.Drawing.Point(17, 49);
            this.naslovgradivaBox.Name = "naslovgradivaBox";
            this.naslovgradivaBox.Size = new System.Drawing.Size(215, 22);
            this.naslovgradivaBox.TabIndex = 25;
            this.naslovgradivaBox.TextChanged += new System.EventHandler(this.naslovgradivaBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Filtriraj po ključni besedi:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.naslovgradivaBox);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(278, 169);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtri";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Size = new System.Drawing.Size(278, 480);
            this.splitContainer2.SplitterDistance = 307;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(956, 480);
            this.splitContainer1.SplitterDistance = 674;
            this.splitContainer1.TabIndex = 1;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 480);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Iskalnik gradiv";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox authorBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox naslovBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}