namespace DVLD
{
    partial class fmWrittenTest
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdD = new System.Windows.Forms.RadioButton();
            this.rdC = new System.Windows.Forms.RadioButton();
            this.rdB = new System.Windows.Forms.RadioButton();
            this.rdA = new System.Windows.Forms.RadioButton();
            this.lbQuestionDescription = new System.Windows.Forms.Label();
            this.btnNext_Submit = new System.Windows.Forms.Button();
            this.lbCurrntQustion = new System.Windows.Forms.Label();
            this.lbTotalNumberOfQuestion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(356, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Written Test";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdD);
            this.groupBox1.Controls.Add(this.rdC);
            this.groupBox1.Controls.Add(this.rdB);
            this.groupBox1.Controls.Add(this.rdA);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(24, 168);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1247, 330);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choices";
            // 
            // rdD
            // 
            this.rdD.AutoSize = true;
            this.rdD.Location = new System.Drawing.Point(7, 267);
            this.rdD.Name = "rdD";
            this.rdD.Size = new System.Drawing.Size(55, 36);
            this.rdD.TabIndex = 3;
            this.rdD.TabStop = true;
            this.rdD.Tag = "4";
            this.rdD.Text = "D";
            this.rdD.UseVisualStyleBackColor = true;
            // 
            // rdC
            // 
            this.rdC.AutoSize = true;
            this.rdC.Location = new System.Drawing.Point(7, 200);
            this.rdC.Name = "rdC";
            this.rdC.Size = new System.Drawing.Size(55, 36);
            this.rdC.TabIndex = 2;
            this.rdC.TabStop = true;
            this.rdC.Tag = "3";
            this.rdC.Text = "C";
            this.rdC.UseVisualStyleBackColor = true;
            // 
            // rdB
            // 
            this.rdB.AutoSize = true;
            this.rdB.Location = new System.Drawing.Point(7, 133);
            this.rdB.Name = "rdB";
            this.rdB.Size = new System.Drawing.Size(54, 36);
            this.rdB.TabIndex = 1;
            this.rdB.TabStop = true;
            this.rdB.Tag = "2";
            this.rdB.Text = "B";
            this.rdB.UseVisualStyleBackColor = true;
            // 
            // rdA
            // 
            this.rdA.AutoSize = true;
            this.rdA.Location = new System.Drawing.Point(7, 66);
            this.rdA.Name = "rdA";
            this.rdA.Size = new System.Drawing.Size(54, 36);
            this.rdA.TabIndex = 0;
            this.rdA.TabStop = true;
            this.rdA.Tag = "1";
            this.rdA.Text = "A";
            this.rdA.UseVisualStyleBackColor = true;
            // 
            // lbQuestionDescription
            // 
            this.lbQuestionDescription.AutoSize = true;
            this.lbQuestionDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuestionDescription.Location = new System.Drawing.Point(18, 85);
            this.lbQuestionDescription.Name = "lbQuestionDescription";
            this.lbQuestionDescription.Size = new System.Drawing.Size(89, 32);
            this.lbQuestionDescription.TabIndex = 2;
            this.lbQuestionDescription.Text = "_____";
            // 
            // btnNext_Submit
            // 
            this.btnNext_Submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext_Submit.Location = new System.Drawing.Point(647, 504);
            this.btnNext_Submit.Name = "btnNext_Submit";
            this.btnNext_Submit.Size = new System.Drawing.Size(132, 57);
            this.btnNext_Submit.TabIndex = 3;
            this.btnNext_Submit.Text = "Next";
            this.btnNext_Submit.UseVisualStyleBackColor = true;
            this.btnNext_Submit.Click += new System.EventHandler(this.btnNext_Submit_Click);
            // 
            // lbCurrntQustion
            // 
            this.lbCurrntQustion.AutoSize = true;
            this.lbCurrntQustion.Location = new System.Drawing.Point(664, 44);
            this.lbCurrntQustion.Name = "lbCurrntQustion";
            this.lbCurrntQustion.Size = new System.Drawing.Size(44, 16);
            this.lbCurrntQustion.TabIndex = 4;
            this.lbCurrntQustion.Text = "label2";
            // 
            // lbTotalNumberOfQuestion
            // 
            this.lbTotalNumberOfQuestion.AutoSize = true;
            this.lbTotalNumberOfQuestion.Location = new System.Drawing.Point(775, 44);
            this.lbTotalNumberOfQuestion.Name = "lbTotalNumberOfQuestion";
            this.lbTotalNumberOfQuestion.Size = new System.Drawing.Size(44, 16);
            this.lbTotalNumberOfQuestion.TabIndex = 5;
            this.lbTotalNumberOfQuestion.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(733, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "/";
            // 
            // fmWrittenTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 575);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbTotalNumberOfQuestion);
            this.Controls.Add(this.lbCurrntQustion);
            this.Controls.Add(this.btnNext_Submit);
            this.Controls.Add(this.lbQuestionDescription);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "fmTest";
            this.Text = "Written Test";
            this.Load += new System.EventHandler(this.fmTest_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbQuestionDescription;
        private System.Windows.Forms.Button btnNext_Submit;
        private System.Windows.Forms.RadioButton rdD;
        private System.Windows.Forms.RadioButton rdC;
        private System.Windows.Forms.RadioButton rdB;
        private System.Windows.Forms.RadioButton rdA;
        private System.Windows.Forms.Label lbCurrntQustion;
        private System.Windows.Forms.Label lbTotalNumberOfQuestion;
        private System.Windows.Forms.Label label4;
    }
}