using System.Windows.Forms;

namespace BasicPDFViewer
{
    partial class PDFViewerBase
    {

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDFViewerBase));
            pdfViewer1 = new PdfiumViewer.PdfViewer();
            button1 = new Button();
            treeView1 = new TreeView();
            splitContainer1 = new SplitContainer();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // pdfViewer1
            // 
            pdfViewer1.AllowDrop = true;
            pdfViewer1.BackColor = System.Drawing.Color.FromArgb(7, 7, 7);
            pdfViewer1.Dock = DockStyle.Fill;
            pdfViewer1.Location = new System.Drawing.Point(0, 0);
            pdfViewer1.Margin = new Padding(4, 3, 4, 3);
            pdfViewer1.Name = "pdfViewer1";
            pdfViewer1.ShowToolbar = false;
            pdfViewer1.Size = new System.Drawing.Size(734, 638);
            pdfViewer1.TabIndex = 1;
            pdfViewer1.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitWidth;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.Transparent;
            button1.BackgroundImage = Properties.Resources.Arrow_Left_Filled_Circle_b3965f;
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveBorder;
            button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveBorder;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new System.Drawing.Point(8, 12);
            button1.Margin = new Padding(6, 3, 6, 3);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(32, 32);
            button1.TabIndex = 3;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // treeView1
            // 
            treeView1.BackColor = System.Drawing.Color.FromArgb(13, 13, 13);
            treeView1.Dock = DockStyle.Fill;
            treeView1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeView1.ForeColor = System.Drawing.Color.FromArgb(74, 84, 74);
            treeView1.HideSelection = false;
            treeView1.LineColor = System.Drawing.Color.Gray;
            treeView1.Location = new System.Drawing.Point(0, 0);
            treeView1.Margin = new Padding(6, 3, 6, 3);
            treeView1.Name = "treeView1";
            treeView1.Size = new System.Drawing.Size(368, 638);
            treeView1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeView1);
            splitContainer1.Panel1MinSize = 50;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Panel2.Controls.Add(button1);
            splitContainer1.Panel2.Controls.Add(pdfViewer1);
            splitContainer1.Panel2MinSize = 50;
            splitContainer1.Size = new System.Drawing.Size(1106, 638);
            splitContainer1.SplitterDistance = 368;
            splitContainer1.TabIndex = 4;
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.Color.Transparent;
            button2.BackgroundImage = Properties.Resources.Bookmark_Icon_b3965f;
            button2.BackgroundImageLayout = ImageLayout.Zoom;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            button2.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveBorder;
            button2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveBorder;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new System.Drawing.Point(8, 50);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(32, 32);
            button2.TabIndex = 4;
            button2.UseVisualStyleBackColor = false;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // PDFViewerBase
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(7, 7, 7);
            ClientSize = new System.Drawing.Size(1106, 638);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(200, 300);
            Name = "PDFViewerBase";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PDF Viewer";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }


        #endregion
        private PdfiumViewer.PdfViewer pdfViewer1;
        private Button button1;
        private TreeView treeView1;
        private SplitContainer splitContainer1;
        private Button button2;
    }
}

