using System;
using System.Collections.Generic;
/****************************************************************************
** SAKARYA ÜNİVERSİTESİ
** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
** BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
** NESNEYE DAYALI PROGRAMLAMA DERSİ
** 2021-2022 BAHAR DÖNEMİ
**
** ÖDEV NUMARASI..........: 2
** ÖĞRENCİ ADI............: HAKKI CEYLAN
** ÖĞRENCİ NUMARASI.......: G211210350
** DERSİN ALINDIĞI GRUP...: 2-A
****************************************************************************/
namespace ndp_task_two
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtBoxInput = new System.Windows.Forms.TextBox();
            this.lblGirdi = new System.Windows.Forms.Label();
            this.lblYazi = new System.Windows.Forms.Label();
            this.txtBoxOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // calculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(339, 310);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(94, 29);
            this.btnCalculate.TabIndex = 0;
            this.btnCalculate.Text = "HESAPLA";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.calculate_Click);
            // 
            // textBox1
            // 
            this.txtBoxInput.Location = new System.Drawing.Point(265, 138);
            this.txtBoxInput.Name = "txtBoxInput";
            this.txtBoxInput.Size = new System.Drawing.Size(250, 27);
            this.txtBoxInput.TabIndex = 2;
            // 
            // lblGirdi
            // 
            this.lblGirdi.AutoSize = true;
            this.lblGirdi.Location = new System.Drawing.Point(241, 145);
            this.lblGirdi.Name = "lblGirdi";
            this.lblGirdi.Size = new System.Drawing.Size(21, 20);
            this.lblGirdi.TabIndex = 3;
            this.lblGirdi.Text = "X:";
            // 
            // lblYazi
            // 
            this.lblYazi.AutoSize = true;
            this.lblYazi.Location = new System.Drawing.Point(242, 177);
            this.lblYazi.Name = "lblYazi";
            this.lblYazi.Size = new System.Drawing.Size(20, 20);
            this.lblYazi.TabIndex = 4;
            this.lblYazi.Text = "Y:";
            // 
            // textBox2
            // 
            this.txtBoxOutput.Location = new System.Drawing.Point(265, 177);
            this.txtBoxOutput.Name = "txtBoxOutput";
            this.txtBoxOutput.ReadOnly = true;
            this.txtBoxOutput.Size = new System.Drawing.Size(250, 27);
            this.txtBoxOutput.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtBoxOutput);
            this.Controls.Add(this.lblYazi);
            this.Controls.Add(this.lblGirdi);
            this.Controls.Add(this.txtBoxInput);
            this.Controls.Add(this.btnCalculate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox txtBoxInput;
        private System.Windows.Forms.Label lblGirdi;
        private System.Windows.Forms.Label lblYazi;
        private System.Windows.Forms.TextBox txtBoxOutput;
    }
   
}


