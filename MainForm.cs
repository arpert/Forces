/*
 * Created by SharpDevelop.
 * User: arpert
 * Date: 2016-06-15
 * Time: 10:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Forces
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
      public int particlesNumber = 10;
      public const int BORDR = 20;
      private double dumpFactor = 0.99;
      
      List<Particle> particles = new List<Particle>();
    
      public int maxx { get { return panel1.Width; } }
      public int maxy { get { return panel1.Height; } }

      public static Random rnd = new Random();

      public void InitParticles()
      {  
         int tries = 1000;
         while (particles.Count > particlesNumber)
            particles.RemoveAt(0);
         
         while (particles.Count < particlesNumber && tries-- > 0)
         {
//         	int ix = maxx/3 + rnd.Next(maxx/3);
//            int iy = maxy/3 + rnd.Next(maxy/3);
         	int ix = rnd.Next(maxx);
            int iy = rnd.Next(maxy);
            
            particles.Add(new Particle(ix, iy, 7+rnd.Next(6)));
         } 
      }

      public void DrawCircle(Graphics gr, Pen pn, int x0, int y0, int r)
      {
         gr.DrawEllipse(pn, x0 - r, y0 - r, r+r, r+r);
      }
      
      public void FillCircle(Graphics gr, Brush br, int x0, int y0, int r)
      {
         gr.FillEllipse(br, x0 - r, y0 - r, r+r, r+r);
      }
      
   Bitmap bmp = null;
   public void show(Graphics gr)
   {
      Pen pn1 = Pens.LightGreen;
      Pen pn2 = Pens.Green;
      if (bmp == null)
         bmp = new Bitmap(maxx, maxy);
      Graphics bgr = Graphics.FromImage(bmp);
      bgr.FillRectangle(new SolidBrush(panel1.BackColor), panel1.ClientRectangle);
      
      double midx = 0, midy = 0;
      int k = 4;
      foreach(Particle p in particles)
      {
         FillCircle(bgr, new SolidBrush(p.clr), (int)p.x, (int)p.y, p.d/2);
         DrawCircle(bgr, pn1, (int)p.x, (int)p.y, p.d/2);
         bgr.DrawLine(pn2, (int)p.x, (int)p.y, (int)(p.x + k * p.dx), (int)(p.y + k * p.dy));
         midx += p.x;
         midy += p.y;
      }

      gr.DrawImageUnscaled(bmp, 0, 0);
//      #if (DEBUG)
//      { gr.DrawLine(Pens.LightGray, 0, 0, Math.Min(maxx, maxy), Math.Min(maxx, maxy)); }
//      #endif
//      }
   }

   public double Force(Particle p0, Particle p1)   
   {
      double dx = Math.Abs(p0.x - p1.x);
      double dy = Math.Abs(p0.y - p1.y);
      
      double d;
      if (cbWrap.Checked)
      {
         if (dx > maxx / 2) dx = maxx - dx;
         if (dy > maxy / 2) dy = maxy - dy;
      }
      d = (dx * dx + dy * dy);
      if (d < 10e-8) d = 10e-8;
       return (20.0 / d);
   }

   public double move()
   {
      double moved = 0;
      double sfx, sfy;
      double f;
      Particle c1;
      for(int i = 0; i < particles.Count; i++)
      {
         sfx = 0;
         sfy = 0;
         Particle c0 = particles[i];
         for(int j = 0; j < particles.Count; j++)
         {
            if (j != i)
            {
	           c1 = particles[j];
               f = Force(c0, c1);
               double dx = (c1.x - c0.x);
               double dy = (c1.y - c0.y);
               double adx = dx;
               double ady = dy;
               
               if (cbWrap.Checked)
               {
                  sfx += f * ((adx > maxx / 2) ? (maxx - adx) * Math.Sign(dx) : -dx) / Math.Sqrt(adx * adx + ady * ady);
                  sfy += f * ((ady > maxy / 2) ? (maxy - ady) * Math.Sign(dy) : -dy) / Math.Sqrt(adx * adx + ady * ady);
               } else
               {
               	  sfx += f * (-dx) / Math.Sqrt(adx * adx + ady * ady);
                  sfy += f * (-dx) / Math.Sqrt(adx * adx + ady * ady);
               }
            }
         }
         c0.dx += sfx / (particles.Count / 2 - 1);
         c0.dy += sfy / (particles.Count / 2 - 1);
         c0.dx *= dumpFactor;
         c0.dy *= dumpFactor;
      }

      for(int i = 0; i < particles.Count; i++)
      {
      	double ox, oy;
      	ox = particles[i].x;
      	oy = particles[i].y;
      	particles[i].Move();
      	double nx = particles[i].x;
      	double ny = particles[i].y;
      	if (cbWrap.Checked)
      	{
      		nx = (nx + maxx) % maxx;
      		ny = (ny + maxy) % maxy;
      	} else
      	{
      	   if (cbSpring.Checked)
      	   {
      	      if ((nx < 0) || (nx > maxx - 1)) particles[i].dx *= -dumpFactor;
      	      if ((ny < 0) || (ny > maxy - 1)) particles[i].dy *= -dumpFactor;
      	   } 
      	   
           if (nx < 0) { if (nx < -BORDR) nx = rnd.Next(maxx); else nx = 0; }
           if (ny < 0) { if (ny < -BORDR) ny = rnd.Next(maxy); else ny = 0; }
           if (nx > maxx - 1) { if (nx > maxx + BORDR) nx = rnd.Next(maxx); else nx = maxx - 1; }
           if (ny > maxy - 1) { if (ny > maxy + BORDR) ny = rnd.Next(maxy); else ny = maxy - 1; }
      	}
      	
        particles[i].x = nx;
        particles[i].y = ny;
      	
        moved += Math.Abs(ox - particles[i].x) + Math.Abs(oy - particles[i].y);
      }

      return moved;
   }

   bool inRun = false;
   int frmCnt = 0;
   int prevSec = 1000;
   public void Run()
   {
      if (!inRun)
      {
   	DateTime dt = DateTime.Now;
   	if (prevSec != dt.Second)
   	{
        lblInfo.Text =  "Frames " + string.Format("{0:####}", frmCnt);
        frmCnt = 0;
        prevSec = dt.Second;
   	}
   	frmCnt++;

         inRun = true;
      double res = move();
   	  show(panel1.CreateGraphics());
   	  //if (res < 1) InitCells(cellNumber);
//   	  lblInfo.Text =  "Moved " + string.Format("{0:###.00}", res);
        inRun = false;
      }
   }

		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			numericUpDown1.Value = timer1.Interval;
			particlesNumber = (int)numericUpDown2.Value;
			dumpFactor = 1.0 - ((double)numUDdumpFactor.Value / 1000.0);
			InitParticles();
			
			Run();
    
      }
		
		void Panel1Paint(object sender, PaintEventArgs e)
		{
			show(e.Graphics);
		}
		
		void BtRunClick(object sender, EventArgs e)
		{
		   if (cbAuto.Checked)
		      InitParticles();
		   else
		      Run();
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			Run();
		}
		
		void NumericUpDown1ValueChanged(object sender, EventArgs e)
		{
			bool timerEnabled = timer1.Enabled;
			timer1.Enabled = false;
			timer1.Interval = (int)numericUpDown1.Value;
			timer1.Enabled = timerEnabled;
	
		}
		
		void BtOkClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
		
		void NumericUpDown2ValueChanged(object sender, EventArgs e)
		{
			particlesNumber = (int)numericUpDown2.Value;
			InitParticles();
			if (!cbAuto.Checked)
			   show(panel1.CreateGraphics());
		}
		
      void CbAutoCheckedChanged(object sender, EventArgs e)
      {
         timer1.Enabled = ((CheckBox)sender).Checked;
      }
      
      void MainFormLoad(object sender, EventArgs e)
      {
    
      }
      
      void CbWrapCheckedChanged(object sender, EventArgs e)
      {
         cbSpring.Enabled = !((CheckBox)sender).Checked;
      }
      
      void NumUDdumpFactorValueChanged(object sender, EventArgs e)
      {
         dumpFactor = 1.0 - ((double)numUDdumpFactor.Value / 1000.0);
      }
      
      void Panel1Resize(object sender, EventArgs e)
      {
         bmp = null;
      }
	}
}
