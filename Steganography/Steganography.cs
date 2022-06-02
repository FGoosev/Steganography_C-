using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using AsymmetricEncryption;
using EncryptionCompare;
using System.IO;
using System.Security.Cryptography;
using System.Linq;

namespace Steganography
{
	/// <summary>
	/// Summary description for SteganographyForm.
	/// </summary>
	public class SteganographyForm : Form
	{
		private Button buttonHideMessage;
		private Panel panelOriginalImage;
		private TextBox textBoxOriginalMessage;
		private Panel panelModifiedImage;
		private GroupBox groupBox1;
		private GroupBox groupBox3;
		private GroupBox groupBox4;
		private Button buttonExtractMessage;
		private TextBox textBoxExtractedlMessage;
		private GroupBox groupBox2;
        private Button buttonLoadImage;
        private Button buttonSaveModifiedImage;

		private Bitmap bitmapOriginal;
		private Bitmap bitmapModified;
        private Button buttonLoadFile;
        private Label labelFileName;

        
        private Label labelPassword;
        private TextBox textBoxPassword;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        private byte[] file_content_bytes;
        private TextBox textBoxEncryptedOriginalMessage;
        private TextBox textBoxExtractedEncryptedMessage;
        private Algorithm sa;

        public SteganographyForm()
		{
			InitializeComponent();
            sa = new Algorithm(Rijndael.Create(), "Rijndael");
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
            this.textBoxEncryptedOriginalMessage = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonExtractMessage = new System.Windows.Forms.Button();
            this.textBoxExtractedlMessage = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxExtractedEncryptedMessage = new System.Windows.Forms.TextBox();
            this.buttonLoadImage = new System.Windows.Forms.Button();
            this.buttonSaveModifiedImage = new System.Windows.Forms.Button();
            this.buttonLoadFile = new System.Windows.Forms.Button();
            this.labelFileName = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonHideMessage
            // 
            this.buttonHideMessage.Location = new System.Drawing.Point(150, 651);
            this.buttonHideMessage.Name = "buttonHideMessage";
            this.buttonHideMessage.Size = new System.Drawing.Size(120, 25);
            this.buttonHideMessage.TabIndex = 0;
            this.buttonHideMessage.Text = "Hide Message";
            this.buttonHideMessage.Click += new System.EventHandler(this.buttonHideMessage_Click);
            // 
            // panelOriginalImage
            // 
            this.panelOriginalImage.Location = new System.Drawing.Point(16, 24);
            this.panelOriginalImage.Name = "panelOriginalImage";
            this.panelOriginalImage.Size = new System.Drawing.Size(417, 290);
            this.panelOriginalImage.TabIndex = 0;
            // 
            // textBoxOriginalMessage
            // 
            this.textBoxOriginalMessage.Location = new System.Drawing.Point(8, 19);
            this.textBoxOriginalMessage.Multiline = true;
            this.textBoxOriginalMessage.Name = "textBoxOriginalMessage";
            this.textBoxOriginalMessage.Size = new System.Drawing.Size(411, 129);
            this.textBoxOriginalMessage.TabIndex = 1;
            this.textBoxOriginalMessage.TextChanged += new System.EventHandler(this.textBoxOriginalMessage_TextChanged);
            // 
            // panelModifiedImage
            // 
            this.panelModifiedImage.Location = new System.Drawing.Point(11, 16);
            this.panelModifiedImage.Name = "panelModifiedImage";
            this.panelModifiedImage.Size = new System.Drawing.Size(417, 290);
            this.panelModifiedImage.TabIndex = 0;
            this.panelModifiedImage.Paint += new System.Windows.Forms.PaintEventHandler(this.panelModifiedImage_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxOriginalMessage);
            this.groupBox1.Controls.Add(this.textBoxEncryptedOriginalMessage);
            this.groupBox1.Location = new System.Drawing.Point(8, 427);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 198);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Original Message";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textBoxEncryptedOriginalMessage
            // 
            this.textBoxEncryptedOriginalMessage.Location = new System.Drawing.Point(8, 153);
            this.textBoxEncryptedOriginalMessage.Multiline = true;
            this.textBoxEncryptedOriginalMessage.Name = "textBoxEncryptedOriginalMessage";
            this.textBoxEncryptedOriginalMessage.Size = new System.Drawing.Size(411, 35);
            this.textBoxEncryptedOriginalMessage.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(8, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(438, 322);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Original Image";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panelModifiedImage);
            this.groupBox4.Location = new System.Drawing.Point(453, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(438, 322);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Modified Image";
            // 
            // buttonExtractMessage
            // 
            this.buttonExtractMessage.Location = new System.Drawing.Point(613, 651);
            this.buttonExtractMessage.Name = "buttonExtractMessage";
            this.buttonExtractMessage.Size = new System.Drawing.Size(120, 25);
            this.buttonExtractMessage.TabIndex = 2;
            this.buttonExtractMessage.Text = "Extract Message";
            this.buttonExtractMessage.Click += new System.EventHandler(this.buttonExtractMessage_Click);
            // 
            // textBoxExtractedlMessage
            // 
            this.textBoxExtractedlMessage.Location = new System.Drawing.Point(10, 65);
            this.textBoxExtractedlMessage.Multiline = true;
            this.textBoxExtractedlMessage.Name = "textBoxExtractedlMessage";
            this.textBoxExtractedlMessage.ReadOnly = true;
            this.textBoxExtractedlMessage.Size = new System.Drawing.Size(417, 120);
            this.textBoxExtractedlMessage.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxExtractedlMessage);
            this.groupBox2.Controls.Add(this.textBoxExtractedEncryptedMessage);
            this.groupBox2.Location = new System.Drawing.Point(454, 427);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(438, 198);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Extracted Message";
            // 
            // textBoxExtractedEncryptedMessage
            // 
            this.textBoxExtractedEncryptedMessage.Location = new System.Drawing.Point(11, 24);
            this.textBoxExtractedEncryptedMessage.Multiline = true;
            this.textBoxExtractedEncryptedMessage.Name = "textBoxExtractedEncryptedMessage";
            this.textBoxExtractedEncryptedMessage.ReadOnly = true;
            this.textBoxExtractedEncryptedMessage.Size = new System.Drawing.Size(417, 35);
            this.textBoxExtractedEncryptedMessage.TabIndex = 10;
            // 
            // buttonLoadImage
            // 
            this.buttonLoadImage.Location = new System.Drawing.Point(10, 336);
            this.buttonLoadImage.Name = "buttonLoadImage";
            this.buttonLoadImage.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadImage.TabIndex = 4;
            this.buttonLoadImage.Text = "Load Image";
            this.buttonLoadImage.UseVisualStyleBackColor = true;
            this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
            // 
            // buttonSaveModifiedImage
            // 
            this.buttonSaveModifiedImage.Location = new System.Drawing.Point(453, 336);
            this.buttonSaveModifiedImage.Name = "buttonSaveModifiedImage";
            this.buttonSaveModifiedImage.Size = new System.Drawing.Size(117, 23);
            this.buttonSaveModifiedImage.TabIndex = 5;
            this.buttonSaveModifiedImage.Text = "Save Modified Image";
            this.buttonSaveModifiedImage.UseVisualStyleBackColor = true;
            this.buttonSaveModifiedImage.Click += new System.EventHandler(this.buttonSaveModifiedImage_Click);
            // 
            // buttonLoadFile
            // 
            this.buttonLoadFile.Location = new System.Drawing.Point(91, 336);
            this.buttonLoadFile.Name = "buttonLoadFile";
            this.buttonLoadFile.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadFile.TabIndex = 6;
            this.buttonLoadFile.Text = "Load File";
            this.buttonLoadFile.UseVisualStyleBackColor = true;
            this.buttonLoadFile.Click += new System.EventHandler(this.buttonLoadFile_Click);
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(172, 341);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(0, 13);
            this.labelFileName.TabIndex = 7;
            this.labelFileName.Click += new System.EventHandler(this.labelFileName_Click);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(12, 387);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 8;
            this.labelPassword.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(71, 384);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(178, 20);
            this.textBoxPassword.TabIndex = 9;
            // 
            // SteganographyForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(901, 730);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.buttonLoadFile);
            this.Controls.Add(this.buttonSaveModifiedImage);
            this.Controls.Add(this.buttonLoadImage);
            this.Controls.Add(this.buttonHideMessage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelOriginalImage);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.buttonExtractMessage);
            this.Controls.Add(this.groupBox2);
            this.Name = "SteganographyForm";
            this.Text = "Steganography";
            this.Load += new System.EventHandler(this.SteganographyForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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

		private void SteganographyForm_Paint(object sender, PaintEventArgs e)
		{
			if (bitmapModified==null) return;	
			Graphics gPanelModified = Graphics.FromHwnd(panelModifiedImage.Handle);
			gPanelModified.DrawImage(bitmapModified, new Point(0 ,0));	
		}
        
        private byte[] Encrypt(byte[] message_bytes)
        {
            string password = "123456";
            if (textBoxPassword.Text.Length != 0) password = textBoxPassword.Text;

            byte[] bytesPassword = Encoding.UTF8.GetBytes(password);
            SHA256 sha256 = new SHA256CryptoServiceProvider();
            byte[] hashbytesPassword = sha256.ComputeHash(bytesPassword);

            sa.SetCipherMode(CipherMode.ECB);
            sa.InitKey(hashbytesPassword);

            return sa.Encryption(message_bytes);
        }
        private byte[] Decrypt(byte[] cyphermessage_bytes) => sa.Decryption(cyphermessage_bytes);
       
        private void buttonHideMessage_Click(object sender, EventArgs e)
		{

            byte[] cypherbytesOriginal = Encrypt(Encoding.UTF8.GetBytes(textBoxOriginalMessage.Text));
            
            
            string cyphermessageOriginal = Encoding.UTF8.GetString(cypherbytesOriginal);
            textBoxEncryptedOriginalMessage.Text = Encoding.UTF8.GetString(cypherbytesOriginal);

            try
			{
				//show wait cursor
				this.Cursor = Cursors.WaitCursor;

				//start off with copy of original image
				bitmapModified = new Bitmap(bitmapOriginal, bitmapOriginal.Width, bitmapOriginal.Height);

				//get original message to be hidden
				int numberbytes = (byte)cyphermessageOriginal.Length*2;
				byte[] bytesOriginal = new byte[numberbytes+1];
				bytesOriginal[0] = (byte)numberbytes;
				Encoding.UTF8.GetBytes(
                    cyphermessageOriginal,
					0,
                    cyphermessageOriginal.Length,
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
						bitmapModified.SetPixel(i, j, Color.FromArgb(r, g, b));
					}

				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error hiding message." + ex.Message);
			}
			finally
			{
				//show normal cursor
				Cursor = Cursors.Arrow;
				//repaint
				Invalidate();
			}
		}

		private void buttonExtractMessage_Click(object sender, EventArgs e)
		{
			//get bytes of message from modified image
			byte[] bytesExtracted = new byte [256];
			try
			{
				//show wait cursor, can be time-consuming
				Cursor = Cursors.WaitCursor;
				
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

						Color clrPixelModified = bitmapModified.GetPixel(i, j);
						byte bits123 = (byte) ((clrPixelModified.R&0x7)<<0);
						byte bits456 = (byte) ((clrPixelModified.G&0x7)<<3);
						byte bits78  = (byte) ((clrPixelModified.B&0x3)<<6);
					
						bytesExtracted[byteCount] = (byte)(bits78 |bits456 | bits123);
						byteCount++;
					}

				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error extracting message." + ex.Message);
			}
			finally
			{	
				Cursor = Cursors.Arrow;     
                int numberbytes = bytesExtracted[0];
                string ExtractedEncryptedMessage = Encoding.UTF8.GetString(bytesExtracted, 1, numberbytes);

                byte[] cypherbytes = bytesExtracted.Skip(1).ToArray();
                string ExtractedMessage = Encoding.UTF8.GetString(sa.Decryption(bytesExtracted));
              
                textBoxExtractedEncryptedMessage.Text = ExtractedEncryptedMessage;
                textBoxExtractedlMessage.Text = ExtractedMessage;        
            }		
		}
        public string ToStr<T>(T[] arr)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var a in arr)
            {
                sb.Append(a + " ");
            }
            return sb.ToString();
        }
        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
			try
			{
                string path = FileOperations.GetPathFileRead();
				//load original bitmap from a file
				bitmapOriginal = (Bitmap)Bitmap.FromFile(path);

				//center to screen
				//CenterToScreen();
				Paint += new PaintEventHandler(SteganographyForm_Paint);
				
				Graphics gPanelOriginal = Graphics.FromHwnd(panelOriginalImage.Handle);
				gPanelOriginal.DrawImage(bitmapOriginal, new Point(0, 0));
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error loading image. " +
					ex.Message);
			}
			
		}

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
			string path = FileOperations.GetPathFileRead();
            file_content_bytes = FileOperations.GetFileContentByte(path);
			labelFileName.Text = path;
			textBoxOriginalMessage.Text = Encoding.UTF8.GetString(file_content_bytes);
			
		}

        private void textBoxOriginalMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSaveModifiedImage_Click(object sender, EventArgs e)
        {
			string path = FileOperations.GetPathFileWrite();
			bitmapModified.Save(path);
		}

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void labelFileName_Click(object sender, EventArgs e)
        {

        }

        private void SteganographyForm_Load(object sender, EventArgs e)
        {

        }

        private void panelModifiedImage_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
