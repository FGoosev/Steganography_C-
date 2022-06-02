using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Text; 

namespace Steganography
{
	/// <summary>
	/// Summary description for SteganographyForm.
	/// </summary>
	public class SteganographyForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonHideMessage;
		private System.Windows.Forms.Panel panelOriginalImage;
		private System.Windows.Forms.TextBox textBoxOriginalMessage;
		private System.Windows.Forms.Panel panelModifiedImage;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button buttonExtractMessage;
		private System.Windows.Forms.TextBox textBoxExtractedlMessage;
		private System.Windows.Forms.GroupBox groupBox2;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SteganographyForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			try
			{
				//load original bitmap from a file
				bitmapOriginal = (Bitmap)Bitmap.FromFile(
					@"..\..\katie_plaintext.jpg");

				//center to screen
				this.CenterToScreen( );
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error loading image. " + 
					ex.Message );
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonHideMessage = new System.Windows.Forms.Button();
			this.panelOriginalImage = new System.Windows.Forms.Panel();
			this.textBoxOriginalMessage = new System.Windows.Forms.TextBox();
			this.panelModifiedImage = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.buttonExtractMessage = new System.Windows.Forms.Button();
			this.textBoxExtractedlMessage = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.SuspendLayout();
			// 
			// buttonHideMessage
			// 
			this.buttonHideMessage.Location = new System.Drawing.Point(8, 552);
			this.buttonHideMessage.Name = "buttonHideMessage";
			this.buttonHideMessage.Size = new System.Drawing.Size(120, 23);
			this.buttonHideMessage.TabIndex = 0;
			this.buttonHideMessage.Text = "Hide Message";
			this.buttonHideMessage.Click += new System.EventHandler(this.buttonHideMessage_Click);
			// 
			// panelOriginalImage
			// 
			this.panelOriginalImage.Location = new System.Drawing.Point(16, 24);
			this.panelOriginalImage.Name = "panelOriginalImage";
			this.panelOriginalImage.Size = new System.Drawing.Size(343, 484);
			this.panelOriginalImage.TabIndex = 0;
			// 
			// textBoxOriginalMessage
			// 
			this.textBoxOriginalMessage.Location = new System.Drawing.Point(152, 552);
			this.textBoxOriginalMessage.Name = "textBoxOriginalMessage";
			this.textBoxOriginalMessage.Size = new System.Drawing.Size(200, 20);
			this.textBoxOriginalMessage.TabIndex = 1;
			this.textBoxOriginalMessage.Text = "";
			// 
			// panelModifiedImage
			// 
			this.panelModifiedImage.Location = new System.Drawing.Point(384, 24);
			this.panelModifiedImage.Name = "panelModifiedImage";
			this.panelModifiedImage.Size = new System.Drawing.Size(343, 484);
			this.panelModifiedImage.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(136, 528);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(232, 56);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Original Message";
			// 
			// groupBox3
			// 
			this.groupBox3.Location = new System.Drawing.Point(8, 8);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(360, 512);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Original Image";
			// 
			// groupBox4
			// 
			this.groupBox4.Location = new System.Drawing.Point(376, 8);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(360, 512);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Modified Image";
			// 
			// buttonExtractMessage
			// 
			this.buttonExtractMessage.Location = new System.Drawing.Point(376, 552);
			this.buttonExtractMessage.Name = "buttonExtractMessage";
			this.buttonExtractMessage.Size = new System.Drawing.Size(120, 23);
			this.buttonExtractMessage.TabIndex = 2;
			this.buttonExtractMessage.Text = "Extract Message";
			this.buttonExtractMessage.Click += new System.EventHandler(this.buttonExtractMessage_Click);
			// 
			// textBoxExtractedlMessage
			// 
			this.textBoxExtractedlMessage.Location = new System.Drawing.Point(520, 552);
			this.textBoxExtractedlMessage.Name = "textBoxExtractedlMessage";
			this.textBoxExtractedlMessage.ReadOnly = true;
			this.textBoxExtractedlMessage.Size = new System.Drawing.Size(200, 20);
			this.textBoxExtractedlMessage.TabIndex = 3;
			this.textBoxExtractedlMessage.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Location = new System.Drawing.Point(504, 528);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(232, 56);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Extractedl Message";
			// 
			// SteganographyForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(744, 589);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.textBoxOriginalMessage,
																		  this.buttonHideMessage,
																		  this.panelModifiedImage,
																		  this.groupBox1,
																		  this.panelOriginalImage,
																		  this.groupBox3,
																		  this.groupBox4,
																		  this.buttonExtractMessage,
																		  this.textBoxExtractedlMessage,
																		  this.groupBox2});
			this.Name = "SteganographyForm";
			this.Text = "Steganography";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.SteganographyForm_Paint);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new SteganographyForm());
		}

		private void SteganographyForm_Paint(
			object sender, 
			System.Windows.Forms.PaintEventArgs e)
		{
			try
			{
				//get Graphics object for painting original
				Graphics gPanelOriginal = 
					Graphics.FromHwnd(
						panelOriginalImage.Handle);

				//draw original bitmap into panel
				gPanelOriginal.DrawImage(
					bitmapOriginal, new Point(0 ,0));

				//return if there is no modified image yet
				if (bitmapModified==null)
					return;

				//get Graphics object for painting modified
				Graphics gPanelModified = 
					Graphics.FromHwnd(
						panelModifiedImage.Handle);

				//draw modified bitmap into panel
				gPanelModified.DrawImage(
					bitmapModified, new Point(0 ,0));
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error drawing image." +
					ex.Message);
				this.Close( );
			}
		}

		private void buttonHideMessage_Click(
			object sender, System.EventArgs e)
		{
			try
			{
				//show wait cursor
				this.Cursor = Cursors.WaitCursor;

				//start off with copy of original image
				bitmapModified = new Bitmap(
					bitmapOriginal, 
					bitmapOriginal.Width, 
					bitmapOriginal.Height);

				//get original message to be hidden
				int numberbytes = 
					(byte)textBoxOriginalMessage.Text.Length;
				byte[] bytesOriginal = new byte[numberbytes+1];
				bytesOriginal[0] = (byte)numberbytes;
				Encoding.UTF8.GetBytes(
					textBoxOriginalMessage.Text,
					0,
					textBoxOriginalMessage.Text.Length,
					bytesOriginal,
					1);

				//set bits 1, 2, 3 of byte into LSB red
				//set bits 4, 5, 6 of byte into LSB green
				//set bits 7 and 8 of byte into LSB blue
				int byteCount = 0;
				for (int i=0; i<bitmapOriginal.Width; i++)
				{
					for (int j=0; j<bitmapOriginal.Height; j++)
					{
						if (bytesOriginal.Length==byteCount)
							return;

						Color clrPixelOriginal = 
							bitmapOriginal.GetPixel(i, j);
						byte r = 
							(byte)((clrPixelOriginal.R & ~0x7) |
							(bytesOriginal[byteCount]>>0)&0x7);
						byte g = 
							(byte)((clrPixelOriginal.G & ~0x7) |
							(bytesOriginal[byteCount]>>3)&0x7);
						byte b = 
							(byte)((clrPixelOriginal.B & ~0x3) |
							(bytesOriginal[byteCount]>>6)&0x3);
						byteCount++;

						//set pixel to modified color
						bitmapModified.SetPixel(
							i, j, Color.FromArgb(r, g, b));
					}

				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error hiding message." +
					ex.Message);
			}
			finally
			{
				//show normal cursor
				this.Cursor = Cursors.Arrow;

				//repaint
				Invalidate();
			}
		}

		private void buttonExtractMessage_Click(
			object sender, System.EventArgs e)
		{
			//get bytes of message from modified image
			byte[] bytesExtracted = new byte [256+1];
			try
			{
				//show wait cursor, can be time-consuming
				this.Cursor = Cursors.WaitCursor;
				
				//get bits 1, 2, 3 of byte from LSB red
				//get bits 4, 5, 6 of byte from LSB green
				//get bits 7 and 8 of byte from LSB blue
				int byteCount = 0;
				for (int i=0; i<bitmapModified.Width; i++)
				{
					for (int j=0; j<bitmapModified.Height; j++)
					{
						if (bytesExtracted.Length==byteCount)
							return;

						Color clrPixelModified = 
							bitmapModified.GetPixel(i, j);
						byte bits123 = 
							(byte)((clrPixelModified.R&0x7)<<0);
						byte bits456 = (
							byte)((clrPixelModified.G&0x7)<<3);
						byte bits78  = (
							byte)((clrPixelModified.B&0x3)<<6);
					
						bytesExtracted[byteCount] = 
							(byte)(bits78 |bits456 | bits123);
						byteCount++;
					}

				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error extracting message." +
					ex.Message);
			}
			finally
			{
				//show normal cursor
				this.Cursor = Cursors.Arrow;

				//get number of bytes from start of array
				int numberbytes = bytesExtracted[0];

				//get remaining bytes in array into string
				textBoxExtractedlMessage.Text =  
					Encoding.UTF8.GetString(
					bytesExtracted,
					1,
					numberbytes);
			}		
		}

		//shared private fields
		private Bitmap bitmapOriginal;
		private Bitmap bitmapModified;
	}
}
