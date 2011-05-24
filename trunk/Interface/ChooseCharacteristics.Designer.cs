namespace Interface
{
    partial class ChooseCharacteristics
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
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxSelectedSoftwares = new System.Windows.Forms.GroupBox();
            this.listBoxSelectedCharact = new System.Windows.Forms.ListBox();
            this.groupBoxCharactList = new System.Windows.Forms.GroupBox();
            this.listBoxCharactList = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
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
            this.groupBoxSelectedSoftwares.SuspendLayout();
            this.groupBoxCharactList.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(437, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Info";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(437, 38);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(200, 23);
            this.progressBar1.TabIndex = 43;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(496, 411);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 42;
            this.button3.Text = "Next";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 241);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 41;
            this.button1.Text = "Remove";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBoxSelectedSoftwares
            // 
            this.groupBoxSelectedSoftwares.Controls.Add(this.listBoxSelectedCharact);
            this.groupBoxSelectedSoftwares.Location = new System.Drawing.Point(437, 203);
            this.groupBoxSelectedSoftwares.Name = "groupBoxSelectedSoftwares";
            this.groupBoxSelectedSoftwares.Size = new System.Drawing.Size(200, 182);
            this.groupBoxSelectedSoftwares.TabIndex = 40;
            this.groupBoxSelectedSoftwares.TabStop = false;
            this.groupBoxSelectedSoftwares.Text = "Selected Characteristics";
            // 
            // listBoxSelectedCharact
            // 
            this.listBoxSelectedCharact.FormattingEnabled = true;
            this.listBoxSelectedCharact.Location = new System.Drawing.Point(27, 20);
            this.listBoxSelectedCharact.Name = "listBoxSelectedCharact";
            this.listBoxSelectedCharact.Size = new System.Drawing.Size(151, 147);
            this.listBoxSelectedCharact.TabIndex = 0;
            // 
            // groupBoxCharactList
            // 
            this.groupBoxCharactList.Controls.Add(this.listBoxCharactList);
            this.groupBoxCharactList.Location = new System.Drawing.Point(34, 43);
            this.groupBoxCharactList.Name = "groupBoxCharactList";
            this.groupBoxCharactList.Size = new System.Drawing.Size(200, 390);
            this.groupBoxCharactList.TabIndex = 39;
            this.groupBoxCharactList.TabStop = false;
            this.groupBoxCharactList.Text = "Characteristics List";
            // 
            // listBoxCharactList
            // 
            this.listBoxCharactList.FormattingEnabled = true;
            this.listBoxCharactList.Location = new System.Drawing.Point(19, 28);
            this.listBoxCharactList.Name = "listBoxCharactList";
            this.listBoxCharactList.Size = new System.Drawing.Size(165, 342);
            this.listBoxCharactList.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(273, 172);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 38;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataBaseToolStripMenuItem,
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(674, 24);
            this.menuStrip1.TabIndex = 45;
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
            this.viewSoftwareWebsiteToolStripMenuItem.Name = "viewSoftwareWebsiteToolStripMenuItem";
            this.viewSoftwareWebsiteToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.viewSoftwareWebsiteToolStripMenuItem.Text = "View Software website";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tutorialsToolStripMenuItem});
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
            // ChooseCharacteristics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 492);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBoxSelectedSoftwares);
            this.Controls.Add(this.groupBoxCharactList);
            this.Controls.Add(this.button2);
            this.Name = "ChooseCharacteristics";
            this.Text = "Be SMART Software";
            this.Load += new System.EventHandler(this.ChooseCharacteristics_Load);
            this.groupBoxSelectedSoftwares.ResumeLayout(false);
            this.groupBoxCharactList.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBoxSelectedSoftwares;
        private System.Windows.Forms.ListBox listBoxSelectedCharact;
        private System.Windows.Forms.GroupBox groupBoxCharactList;
        private System.Windows.Forms.ListBox listBoxCharactList;
        private System.Windows.Forms.Button button2;
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
    }
}