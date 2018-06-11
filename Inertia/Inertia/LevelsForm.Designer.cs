namespace Inertia
{
    partial class LevelsForm
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
            this.buttonMenu = new System.Windows.Forms.Button();
            this.buttonLevel01 = new System.Windows.Forms.Button();
            this.buttonLevel02 = new System.Windows.Forms.Button();
            this.buttonLevel03 = new System.Windows.Forms.Button();
            this.labelScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonMenu
            // 
            this.buttonMenu.BackColor = System.Drawing.SystemColors.MenuText;
            this.buttonMenu.DialogResult = System.Windows.Forms.DialogResult.No;
            this.buttonMenu.Font = new System.Drawing.Font("Oswald", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMenu.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonMenu.Location = new System.Drawing.Point(39, 358);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(216, 77);
            this.buttonMenu.TabIndex = 6;
            this.buttonMenu.Text = "Menu";
            this.buttonMenu.UseVisualStyleBackColor = false;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // buttonLevel01
            // 
            this.buttonLevel01.BackColor = System.Drawing.SystemColors.MenuText;
            this.buttonLevel01.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.buttonLevel01.Font = new System.Drawing.Font("Oswald", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLevel01.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonLevel01.Location = new System.Drawing.Point(39, 81);
            this.buttonLevel01.Name = "buttonLevel01";
            this.buttonLevel01.Size = new System.Drawing.Size(216, 77);
            this.buttonLevel01.TabIndex = 5;
            this.buttonLevel01.Text = "Level 1";
            this.buttonLevel01.UseVisualStyleBackColor = false;
            this.buttonLevel01.Click += new System.EventHandler(this.buttonLevel01_Click);
            // 
            // buttonLevel02
            // 
            this.buttonLevel02.BackColor = System.Drawing.SystemColors.MenuText;
            this.buttonLevel02.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.buttonLevel02.Font = new System.Drawing.Font("Oswald", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLevel02.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonLevel02.Location = new System.Drawing.Point(39, 173);
            this.buttonLevel02.Name = "buttonLevel02";
            this.buttonLevel02.Size = new System.Drawing.Size(216, 77);
            this.buttonLevel02.TabIndex = 7;
            this.buttonLevel02.Text = "Level 2";
            this.buttonLevel02.UseVisualStyleBackColor = false;
            this.buttonLevel02.Click += new System.EventHandler(this.buttonLevel02_Click);
            // 
            // buttonLevel03
            // 
            this.buttonLevel03.BackColor = System.Drawing.SystemColors.MenuText;
            this.buttonLevel03.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.buttonLevel03.Font = new System.Drawing.Font("Oswald", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLevel03.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonLevel03.Location = new System.Drawing.Point(39, 265);
            this.buttonLevel03.Name = "buttonLevel03";
            this.buttonLevel03.Size = new System.Drawing.Size(216, 77);
            this.buttonLevel03.TabIndex = 8;
            this.buttonLevel03.Text = "Level 3";
            this.buttonLevel03.UseVisualStyleBackColor = false;
            this.buttonLevel03.Click += new System.EventHandler(this.buttonLevel03_Click);
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Oswald", 30F, System.Drawing.FontStyle.Bold);
            this.labelScore.Location = new System.Drawing.Point(12, 9);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(273, 60);
            this.labelScore.TabIndex = 9;
            this.labelScore.Text = "SELECT A LEVEL";
            // 
            // LevelsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 447);
            this.ControlBox = false;
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.buttonLevel03);
            this.Controls.Add(this.buttonLevel02);
            this.Controls.Add(this.buttonMenu);
            this.Controls.Add(this.buttonLevel01);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LevelsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.Button buttonLevel01;
        private System.Windows.Forms.Button buttonLevel02;
        private System.Windows.Forms.Button buttonLevel03;
        private System.Windows.Forms.Label labelScore;
    }
}