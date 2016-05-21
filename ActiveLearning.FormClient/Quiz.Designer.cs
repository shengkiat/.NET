namespace ActiveLearning.FormClient
{
    partial class Quiz
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
            this.LblQuestion = new System.Windows.Forms.Label();
            this.BtnSubmit = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.ListBoxOptions = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // LblQuestion
            // 
            this.LblQuestion.AutoSize = true;
            this.LblQuestion.Location = new System.Drawing.Point(78, 33);
            this.LblQuestion.Name = "LblQuestion";
            this.LblQuestion.Size = new System.Drawing.Size(0, 13);
            this.LblQuestion.TabIndex = 0;
            // 
            // BtnSubmit
            // 
            this.BtnSubmit.Location = new System.Drawing.Point(130, 430);
            this.BtnSubmit.Name = "BtnSubmit";
            this.BtnSubmit.Size = new System.Drawing.Size(165, 64);
            this.BtnSubmit.TabIndex = 2;
            this.BtnSubmit.Text = "Submit";
            this.BtnSubmit.UseVisualStyleBackColor = true;
            this.BtnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(367, 430);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(165, 64);
            this.BtnClose.TabIndex = 3;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // ListBoxOptions
            // 
            this.ListBoxOptions.FormattingEnabled = true;
            this.ListBoxOptions.Location = new System.Drawing.Point(81, 105);
            this.ListBoxOptions.Name = "ListBoxOptions";
            this.ListBoxOptions.Size = new System.Drawing.Size(482, 225);
            this.ListBoxOptions.TabIndex = 6;
            // 
            // Quiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 552);
            this.Controls.Add(this.ListBoxOptions);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnSubmit);
            this.Controls.Add(this.LblQuestion);
            this.Name = "Quiz";
            this.Text = "Quiz";
            this.Load += new System.EventHandler(this.Quiz_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblQuestion;
        private System.Windows.Forms.Button BtnSubmit;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.ListBox ListBoxOptions;
    }
}