
namespace Muhasabe
{
    partial class frmReceiptLoginDetail
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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txttutar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboreceiptip = new System.Windows.Forms.ComboBox();
            this.combokdv = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(25, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 91;
            this.label2.Text = "KdvOranı";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(24, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 90;
            this.label4.Text = "Fiş Tipi:";
            // 
            // txttutar
            // 
            this.txttutar.Location = new System.Drawing.Point(185, 94);
            this.txttutar.Margin = new System.Windows.Forms.Padding(4);
            this.txttutar.Name = "txttutar";
            this.txttutar.Size = new System.Drawing.Size(132, 22);
            this.txttutar.TabIndex = 89;
            this.txttutar.Tag = "@pReceiptTotal";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(25, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 88;
            this.label1.Text = "Tutar:";
            // 
            // comboreceiptip
            // 
            this.comboreceiptip.FormattingEnabled = true;
            this.comboreceiptip.Location = new System.Drawing.Point(185, 51);
            this.comboreceiptip.Name = "comboreceiptip";
            this.comboreceiptip.Size = new System.Drawing.Size(121, 24);
            this.comboreceiptip.TabIndex = 93;
            this.comboreceiptip.Tag = "@pReceiptType";
            // 
            // combokdv
            // 
            this.combokdv.FormattingEnabled = true;
            this.combokdv.Location = new System.Drawing.Point(185, 128);
            this.combokdv.Name = "combokdv";
            this.combokdv.Size = new System.Drawing.Size(121, 24);
            this.combokdv.TabIndex = 94;
            this.combokdv.Tag = "@pKDVTipID";
            // 
            // frmReceiptLoginDetail
            // 
            this.AssemblyName = "BusinessLayer";
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClassName = "BusinessLayer.clsReceiptDetails";
            this.ClientSize = new System.Drawing.Size(363, 220);
            this.Controls.Add(this.combokdv);
            this.Controls.Add(this.comboreceiptip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txttutar);
            this.Controls.Add(this.label1);
            this.Name = "frmReceiptLoginDetail";
            this.Text = "frmReceiptLoginDetail";
            this.Load += new System.EventHandler(this.frmReceiptLoginDetail_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txttutar, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.comboreceiptip, 0);
            this.Controls.SetChildIndex(this.combokdv, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txttutar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboreceiptip;
        private System.Windows.Forms.ComboBox combokdv;
    }
}