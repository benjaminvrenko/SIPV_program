namespace WindowsFormsApp1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.fakulteteGroupBox = new System.Windows.Forms.GroupBox();
            this.fakulteteListView = new System.Windows.Forms.ListView();
            this.fakulteteHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.iskanjeGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.stRezultatovCBox = new System.Windows.Forms.ComboBox();
            this.raziskovalciBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rezultatiGroupBox = new System.Windows.Forms.GroupBox();
            this.rezultatiListView = new System.Windows.Forms.ListView();
            this.evidencnaHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nazivHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.priimekHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.podrocjeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vedaHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.desniSplitContainer = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.fakulteteGroupBox.SuspendLayout();
            this.iskanjeGroupBox.SuspendLayout();
            this.rezultatiGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.desniSplitContainer)).BeginInit();
            this.desniSplitContainer.Panel1.SuspendLayout();
            this.desniSplitContainer.Panel2.SuspendLayout();
            this.desniSplitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1275, 26);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(78, 23);
            this.toolStripDropDownButton1.Text = "Datoteka";
            this.toolStripDropDownButton1.ToolTipText = "Datoteka";
            this.toolStripDropDownButton1.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 609);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1275, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // fakulteteGroupBox
            // 
            this.fakulteteGroupBox.Controls.Add(this.fakulteteListView);
            this.fakulteteGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fakulteteGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fakulteteGroupBox.Location = new System.Drawing.Point(0, 0);
            this.fakulteteGroupBox.Name = "fakulteteGroupBox";
            this.fakulteteGroupBox.Size = new System.Drawing.Size(386, 583);
            this.fakulteteGroupBox.TabIndex = 5;
            this.fakulteteGroupBox.TabStop = false;
            this.fakulteteGroupBox.Text = "Seznam fakultet";
            // 
            // fakulteteListView
            // 
            this.fakulteteListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fakulteteHeader});
            this.fakulteteListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fakulteteListView.Location = new System.Drawing.Point(3, 19);
            this.fakulteteListView.Name = "fakulteteListView";
            this.fakulteteListView.Size = new System.Drawing.Size(380, 561);
            this.fakulteteListView.TabIndex = 0;
            this.fakulteteListView.UseCompatibleStateImageBehavior = false;
            // 
            // fakulteteHeader
            // 
            this.fakulteteHeader.Text = "Fakultete";
            this.fakulteteHeader.Width = 600;
            // 
            // iskanjeGroupBox
            // 
            this.iskanjeGroupBox.Controls.Add(this.label5);
            this.iskanjeGroupBox.Controls.Add(this.raziskovalciBox);
            this.iskanjeGroupBox.Controls.Add(this.stRezultatovCBox);
            this.iskanjeGroupBox.Controls.Add(this.searchButton);
            this.iskanjeGroupBox.Controls.Add(this.label2);
            this.iskanjeGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iskanjeGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.iskanjeGroupBox.Location = new System.Drawing.Point(0, 0);
            this.iskanjeGroupBox.Name = "iskanjeGroupBox";
            this.iskanjeGroupBox.Size = new System.Drawing.Size(260, 583);
            this.iskanjeGroupBox.TabIndex = 4;
            this.iskanjeGroupBox.TabStop = false;
            this.iskanjeGroupBox.Text = "Iskanje";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "Ime/Priimek raziskovalca:";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(150, 134);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(83, 28);
            this.searchButton.TabIndex = 14;
            this.searchButton.Text = "Išči";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // stRezultatovCBox
            // 
            this.stRezultatovCBox.FormattingEnabled = true;
            this.stRezultatovCBox.Items.AddRange(new object[] {
            "15",
            "20",
            "30",
            "50",
            "75",
            "100"});
            this.stRezultatovCBox.Location = new System.Drawing.Point(182, 84);
            this.stRezultatovCBox.Name = "stRezultatovCBox";
            this.stRezultatovCBox.Size = new System.Drawing.Size(59, 24);
            this.stRezultatovCBox.TabIndex = 27;
            // 
            // raziskovalciBox
            // 
            this.raziskovalciBox.Location = new System.Drawing.Point(15, 48);
            this.raziskovalciBox.Name = "raziskovalciBox";
            this.raziskovalciBox.Size = new System.Drawing.Size(226, 23);
            this.raziskovalciBox.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "Št. prikazanih rezultatov:";
            // 
            // rezultatiGroupBox
            // 
            this.rezultatiGroupBox.Controls.Add(this.rezultatiListView);
            this.rezultatiGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rezultatiGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rezultatiGroupBox.Location = new System.Drawing.Point(0, 0);
            this.rezultatiGroupBox.Name = "rezultatiGroupBox";
            this.rezultatiGroupBox.Size = new System.Drawing.Size(625, 583);
            this.rezultatiGroupBox.TabIndex = 3;
            this.rezultatiGroupBox.TabStop = false;
            this.rezultatiGroupBox.Text = "Rezultati";
            // 
            // rezultatiListView
            // 
            this.rezultatiListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.evidencnaHeader,
            this.nazivHeader,
            this.priimekHeader,
            this.imeHeader,
            this.podrocjeHeader,
            this.vedaHeader});
            this.rezultatiListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rezultatiListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rezultatiListView.GridLines = true;
            this.rezultatiListView.Location = new System.Drawing.Point(3, 19);
            this.rezultatiListView.Name = "rezultatiListView";
            this.rezultatiListView.Size = new System.Drawing.Size(619, 561);
            this.rezultatiListView.TabIndex = 0;
            this.rezultatiListView.UseCompatibleStateImageBehavior = false;
            this.rezultatiListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.rezultatiListView_ItemSelectionChanged);
            // 
            // evidencnaHeader
            // 
            this.evidencnaHeader.Text = "Evid. št.";
            this.evidencnaHeader.Width = 90;
            // 
            // nazivHeader
            // 
            this.nazivHeader.Text = "Naziv";
            // 
            // priimekHeader
            // 
            this.priimekHeader.DisplayIndex = 3;
            this.priimekHeader.Text = "Priimek";
            this.priimekHeader.Width = 100;
            // 
            // imeHeader
            // 
            this.imeHeader.DisplayIndex = 2;
            this.imeHeader.Text = "Ime";
            this.imeHeader.Width = 100;
            // 
            // podrocjeHeader
            // 
            this.podrocjeHeader.Text = "Razisk. področje";
            this.podrocjeHeader.Width = 150;
            // 
            // vedaHeader
            // 
            this.vedaHeader.Text = "Gl. področje";
            this.vedaHeader.Width = 120;
            // 
            // desniSplitContainer
            // 
            this.desniSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.desniSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.desniSplitContainer.Name = "desniSplitContainer";
            // 
            // desniSplitContainer.Panel1
            // 
            this.desniSplitContainer.Panel1.Controls.Add(this.rezultatiGroupBox);
            // 
            // desniSplitContainer.Panel2
            // 
            this.desniSplitContainer.Panel2.Controls.Add(this.fakulteteGroupBox);
            this.desniSplitContainer.Size = new System.Drawing.Size(1015, 583);
            this.desniSplitContainer.SplitterDistance = 625;
            this.desniSplitContainer.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iskanjeGroupBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 583);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.desniSplitContainer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(260, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1015, 583);
            this.panel2.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 631);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Iskalnik";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.fakulteteGroupBox.ResumeLayout(false);
            this.iskanjeGroupBox.ResumeLayout(false);
            this.iskanjeGroupBox.PerformLayout();
            this.rezultatiGroupBox.ResumeLayout(false);
            this.desniSplitContainer.Panel1.ResumeLayout(false);
            this.desniSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.desniSplitContainer)).EndInit();
            this.desniSplitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox fakulteteGroupBox;
        private System.Windows.Forms.ListView fakulteteListView;
        private System.Windows.Forms.ColumnHeader fakulteteHeader;
        private System.Windows.Forms.GroupBox iskanjeGroupBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox raziskovalciBox;
        private System.Windows.Forms.ComboBox stRezultatovCBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox rezultatiGroupBox;
        private System.Windows.Forms.ListView rezultatiListView;
        private System.Windows.Forms.ColumnHeader evidencnaHeader;
        private System.Windows.Forms.ColumnHeader nazivHeader;
        private System.Windows.Forms.ColumnHeader priimekHeader;
        private System.Windows.Forms.ColumnHeader imeHeader;
        private System.Windows.Forms.ColumnHeader podrocjeHeader;
        private System.Windows.Forms.ColumnHeader vedaHeader;
        private System.Windows.Forms.SplitContainer desniSplitContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

