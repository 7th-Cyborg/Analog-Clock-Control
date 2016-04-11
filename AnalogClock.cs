using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace AnalogClock
{
    public partial class StylishAnalogClock : Control
    {
        public StylishAnalogClock()
        {
            InitializeComponent();
            //Sprijecavamo treptanje grafike
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            DefaultStyle();
        }

        #region Enumeracije
        /// <summary>
        /// Enumeracija za oblik okvira sata
        /// </summary>
        public enum ClockFrame
        {
            Normal,
            Thin
        }
        /// <summary>
        /// Crte gdje se nalaze brojevi
        /// </summary>
        public enum ClockLines
        {
            None,
            Diamond,
            Circle,
            Line,
            LinewithCircles
        }
        /// <summary>
        ///Enumeracija za tip Brojeva
        /// <summary>
        public enum ClockNumbers
        {
            None,
            Normal,
            Roman,
            Normal_90,
            Roman_90
        }
        /// <summary>
        ///Enumeracija za izgled kazaljki
        /// <summary>
        public enum ClockHand
        {
            Line,
            Diamond,
            RoundLine,
            Retro
        }
        /// <summary>
        ///Enumeracija za izgled Sekundne Kazaljke
        /// <summary>
        public enum ClockHandSecond
        {
            Line
        }
        #endregion

        #region Deklaracije varijabli
        //Konstante
        //Radius sata
        private const int iRadius = 1850;
        //Sirina za okvir sata
        private const int iSirinaNormal = 250;
        private const int iSirinaThin = 100;

        /// <summary>
        /// Okvir sata
        /// </summary>

        //Boje za gradijent od okvira
        private Color colFrameOutside1;
        private Color colFrameOutside2;
        private Color colFrameInside1;
        private Color colFrameInside2;

        //Okvir stil Normal ili Thin
        private ClockFrame clkFrameStyle;

        /// <summary>
        /// Oznake za brojeve
        /// </summary>
         
        //Stil linija
        private ClockLines clkHoursLineStyle;
        private ClockLines clkMinutesLineStyle;

        //Boja linija
        private Color colHoursLine;
        private Color colMinutesLine;

        ///<summary>
        /// Brojevi
        ///</summary>
        private ClockNumbers clkNumbers;
        private Color colNumbers;

        //Za brojeve
        private String[] strNormal = new string[] { "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "1", "2" };
        private String[] strRoman = new string[] { "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII", "I", "II" };

        ///<summary>
        /// Kazaljke
        ///</summary>
        private ClockHand clkHourHandStyle;
        private ClockHand clkMinuteHandStyle;
        private Color colHourHand;
        private Color colMinuteHand;
        private DateTime dtTime;

        private ClockHandSecond clkSecondHandStyle;
        private Color colSecondHand;
        //ako je true timer interval mora biti 100
        private bool bUseSmoothSecondHand;

        private Color clkGlass;
        #endregion

        # region Postavke
        //Postavke okvira sata

        public Color ClockFrameOuterColor1
        {
            get
            {
                return colFrameOutside1;
            }
            set
            {
                colFrameOutside1 = value;
                this.Invalidate();
            }
        }

        public Color ClockFrameOuterColor2
        {
            get
            {
                return colFrameOutside2;
            }
            set
            {
                colFrameOutside2 = value;
                this.Invalidate();
            }
        }

        public Color ClockFrameInnerColor1
        {
            get
            {
                return colFrameInside1;
            }
            set
            {
                colFrameInside1 = value;
                this.Invalidate();
            }
        }

        public Color ClockFrameInnerColor2
        {
            get
            {
                return colFrameInside2;
            }
            set
            {
                colFrameInside2 = value;
                this.Invalidate();
            }
        }

        public ClockFrame ClockFrameStyle
        {
            get
            {
                return clkFrameStyle;
            }
            set
            {
                clkFrameStyle = value;
                this.Invalidate();
            }
        }

        //postavke za oznake od rojeva

        public ClockLines ClockHoursLineStyle
        {
            get
            {
                return clkHoursLineStyle;
            }
            set
            {
                clkHoursLineStyle = value;
                this.Invalidate();
            }
        }

        public ClockLines ClockMinutesLineStyle
        {
            get
            {
                return clkMinutesLineStyle;
            }
            set
            {
                clkMinutesLineStyle = value;
                this.Invalidate();
            }
        }
        
        public Color ClockHoursLineColor
        {
            get
            {
                return colHoursLine;
            }
            set
            {
                colHoursLine = value;
                this.Invalidate();
            }
        }

        public Color ClockMinutesLineColor
        {
            get
            {
                return colMinutesLine;
            }
            set
            {
                colMinutesLine = value;
                this.Invalidate();
            }
        }

        //Brojevi
        public ClockNumbers ClockNumbersStyle
        {
            get
            {
                return clkNumbers;
            }
            set
            {
                clkNumbers = value;
                this.Invalidate();
            }
        }

        public Color ClockNumbersColor
        {
            get
            {
                return colNumbers;
            }
            set
            {
                colNumbers = value;
                this.Invalidate();
            }
        }

        //Kazaljke
        public ClockHand ClockHourHandStyle
        {
            get
            {
                return clkHourHandStyle;
            }
            set
            {
                clkHourHandStyle = value;
                this.Invalidate();
            }
        }

        public ClockHand ClockMinuteHandStyle
        {
            get
            {
                return clkMinuteHandStyle;
            }
            set
            {
                clkMinuteHandStyle = value;
                this.Invalidate();
            }
        }

        public Color ClockHourHandColor
        {
            get
            {
                return colHourHand;
            }
            set
            {
                colHourHand = value;
                this.Invalidate();
            }
        }

        public Color ClockMinuteHandColor
        {
            get
            {
                return colMinuteHand;
            }
            set
            {
                colMinuteHand = value;
                this.Invalidate();
            }
        }

        public DateTime ClockTime
        {
            get
            {
                return dtTime;
            }
            set
            {
                dtTime = value;
                this.Invalidate();
            }
        }

        //public ClockHandSecond ClockSecondHandStyle
        //{
        //    get
        //    {
        //        return clkSecondHandStyle;
        //    }
        //    set
        //    {
        //        clkSecondHandStyle = value;
        //    }
        //}

        public Color ClockSecondHandColor
        {
            get
            {
                return colSecondHand;
            }
            set
            {
                colSecondHand = value;
                this.Invalidate();
            }
        }

        public bool ClockUseSmoothSecondHand
        {
            get
            {
                return bUseSmoothSecondHand;
            }
            set
            {
                bUseSmoothSecondHand = value;
                this.Invalidate();
            }
        }
        public Color ClockGlassColor
        {
            get
            {
                return clkGlass;
            }
            set
            {
                clkGlass = value;
                this.Invalidate();
            }
        }
        #endregion

        #region OnPaint Funkcija
        protected override void OnPaint(PaintEventArgs pe)
        {
            //Osiguravamo da je velicina forme uvijek kvadrat
            this.Width = this.Height;
            // Stvaranje objekta koji cemo koristit za grafiku
            Graphics grfx = pe.Graphics;
            //Testne vrijednosti postavki
            //TestPostavke();
            
            //Iniciranje grafike i kvalitete prikaza
            InitializeGraphicCoordinates(grfx);
            SetupGraphics(grfx);
            //Crtanje frama
            DrawClockFrame(grfx);
            //Crtanje stakla
            DrawClockGlass(grfx);
            //Crtanje linija
            DrawClockLines(grfx);
            //Crtanje brojeva
            DrawClockNumbers(grfx);
            //Crtanje kazaljki
            DrawClockHourHand(grfx);
            DrawClockMinuteHand(grfx);
            DrawClockSecondHand(grfx);
            //Crtanje stakla
            //DrawClockGlass(grfx);
            // Calling the base class OnPaint
            base.OnPaint(pe);
        }
        #endregion

        #region Inicijacija grafike
        /// <summary>
        /// Inicijacija grafike transformiranjem u kordinatni sustav i scale
        /// </summary>
        /// <param name="grfx">Objekt za grafiku</param>
        private void InitializeGraphicCoordinates(Graphics grfx)
        {
            if (this.Width == 0 || this.Height == 0)
                return;

            //Postavljamo grafiku na srediste kontrole
            grfx.TranslateTransform(this.Width / 2, this.Height / 2);

            float fInches = Math.Min(this.Width / grfx.DpiX, this.Height / grfx.DpiY);
            //Postavljamo omjer na 1000 sto znaci da od centra u svim smjerovima duzina iznosi 1000
            grfx.ScaleTransform(fInches * grfx.DpiX / 2000, fInches * grfx.DpiY / 2000);
        }
        /// <summary>
        /// Podesavanje raznih parametara za kvalitetniji prikaz
        /// </summary>
        /// <param name="grfx">Objekt za grafiku</param>
        private void SetupGraphics(Graphics grfx)
        {
            grfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            grfx.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            grfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            grfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        }
        #endregion

        #region Crtanje okvira 
        /// <summary>
        /// Funkcija koja iscrtava okvir sata
        /// </summary>
        /// <param name="grfx">Objekt za grafiku</param>
        private void DrawClockFrame(Graphics grfx)
        {
            //Spremamo stanje grafike kako bi ga mogli kasnije vratit
            GraphicsState gs = grfx.Save();
            
            //Sirina sata za stilove i sjena
            int iSirina = 100;
            int iSizeShadow = 80;

            //Koji okvir se iscrtava
            switch (clkFrameStyle)
            {
                case ClockFrame.Normal:
                    iSirina = iSirinaNormal;
                    break;
                case ClockFrame.Thin:
                    iSirina = iSirinaThin;
                    break;
            }
            
            LinearGradientBrush linearBrush =
                                   new LinearGradientBrush(new Rectangle(-iRadius/2, -iRadius/2,
                                   iRadius , iRadius),
                                   colFrameOutside1,
                                   colFrameOutside2,
                                   225);

            //Sjena
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(10 - (iRadius + iSizeShadow) / 2, 10 - (iRadius + iSizeShadow) / 2, iRadius + iSizeShadow, iRadius + iSizeShadow);
            PathGradientBrush pthGradient = new PathGradientBrush(grPath);
            pthGradient.CenterColor = Color.FromArgb(255, 0, 0, 0);
            Color[] colGradient = { Color.FromArgb(0,0,0,0) };
            pthGradient.SurroundColors = colGradient;
            pthGradient.FocusScales = new PointF(0.94f, 0.94f);
            //pthGradient.CenterPoint = new PointF(0 - (iRadius + iSizeShadow) / 2, 0 - (iRadius + iSizeShadow) / 2);
            grfx.FillEllipse(pthGradient, 10 - (iRadius + iSizeShadow) / 2, 10 - (iRadius + iSizeShadow) / 2, iRadius + iSizeShadow, iRadius + iSizeShadow);
            
             //Vanjski prvi krug
            grfx.FillEllipse(linearBrush, 0 - iRadius / 2, 0 - iRadius / 2, iRadius, iRadius);
            
            //Vanjski drugi krug
            linearBrush.LinearColors = new Color[] { colFrameOutside2, colFrameOutside1 };
            grfx.FillEllipse(linearBrush, -(iRadius - iSirina) / 2, -(iRadius - iSirina) / 2, iRadius - iSirina, iRadius - iSirina);

            //Unutarnji krug (Povrsina sata sa kazaljkama i brojevima)
            linearBrush.LinearColors = new Color[] { colFrameInside1, colFrameInside2 };
            grfx.FillEllipse(linearBrush, 0 - (iRadius - 40 - iSirina) / 2, 0 - (iRadius - 40 - iSirina) / 2, iRadius - iSirina - 40, iRadius - iSirina - 40);

            grfx.Restore(gs);
        }
        #endregion

        #region Crtanje Linija
        /// <summary>
        /// Funkcija koja iscrtava linije kod brojeva
        /// </summary>
        /// <param name="grfx">Objekt za grafiku</param>
        private void DrawClockLines(Graphics grfx)
        {
            GraphicsState gs = grfx.Save();

            if (clkHoursLineStyle == ClockLines.None && clkMinutesLineStyle == ClockLines.None)
                return;
            if (clkHoursLineStyle == ClockLines.None)
                return;

            int iRadiusInner = clkFrameStyle == ClockFrame.Normal ? (iRadius - 40 - iSirinaNormal) : (iRadius - 40 - iSirinaThin);

            for (int i = 0; i < 60; i++)
            {
                if (i % 5 == 0)
                {
                    DrawLinesShape(grfx, clkHoursLineStyle, (iRadiusInner - 130) / 2, 75, true);
                }
                else
                {
                    DrawLinesShape(grfx, clkMinutesLineStyle, (iRadiusInner -130) / 2, 35, false);
                }

                grfx.RotateTransform(6);
            }//end for
            grfx.Restore(gs);
        }

        /// <summary>
        /// Pomocna funkcija funkciji DrawClockLines sluzi za crtanje oblika
        /// </summary>
        /// <param name="grfx">Objekt za grafiku</param>
        /// <param name="clkLines">Koji oblik treba bit iscrtan</param>
        /// <param name="iRadius">Radius sata</param>
        /// <param name="iSize">Velicina oblika</param>
        /// <param name="bHour">Dali je boja za sate(true) ili minute(false)</param>
        private void DrawLinesShape(Graphics grfx, ClockLines clkLines, int iRadius, int iSize, bool bHour)
        {
            Color colLinije = bHour == true ? colHoursLine : colMinutesLine; 
            switch (clkLines)
            {
                case ClockLines.None:
                    return;
                case ClockLines.Circle:
                    {
                        grfx.FillEllipse(new SolidBrush(colLinije), new Rectangle(0 - iSize  / 2, -iRadius - iSize / 2, iSize-10 , iSize-10));
                        break;
                    }
                case ClockLines.Diamond:
                    {
                        //PointF[] pfPoints = new PointF[] { new PointF(0, -iRadius - iSize / 2), new PointF(iSize / 2, -iRadius),
                        //new PointF(0,-iRadius + iSize / 2),new PointF(-iSize / 2, -iRadius)};
                        PointF[] pfPoints = new PointF[] { new PointF(0, -iRadius - iSize / 2), new PointF(iSize / 4, -iRadius),
                        new PointF(0,-iRadius + iSize / 2),new PointF(-iSize / 4, -iRadius)};
                        grfx.FillPolygon(new SolidBrush(colLinije), pfPoints);
                        break;
                    }
                case ClockLines.Line:
                    {
                        grfx.FillRectangle(new SolidBrush(colLinije), new Rectangle((0 - iSize / 2) / 2, -iRadius  - iSize / 2, iSize / 3, iSize));
                        break;
                    }
                case ClockLines.LinewithCircles:
                    {
                        int iSizeLine = 75;
                        //grfx.DrawEllipse(new Pen(new SolidBrush(colHoursLine)), 0 - iRadius / 2, 0 - iRadius / 2, iRadius, iRadius);
                        grfx.FillRectangle(new SolidBrush(colLinije), new Rectangle((0 - iSizeLine / 2) / 2, -iRadius - iSizeLine / 2, iSizeLine / 3, iSizeLine));
                        break;
                    }
            }
        }
        #endregion

        #region Crtanje brojeva
        /// <summary>
        /// Funkcija koja iscrtava brojeve
        /// </summary>
        /// <param name="grfx">Objekt za grafiku</param>
        private void DrawClockNumbers(Graphics grfx)
        {
            GraphicsState gs = grfx.Save();
            //Broj s kojim pratimo trenutni broj u petlji
            int iCurrent = 0;
            int iTextSize = 14;
            int iRadiusInner = clkFrameStyle == ClockFrame.Normal ? (iRadius - 510 - iSirinaNormal) : (iRadius - 510 - iSirinaThin);
           
            PointF pfcoordinates  = new PointF();
            SizeF sfTextLenght = new SizeF();
            Font font = new Font("Tahoma", iTextSize * Font.SizeInPoints, FontStyle.Bold);

            for (int i = 0; i < 720; i += 60)
            {
                //500 je udaljenost od sredista radijus
                pfcoordinates.X = (float)(Math.Cos((i * Math.PI) / 360) * (iRadiusInner /2));
                pfcoordinates.Y = (float)(Math.Sin((i * Math.PI) / 360) * (iRadiusInner /2));

                switch (clkNumbers)
                {
                    case ClockNumbers.None:
                        return;
                    case ClockNumbers.Normal:
                        {
                            sfTextLenght = grfx.MeasureString(strNormal[iCurrent], font);
                            grfx.DrawString(strNormal[iCurrent], font, new SolidBrush(colNumbers),
                                pfcoordinates.X - sfTextLenght.Width / 2, 
                                pfcoordinates.Y - sfTextLenght.Height / 2);
                            break;
                        }
                    case ClockNumbers.Roman:
                        {
                            sfTextLenght = grfx.MeasureString(strRoman[iCurrent], font);
                            grfx.DrawString(strRoman[iCurrent], font, new SolidBrush(colNumbers),
                                pfcoordinates.X - sfTextLenght.Width / 2,
                                pfcoordinates.Y - sfTextLenght.Height / 2);
                            break;
                        }
                    case ClockNumbers.Normal_90:
                        {
                            if (iCurrent % 3 == 0)
                            {
                                sfTextLenght = grfx.MeasureString(strNormal[iCurrent], font);
                                grfx.DrawString(strNormal[iCurrent], font, new SolidBrush(colNumbers),
                                    pfcoordinates.X - sfTextLenght.Width / 2,
                                    pfcoordinates.Y - sfTextLenght.Height / 2);   
                            }
                            break;
                        }
                    case ClockNumbers.Roman_90:
                        {
                            if (iCurrent % 3 == 0)
                            {
                                sfTextLenght = grfx.MeasureString(strRoman[iCurrent], font);
                                grfx.DrawString(strRoman[iCurrent], font, new SolidBrush(colNumbers),
                                    pfcoordinates.X - sfTextLenght.Width / 2,
                                    pfcoordinates.Y - sfTextLenght.Height / 2); 
                            }
                            break;
                        }
                }
                iCurrent += 1;
            }//end for

            grfx.Restore(gs);
        }
        #endregion

        #region Crtanje Kazaljki
        /// <summary>
        /// Funkcija koja crta satnu kazaljku
        /// </summary>
        /// <param name="grfx">Objekt za grafiku</param>
        private void DrawClockHourHand(Graphics grfx)
        {
            GraphicsState gs = grfx.Save();

            grfx.RotateTransform(360f * dtTime.Hour / 12 + 30f * dtTime.Minute / 60);
            int iRadiusInner = clkFrameStyle == ClockFrame.Normal ? (iRadius - 40 - iSirinaNormal) : (iRadius - 40 - iSirinaThin);

            switch (clkHourHandStyle)
            {
                case ClockHand.Diamond:
                    {
                        grfx.FillPolygon(new SolidBrush(colHourHand), new Point[] 
                                          {
                                              new Point(0,iRadiusInner/9),new Point(75,0),
                                              new Point(0,-iRadiusInner/3 ),new Point(-75,0)
                                          });
                        break;
                    }
                case ClockHand.Line:
                    {
                        grfx.DrawLine(new Pen(new SolidBrush(colHourHand), 55), 0, 75, 0, -iRadiusInner / 4);
                        break;
                    }
                case ClockHand.Retro:
                    {
                        grfx.DrawLine(new Pen(new SolidBrush(colHourHand), 55), 0, 75, 0, -iRadiusInner / 6);
                        grfx.FillClosedCurve(new SolidBrush(colHourHand), new Point[] { 
                                 new Point(0 , -iRadiusInner / 6 + 2),new Point(55, -iRadiusInner / 6 + 50),
                                 new Point(0 , -iRadiusInner / 4),new Point(-55, -iRadiusInner / 6 + 50)
                                 
                                 }, FillMode.Alternate, 0.4f);
                        break;
                    }
                case ClockHand.RoundLine:
                    {
                        grfx.FillEllipse(new SolidBrush(colHourHand), new Rectangle((iRadius / 20) / 2, 0, -iRadius / 20, -iRadius / 4));
                        break;
                    }
            }
            grfx.Restore(gs);
        }

        /// <summary>
        /// Funkcija koja crta minutnu kazaljku
        /// </summary>
        /// <param name="grfx">Objekt za grafiku</param>
        private void DrawClockMinuteHand(Graphics grfx)
        {
            GraphicsState gs = grfx.Save();

            grfx.RotateTransform(360f * dtTime.Minute / 60 + 6f * dtTime.Second / 60);
            int iRadiusInner = clkFrameStyle == ClockFrame.Normal ? (iRadius - 40 - iSirinaNormal) : (iRadius - 40 - iSirinaThin);

            switch (clkMinuteHandStyle)
            {
                case ClockHand.Diamond:
                    {
                        grfx.FillPolygon(new SolidBrush(colMinuteHand), new Point[] 
                                          {
                                              new Point(0, iRadiusInner / 9),new Point(50, 0),
                                              new Point(20, -iRadiusInner/2+200),new Point(0, -iRadiusInner/2 + 100),
                                              new Point(-20, -iRadiusInner/2+200),new Point(-50, 0)
                                          });
                        break;
                    }
                case ClockHand.Line:
                    {
                        grfx.DrawLine(new Pen(new SolidBrush(colMinuteHand), 41), 0, 75, 0, -iRadiusInner / 2 + 120);
                        break;
                    }
                case ClockHand.Retro:
                    {
                        grfx.DrawLine(new Pen(new SolidBrush(colMinuteHand), 41), 0, 75, 0, -iRadiusInner / 2 + 250);
                        grfx.FillClosedCurve(new SolidBrush(colMinuteHand), new Point[] { 
                                 new Point(0 , -iRadiusInner / 2 + 252),new Point(41, -iRadiusInner / 3 + 50),
                                 new Point(0 , -iRadiusInner / 2 + 100),new Point(-41, -iRadiusInner / 3 + 50)
                                 
                                 }, FillMode.Alternate, 0.3f);
                        break;
                    }
                case ClockHand.RoundLine:
                    {
                        grfx.FillEllipse(new SolidBrush(colMinuteHand), new Rectangle((iRadiusInner / 20) / 2, 0, -iRadiusInner / 20, -iRadiusInner / 2 + 160));
                        break;
                    }
            }
            grfx.Restore(gs);
        }

        /// <summary>
        /// Funkcija koja crta sekundnu kazaljku
        /// </summary>
        /// <param name="grfx">Objekt za grafiku</param>
        private void DrawClockSecondHand(Graphics grfx)
        {
            GraphicsState gs = grfx.Save();
            if (bUseSmoothSecondHand == true)
            {
                grfx.RotateTransform(360f * dtTime.Second / 60 + 6f * dtTime.Millisecond / 1000);
            }
            else
            {
                grfx.RotateTransform(360f * dtTime.Second / 60 + 6f);
            }

            int iRadiusInner = clkFrameStyle == ClockFrame.Normal ? (iRadius - 40 - iSirinaNormal) : (iRadius - 40 - iSirinaThin);

            switch (clkSecondHandStyle)
            {
                case ClockHandSecond.Line:
                    {
                        Pen pen = new Pen(new SolidBrush(colSecondHand), 21);
                        grfx.DrawLine(pen, 0, 130, 0, -iRadiusInner / 2 + 41);
                        pen.Width = 41;
                        grfx.DrawLine(pen, 0, 200, 0, -130/2 + 25);
                        grfx.FillEllipse(new SolidBrush(colSecondHand), new Rectangle(-45, -45, 90, 90));
                        break;
                    }
            }
            grfx.Restore(gs);
        }
        #endregion

        #region Crtanje stakla
        //clkGlass
        /// <summary>
        /// Funkcija koja crta staklo(efekt)
        /// </summary>
        /// <param name="grfx">Objekt za grafiku</param>
        private void DrawClockGlass(Graphics grfx)
        {
            GraphicsState gs = grfx.Save();
            int iRadiusInner = clkFrameStyle == ClockFrame.Normal ? (iRadius - 40 - iSirinaNormal) : (iRadius - 40 - iSirinaThin);
            grfx.RotateTransform(340);
            LinearGradientBrush linGrBrush = new LinearGradientBrush(
                                             new Point(0, -iRadiusInner/2),
                                             new Point(0, -0),
                                             clkGlass,
                                             Color.Transparent);

            grfx.FillClosedCurve(linGrBrush, new Point[] { 
                                 new Point(iRadiusInner/2 , -100),new Point(0, -iRadiusInner/2),
                                 new Point(-iRadiusInner/2 , -100),new Point(0, -200)
                                 
                                 },FillMode.Alternate,1.0f);

            grfx.Restore(gs);
        }
        #endregion

        #region Default-ni Stil
        /// <summary>
        /// Koristi se za testiranje kontrole
        /// </summary>
        void DefaultStyle()
        {
            //Boje za gradijent od okvira
            colFrameOutside1 = Color.FromArgb(0, 0, 0);
            colFrameOutside2 = Color.FromArgb(120, 120, 255);
            colFrameInside1 = Color.FromArgb(255, 255, 200);
            colFrameInside2 = Color.FromArgb(255, 255, 150);

            clkFrameStyle = ClockFrame.Thin;

            //linije
            clkHoursLineStyle = ClockLines.Line;
            clkMinutesLineStyle = ClockLines.Diamond;

            colHoursLine = Color.FromArgb(0, 0, 0);
            colMinutesLine = Color.FromArgb(0, 0, 0);

            //Brojevi
            clkNumbers = ClockNumbers.Normal_90;
            colNumbers = Color.FromArgb(0, 0, 0);

            //kazaljka sata
            clkHourHandStyle = ClockHand.RoundLine;
            clkMinuteHandStyle = ClockHand.RoundLine;
            dtTime = DateTime.Now;
            //Invalidate();
            colHourHand = Color.FromArgb(0,0,0);
            colMinuteHand = Color.FromArgb(0,0,0);

            colSecondHand = Color.FromArgb(255, 0, 0);
            clkSecondHandStyle = ClockHandSecond.Line;
            bUseSmoothSecondHand = false;

            //staklo
            clkGlass = Color.FromArgb(255, 255, 255);
        }
        #endregion
    }
}
