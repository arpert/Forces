/*
 * Created by SharpDevelop.
 * User: arpert
 * Date: 2016-06-15
 * Time: 10:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Forces
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btOk;
		private System.Windows.Forms.Button btRun;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.CheckBox cbWrap;
		private System.Windows.Forms.CheckBox cbAuto;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox cbSpring;
		private System.Windows.Forms.NumericUpDown numUDdumpFactor;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
		   this.components = new System.ComponentModel.Container();
		   this.panel1 = new System.Windows.Forms.Panel();
		   this.btOk = new System.Windows.Forms.Button();
		   this.btRun = new System.Windows.Forms.Button();
		   this.timer1 = new System.Windows.Forms.Timer(this.components);
		   this.lblInfo = new System.Windows.Forms.Label();
		   this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
		   this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
		   this.cbWrap = new System.Windows.Forms.CheckBox();
		   this.cbAuto = new System.Windows.Forms.CheckBox();
		   this.label2 = new System.Windows.Forms.Label();
		   this.label3 = new System.Windows.Forms.Label();
		   this.cbSpring = new System.Windows.Forms.CheckBox();
		   this.numUDdumpFactor = new System.Windows.Forms.NumericUpDown();
		   ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
		   ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
		   ((System.ComponentModel.ISupportInitialize)(this.numUDdumpFactor)).BeginInit();
		   this.SuspendLayout();
		   // 
		   // panel1
		   // 
		   this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
         | System.Windows.Forms.AnchorStyles.Left) 
         | System.Windows.Forms.AnchorStyles.Right)));
		   this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		   this.panel1.Location = new System.Drawing.Point(1, 1);
		   this.panel1.Name = "panel1";
		   this.panel1.Size = new System.Drawing.Size(320, 320);
		   this.panel1.TabIndex = 0;
		   this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1Paint);
		   this.panel1.Resize += new System.EventHandler(this.Panel1Resize);
		   // 
		   // btOk
		   // 
		   this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		   this.btOk.Location = new System.Drawing.Point(403, 287);
		   this.btOk.Name = "btOk";
		   this.btOk.Size = new System.Drawing.Size(75, 23);
		   this.btOk.TabIndex = 1;
		   this.btOk.Text = "OK";
		   this.btOk.UseVisualStyleBackColor = true;
		   this.btOk.Click += new System.EventHandler(this.BtOkClick);
		   // 
		   // btRun
		   // 
		   this.btRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		   this.btRun.Location = new System.Drawing.Point(403, 258);
		   this.btRun.Name = "btRun";
		   this.btRun.Size = new System.Drawing.Size(75, 23);
		   this.btRun.TabIndex = 2;
		   this.btRun.Text = "Go";
		   this.btRun.UseVisualStyleBackColor = true;
		   this.btRun.Click += new System.EventHandler(this.BtRunClick);
		   // 
		   // timer1
		   // 
		   this.timer1.Interval = 40;
		   this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
		   // 
		   // lblInfo
		   // 
		   this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
		   this.lblInfo.Location = new System.Drawing.Point(327, 9);
		   this.lblInfo.Name = "lblInfo";
		   this.lblInfo.Size = new System.Drawing.Size(151, 23);
		   this.lblInfo.TabIndex = 4;
		   // 
		   // numericUpDown1
		   // 
		   this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
		   this.numericUpDown1.Location = new System.Drawing.Point(403, 65);
		   this.numericUpDown1.Maximum = new decimal(new int[] {
         1000,
         0,
         0,
         0});
		   this.numericUpDown1.Minimum = new decimal(new int[] {
         1,
         0,
         0,
         0});
		   this.numericUpDown1.Name = "numericUpDown1";
		   this.numericUpDown1.Size = new System.Drawing.Size(75, 22);
		   this.numericUpDown1.TabIndex = 5;
		   this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		   this.numericUpDown1.Value = new decimal(new int[] {
         100,
         0,
         0,
         0});
		   this.numericUpDown1.ValueChanged += new System.EventHandler(this.NumericUpDown1ValueChanged);
		   // 
		   // numericUpDown2
		   // 
		   this.numericUpDown2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		   this.numericUpDown2.Location = new System.Drawing.Point(403, 202);
		   this.numericUpDown2.Maximum = new decimal(new int[] {
         200,
         0,
         0,
         0});
		   this.numericUpDown2.Minimum = new decimal(new int[] {
         2,
         0,
         0,
         0});
		   this.numericUpDown2.Name = "numericUpDown2";
		   this.numericUpDown2.Size = new System.Drawing.Size(75, 22);
		   this.numericUpDown2.TabIndex = 6;
		   this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		   this.numericUpDown2.Value = new decimal(new int[] {
         9,
         0,
         0,
         0});
		   this.numericUpDown2.ValueChanged += new System.EventHandler(this.NumericUpDown2ValueChanged);
		   // 
		   // cbWrap
		   // 
		   this.cbWrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		   this.cbWrap.Location = new System.Drawing.Point(352, 172);
		   this.cbWrap.Name = "cbWrap";
		   this.cbWrap.Size = new System.Drawing.Size(126, 24);
		   this.cbWrap.TabIndex = 7;
		   this.cbWrap.Text = "Wrap";
		   this.cbWrap.UseVisualStyleBackColor = true;
		   this.cbWrap.CheckedChanged += new System.EventHandler(this.CbWrapCheckedChanged);
		   // 
		   // cbAuto
		   // 
		   this.cbAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
		   this.cbAuto.Location = new System.Drawing.Point(403, 35);
		   this.cbAuto.Name = "cbAuto";
		   this.cbAuto.Size = new System.Drawing.Size(75, 24);
		   this.cbAuto.TabIndex = 8;
		   this.cbAuto.Text = "Auto";
		   this.cbAuto.UseVisualStyleBackColor = true;
		   this.cbAuto.CheckedChanged += new System.EventHandler(this.CbAutoCheckedChanged);
		   // 
		   // label2
		   // 
		   this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
		   this.label2.Location = new System.Drawing.Point(352, 67);
		   this.label2.Name = "label2";
		   this.label2.Size = new System.Drawing.Size(45, 23);
		   this.label2.TabIndex = 9;
		   this.label2.Text = "Delay";
		   this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
		   // 
		   // label3
		   // 
		   this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		   this.label3.Location = new System.Drawing.Point(352, 204);
		   this.label3.Name = "label3";
		   this.label3.Size = new System.Drawing.Size(45, 23);
		   this.label3.TabIndex = 10;
		   this.label3.Text = "N";
		   this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
		   // 
		   // cbSpring
		   // 
		   this.cbSpring.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		   this.cbSpring.Location = new System.Drawing.Point(352, 142);
		   this.cbSpring.Name = "cbSpring";
		   this.cbSpring.Size = new System.Drawing.Size(126, 24);
		   this.cbSpring.TabIndex = 11;
		   this.cbSpring.Text = "Elastic border";
		   this.cbSpring.UseVisualStyleBackColor = true;
		   // 
		   // numUDdumpFactor
		   // 
		   this.numUDdumpFactor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		   this.numUDdumpFactor.Location = new System.Drawing.Point(403, 230);
		   this.numUDdumpFactor.Maximum = new decimal(new int[] {
         200,
         0,
         0,
         0});
		   this.numUDdumpFactor.Name = "numUDdumpFactor";
		   this.numUDdumpFactor.Size = new System.Drawing.Size(75, 22);
		   this.numUDdumpFactor.TabIndex = 12;
		   this.numUDdumpFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		   this.numUDdumpFactor.Value = new decimal(new int[] {
         9,
         0,
         0,
         0});
		   this.numUDdumpFactor.ValueChanged += new System.EventHandler(this.NumUDdumpFactorValueChanged);
		   // 
		   // MainForm
		   // 
		   this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
		   this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		   this.ClientSize = new System.Drawing.Size(490, 322);
		   this.Controls.Add(this.numUDdumpFactor);
		   this.Controls.Add(this.cbSpring);
		   this.Controls.Add(this.label3);
		   this.Controls.Add(this.label2);
		   this.Controls.Add(this.cbAuto);
		   this.Controls.Add(this.cbWrap);
		   this.Controls.Add(this.numericUpDown2);
		   this.Controls.Add(this.numericUpDown1);
		   this.Controls.Add(this.lblInfo);
		   this.Controls.Add(this.btRun);
		   this.Controls.Add(this.btOk);
		   this.Controls.Add(this.panel1);
		   this.Name = "MainForm";
		   this.Text = "Forces";
		   this.Load += new System.EventHandler(this.MainFormLoad);
		   ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
		   ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
		   ((System.ComponentModel.ISupportInitialize)(this.numUDdumpFactor)).EndInit();
		   this.ResumeLayout(false);

		}
	}
}
