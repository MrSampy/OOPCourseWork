namespace MainForm.Windows
{
    partial class UserTable
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
            this.UserView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.UserView)).BeginInit();
            this.SuspendLayout();
            // 
            // UserView
            // 
            this.UserView.AllowDrop = true;
            this.UserView.AllowUserToAddRows = false;
            this.UserView.AllowUserToDeleteRows = false;
            this.UserView.BackgroundColor = System.Drawing.Color.IndianRed;
            this.UserView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UserView.GridColor = System.Drawing.Color.Firebrick;
            this.UserView.Location = new System.Drawing.Point(0, -2);
            this.UserView.Name = "UserView";
            this.UserView.ReadOnly = true;
            this.UserView.RowTemplate.Height = 25;
            this.UserView.Size = new System.Drawing.Size(343, 409);
            this.UserView.TabIndex = 0;
            // 
            // UserTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 405);
            this.Controls.Add(this.UserView);
            this.Name = "UserTable";
            this.Text = "UserTable";
            ((System.ComponentModel.ISupportInitialize)(this.UserView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView UserView;
    }
}