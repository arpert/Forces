/*
 * Created by SharpDevelop.
 * User: arpert
 * Date: 2016-06-15
 * Time: 10:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Collections.Generic;

namespace Forces
{
	/// <summary>
	/// Description of Cell.
	/// </summary>
	  public class Cell {
		private MainForm parent;
      public double x, y;
      public double dx, dy;
      public int dir;
      public Color clr;
      double force;
      KnownColor[] clrs = (KnownColor[])Enum.GetValues(typeof(KnownColor));
      public Cell(MainForm parent) 
      { 
      	this.parent = parent;
      	x = 0; y = 0; dir = 0; force = 0; dx = 0; dy = 0;
      	clr = Color.FromKnownColor(clrs[MainForm.rnd.Next(clrs.Length)]);
      }

      public Cell(MainForm parent, double x, double y) 
      { this.parent = parent;
      	this.x = x; this.y = y; dir = 0; force = 0; dx = 0; dy = 0; 
      	clr = Color.FromKnownColor(clrs[MainForm.rnd.Next(clrs.Length)]);
      }

      public Cell(MainForm parent, double x, double y, int dir, double force) 
      { this.parent = parent;
      	this.x = x; this.y = y; this.dir = dir; this.force = force; dx = 0; dy = 0;
      	clr = Color.FromKnownColor(clrs[MainForm.rnd.Next(clrs.Length)]);
      }

      public void Move() 
      { 
         double nx = x, ny = y;
         double m = 1.0;//Math.Sqrt(dx*dx + dy*dy);
         x += dx / m;
         y += dy / m;
//         dx *= 0.999;
//         dy *= 0.999;
      }
 
   }

}
