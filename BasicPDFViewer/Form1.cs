using PdfiumViewer;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BasicPDFViewer
{
    public partial class PDFViewerBase : Form
    {
        DirectoryInfo directoryInfo;
        PdfDocument doc;
        ContextMenuStrip contextMenu;

        string rootPath;

        public PDFViewerBase()
        {
            InitializeComponent();

            string[] args = Environment.GetCommandLineArgs();

            this.pdfViewer1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pdfViewer1_KeyPress);
            this.pdfViewer1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pdfViewer1_MouseDown);
            this.pdfViewer1.MouseLeave += new System.EventHandler(this.pdfViewer1_MouseLeave);
            this.pdfViewer1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pdfViewer1_MouseMove);
            this.pdfViewer1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pdfViewer1_MouseUp);

            this.treeView1.MouseDown += treeList1_MouseDown;
            this.treeView1.MouseLeave += treeList1_MouseLeave;
            this.treeView1.MouseMove += treeList1_MouseMove;
            this.treeView1.MouseUp += treeList1_MouseUp;

            this.MouseClick += new MouseEventHandler(this.mouseclick_Text);

            this.KeyDown += new KeyEventHandler(PDFViewerBase_KeyDown);

            foreach (string a in args)
            {
                if (a.ToLower() == "R" || a.ToLower() == "reset")
                {
                    contextMenu_ResetRoot(null, null);
                }
            }


            rootPath = FileWriter.ReadFile(FileWriter.DEFAULT_PATH);

            //directory tree
            directoryInfo = new DirectoryInfo(rootPath);

            if (directoryInfo.Exists)
            {
                treeView1.AfterSelect += treeView1_AfterSelect;
                BuildTree(directoryInfo, treeView1.Nodes);
            }

            Disposed += (s, e) =>
            {
                var document = pdfViewer1.Document;
                if (document != null)
                    document.Dispose();
            };

            //context menu
            contextMenu = new ContextMenuStrip();

            contextMenu.Opening += new System.ComponentModel.CancelEventHandler(cms_Opening);


            treeView1.ContextMenuStrip = contextMenu;


        }


        #region DRAG_AND_DROP
        private bool dragDrop;
        
        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            base.OnDragDrop(drgevent);

            string file = (string)drgevent.Data.GetData(DataFormats.FileDrop);
            LoadPdf(file);

        }
        protected override void OnDragLeave(EventArgs e)
        {
            this.pdfViewer1.BackColor = Color.FromArgb(7, 7, 7);

            base.OnDragLeave(e);
        }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            this.pdfViewer1.BackColor = Color.FromArgb(25, 25, 25);
            drgevent.Effect = DragDropEffects.Move;

            base.OnDragEnter(drgevent);
        }
        #endregion

        private void mouseclick_Text(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("Test complete");
        }

        private void BuildNewDirectory(string path)
        {
            var dirInfo = new DirectoryInfo(path);
            if (dirInfo.Exists)
            {
                directoryInfo = dirInfo;
                RefreshDirectory();
            }
        }

        private void PDFViewerBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                RefreshDirectory();
            }

            if (e.KeyCode == Keys.O)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.InitialDirectory = directoryInfo.FullName;
                dialog.Filter = "PDF files|*.pdf";
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadPdf(dialog.FileName);
                }
            }

            if (e.KeyCode == Keys.T)
                TopMost = !TopMost;

        }

        private void RefreshDirectory()
        {
            treeView1.Nodes.Clear();
            BuildTree(directoryInfo, treeView1.Nodes);
        }

        private void cms_Opening(object sender, CancelEventArgs e)
        {
            Control c = contextMenu.SourceControl as Control;
            ToolStripDropDownItem tsi = contextMenu.OwnerItem as ToolStripDropDownItem;

            contextMenu.Items.Clear();

            var item = contextMenu.Items.Add("Change root directory...");
            item.Click += contextMenu_ClickTest;



            contextMenu.Items.Add("-");
            var item2 = contextMenu.Items.Add("Reset root directory");
            item2.Click += contextMenu_ResetRoot;

            e.Cancel = false;

        }

        private void contextMenu_ResetRoot(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            BuildNewDirectory(path);
            UpdateRootPath(path);
        }

        private void contextMenu_ClickTest(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.Description = "Choose folder";
            dialog.RootFolder = Environment.SpecialFolder.MyDocuments;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                BuildNewDirectory(dialog.SelectedPath);
                UpdateRootPath(dialog.SelectedPath);
            }
        }

        private void UpdateRootPath(string newPath) => rootPath = FileWriter.WriteFile(FileWriter.DEFAULT_PATH, newPath);

        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection nodes)
        {
            TreeNode curNode = nodes.Add(directoryInfo.Name);

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                if (file.Extension == ".pdf")
                {
                    curNode.Nodes.Add(file.FullName, file.Name);
                }
            }

            foreach (DirectoryInfo subDir in directoryInfo.GetDirectories())
            {
                BuildTree(subDir, curNode.Nodes);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name.EndsWith("pdf"))
            {
                string dir = directoryInfo.Parent.FullName;
                string path = dir + "/" + e.Node.FullPath;

                //this.doc = PdfDocument.Load(path);

                LoadPdf(path);

                GC.Collect();
            }
        }

        private void LoadPdf(string path)
        {
            this.pdfViewer1.Document = PdfDocument.Load(new MemoryStream(File.ReadAllBytes(path)));
            this.button2.Visible = true;
        }

        #region MOUSE_MOVEMENT

        private bool mouseDown;
        private Point lastLocation;
        private bool resizing;
        private void pdfViewer1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mouseDown = true;
                lastLocation = e.Location;
            }
            else if (e.Button == MouseButtons.Middle)
            {
                resizing = true;
                lastLocation = e.Location;
            }
        }

        private void pdfViewer1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }

            if (resizing)
            {
                this.Size += new Size(e.X - lastLocation.X, e.Y - lastLocation.Y);

                lastLocation = e.Location;

                this.pdfViewer1.Size = this.Size;

                this.Update();
            }
        }

        private void pdfViewer1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            resizing = false;
        }

        private void pdfViewer1_MouseLeave(object sender, EventArgs e)
        {
            mouseDown = false;
            resizing = false;
        }

        private void treeList1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mouseDown = true;
                lastLocation = e.Location;
            }
            else if (e.Button == MouseButtons.Middle)
            {
                resizing = true;
                lastLocation = e.Location;
            }
        }

        private void treeList1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }

            if (resizing)
            {
                this.Size += new Size(e.X - lastLocation.X, e.Y - lastLocation.Y);

                lastLocation = e.Location;

                this.pdfViewer1.Size = this.Size;

                this.Update();
            }
        }

        private void treeList1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            resizing = false;
        }

        private void treeList1_MouseLeave(object sender, EventArgs e)
        {
            mouseDown = false;
            resizing = false;
        }
        #endregion

        private void pdfViewer1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel1Collapsed = !this.splitContainer1.Panel1Collapsed;

            if (this.splitContainer1.Panel1Collapsed)
                button1.BackgroundImage = Properties.Resources.Arrow_Right_Filled_Circle_b3965f;
            else
                button1.BackgroundImage = Properties.Resources.Arrow_Left_Filled_Circle_b3965f;

            
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Debug.WriteLine("MOUSE DOWN LOGGED");
            Console.WriteLine("Mouse logged");
            base.OnMouseDown(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.pdfViewer1.ShowBookmarks = !this.pdfViewer1.ShowBookmarks;
        }
    }
}
