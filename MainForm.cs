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
      public int cellNumber = 10;
      public const int BORDR = 20;
      private double dumpFactor = 0.99;
      
      List<Cell> cells = new List<Cell>();
    
      public int maxx { get { return panel1.Width; } }
      public int maxy { get { return panel1.Height; } }

      public static Random rnd = new Random();
      int x0 = 3, y0 = 1;

      public void InitCells(int sb)
      {  
         int tries = 1000;
         while (cells.Count > sb)
            cells.RemoveAt(0);
         
         while (cells.Count < sb && tries-- > 0)
         {
//         	int ix = maxx/3 + rnd.Next(maxx/3);
//            int iy = maxy/3 + rnd.Next(maxy/3);
         	int ix = rnd.Next(maxx);
            int iy = rnd.Next(maxy);
            
            cells.Add(new Cell(this, ix, iy));
         } 
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
      int d = 10, k = 4;
      foreach(Cell c in cells)
      {
         bgr.FillEllipse(new SolidBrush(c.clr), (int)c.x - d/2, (int)c.y - d/2, d, d);
         bgr.DrawEllipse(pn1, (int)c.x - d/2, (int)c.y - d/2, d, d);
         bgr.DrawLine(pn2, (int)c.x, (int)c.y, (int)(c.x + k * c.dx), (int)(c.y + k * c.dy));
         midx += c.x;
         midy += c.y;
      }

      if (x0 + (int)(midx / cells.Count) > 0 && y0 + (int)(midy / cells.Count) > 0)
{
//      Console.SetCursorPosition(x0 + (int)(midx / cells.Count) , y0 + (int)(midy / cells.Count));
//      Console.Write("#");
}
      gr.DrawImageUnscaled(bmp, 0, 0);
//      lblInfo.Text = string.Format("{0} {1}", x0 + (int)(midx / cells.Count) , y0 + (int)(midy / cells.Count));
//gr.DrawLine(Pens.LightGray, 0, 0, Math.Min(maxx, maxy), Math.Min(maxx, maxy));
   }

   public double Force(Cell c0, Cell c1)   
   {
      double dx = Math.Abs(c0.x - c1.x);
      double dy = Math.Abs(c0.y - c1.y);
      
      double d;
      if (cbWrap.Checked)
      {
         if (dx > maxx / 2) dx = maxx - dx;
         if (dy > maxy / 2) dy = maxy - dy;
      }
      d = (dx * dx + dy * dy);
       if (d < 10e-6) d = 10e-6;
       return (20.0 / d);
   }

   public double move()
   {
      double moved = 0;
      double sfx, sfy;
      double f;
      Cell c1;
      for(int i = 0; i < cells.Count; i++)
      {
         sfx = 0;
         sfy = 0;
         Cell c0 = cells[i];
         for(int j = 0; j < cells.Count; j++)
         {
            if (j != i)
            {
	           c1 = cells[j];
               f = Force(c0, c1);
               if (cbWrap.Checked)
               {
                  sfx += f * ((Math.Abs(c0.x - c1.x) > maxx / 2) ? (maxx - Math.Abs(c0.x - c1.x)) * Math.Sign(c1.x - c0.x) : (c0.x - c1.x));
                  sfy += f * ((Math.Abs(c0.y - c1.y) > maxy / 2) ? (maxy - Math.Abs(c0.y - c1.y)) * Math.Sign(c1.y - c0.y) : (c0.y - c1.y));
               } else
               {
                  sfx += f * (c0.x - c1.x);
                  sfy += f * (c0.y - c1.y);
               }
            }
         }
         c0.dx += sfx / (cells.Count - 1);
         c0.dy += sfy / (cells.Count - 1);
         c0.dx *= dumpFactor;
         c0.dy *= dumpFactor;
      }

      for(int i = 0; i < cells.Count; i++)
      {
      	double ox, oy;
      	ox = cells[i].x;
      	oy = cells[i].y;
      	cells[i].Move();
      	double nx = cells[i].x;
      	double ny = cells[i].y;
      	if (cbWrap.Checked)
      	{
      		nx = (nx + maxx) % maxx;
      		ny = (ny + maxy) % maxy;
      	} else
      	{
      	   if (cbSpring.Checked)
      	   {
      	      if ((nx < 0) || (nx > maxx - 1)) cells[i].dx *= -dumpFactor;
      	      if ((ny < 0) || (ny > maxy - 1)) cells[i].dy *= -dumpFactor;
      	   } 
      	   
           if (nx < 0) { if (nx < -BORDR) nx = rnd.Next(maxx); else nx = 0; }
           if (ny < 0) { if (ny < -BORDR) ny = rnd.Next(maxy); else ny = 0; }
           if (nx > maxx - 1) { if (nx > maxx + BORDR) nx = rnd.Next(maxx); else nx = maxx - 1; }
           if (ny > maxy - 1) { if (ny > maxy + BORDR) ny = rnd.Next(maxy); else ny = maxy - 1; }
      	}
      	
        cells[i].x = nx;
        cells[i].y = ny;
      	
        moved += Math.Abs(ox - cells[i].x) + Math.Abs(oy - cells[i].y);
      }

      return moved;
   }

   bool inRun = false;
   int frmCnt = 0;
   public void Run()
   {
      frmCnt++;
      if (!inRun)
      {
         inRun = true;
      double res = move();
   	  show(panel1.CreateGraphics());
   	  //if (res < 1) InitCells(cellNumber);
//   	  lblInfo.Text =  "Moved " + string.Format("{0:###.00}", res);
if (frmCnt > 1)
        lblInfo.Text =  "Frames " + string.Format("{0:####}", frmCnt);
        inRun = false;
        frmCnt = 0;
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
			cellNumber = (int)numericUpDown2.Value;
			dumpFactor = 1.0 - ((double)numUDdumpFactor.Value / 1000.0);
			InitCells(cellNumber);
			
			Run();
    
      }
		
		void Panel1Paint(object sender, PaintEventArgs e)
		{
			show(e.Graphics);
		}
		
		void BtRunClick(object sender, EventArgs e)
		{
		   if (cbAuto.Checked)
		      InitCells(cellNumber);
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
			cellNumber = (int)numericUpDown2.Value;
			InitCells(cellNumber);
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
