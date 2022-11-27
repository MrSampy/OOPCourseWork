namespace MainForm.Windows
{
    partial class ProductCreator
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
            this.button1 = new System.Windows.Forms.Button();
            this.productName = new System.Windows.Forms.TextBox();
            this.productCategory = new System.Windows.Forms.TextBox();
            this.productDesc = new System.Windows.Forms.TextBox();
            this.productPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(238, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create new product";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // productName
            // 
            this.productName.Location = new System.Drawing.Point(31, 102);
            this.productName.Name = "productName";
            this.productName.Size = new System.Drawing.Size(100, 23);
            this.productName.TabIndex = 1;
            // 
            // productCategory
            // 
            this.productCategory.Location = new System.Drawing.Point(174, 102);
            this.productCategory.Name = "productCategory";
            this.productCategory.Size = new System.Drawing.Size(100, 23);
            this.productCategory.TabIndex = 2;
            // 
            // productDesc
            // 
            this.productDesc.Location = new System.Drawing.Point(321, 102);
            this.productDesc.Name = "productDesc";
            this.productDesc.Size = new System.Drawing.Size(162, 23);
            this.productDesc.TabIndex = 3;
            // 
            // productPrice
            // 
            this.productPrice.Location = new System.Drawing.Point(525, 102);
            this.productPrice.Name = "productPrice";
            this.productPrice.Size = new System.Drawing.Size(91, 23);
            this.productPrice.TabIndex = 4;
            this.productPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.productPrice_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(525, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Price";
            // 
            // ProductCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 199);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productPrice);
            this.Controls.Add(this.productDesc);
            this.Controls.Add(this.productCategory);
            this.Controls.Add(this.productName);
            this.Controls.Add(this.button1);
            this.Name = "ProductCreator";
            this.Text = "ProductCreator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private TextBox productName;
        private TextBox productCategory;
        private TextBox productDesc;
        private TextBox productPrice;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}