using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AnalogClock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Timer timer1 = new Timer();
            timer1.Interval = 1000;
            timer1.Tick +=new EventHandler(timer1_Tick);
            timer1.Start();

            System.Windows.Forms.PropertyGrid propertyGrid1 = new PropertyGrid();
            propertyGrid1.CommandsVisibleIfAvailable = true;
			propertyGrid1.LargeButtons = false;
			propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar;
			propertyGrid1.Location = new System.Drawing.Point(200, 8);
			propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.SelectedObject = this.stylishAnalogClock1;
			propertyGrid1.Size = new System.Drawing.Size(280, 464);
			propertyGrid1.TabIndex = 1;
			propertyGrid1.Text = "propertyGrid1";
			propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window;
			propertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText;

            Controls.Add(propertyGrid1);



        }

        public void timer1_Tick(Object o, EventArgs e)
        {
            stylishAnalogClock1.ClockTime = DateTime.Now;
            //stylishAnalogClock1.Invalidate();
        }
    
    }
}