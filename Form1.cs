using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_Editor_YT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = Clipboard.GetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
            richTextBox2.Text = Clipboard.GetText();
            richTextBox1.Text = " ";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
        }
        int start = 0;
        int indexOfSearchText = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            int startindex = 0;

            if (textBox1.Text.Length > 0)
                startindex = FindMyText(textBox1.Text.Trim(), start, richTextBox1.Text.Length);

            // If string was found in the RichTextBox, highlight it
            if (startindex >= 0)
            {
                // Set the highlight color as red
                richTextBox1.SelectionColor = Color.Red;
                // Find the end index. End Index = number of characters in textbox
                int endindex = textBox1.Text.Length;
                // Highlight the search string
                richTextBox1.Select(startindex, endindex);
                // mark the start position after the position of
                // last search string
                start = startindex + endindex;
            }
            
        }
       
        public int FindMyText(string txtToSearch, int searchStart, int searchEnd)
        {
            // Unselect the previously searched string
            if (searchStart > 0 && searchEnd > 0 && indexOfSearchText >= 0)
            {
                richTextBox1.Undo();
            }

            // Set the return value to -1 by default.
            int retVal = -1;

            // A valid starting index should be specified.
            // if indexOfSearchText = -1, the end of search
            if (searchStart >= 0 && indexOfSearchText >= 0)
            {
                // A valid ending index
                if (searchEnd > searchStart || searchEnd == -1)
                {
                    // Find the position of search string in RichTextBox
                    indexOfSearchText = richTextBox1.Find(txtToSearch, searchStart, searchEnd, RichTextBoxFinds.None);
                    // Determine whether the text was found in richTextBox1.
                    if (indexOfSearchText != -1)
                    {
                        // Return the index to the specified search text.
                        retVal = indexOfSearchText;
                    }

                }

            }
            return retVal;
        }

        // Reset the richtextbox when user changes the search string
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            start = 0;
            indexOfSearchText = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            float size = Convert.ToSingle(((ComboBox)sender).Text);

            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, size);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (comboBox2.SelectedIndex == 0)
            {
                richTextBox1.ForeColor = Color.Red;
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                richTextBox1.ForeColor = Color.Blue;
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                richTextBox1.ForeColor = Color.Green;
            }
            else if (comboBox2.SelectedIndex == 3)
            {
                richTextBox1.ForeColor = Color.Yellow;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text.ToUpper();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text.ToLower();
        }

        private void button8_Click(object sender, EventArgs e)
        {
          
            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Italic)
            {
                style &= ~FontStyle.Italic;
            }
            else
            {
                style |= FontStyle.Italic;
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Italic)
            {
                style &= ~FontStyle.Bold;
            }
            else
            {
                style |= FontStyle.Bold;
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Italic)
            {
                style &= ~FontStyle.Underline;
            }
            else
            {
                style |= FontStyle.Underline;
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        
        }

      
    }
}

