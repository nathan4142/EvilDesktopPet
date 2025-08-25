namespace Quizzy
{
    partial class QuizzyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MenuStrip = new MenuStrip();
            studyTToolStripMenuItem = new ToolStripMenuItem();
            flashcardsToolStripMenuItem = new ToolStripMenuItem();
            writeToolStripMenuItem = new ToolStripMenuItem();
            testToolStripMenuItem = new ToolStripMenuItem();
            MenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // MenuStrip
            // 
            MenuStrip.Items.AddRange(new ToolStripItem[] { studyTToolStripMenuItem });
            MenuStrip.Location = new Point(0, 0);
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Size = new Size(800, 24);
            MenuStrip.TabIndex = 0;
            MenuStrip.Text = "menuStrip1";
            // 
            // studyTToolStripMenuItem
            // 
            studyTToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { flashcardsToolStripMenuItem, writeToolStripMenuItem, testToolStripMenuItem });
            studyTToolStripMenuItem.Name = "studyTToolStripMenuItem";
            studyTToolStripMenuItem.Size = new Size(76, 20);
            studyTToolStripMenuItem.Text = "Study Type";
            // 
            // flashcardsToolStripMenuItem
            // 
            flashcardsToolStripMenuItem.Name = "flashcardsToolStripMenuItem";
            flashcardsToolStripMenuItem.Size = new Size(180, 22);
            flashcardsToolStripMenuItem.Text = "Flashcards";
            flashcardsToolStripMenuItem.Click += flashcardsToolStripMenuItem_Click;
            // 
            // writeToolStripMenuItem
            // 
            writeToolStripMenuItem.Name = "writeToolStripMenuItem";
            writeToolStripMenuItem.Size = new Size(180, 22);
            writeToolStripMenuItem.Text = "Write";
            writeToolStripMenuItem.Click += writeToolStripMenuItem_Click;
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            testToolStripMenuItem.Size = new Size(180, 22);
            testToolStripMenuItem.Text = "Test";
            // 
            // QuizzyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(MenuStrip);
            MainMenuStrip = MenuStrip;
            Name = "QuizzyForm";
            Text = "QuizzyForm";
            MenuStrip.ResumeLayout(false);
            MenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MenuStrip;
        private ToolStripMenuItem studyTToolStripMenuItem;
        private ToolStripMenuItem flashcardsToolStripMenuItem;
        private ToolStripMenuItem writeToolStripMenuItem;
        private ToolStripMenuItem testToolStripMenuItem;
    }
}