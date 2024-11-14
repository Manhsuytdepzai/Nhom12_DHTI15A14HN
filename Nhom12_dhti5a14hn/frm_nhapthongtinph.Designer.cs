namespace Nhom12_dhti5a14hn
{
    partial class frm_nhapthongtinph
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.a = new System.Windows.Forms.Label();
            this.txt_iddh = new System.Windows.Forms.TextBox();
            this.txt_nd = new System.Windows.Forms.RichTextBox();
            this.ngaygui = new System.Windows.Forms.DateTimePicker();
            this.gui = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.a);
            this.groupBox1.Controls.Add(this.txt_iddh);
            this.groupBox1.Controls.Add(this.txt_nd);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(88, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(911, 434);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phản hồi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(63, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 29);
            this.label5.TabIndex = 25;
            this.label5.Text = "Nội dung:";
            // 
            // a
            // 
            this.a.AutoSize = true;
            this.a.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.a.Location = new System.Drawing.Point(32, 68);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(170, 29);
            this.a.TabIndex = 24;
            this.a.Text = "Mã đơn hàng:";
            // 
            // txt_iddh
            // 
            this.txt_iddh.Location = new System.Drawing.Point(232, 63);
            this.txt_iddh.Multiline = true;
            this.txt_iddh.Name = "txt_iddh";
            this.txt_iddh.Size = new System.Drawing.Size(626, 34);
            this.txt_iddh.TabIndex = 20;
            // 
            // txt_nd
            // 
            this.txt_nd.Location = new System.Drawing.Point(232, 187);
            this.txt_nd.Name = "txt_nd";
            this.txt_nd.Size = new System.Drawing.Size(626, 224);
            this.txt_nd.TabIndex = 16;
            this.txt_nd.Text = "";
            // 
            // ngaygui
            // 
            this.ngaygui.Location = new System.Drawing.Point(799, 81);
            this.ngaygui.Name = "ngaygui";
            this.ngaygui.Size = new System.Drawing.Size(200, 22);
            this.ngaygui.TabIndex = 8;
            this.ngaygui.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // gui
            // 
            this.gui.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gui.Location = new System.Drawing.Point(480, 582);
            this.gui.Name = "gui";
            this.gui.Size = new System.Drawing.Size(137, 45);
            this.gui.TabIndex = 9;
            this.gui.Text = "Gửi";
            this.gui.UseVisualStyleBackColor = true;
            this.gui.Click += new System.EventHandler(this.gui_Click);
            // 
            // frm_nhapthongtinph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 685);
            this.Controls.Add(this.gui);
            this.Controls.Add(this.ngaygui);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_nhapthongtinph";
            this.Text = "frm_nhapthongtinph";
            this.Load += new System.EventHandler(this.frm_nhapthongtinph_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label a;
        private System.Windows.Forms.TextBox txt_iddh;
        private System.Windows.Forms.RichTextBox txt_nd;
        private System.Windows.Forms.DateTimePicker ngaygui;
        private System.Windows.Forms.Button gui;
    }
}