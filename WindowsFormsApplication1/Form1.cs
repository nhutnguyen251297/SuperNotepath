﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace WindowsFormsApplication1
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void tSCBSize_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 120; i++)
            {
                tSCBSize.Items.Add(i);
            }
            InstalledFontCollection listFont = new InstalledFontCollection();
            int c=0, j = 0;
            foreach (FontFamily font in listFont.Families)
            {
                tSCBFont.Items.Add(font.Name);
            }
        }

        private void tSCBFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            FontFamily fa = new FontFamily(tSCBFont.Text);
            Font f = new System.Drawing.Font(fa, float.Parse(tSCBSize.Text));
            if (rTBMain.SelectedText.Length > 0)
                rTBMain.SelectionFont = f;
        }

        private void tSCBSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            FontFamily fa = new FontFamily(tSCBFont.Text);
            Font f = new System.Drawing.Font(fa, float.Parse(tSCBSize.Text));
            if (rTBMain.SelectedText.Length > 0)
                rTBMain.SelectionFont = f;
        }

        private void tSBtnBold_Click(object sender, EventArgs e)
        {

            if (rTBMain.SelectedText.Length > 0)
            {
                if (this.tSBtnBold.Checked == true)
                {
                    FontStyle style = rTBMain.SelectionFont.Style;
                    style = style | FontStyle.Bold;
                    Font f = new System.Drawing.Font(new FontFamily(tSCBFont.Text), float.Parse(tSCBSize.Text), style);
                    rTBMain.SelectionFont = f;
                }
                else
                {
                    FontStyle style = rTBMain.SelectionFont.Style;
                    style = style ^ FontStyle.Bold;
                    Font f = new System.Drawing.Font(new FontFamily(tSCBFont.Text), float.Parse(tSCBSize.Text), style);
                    rTBMain.SelectionFont = f;
                }
            }
        }

        private void tSBtnItalic_Click(object sender, EventArgs e)
        {
            if (rTBMain.SelectedText.Length > 0)
            {
                if (this.tSBtnItalic.Checked == true)
                {
                    FontStyle style = rTBMain.SelectionFont.Style;
                    style = style | FontStyle.Italic;
                    Font f = new System.Drawing.Font(new FontFamily(tSCBFont.Text), float.Parse(tSCBSize.Text), style);
                    rTBMain.SelectionFont = f;
                }
                else
                {
                    FontStyle style = rTBMain.SelectionFont.Style;
                    style = style ^ FontStyle.Italic;
                    Font f = new System.Drawing.Font(new FontFamily(tSCBFont.Text), float.Parse(tSCBSize.Text), style);
                    rTBMain.SelectionFont = f;
                }
            }
        }

        private void tSBtnUnderline_Click(object sender, EventArgs e)
        {
            if (rTBMain.SelectedText.Length > 0)
            {
                if (this.tSBtnUnderline.Checked == true)
                {
                    FontStyle style = rTBMain.SelectionFont.Style;
                    style = style | FontStyle.Underline;
                    Font f = new System.Drawing.Font(new FontFamily(tSCBFont.Text), float.Parse(tSCBSize.Text), style);
                    rTBMain.SelectionFont = f;
                }
                else
                {
                    FontStyle style = rTBMain.SelectionFont.Style;
                    style = style ^ FontStyle.Underline;
                    Font f = new System.Drawing.Font(new FontFamily(tSCBFont.Text), float.Parse(tSCBSize.Text), style);
                    rTBMain.SelectionFont = f;
                }
            }
        }

        private void tSBtnTextColor_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                rTBMain.SelectionColor = colorDialog1.Color;
            }

        }

        private void tSBtnBackgroundColor_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                rTBMain.BackColor = colorDialog1.Color;
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rTBMain.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rTBMain.Redo();
        }

        private void tSBtnUndo_Click(object sender, EventArgs e)
        {
            undoToolStripMenuItem.PerformClick();
        }

        private void tSBtnRedo_Click(object sender, EventArgs e)
        {
            redoToolStripMenuItem.PerformClick();
        }

       

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult da;

            da = MessageBox.Show("Do you want to save changes to Note?", "SuperNotepath", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (da == DialogResult.Yes)
            {
                tSBtnSave_Click(sender, e);
                rTBMain.Clear();
            }
            if (da == DialogResult.No)
            {
                rTBMain.Clear();
            }
        }
        private void tSBtnNew_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem.PerformClick();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog Open = new OpenFileDialog();
            Open.Filter = ".doc|*.doc| .txt| *.txt";
            Open.RestoreDirectory = true;
            if (Open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rTBMain.LoadFile(Open.FileName, RichTextBoxStreamType.PlainText);
            }
        }
        private void tSBtnOpen_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem.PerformClick();
        }

        private void tSBtnSave_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem.PerformClick();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog Save = new SaveFileDialog();
            Save.RestoreDirectory = true;
            Save.Filter = ".txt| *.txt| .doc| *.doc";
            if (Save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rTBMain.SaveFile(Save.FileName);
            }
        }

        private void tSBtnCopy_Click(object sender, EventArgs e)
        {

        }

        private void tSBtnPaste_Click(object sender, EventArgs e)
        {

        }

        private void tSBtnPinNote_Click(object sender, EventArgs e)
        {

        }
    }
}
