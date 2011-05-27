namespace Interface
{
    partial class EditSWList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSWList));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxCharactList = new System.Windows.Forms.GroupBox();
            this.dataGridViewTabelaSoftware = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSoftwareListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSoftwareWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tutorialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aHPTutorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sMARTTutorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.valueFNTutorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonAddnew = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxCharactList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTabelaSoftware)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxCharactList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(508, 515);
            this.splitContainer1.SplitterDistance = 463;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBoxCharactList
            // 
            this.groupBoxCharactList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCharactList.Controls.Add(this.dataGridViewTabelaSoftware);
            this.groupBoxCharactList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCharactList.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.groupBoxCharactList.Location = new System.Drawing.Point(12, 27);
            this.groupBoxCharactList.Name = "groupBoxCharactList";
            this.groupBoxCharactList.Size = new System.Drawing.Size(484, 433);
            this.groupBoxCharactList.TabIndex = 43;
            this.groupBoxCharactList.TabStop = false;
            this.groupBoxCharactList.Text = "Softwares List";
            // 
            // dataGridViewTabelaSoftware
            // 
            this.dataGridViewTabelaSoftware.BackgroundColor = System.Drawing.SystemColors.WindowFrame;
            this.dataGridViewTabelaSoftware.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTabelaSoftware.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridViewTabelaSoftware.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTabelaSoftware.Location = new System.Drawing.Point(3, 20);
            this.dataGridViewTabelaSoftware.Name = "dataGridViewTabelaSoftware";
            this.dataGridViewTabelaSoftware.Size = new System.Drawing.Size(478, 410);
            this.dataGridViewTabelaSoftware.TabIndex = 0;
            this.dataGridViewTabelaSoftware.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTabelaSoftware_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataBaseToolStripMenuItem,
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.editAccountToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(508, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataBaseToolStripMenuItem
            // 
            this.dataBaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.dataBaseToolStripMenuItem.Name = "dataBaseToolStripMenuItem";
            this.dataBaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.dataBaseToolStripMenuItem.Text = "DataBase";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editSoftwareListToolStripMenuItem,
            this.viewSoftwareWebsiteToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.fileToolStripMenuItem.Text = "Sotware";
            // 
            // editSoftwareListToolStripMenuItem
            // 
            this.editSoftwareListToolStripMenuItem.Name = "editSoftwareListToolStripMenuItem";
            this.editSoftwareListToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.editSoftwareListToolStripMenuItem.Text = "Edit software list";
            // 
            // viewSoftwareWebsiteToolStripMenuItem
            // 
            this.viewSoftwareWebsiteToolStripMenuItem.Enabled = false;
            this.viewSoftwareWebsiteToolStripMenuItem.Name = "viewSoftwareWebsiteToolStripMenuItem";
            this.viewSoftwareWebsiteToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.viewSoftwareWebsiteToolStripMenuItem.Text = "View Software website";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tutorialsToolStripMenuItem,
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // tutorialsToolStripMenuItem
            // 
            this.tutorialsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aHPTutorialToolStripMenuItem,
            this.sMARTTutorialToolStripMenuItem,
            this.valueFNTutorialToolStripMenuItem});
            this.tutorialsToolStripMenuItem.Name = "tutorialsToolStripMenuItem";
            this.tutorialsToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.tutorialsToolStripMenuItem.Text = "Tutorials";
            // 
            // aHPTutorialToolStripMenuItem
            // 
            this.aHPTutorialToolStripMenuItem.Name = "aHPTutorialToolStripMenuItem";
            this.aHPTutorialToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.aHPTutorialToolStripMenuItem.Text = "AHP Tutorial";
            // 
            // sMARTTutorialToolStripMenuItem
            // 
            this.sMARTTutorialToolStripMenuItem.Name = "sMARTTutorialToolStripMenuItem";
            this.sMARTTutorialToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.sMARTTutorialToolStripMenuItem.Text = "SMART Tutorial";
            // 
            // valueFNTutorialToolStripMenuItem
            // 
            this.valueFNTutorialToolStripMenuItem.Name = "valueFNTutorialToolStripMenuItem";
            this.valueFNTutorialToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.valueFNTutorialToolStripMenuItem.Text = "ValueFN Tutorial";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // editAccountToolStripMenuItem
            // 
            this.editAccountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem});
            this.editAccountToolStripMenuItem.Name = "editAccountToolStripMenuItem";
            this.editAccountToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.editAccountToolStripMenuItem.Text = "Edit Account";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            // 
            // buttonAddnew
            // 
            this.buttonAddnew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAddnew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddnew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAddnew.Location = new System.Drawing.Point(112, 11);
            this.buttonAddnew.Name = "buttonAddnew";
            this.buttonAddnew.Size = new System.Drawing.Size(125, 25);
            this.buttonAddnew.TabIndex = 0;
            this.buttonAddnew.Text = "Add new Sotfware";
            this.buttonAddnew.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(14, 11);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(125, 25);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.Text = "Delete Software";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.buttonAddnew);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.buttonDelete);
            this.splitContainer2.Size = new System.Drawing.Size(508, 48);
            this.splitContainer2.SplitterDistance = 250;
            this.splitContainer2.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Width = 40;
            // 
            // EditSWList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 515);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditSWList";
            this.Text = "Edit Software List";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxCharactList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTabelaSoftware)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxCharactList;
        private System.Windows.Forms.DataGridView dataGridViewTabelaSoftware;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSoftwareListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewSoftwareWebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tutorialsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aHPTutorialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sMARTTutorialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem valueFNTutorialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button buttonAddnew;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
    }
}