namespace AnalogClock
{
    partial class Form1
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
            this.stylishAnalogClock1 = new AnalogClock.StylishAnalogClock();
            this.SuspendLayout();
            // 
            // stylishAnalogClock1
            // 
            this.stylishAnalogClock1.ClockFrameInnerColor1 = System.Drawing.Color.WhiteSmoke;
            this.stylishAnalogClock1.ClockFrameInnerColor2 = System.Drawing.Color.Black;
            this.stylishAnalogClock1.ClockFrameOuterColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.stylishAnalogClock1.ClockFrameOuterColor2 = System.Drawing.Color.Silver;
            this.stylishAnalogClock1.ClockFrameStyle = AnalogClock.StylishAnalogClock.ClockFrame.Normal;
            this.stylishAnalogClock1.ClockGlassColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.stylishAnalogClock1.ClockHourHandColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stylishAnalogClock1.ClockHourHandStyle = AnalogClock.StylishAnalogClock.ClockHand.Retro;
            this.stylishAnalogClock1.ClockHoursLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stylishAnalogClock1.ClockHoursLineStyle = AnalogClock.StylishAnalogClock.ClockLines.Line;
            this.stylishAnalogClock1.ClockMinuteHandColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stylishAnalogClock1.ClockMinuteHandStyle = AnalogClock.StylishAnalogClock.ClockHand.Retro;
            this.stylishAnalogClock1.ClockMinutesLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stylishAnalogClock1.ClockMinutesLineStyle = AnalogClock.StylishAnalogClock.ClockLines.Diamond;
            this.stylishAnalogClock1.ClockNumbersColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stylishAnalogClock1.ClockNumbersStyle = AnalogClock.StylishAnalogClock.ClockNumbers.Normal_90;
            this.stylishAnalogClock1.ClockSecondHandColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stylishAnalogClock1.ClockTime = new System.DateTime(2007, 4, 16, 18, 25, 47, 187);
            this.stylishAnalogClock1.ClockUseSmoothSecondHand = false;
            this.stylishAnalogClock1.Location = new System.Drawing.Point(12, 12);
            this.stylishAnalogClock1.Name = "stylishAnalogClock1";
            this.stylishAnalogClock1.Size = new System.Drawing.Size(150, 150);
            this.stylishAnalogClock1.TabIndex = 0;
            this.stylishAnalogClock1.Text = "stylishAnalogClock1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(522, 483);
            this.Controls.Add(this.stylishAnalogClock1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private StylishAnalogClock stylishAnalogClock1;

    }
}