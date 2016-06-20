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
	  public class Particle {
      public double x, y;
      public double dx, dy;
      public int d = 20; ///< diameter
      public Color clr;
      double force;
      KnownColor[] clrs = (KnownColor[])Enum.GetValues(typeof(KnownColor));
      public Particle() 
      { 
      	x = 0; y = 0; force = 0; dx = 0; dy = 0;
      	clr = Color.FromKnownColor(clrs[MainForm.rnd.Next(clrs.Length)]);
      }

      public Particle(double x, double y) 
      { 
      	this.x = x; this.y = y; force = 0; dx = 0; dy = 0;
      	clr = Color.FromKnownColor(clrs[MainForm.rnd.Next(clrs.Length)]);
      }

      public Particle(double x, double y, int d) 
      { 
      	this.x = x; this.y = y; this.force = 0; dx = 0; dy = 0; this.d = d;
      	clr = Color.FromKnownColor(clrs[MainForm.rnd.Next(clrs.Length)]);
      }

      public void Move() 
      { 
         double nx = x, ny = y;
         x += dx;
         y += dy;
      }
 
   }

}
