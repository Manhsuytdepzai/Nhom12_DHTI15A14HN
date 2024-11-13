namespace Nhom12_dhti5a14hn
{
    partial class Form3
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
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_ktra = new System.Windows.Forms.Button();
            this.display_qldh = new System.Windows.Forms.DataGridView();
            this.dtp_ngaylaphd = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_sl = new System.Windows.Forms.TextBox();
            this.t = new System.Windows.Forms.Label();
            this.btn_xoact = new System.Windows.Forms.Button();
            this.btn_suact = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.txt_sdt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_tenkh = new System.Windows.Forms.TextBox();
            this.txt_giaban = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_tenthuoc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_madhthem = new System.Windows.Forms.TextBox();
            this.txt_madh = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_mathuoc = new System.Windows.Forms.TextBox();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_themvao = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_tk = new System.Windows.Forms.TextBox();
            this.display_dh = new System.Windows.Forms.DataGridView();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.xuat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.display_qldh)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.display_dh)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_them
            // 
            this.btn_them.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_them.Location = new System.Drawing.Point(7, 283);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(121, 47);
            this.btn_them.TabIndex = 1;
            this.btn_them.Text = "Thêm ";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_back
            // 
            this.btn_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.Location = new System.Drawing.Point(12, 31);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(74, 30);
            this.btn_back.TabIndex = 17;
            this.btn_back.Text = "<";
            this.btn_back.UseVisualStyleBackColor = true;
            // 
            // btn_ktra
            // 
            this.btn_ktra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ktra.Location = new System.Drawing.Point(965, 97);
            this.btn_ktra.Name = "btn_ktra";
            this.btn_ktra.Size = new System.Drawing.Size(116, 47);
            this.btn_ktra.TabIndex = 16;
            this.btn_ktra.Text = "Kiểm Tra";
            this.btn_ktra.UseVisualStyleBackColor = true;
            this.btn_ktra.Click += new System.EventHandler(this.btn_ktra_Click);
            // 
            // display_qldh
            // 
            this.display_qldh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.display_qldh.Location = new System.Drawing.Point(546, 150);
            this.display_qldh.Name = "display_qldh";
            this.display_qldh.RowHeadersWidth = 51;
            this.display_qldh.RowTemplate.Height = 24;
            this.display_qldh.Size = new System.Drawing.Size(535, 242);
            this.display_qldh.TabIndex = 10;
            this.display_qldh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.display_qldh_CellClick);
            this.display_qldh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.display_qldh_CellContentClick);
            // 
            // dtp_ngaylaphd
            // 
            this.dtp_ngaylaphd.Location = new System.Drawing.Point(798, 36);
            this.dtp_ngaylaphd.Name = "dtp_ngaylaphd";
            this.dtp_ngaylaphd.Size = new System.Drawing.Size(283, 22);
            this.dtp_ngaylaphd.TabIndex = 18;
            this.dtp_ngaylaphd.ValueChanged += new System.EventHandler(this.dtp_ngaylaphd_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_sl);
            this.panel1.Controls.Add(this.t);
            this.panel1.Controls.Add(this.btn_xoact);
            this.panel1.Controls.Add(this.btn_suact);
            this.panel1.Controls.Add(this.reset);
            this.panel1.Controls.Add(this.txt_sdt);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txt_tenkh);
            this.panel1.Controls.Add(this.txt_giaban);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txt_tenthuoc);
            this.panel1.Controls.Add(this.btn_them);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_madhthem);
            this.panel1.Controls.Add(this.txt_madh);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txt_mathuoc);
            this.panel1.Location = new System.Drawing.Point(12, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 586);
            this.panel1.TabIndex = 19;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txt_sl
            // 
            this.txt_sl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sl.Location = new System.Drawing.Point(185, 247);
            this.txt_sl.Name = "txt_sl";
            this.txt_sl.Size = new System.Drawing.Size(324, 30);
            this.txt_sl.TabIndex = 31;
            // 
            // t
            // 
            this.t.AutoSize = true;
            this.t.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t.Location = new System.Drawing.Point(27, 247);
            this.t.Name = "t";
            this.t.Size = new System.Drawing.Size(105, 25);
            this.t.TabIndex = 30;
            this.t.Text = "Số lượng:";
            // 
            // btn_xoact
            // 
            this.btn_xoact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoact.Location = new System.Drawing.Point(261, 283);
            this.btn_xoact.Name = "btn_xoact";
            this.btn_xoact.Size = new System.Drawing.Size(121, 47);
            this.btn_xoact.TabIndex = 29;
            this.btn_xoact.Text = "Xoá";
            this.btn_xoact.UseVisualStyleBackColor = true;
            this.btn_xoact.Click += new System.EventHandler(this.btn_xoact_Click);
            // 
            // btn_suact
            // 
            this.btn_suact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_suact.Location = new System.Drawing.Point(134, 283);
            this.btn_suact.Name = "btn_suact";
            this.btn_suact.Size = new System.Drawing.Size(121, 47);
            this.btn_suact.TabIndex = 28;
            this.btn_suact.Text = "Sửa";
            this.btn_suact.UseVisualStyleBackColor = true;
            this.btn_suact.Click += new System.EventHandler(this.btn_suact_Click);
            // 
            // reset
            // 
            this.reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset.Location = new System.Drawing.Point(388, 283);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(121, 47);
            this.reset.TabIndex = 27;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // txt_sdt
            // 
            this.txt_sdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sdt.Location = new System.Drawing.Point(185, 469);
            this.txt_sdt.Name = "txt_sdt";
            this.txt_sdt.Size = new System.Drawing.Size(324, 30);
            this.txt_sdt.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(27, 469);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 25);
            this.label11.TabIndex = 21;
            this.label11.Text = "Sdth:";
            // 
            // txt_tenkh
            // 
            this.txt_tenkh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tenkh.Location = new System.Drawing.Point(185, 524);
            this.txt_tenkh.Name = "txt_tenkh";
            this.txt_tenkh.Size = new System.Drawing.Size(324, 30);
            this.txt_tenkh.TabIndex = 26;
            // 
            // txt_giaban
            // 
            this.txt_giaban.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_giaban.Location = new System.Drawing.Point(185, 199);
            this.txt_giaban.Name = "txt_giaban";
            this.txt_giaban.Size = new System.Drawing.Size(324, 30);
            this.txt_giaban.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 524);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 25);
            this.label4.TabIndex = 21;
            this.label4.Text = "Tên Kh:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(425, 46);
            this.label5.TabIndex = 20;
            this.label5.Text = "Thêm chi tiết hoá đơn";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(126, 368);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(289, 46);
            this.label9.TabIndex = 20;
            this.label9.Text = "Thêm hoá đơn";
            // 
            // txt_tenthuoc
            // 
            this.txt_tenthuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tenthuoc.Location = new System.Drawing.Point(185, 152);
            this.txt_tenthuoc.Name = "txt_tenthuoc";
            this.txt_tenthuoc.Size = new System.Drawing.Size(324, 30);
            this.txt_tenthuoc.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 25);
            this.label6.TabIndex = 21;
            this.label6.Text = "Giá bán:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 25);
            this.label3.TabIndex = 18;
            this.label3.Text = "Tên Thuốc:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "Mã DH:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "Mã thuốc:";
            // 
            // txt_madhthem
            // 
            this.txt_madhthem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_madhthem.Location = new System.Drawing.Point(185, 417);
            this.txt_madhthem.Name = "txt_madhthem";
            this.txt_madhthem.Size = new System.Drawing.Size(324, 30);
            this.txt_madhthem.TabIndex = 16;
            this.txt_madhthem.TextChanged += new System.EventHandler(this.txt_mathuoc_TextChanged);
            // 
            // txt_madh
            // 
            this.txt_madh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_madh.Location = new System.Drawing.Point(185, 67);
            this.txt_madh.Name = "txt_madh";
            this.txt_madh.Size = new System.Drawing.Size(324, 30);
            this.txt_madh.TabIndex = 16;
            this.txt_madh.TextChanged += new System.EventHandler(this.txt_mathuoc_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 422);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 25);
            this.label8.TabIndex = 17;
            this.label8.Text = "Mã DH:";
            // 
            // txt_mathuoc
            // 
            this.txt_mathuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_mathuoc.Location = new System.Drawing.Point(185, 116);
            this.txt_mathuoc.Name = "txt_mathuoc";
            this.txt_mathuoc.Size = new System.Drawing.Size(324, 30);
            this.txt_mathuoc.TabIndex = 16;
            this.txt_mathuoc.TextChanged += new System.EventHandler(this.txt_mathuoc_TextChanged);
            // 
            // btn_reset
            // 
            this.btn_reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset.Location = new System.Drawing.Point(960, 636);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(121, 47);
            this.btn_reset.TabIndex = 31;
            this.btn_reset.Text = "Reload";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_themvao
            // 
            this.btn_themvao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_themvao.Location = new System.Drawing.Point(546, 636);
            this.btn_themvao.Name = "btn_themvao";
            this.btn_themvao.Size = new System.Drawing.Size(121, 47);
            this.btn_themvao.TabIndex = 30;
            this.btn_themvao.Text = "Thêm ";
            this.btn_themvao.UseVisualStyleBackColor = true;
            this.btn_themvao.Click += new System.EventHandler(this.btn_themvao_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(363, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 46);
            this.label1.TabIndex = 20;
            this.label1.Text = "Quản Lý đơn hàng";
            // 
            // txt_tk
            // 
            this.txt_tk.Location = new System.Drawing.Point(546, 97);
            this.txt_tk.Multiline = true;
            this.txt_tk.Name = "txt_tk";
            this.txt_tk.Size = new System.Drawing.Size(413, 47);
            this.txt_tk.TabIndex = 21;
            this.txt_tk.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // display_dh
            // 
            this.display_dh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.display_dh.Location = new System.Drawing.Point(546, 406);
            this.display_dh.Name = "display_dh";
            this.display_dh.RowHeadersWidth = 51;
            this.display_dh.RowTemplate.Height = 24;
            this.display_dh.Size = new System.Drawing.Size(536, 219);
            this.display_dh.TabIndex = 32;
            this.display_dh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.display_dh_CellClick);
            this.display_dh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.display_dh_CellContentClick_1);
            // 
            // btn_sua
            // 
            this.btn_sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sua.Location = new System.Drawing.Point(682, 636);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(121, 47);
            this.btn_sua.TabIndex = 33;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoa.Location = new System.Drawing.Point(824, 636);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(121, 47);
            this.btn_xoa.TabIndex = 34;
            this.btn_xoa.Text = "Xoá";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // xuat
            // 
            this.xuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xuat.Location = new System.Drawing.Point(1008, 64);
            this.xuat.Name = "xuat";
            this.xuat.Size = new System.Drawing.Size(74, 30);
            this.xuat.TabIndex = 35;
            this.xuat.Text = "=>";
            this.xuat.UseVisualStyleBackColor = true;
            this.xuat.Click += new System.EventHandler(this.xuat_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 704);
            this.Controls.Add(this.xuat);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.display_dh);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.txt_tk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtp_ngaylaphd);
            this.Controls.Add(this.btn_ktra);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.display_qldh);
            this.Controls.Add(this.btn_themvao);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.display_qldh)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.display_dh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_ktra;
        private System.Windows.Forms.DataGridView display_qldh;
        private System.Windows.Forms.DateTimePicker dtp_ngaylaphd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_themvao;
        private System.Windows.Forms.TextBox txt_giaban;
        private System.Windows.Forms.TextBox txt_tenthuoc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_mathuoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_tk;
        private System.Windows.Forms.TextBox txt_tenkh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_madh;
        private System.Windows.Forms.TextBox txt_madhthem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_sdt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView display_dh;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button btn_suact;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_xoact;
        private System.Windows.Forms.TextBox txt_sl;
        private System.Windows.Forms.Label t;
        private System.Windows.Forms.Button xuat;
    }
}