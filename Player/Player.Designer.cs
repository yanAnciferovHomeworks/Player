namespace Player
{
    partial class Player
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
            this._prev = new System.Windows.Forms.Button();
            this._play = new System.Windows.Forms.Button();
            this._pause = new System.Windows.Forms.Button();
            this._stop = new System.Windows.Forms.Button();
            this._next = new System.Windows.Forms.Button();
            this.SoundBar = new System.Windows.Forms.TrackBar();
            this.TimeBar = new System.Windows.Forms.TrackBar();
            this.Name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SoundBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Prev
            // 
            this._prev.Location = new System.Drawing.Point(31, 81);
            this._prev.Name = "Prev";
            this._prev.Size = new System.Drawing.Size(31, 23);
            this._prev.TabIndex = 0;
            this._prev.Text = "<<";
            this._prev.UseVisualStyleBackColor = true;
            // 
            // Play
            // 
            this._play.Location = new System.Drawing.Point(79, 81);
            this._play.Name = "Play";
            this._play.Size = new System.Drawing.Size(31, 23);
            this._play.TabIndex = 1;
            this._play.Text = "Pl";
            this._play.UseVisualStyleBackColor = true;
            // 
            // Pause
            // 
            this._pause.Location = new System.Drawing.Point(135, 81);
            this._pause.Name = "Pause";
            this._pause.Size = new System.Drawing.Size(31, 23);
            this._pause.TabIndex = 2;
            this._pause.Text = "P";
            this._pause.UseVisualStyleBackColor = true;
            // 
            // Stop
            // 
            this._stop.Location = new System.Drawing.Point(191, 81);
            this._stop.Name = "Stop";
            this._stop.Size = new System.Drawing.Size(31, 23);
            this._stop.TabIndex = 3;
            this._stop.Text = "S";
            this._stop.UseVisualStyleBackColor = true;
            // 
            // Next
            // 
            this._next.Location = new System.Drawing.Point(251, 81);
            this._next.Name = "Next";
            this._next.Size = new System.Drawing.Size(31, 23);
            this._next.TabIndex = 4;
            this._next.Text = ">>";
            this._next.UseVisualStyleBackColor = true;
            // 
            // SoundBar
            // 
            this.SoundBar.Location = new System.Drawing.Point(305, 81);
            this.SoundBar.Name = "SoundBar";
            this.SoundBar.Size = new System.Drawing.Size(115, 45);
            this.SoundBar.TabIndex = 5;
            this.SoundBar.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // TimeBar
            // 
            this.TimeBar.Location = new System.Drawing.Point(12, 30);
            this.TimeBar.Maximum = 100;
            this.TimeBar.Name = "TimeBar";
            this.TimeBar.Size = new System.Drawing.Size(393, 45);
            this.TimeBar.TabIndex = 6;
            this.TimeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // Name
            // 
            this.Name.AutoSize = true;
            this.Name.Location = new System.Drawing.Point(58, 11);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(0, 13);
            this.Name.TabIndex = 7;
            // 
            // Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 116);
            this.Controls.Add(this.Name);
            this.Controls.Add(this.TimeBar);
            this.Controls.Add(this.SoundBar);
            this.Controls.Add(this._next);
            this.Controls.Add(this._stop);
            this.Controls.Add(this._pause);
            this.Controls.Add(this._play);
            this.Controls.Add(this._prev);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.SoundBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _prev;
        private System.Windows.Forms.Button _play;
        private System.Windows.Forms.Button _pause;
        private System.Windows.Forms.Button _stop;
        private System.Windows.Forms.Button _next;
        private System.Windows.Forms.TrackBar SoundBar;
        private System.Windows.Forms.TrackBar TimeBar;
        private System.Windows.Forms.Label Name;
    }
}

