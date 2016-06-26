namespace FlyingCursors
{
    partial class FlyingCursors
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
            this.components = new System.ComponentModel.Container();
            this.timerTick = new System.Windows.Forms.Timer(this.components);
            this.timerSpawn = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.timerDraw = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerTick
            // 
            this.timerTick.Enabled = true;
            this.timerTick.Interval = 10;
            this.timerTick.Tick += new System.EventHandler(this.timerTick_Tick);
            // 
            // timerSpawn
            // 
            this.timerSpawn.Enabled = true;
            this.timerSpawn.Interval = 50;
            this.timerSpawn.Tick += new System.EventHandler(this.timerSpawn_Tick);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(81, 33);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // timerDraw
            // 
            this.timerDraw.Enabled = true;
            this.timerDraw.Interval = 15;
            this.timerDraw.Tick += new System.EventHandler(this.timerDraw_Tick);
            // 
            // FlyingCursors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(375, 369);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FlyingCursors";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "MOTHERFUCKING FLYING CURSORS";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.FlyingCursors_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FlyingCursors_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerTick;
        private System.Windows.Forms.Timer timerSpawn;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Timer timerDraw;
    }
}

