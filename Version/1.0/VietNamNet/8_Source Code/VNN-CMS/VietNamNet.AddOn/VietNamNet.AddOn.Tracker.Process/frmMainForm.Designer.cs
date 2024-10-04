namespace VietNamNet.AddOn.Tracker.Process
{
    partial class frmMainForm
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
            this.cmdSurvey = new System.Windows.Forms.Button();
            this.cmdComment = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdSurvey
            // 
            this.cmdSurvey.Location = new System.Drawing.Point(56, 110);
            this.cmdSurvey.Name = "cmdSurvey";
            this.cmdSurvey.Size = new System.Drawing.Size(156, 23);
            this.cmdSurvey.TabIndex = 0;
            this.cmdSurvey.Text = "Survey Process";
            this.cmdSurvey.UseVisualStyleBackColor = true;
            this.cmdSurvey.Click += new System.EventHandler(this.cmdSurvey_Click);
            // 
            // cmdComment
            // 
            this.cmdComment.Location = new System.Drawing.Point(56, 149);
            this.cmdComment.Name = "cmdComment";
            this.cmdComment.Size = new System.Drawing.Size(156, 23);
            this.cmdComment.TabIndex = 1;
            this.cmdComment.Text = "Comment Process";
            this.cmdComment.UseVisualStyleBackColor = true;
            this.cmdComment.Click += new System.EventHandler(this.cmdComment_Click);
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 304);
            this.Controls.Add(this.cmdComment);
            this.Controls.Add(this.cmdSurvey);
            this.Name = "frmMainForm";
            this.Text = "Process - Main form";
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdSurvey;
        private System.Windows.Forms.Button cmdComment;


    }
}