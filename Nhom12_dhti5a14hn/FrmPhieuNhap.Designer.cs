namespace Nhom12_dhti5a14hn
{
    partial class FrmPhieuNhap
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
            this.display_pn = new System.Windows.Forms.DataGridView();
            this.btn_xoact = new System.Windows.Forms.Button();
            this.btn_suact = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_tt = new System.Windows.Forms.TextBox();
            this.txt_mancc = new System.Windows.Forms.TextBox();
            this.display_ctpn = new System.Windows.Forms.DataGridView();
            this.xoact = new System.Windows.Forms.Button();
            this.suact = new System.Windows.Forms.Button();
            this.btn_reset2 = new System.Windows.Forms.Button();
            this.themct = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMactpn = new System.Windows.Forms.TextBox();
            this.txt_idpn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaThuoc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_mapn = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.display_pn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.display_ctpn)).BeginInit();
            this.SuspendLayout();
            // 
            // display_pn
            // 
            this.display_pn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.display_pn.Location = new System.Drawing.Point(550, 96);
            this.display_pn.Name = "display_pn";
            this.display_pn.RowHeadersWidth = 51;
            this.display_pn.RowTemplate.Height = 24;
            this.display_pn.Size = new System.Drawing.Size(596, 215);
            this.display_pn.TabIndex = 53;
            this.display_pn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.display_pn_CellClick);
            // 
            // btn_xoact
            // 
            this.btn_xoact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoact.Location = new System.Drawing.Point(296, 264);
            this.btn_xoact.Name = "btn_xoact";
            this.btn_xoact.Size = new System.Drawing.Size(121, 47);
            this.btn_xoact.TabIndex = 52;
            this.btn_xoact.Text = "Xoá";
            this.btn_xoact.UseVisualStyleBackColor = true;
            this.btn_xoact.Click += new System.EventHandler(this.btn_xoact_Click);
            // 
            // btn_suact
            // 
            this.btn_suact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_suact.Location = new System.Drawing.Point(169, 264);
            this.btn_suact.Name = "btn_suact";
            this.btn_suact.Size = new System.Drawing.Size(121, 47);
            this.btn_suact.TabIndex = 51;
            this.btn_suact.Text = "Sửa";
            this.btn_suact.UseVisualStyleBackColor = true;
            this.btn_suact.Click += new System.EventHandler(this.btn_suact_Click);
            // 
            // reset
            // 
            this.reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset.Location = new System.Drawing.Point(423, 264);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(121, 47);
            this.reset.TabIndex = 50;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            // 
            // btn_them
            // 
            this.btn_them.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_them.Location = new System.Drawing.Point(42, 264);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(121, 47);
            this.btn_them.TabIndex = 43;
            this.btn_them.Text = "Thêm ";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(50, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 25);
            this.label7.TabIndex = 46;
            this.label7.Text = "Tổng tiền:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 25);
            this.label2.TabIndex = 47;
            this.label2.Text = "Mã NCC:";
            // 
            // txt_tt
            // 
            this.txt_tt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tt.Location = new System.Drawing.Point(220, 216);
            this.txt_tt.Name = "txt_tt";
            this.txt_tt.Size = new System.Drawing.Size(324, 30);
            this.txt_tt.TabIndex = 44;
            // 
            // txt_mancc
            // 
            this.txt_mancc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_mancc.Location = new System.Drawing.Point(220, 160);
            this.txt_mancc.Name = "txt_mancc";
            this.txt_mancc.Size = new System.Drawing.Size(324, 30);
            this.txt_mancc.TabIndex = 45;
            // 
            // display_ctpn
            // 
            this.display_ctpn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.display_ctpn.Location = new System.Drawing.Point(550, 389);
            this.display_ctpn.Name = "display_ctpn";
            this.display_ctpn.RowHeadersWidth = 51;
            this.display_ctpn.RowTemplate.Height = 24;
            this.display_ctpn.Size = new System.Drawing.Size(596, 304);
            this.display_ctpn.TabIndex = 62;
            this.display_ctpn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.display_ctpn_CellClick);
            this.display_ctpn.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.display_ctpn_CellContentClick);
            // 
            // xoact
            // 
            this.xoact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xoact.Location = new System.Drawing.Point(296, 646);
            this.xoact.Name = "xoact";
            this.xoact.Size = new System.Drawing.Size(121, 47);
            this.xoact.TabIndex = 61;
            this.xoact.Text = "Xoá";
            this.xoact.UseVisualStyleBackColor = true;
            this.xoact.Click += new System.EventHandler(this.xoact_Click);
            // 
            // suact
            // 
            this.suact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suact.Location = new System.Drawing.Point(169, 646);
            this.suact.Name = "suact";
            this.suact.Size = new System.Drawing.Size(121, 47);
            this.suact.TabIndex = 60;
            this.suact.Text = "Sửa";
            this.suact.UseVisualStyleBackColor = true;
            this.suact.Click += new System.EventHandler(this.suact_Click);
            // 
            // btn_reset2
            // 
            this.btn_reset2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset2.Location = new System.Drawing.Point(423, 646);
            this.btn_reset2.Name = "btn_reset2";
            this.btn_reset2.Size = new System.Drawing.Size(121, 47);
            this.btn_reset2.TabIndex = 59;
            this.btn_reset2.Text = "Reset";
            this.btn_reset2.UseVisualStyleBackColor = true;
            // 
            // themct
            // 
            this.themct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themct.Location = new System.Drawing.Point(42, 646);
            this.themct.Name = "themct";
            this.themct.Size = new System.Drawing.Size(121, 47);
            this.themct.TabIndex = 54;
            this.themct.Text = "Thêm ";
            this.themct.UseVisualStyleBackColor = true;
            this.themct.Click += new System.EventHandler(this.themct_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 57;
            this.label1.Text = "Mã CTPN:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 493);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 25);
            this.label3.TabIndex = 58;
            this.label3.Text = "Mã Thuốc:";
            // 
            // txtMactpn
            // 
            this.txtMactpn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMactpn.Location = new System.Drawing.Point(220, 389);
            this.txtMactpn.Name = "txtMactpn";
            this.txtMactpn.Size = new System.Drawing.Size(324, 30);
            this.txtMactpn.TabIndex = 55;
            // 
            // txt_idpn
            // 
            this.txt_idpn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_idpn.Location = new System.Drawing.Point(220, 438);
            this.txt_idpn.Name = "txt_idpn";
            this.txt_idpn.Size = new System.Drawing.Size(324, 30);
            this.txt_idpn.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 443);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 25);
            this.label4.TabIndex = 65;
            this.label4.Text = "Mã Phiếu nhập:";
            // 
            // txtMaThuoc
            // 
            this.txtMaThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaThuoc.Location = new System.Drawing.Point(220, 488);
            this.txtMaThuoc.Name = "txtMaThuoc";
            this.txtMaThuoc.Size = new System.Drawing.Size(324, 30);
            this.txtMaThuoc.TabIndex = 63;
            this.txtMaThuoc.TextChanged += new System.EventHandler(this.txtMaThuoc_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 539);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 25);
            this.label6.TabIndex = 69;
            this.label6.Text = "Đơn giá:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(37, 590);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 25);
            this.label8.TabIndex = 70;
            this.label8.Text = "Số lượng:";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonGia.Location = new System.Drawing.Point(220, 536);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(324, 30);
            this.txtDonGia.TabIndex = 67;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.Location = new System.Drawing.Point(220, 585);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(324, 30);
            this.txtSoLuong.TabIndex = 68;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(390, 328);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(370, 46);
            this.label9.TabIndex = 71;
            this.label9.Text = "Chi tiết phiếu nhập";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(446, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(231, 46);
            this.label10.TabIndex = 71;
            this.label10.Text = "Phiếu nhập";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(50, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(164, 25);
            this.label11.TabIndex = 73;
            this.label11.Text = "Mã Phiếu nhập:";
            // 
            // txt_mapn
            // 
            this.txt_mapn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_mapn.Location = new System.Drawing.Point(220, 96);
            this.txt_mapn.Name = "txt_mapn";
            this.txt_mapn.Size = new System.Drawing.Size(324, 30);
            this.txt_mapn.TabIndex = 72;
            // 
            // FrmPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 705);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_mapn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDonGia);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMaThuoc);
            this.Controls.Add(this.display_ctpn);
            this.Controls.Add(this.xoact);
            this.Controls.Add(this.suact);
            this.Controls.Add(this.btn_reset2);
            this.Controls.Add(this.themct);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMactpn);
            this.Controls.Add(this.txt_idpn);
            this.Controls.Add(this.display_pn);
            this.Controls.Add(this.btn_xoact);
            this.Controls.Add(this.btn_suact);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_tt);
            this.Controls.Add(this.txt_mancc);
            this.Name = "FrmPhieuNhap";
            this.Text = "FrmPhieuNhap";
            this.Load += new System.EventHandler(this.FrmPhieuNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.display_pn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.display_ctpn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView display_pn;
        private System.Windows.Forms.Button btn_xoact;
        private System.Windows.Forms.Button btn_suact;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_tt;
        private System.Windows.Forms.TextBox txt_mancc;
        private System.Windows.Forms.DataGridView display_ctpn;
        private System.Windows.Forms.Button xoact;
        private System.Windows.Forms.Button suact;
        private System.Windows.Forms.Button btn_reset2;
        private System.Windows.Forms.Button themct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMactpn;
        private System.Windows.Forms.TextBox txt_idpn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaThuoc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_mapn;
    }
}