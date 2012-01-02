namespace Battleships
{
    partial class MainForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgPlayerShips = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgComputerShips = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayerShips)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgComputerShips)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(199, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BATTLESHIPS";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgPlayerShips);
            this.panel1.Location = new System.Drawing.Point(28, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 280);
            this.panel1.TabIndex = 1;
            // 
            // dgPlayerShips
            // 
            this.dgPlayerShips.AllowUserToAddRows = false;
            this.dgPlayerShips.AllowUserToDeleteRows = false;
            this.dgPlayerShips.AllowUserToResizeColumns = false;
            this.dgPlayerShips.AllowUserToResizeRows = false;
            this.dgPlayerShips.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPlayerShips.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgPlayerShips.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgPlayerShips.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPlayerShips.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgPlayerShips.Location = new System.Drawing.Point(0, 0);
            this.dgPlayerShips.MultiSelect = false;
            this.dgPlayerShips.Name = "dgPlayerShips";
            this.dgPlayerShips.ReadOnly = true;
            this.dgPlayerShips.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgPlayerShips.Size = new System.Drawing.Size(280, 280);
            this.dgPlayerShips.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgComputerShips);
            this.panel2.Location = new System.Drawing.Point(366, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 280);
            this.panel2.TabIndex = 2;
            // 
            // dgComputerShips
            // 
            this.dgComputerShips.AllowUserToAddRows = false;
            this.dgComputerShips.AllowUserToDeleteRows = false;
            this.dgComputerShips.AllowUserToResizeColumns = false;
            this.dgComputerShips.AllowUserToResizeRows = false;
            this.dgComputerShips.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgComputerShips.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgComputerShips.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgComputerShips.Location = new System.Drawing.Point(0, 0);
            this.dgComputerShips.Name = "dgComputerShips";
            this.dgComputerShips.Size = new System.Drawing.Size(280, 280);
            this.dgComputerShips.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "PLAYER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(363, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "COMPUTER";
            // 
            // lblStatus
            // 
            this.lblStatus.AllowDrop = true;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(24, 346);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 20);
            this.lblStatus.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(28, 394);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 42);
            this.button1.TabIndex = 6;
            this.button1.Text = "New Game";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 477);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitle);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayerShips)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgComputerShips)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgPlayerShips;
        private System.Windows.Forms.DataGridView dgComputerShips;

    }
}

