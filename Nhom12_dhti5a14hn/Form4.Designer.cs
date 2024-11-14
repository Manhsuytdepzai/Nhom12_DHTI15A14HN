namespace Nhom12_dhti5a14hn
{
    partial class Form4
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
            this.btn_xoact = new System.Windows.Forms.Button();
            this.btn_suact = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.txt_dchi = new System.Windows.Forms.TextBox();
            this.btn_them = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_mancc = new System.Windows.Forms.TextBox();
            this.txt_tenncc = new System.Windows.Forms.TextBox();
            this.display_ncc = new System.Windows.Forms.DataGridView();
            this.btn_back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.display_ncc)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_xoact
            // 
            this.btn_xoact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoact.Location = new System.Drawing.Point(289, 241);
            this.btn_xoact.Name = "btn_xoact";
            this.btn_xoact.Size = new System.Drawing.Size(121, 47);
            this.btn_xoact.TabIndex = 41;
            this.btn_xoact.Text = "Xoá";
            this.btn_xoact.UseVisualStyleBackColor = true;
            this.btn_xoact.Click += new System.EventHandler(this.btn_xoact_Click);
            // 
            // btn_suact
            // 
            this.btn_suact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_suact.Location = new System.Drawing.Point(162, 241);
            this.btn_suact.Name = "btn_suact";
            this.btn_suact.Size = new System.Drawing.Size(121, 47);
            this.btn_suact.TabIndex = 40;
            this.btn_suact.Text = "Sửa";
            this.btn_suact.UseVisualStyleBackColor = true;
            this.btn_suact.Click += new System.EventHandler(this.btn_suact_Click);
            // 
            // reset
            // 
            this.reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset.Location = new System.Drawing.Point(416, 241);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(121, 47);
            this.reset.TabIndex = 39;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // txt_dchi
            // 
            this.txt_dchi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dchi.Location = new System.Drawing.Point(202, 196);
            this.txt_dchi.Name = "txt_dchi";
            this.txt_dchi.Size = new System.Drawing.Size(324, 30);
            this.txt_dchi.TabIndex = 37;
            // 
            // btn_them
            // 
            this.btn_them.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_them.Location = new System.Drawing.Point(35, 241);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(121, 47);
            this.btn_them.TabIndex = 30;
            this.btn_them.Text = "Thêm ";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 25);
            this.label3.TabIndex = 35;
            this.label3.Text = "Địa chỉ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(44, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 25);
            this.label7.TabIndex = 33;
            this.label7.Text = "Mã NCC:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 25);
            this.label2.TabIndex = 34;
            this.label2.Text = "Tên NCC:";
            // 
            // txt_mancc
            // 
            this.txt_mancc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_mancc.Location = new System.Drawing.Point(202, 94);
            this.txt_mancc.Name = "txt_mancc";
            this.txt_mancc.Size = new System.Drawing.Size(324, 30);
            this.txt_mancc.TabIndex = 31;
            // 
            // txt_tenncc
            // 
            this.txt_tenncc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tenncc.Location = new System.Drawing.Point(202, 143);
            this.txt_tenncc.Name = "txt_tenncc";
            this.txt_tenncc.Size = new System.Drawing.Size(324, 30);
            this.txt_tenncc.TabIndex = 32;
            // 
            // display_ncc
            // 
            this.display_ncc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.display_ncc.Location = new System.Drawing.Point(543, 94);
            this.display_ncc.Name = "display_ncc";
            this.display_ncc.RowHeadersWidth = 51;
            this.display_ncc.RowTemplate.Height = 24;
            this.display_ncc.Size = new System.Drawing.Size(596, 590);
            this.display_ncc.TabIndex = 42;
            this.display_ncc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.display_ncc_CellClick);
            this.display_ncc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.display_ncc_CellContentClick);
            // 
            // btn_back
            // 
            this.btn_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.Location = new System.Drawing.Point(35, 26);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(74, 30);
            this.btn_back.TabIndex = 43;
            this.btn_back.Text = "<";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 696);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.display_ncc);
            this.Controls.Add(this.btn_xoact);
            this.Controls.Add(this.btn_suact);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.txt_dchi);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_mancc);
            this.Controls.Add(this.txt_tenncc);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.display_ncc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_xoact;
        private System.Windows.Forms.Button btn_suact;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.TextBox txt_dchi;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_mancc;
        private System.Windows.Forms.TextBox txt_tenncc;
        private System.Windows.Forms.DataGridView display_ncc;
        private System.Windows.Forms.Button btn_back;
    }
}