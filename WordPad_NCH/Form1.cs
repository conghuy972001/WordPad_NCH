using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WordPad_NCH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textWord.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Open my new File";
            of.Filter = " Text Files (*.docx)|*.docx|All Files (*.*)|*.*";
            if (of.ShowDialog() == DialogResult.OK)
                textWord.LoadFile(of.FileName, RichTextBoxStreamType.PlainText);
            this.Text = of.FileName;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Save my new File";
            sf.Filter = " Text Files (*.docx)|*.docx|All Files (*.*)|*.*";
            if (sf.ShowDialog() == DialogResult.OK)
                textWord.SaveFile(sf.FileName, RichTextBoxStreamType.PlainText);
            this.Text = sf.FileName;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //colorDialog1.ShowDialog();
            ColorDialog cld = new ColorDialog();
            cld.Color = textWord.ForeColor;
            cld.ShowDialog();
            textWord.ForeColor = cld.Color;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = textWord.Font;
            fd.ShowDialog();
            textWord.Font = fd.Font;
        }

        Image i;
        Bitmap b;
        private void insertImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog img = new OpenFileDialog();

            img.Title = "Insert new Image";
            img.Filter = " Image Files (*.png)|*.png|All Files (*.*)|*.*";
                if (img.ShowDialog() == DialogResult.OK)
            {
                createImage(img.FileName);
            } 
        }
        private void createImage(string name)
        {
            Clipboard.SetImage(Image.FromFile(name));
            textWord.Paste();
        }
    }
}
