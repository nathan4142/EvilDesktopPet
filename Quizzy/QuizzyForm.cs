using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizzy
{
    public partial class QuizzyForm : Form
    {
        public QuizzyForm()
        {
            InitializeComponent();
        }

        private void flashcardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlashCardsForm f = new FlashCardsForm();
            f.FormClosed += (s, args) => this.Show();
            f.Show();
            this.Hide();
        }

        private void writeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WriteForm w = new WriteForm();
            w.FormClosed += (s, args) => this.Show();
            w.Show();
            this.Hide();
        }
    }
}
