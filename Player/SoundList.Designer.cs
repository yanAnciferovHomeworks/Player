namespace Player
{
    partial class SoundList
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Add = new System.Windows.Forms.Button();
            this.Remove = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Load = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(260, 186);
            this.listBox1.TabIndex = 0;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(25, 214);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(34, 23);
            this.Add.TabIndex = 1;
            this.Add.Text = "+";
            this.Add.UseVisualStyleBackColor = true;
            // 
            // Remove
            // 
            this.Remove.Location = new System.Drawing.Point(74, 214);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(34, 23);
            this.Remove.TabIndex = 2;
            this.Remove.Text = "-";
            this.Remove.UseVisualStyleBackColor = true;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(130, 214);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(43, 23);
            this.Save.TabIndex = 3;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            // 
            // Load
            // 
            this.Load.Location = new System.Drawing.Point(194, 214);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(43, 23);
            this.Load.TabIndex = 4;
            this.Load.Text = "Load";
            this.Load.UseVisualStyleBackColor = true;
            // 
            // SoundList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Load);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.listBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SoundList";
            this.ShowIcon = false;
            this.Text = "Список";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Load;
    }
}