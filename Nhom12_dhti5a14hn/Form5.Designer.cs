namespace Nhom12_dhti5a14hn
{
    partial class Form5
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
            this.Tk = new System.Windows.Forms.Button();
            this.xoa = new System.Windows.Forms.Button();
            this.sua = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtdienthoai = new System.Windows.Forms.TextBox();
            this.txthoten = new System.Windows.Forms.TextBox();
            this.txtmakh = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Display_kh = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Display_kh)).BeginInit();
            this.SuspendLayout();
            // 
            // Tk
            // 
            this.Tk.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Tk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tk.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Tk.Location = new System.Drawing.Point(694, 547);
            this.Tk.Name = "Tk";
            this.Tk.Size = new System.Drawing.Size(106, 36);
            this.Tk.TabIndex = 16;
            this.Tk.Text = "Tìm Kiếm";
            this.Tk.UseVisualStyleBackColor = false;
            // 
            // xoa
            // 
            this.xoa.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xoa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.xoa.Location = new System.Drawing.Point(571, 547);
            this.xoa.Name = "xoa";
            this.xoa.Size = new System.Drawing.Size(75, 36);
            this.xoa.TabIndex = 15;
            this.xoa.Text = "Xóa ";
            this.xoa.UseVisualStyleBackColor = false;
            this.xoa.Click += new System.EventHandler(this.xoa_Click);
            // 
            // sua
            // 
            this.sua.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sua.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sua.Location = new System.Drawing.Point(442, 547);
            this.sua.Name = "sua";
            this.sua.Size = new System.Drawing.Size(75, 36);
            this.sua.TabIndex = 14;
            this.sua.Text = "Sửa ";
            this.sua.UseVisualStyleBackColor = false;
            this.sua.Click += new System.EventHandler(this.sua_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.label1.Location = new System.Drawing.Point(410, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 38);
            this.label1.TabIndex = 12;
            this.label1.Text = "Danh mục khách hàng ";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "sdt_kh";
            this.Column4.HeaderText = "Điện thoại";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // txtdienthoai
            // 
            this.txtdienthoai.Location = new System.Drawing.Point(146, 93);
            this.txtdienthoai.Name = "txtdienthoai";
            this.txtdienthoai.Size = new System.Drawing.Size(393, 23);
            this.txtdienthoai.TabIndex = 3;
            // 
            // txthoten
            // 
            this.txthoten.Location = new System.Drawing.Point(146, 64);
            this.txthoten.Name = "txthoten";
            this.txthoten.Size = new System.Drawing.Size(393, 23);
            this.txthoten.TabIndex = 2;
            // 
            // txtmakh
            // 
            this.txtmakh.Location = new System.Drawing.Point(146, 31);
            this.txtmakh.Name = "txtmakh";
            this.txtmakh.Size = new System.Drawing.Size(393, 23);
            this.txtmakh.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Điện thoại:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Họ tên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Khách hàng:";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "diachi_kh";
            this.Column3.HeaderText = "Địa chỉ";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 160;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "hoten_kh";
            this.Column2.HeaderText = "Họ tên";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 130;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ma_kh";
            this.Column1.HeaderText = "Mã KH";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtdienthoai);
            this.groupBox1.Controls.Add(this.txthoten);
            this.groupBox1.Controls.Add(this.txtmakh);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(294, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 137);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin khách hàng";
            // 
            // Display_kh
            // 
            this.Display_kh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Display_kh.Location = new System.Drawing.Point(294, 298);
            this.Display_kh.Name = "Display_kh";
            this.Display_kh.RowHeadersWidth = 51;
            this.Display_kh.RowTemplate.Height = 24;
            this.Display_kh.Size = new System.Drawing.Size(569, 219);
            this.Display_kh.TabIndex = 17;
            this.Display_kh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Display_kh_CellClick);
            this.Display_kh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Display_kh_CellContentClick);
            this.Display_kh.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Display_kh_DataBindingComplete);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 667);
            this.Controls.Add(this.Display_kh);
            this.Controls.Add(this.Tk);
            this.Controls.Add(this.xoa);
            this.Controls.Add(this.sua);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Display_kh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Tk;
        private System.Windows.Forms.Button xoa;
        private System.Windows.Forms.Button sua;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.TextBox txtdienthoai;
        private System.Windows.Forms.TextBox txthoten;
        private System.Windows.Forms.TextBox txtmakh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView Display_kh;
    }
}