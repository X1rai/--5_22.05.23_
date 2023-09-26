using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Артемьев.ЗД_5_22._05._23_
{
    public partial class Form1 : Form
    {
        Form2 fr2 = new Form2();
        string Nait, Zam;
        public Form1()
        {
            InitializeComponent();

        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fr2.openFileDialog1.ShowDialog();
            if (fr2.openFileDialog1.FileName == String.Empty) return;
           else
            {
                fr2.MdiParent = this;
                fr2.Size = new Size(810, 405);
                fr2.richTextBox1.LoadFile(fr2.openFileDialog1.FileName);
                fr2.Show();
            }
          
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            fr2.richTextBox1.Clear();
            fr2.openFileDialog1.FileName = @"";
            fr2.openFileDialog1.Filter = "Текстовые файлы (*.rtf)|*.rtf|All files (*.*)|*.*";
            fr2.saveFileDialog1.Filter = "Текстовые файлы (*.rtf)|*.rtf|All files (*.*)|*.*";
            toolStripComboBox1.Text = fr2.richTextBox1.Font.Name;
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
                fr2.saveFileDialog1.FileName = fr2.openFileDialog1.FileName;
            if (fr2.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fr2.richTextBox1.SaveFile(fr2.saveFileDialog1.FileName);
                }
                catch (Exception Ситуация)
                { 
                    MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fr2.saveFileDialog1.FileName = fr2.openFileDialog1.FileName;
            if (fr2.saveFileDialog1.FileName == String.Empty)
            {
                try 
                {
                    fr2.saveFileDialog1.ShowDialog();
                    fr2.saveFileDialog1.FileName = fr2.openFileDialog1.FileName;
                    fr2.richTextBox1.SaveFile(fr2.saveFileDialog1.FileName);
                }
                catch (Exception Ситуация)
                {
                    MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                fr2.saveFileDialog1.FileName = fr2.openFileDialog1.FileName;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void цветТекстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fr2.richTextBox1.SelectionLength > 0)
            {
                ColorDialog f = new ColorDialog();
                f.ShowDialog();
                fr2.richTextBox1.SelectionColor = f.Color;

            }

        }

        private void шрифтToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (fr2.richTextBox1.SelectionLength > 0)
            {
                FontDialog myFontDialog = new FontDialog();
                myFontDialog.ShowDialog();
                fr2.richTextBox1.SelectionFont = (myFontDialog.Font);
            }
        }

        private void цветФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fr2.richTextBox1.SelectionLength > 0)
            {
                ColorDialog f = new ColorDialog();
                f.ShowDialog ();
                fr2.richTextBox1.SelectionBackColor = (f.Color);
            }
        }

        private void поЦентруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fr2.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void поПрКраюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fr2.richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void поЛеКраюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fr2.richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработчик: Артемьев И.А\nДата начала 22.05.23\n Дата завершения 25.05.23");
        }

        private void toolStripComboBox2_TextChanged(object sender, EventArgs e)
        {
            Shir();
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            Shir();  
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }
        private void Shir()
        {
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            foreach (FontFamily fontFamily in installedFontCollection.Families)
            {
                toolStripComboBox1.Items.Add(fontFamily.Name);
            }



            int[] fontSizes = {8, 9, 10, 11, 12 , 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (int fontSize in fontSizes)
            {
                toolStripComboBox2.Items.Add(fontSize);
            }
            if(toolStripComboBox2.Text == "") 
            {
                fr2.richTextBox1.Font = new Font(toolStripComboBox1.Text, fr2.richTextBox1.Font.Size);
            }
            else
            fr2.richTextBox1.Font = new Font(toolStripComboBox1.Text, Convert.ToInt32(toolStripComboBox2.Text));

        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fr2.MdiParent = this;
            fr2.Size = new Size(800, 423);
            fr2.Show();
        }

        private void заменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(toolStripTextBox2.Text == "") { }
            else
            {
                StringBuilder sb = new StringBuilder(fr2.richTextBox1.Text);
                Zam = toolStripTextBox2.Text;
                for (int i = 0; i < sb.Length; i++)
                {
                    if (sb[i] == Convert.ToChar(Nait))
                    {
                        sb[i] = Convert.ToChar(Zam);
                    }
                   
                }
                fr2.richTextBox1.Text = sb.ToString();

            }
        }

        private void выделитьШрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fr2.richTextBox1.SelectAll();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fr2.saveFileDialog1.FileName = fr2.openFileDialog1.FileName;
            if (fr2.saveFileDialog1.FileName == String.Empty)
            {
                try
                {
                    fr2.saveFileDialog1.ShowDialog();
                    fr2.saveFileDialog1.FileName = fr2.openFileDialog1.FileName;
                    fr2.richTextBox1.SaveFile(fr2.saveFileDialog1.FileName);
                }
                catch (Exception Ситуация)
                {
                    MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                fr2.saveFileDialog1.FileName = fr2.openFileDialog1.FileName;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            fr2.saveFileDialog1.FileName = fr2.openFileDialog1.FileName;
            if (fr2.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fr2.richTextBox1.SaveFile(fr2.saveFileDialog1.FileName);
                }
                catch (Exception Ситуация)
                {
                    MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            fr2.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            fr2.richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            fr2.richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (fr2.richTextBox1.SelectionLength > 0)
            {
                Font font = new Font(fr2.richTextBox1.Font, fr2.richTextBox1.Font.Style | FontStyle.Underline);
                fr2.richTextBox1.SelectionFont = (font);
            }

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (fr2.richTextBox1.SelectionLength > 0)
            {
                Font font = new Font(fr2.richTextBox1.Font, fr2.richTextBox1.Font.Style | FontStyle.Bold);
                fr2.richTextBox1.SelectionFont = (font);
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (fr2.richTextBox1.SelectionLength > 0)
            {
                Font font = new Font(fr2.richTextBox1.Font, fr2.richTextBox1.Font.Style | FontStyle.Italic);
                fr2.richTextBox1.SelectionFont = (font);
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void всеЗаглавныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fr2.richTextBox1.Text = fr2.richTextBox1.Text.ToUpper();
        }

        private void всеПрописныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fr2.richTextBox1.Text = fr2.richTextBox1.Text.ToLower();
        }

        private void какВТекстеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fr2.richTextBox1.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(fr2.richTextBox1.Text);
        }

        private void найтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(toolStripTextBox1.Text == "") { }
            else
            Nait =  toolStripTextBox1.Text;

        }
    }
}
