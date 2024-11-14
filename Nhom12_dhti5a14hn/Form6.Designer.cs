namespace Nhom12_dhti5a14hn
{
    partial class Form6
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
            this.xuatthuoc = new System.Windows.Forms.Button();
            this.display_baocao = new System.Windows.Forms.DataGridView();
            this.thongke = new System.Windows.Forms.Button();
            this.btn_tkall = new System.Windows.Forms.Button();
            this.display = new System.Windows.Forms.DataGridView();
            this.thuocall = new System.Windows.Forms.Button();
            this.tuoctn = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.xuathoadon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.display_baocao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.display)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.label1.Location = new System.Drawing.Point(393, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 42);
            this.label1.TabIndex = 10;
            this.label1.Text = "Báo cáo thống kê ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // xuatthuoc
            // 
            this.xuatthuoc.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.xuatthuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xuatthuoc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.xuatthuoc.Location = new System.Drawing.Point(767, 70);
            this.xuatthuoc.Name = "xuatthuoc";
            this.xuatthuoc.Size = new System.Drawing.Size(340, 49);
            this.xuatthuoc.TabIndex = 12;
            this.xuatthuoc.Text = "Xuất ra báo cáo trong ngày";
            this.xuatthuoc.UseVisualStyleBackColor = false;
            this.xuatthuoc.Click += new System.EventHandler(this.xuatthuoc_Click);
            // 
            // display_baocao
            // 
            this.display_baocao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.display_baocao.Location = new System.Drawing.Point(42, 125);
            this.display_baocao.Name = "display_baocao";
            this.display_baocao.RowHeadersWidth = 51;
            this.display_baocao.RowTemplate.Height = 24;
            this.display_baocao.Size = new System.Drawing.Size(537, 361);
            this.display_baocao.TabIndex = 13;
            this.display_baocao.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.display_baocao_CellContentClick);
            // 
            // thongke
            // 
            this.thongke.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.thongke.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thongke.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.thongke.Location = new System.Drawing.Point(42, 511);
            this.thongke.Name = "thongke";
            this.thongke.Size = new System.Drawing.Size(357, 49);
            this.thongke.TabIndex = 14;
            this.thongke.Text = "Thống kê hoá đơn ttrong ngày";
            this.thongke.UseVisualStyleBackColor = false;
            this.thongke.Click += new System.EventHandler(this.thongke_Click);
            // 
            // btn_tkall
            // 
            this.btn_tkall.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_tkall.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tkall.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_tkall.Location = new System.Drawing.Point(42, 579);
            this.btn_tkall.Name = "btn_tkall";
            this.btn_tkall.Size = new System.Drawing.Size(357, 49);
            this.btn_tkall.TabIndex = 15;
            this.btn_tkall.Text = "Thống kê tất cả hoá đơn";
            this.btn_tkall.UseVisualStyleBackColor = false;
            this.btn_tkall.Click += new System.EventHandler(this.btn_tkall_Click);
            // 
            // display
            // 
            this.display.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.display.Location = new System.Drawing.Point(599, 125);
            this.display.Name = "display";
            this.display.RowHeadersWidth = 51;
            this.display.RowTemplate.Height = 24;
            this.display.Size = new System.Drawing.Size(508, 361);
            this.display.TabIndex = 16;
            // 
            // thuocall
            // 
            this.thuocall.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.thuocall.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thuocall.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.thuocall.Location = new System.Drawing.Point(599, 579);
            this.thuocall.Name = "thuocall";
            this.thuocall.Size = new System.Drawing.Size(455, 49);
            this.thuocall.TabIndex = 18;
            this.thuocall.Text = "Thống kê tất cả thuốc bán ra ";
            this.thuocall.UseVisualStyleBackColor = false;
            this.thuocall.Click += new System.EventHandler(this.thuocall_Click);
            // 
            // tuoctn
            // 
            this.tuoctn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tuoctn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoctn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tuoctn.Location = new System.Drawing.Point(599, 511);
            this.tuoctn.Name = "tuoctn";
            this.tuoctn.Size = new System.Drawing.Size(455, 49);
            this.tuoctn.TabIndex = 17;
            this.tuoctn.Text = "Thống kê số lượng thuốc bán ra trong ngày";
            this.tuoctn.UseVisualStyleBackColor = false;
            this.tuoctn.Click += new System.EventHandler(this.tuoctn_Click);
            // 
            // btn_back
            // 
            this.btn_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.Location = new System.Drawing.Point(12, 12);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(74, 30);
            this.btn_back.TabIndex = 44;
            this.btn_back.Text = "<";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // xuathoadon
            // 
            this.xuathoadon.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.xuathoadon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xuathoadon.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.xuathoadon.Location = new System.Drawing.Point(42, 70);
            this.xuathoadon.Name = "xuathoadon";
            this.xuathoadon.Size = new System.Drawing.Size(326, 49);
            this.xuathoadon.TabIndex = 45;
            this.xuathoadon.Text = "Xuất ra thống kê bán hàng";
            this.xuathoadon.UseVisualStyleBackColor = false;
            this.xuathoadon.Click += new System.EventHandler(this.xuathoadon_Click);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 707);
            this.Controls.Add(this.xuathoadon);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.thuocall);
            this.Controls.Add(this.tuoctn);
            this.Controls.Add(this.display);
            this.Controls.Add(this.btn_tkall);
            this.Controls.Add(this.thongke);
            this.Controls.Add(this.display_baocao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.xuatthuoc);
            this.Name = "Form6";
            this.Text = "Form6";
            this.Load += new System.EventHandler(this.Form6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.display_baocao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.display)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button xuatthuoc;
        private System.Windows.Forms.DataGridView display_baocao;
        private System.Windows.Forms.Button thongke;
        private System.Windows.Forms.Button btn_tkall;
        private System.Windows.Forms.DataGridView display;
        private System.Windows.Forms.Button thuocall;
        private System.Windows.Forms.Button tuoctn;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button xuathoadon;
    }
}