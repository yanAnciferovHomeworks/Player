namespace Player
{
    partial class Pl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pl));
            this._prev = new System.Windows.Forms.Button();
            this._play = new System.Windows.Forms.Button();
            this._pause = new System.Windows.Forms.Button();
            this._stop = new System.Windows.Forms.Button();
            this._next = new System.Windows.Forms.Button();
            this.SoundBar = new System.Windows.Forms.TrackBar();
            this.TimeBar = new System.Windows.Forms.TrackBar();
            this.Name = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.SoundBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // _prev
            // 
            this._prev.Image = ((System.Drawing.Image)(resources.GetObject("_prev.Image")));
            this._prev.Location = new System.Drawing.Point(102, 75);
            this._prev.Name = "_prev";
            this._prev.Size = new System.Drawing.Size(42, 35);
            this._prev.TabIndex = 0;
            this._prev.UseVisualStyleBackColor = true;
            this._prev.Click += new System.EventHandler(this._prev_Click);
            // 
            // _play
            // 
            this._play.Image = ((System.Drawing.Image)(resources.GetObject("_play.Image")));
            this._play.Location = new System.Drawing.Point(152, 75);
            this._play.Name = "_play";
            this._play.Size = new System.Drawing.Size(41, 35);
            this._play.TabIndex = 1;
            this._play.UseVisualStyleBackColor = true;
            this._play.Click += new System.EventHandler(this._play_Click);
            // 
            // _pause
            // 
            this._pause.Image = ((System.Drawing.Image)(resources.GetObject("_pause.Image")));
            this._pause.Location = new System.Drawing.Point(201, 75);
            this._pause.Name = "_pause";
            this._pause.Size = new System.Drawing.Size(40, 35);
            this._pause.TabIndex = 2;
            this._pause.UseVisualStyleBackColor = true;
            this._pause.Click += new System.EventHandler(this._pause_Click);
            // 
            // _stop
            // 
            this._stop.Image = ((System.Drawing.Image)(resources.GetObject("_stop.Image")));
            this._stop.Location = new System.Drawing.Point(249, 75);
            this._stop.Name = "_stop";
            this._stop.Size = new System.Drawing.Size(40, 35);
            this._stop.TabIndex = 3;
            this._stop.UseVisualStyleBackColor = true;
            this._stop.Click += new System.EventHandler(this._stop_Click);
            // 
            // _next
            // 
            this._next.Image = ((System.Drawing.Image)(resources.GetObject("_next.Image")));
            this._next.Location = new System.Drawing.Point(297, 75);
            this._next.Name = "_next";
            this._next.Size = new System.Drawing.Size(39, 35);
            this._next.TabIndex = 4;
            this._next.UseVisualStyleBackColor = true;
            this._next.Click += new System.EventHandler(this._next_Click);
            // 
            // SoundBar
            // 
            this.SoundBar.Location = new System.Drawing.Point(451, 30);
            this.SoundBar.Maximum = 100;
            this.SoundBar.Name = "SoundBar";
            this.SoundBar.Size = new System.Drawing.Size(115, 45);
            this.SoundBar.TabIndex = 5;
            this.SoundBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.SoundBar.Value = 50;
            this.SoundBar.Scroll += new System.EventHandler(this.SoundBar_Scroll);
            // 
            // TimeBar
            // 
            this.TimeBar.LargeChange = 10;
            this.TimeBar.Location = new System.Drawing.Point(12, 30);
            this.TimeBar.Maximum = 100;
            this.TimeBar.Name = "TimeBar";
            this.TimeBar.Size = new System.Drawing.Size(381, 45);
            this.TimeBar.SmallChange = 5;
            this.TimeBar.TabIndex = 6;
            this.TimeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TimeBar.Scroll += new System.EventHandler(this.TimeBar_Scroll);
            this.TimeBar.ValueChanged += new System.EventHandler(this.TimeBar_ValueChanged);
            // 
            // Name
            // 
            this.Name.AutoSize = true;
            this.Name.Location = new System.Drawing.Point(58, 11);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(0, 13);
            this.Name.TabIndex = 7;
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Location = new System.Drawing.Point(393, 35);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(0, 13);
            this.Time.TabIndex = 8;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(451, 85);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Плейлист";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Pl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 120);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Time);
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
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

