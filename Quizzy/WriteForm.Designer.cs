namespace Quizzy
{
    partial class WriteForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            TermLabel = new Label();
            userInputTextBox = new TextBox();
            CorrectDefinitionTextBox = new RichTextBox();
            NumDoneLabel = new Label();
            Next_Bttn = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(TermLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(userInputTextBox, 0, 1);
            tableLayoutPanel1.Controls.Add(CorrectDefinitionTextBox, 0, 2);
            tableLayoutPanel1.Location = new Point(98, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.4641132F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 44.52055F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 38.356163F));
            tableLayoutPanel1.Size = new Size(346, 292);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // TermLabel
            // 
            TermLabel.Anchor = AnchorStyles.None;
            TermLabel.AutoSize = true;
            TermLabel.Font = new Font("Segoe UI", 25F);
            TermLabel.Location = new Point(136, 2);
            TermLabel.Name = "TermLabel";
            TermLabel.Size = new Size(74, 46);
            TermLabel.TabIndex = 1;
            TermLabel.Text = "null";
            // 
            // userInputTextBox
            // 
            userInputTextBox.Location = new Point(3, 53);
            userInputTextBox.Multiline = true;
            userInputTextBox.Name = "userInputTextBox";
            userInputTextBox.Size = new Size(340, 123);
            userInputTextBox.TabIndex = 2;
            userInputTextBox.KeyDown += CheckAnswer;
            // 
            // CorrectDefinitionTextBox
            // 
            CorrectDefinitionTextBox.Dock = DockStyle.Fill;
            CorrectDefinitionTextBox.Location = new Point(3, 182);
            CorrectDefinitionTextBox.Name = "CorrectDefinitionTextBox";
            CorrectDefinitionTextBox.ReadOnly = true;
            CorrectDefinitionTextBox.Size = new Size(340, 107);
            CorrectDefinitionTextBox.TabIndex = 3;
            CorrectDefinitionTextBox.Text = "";
            // 
            // NumDoneLabel
            // 
            NumDoneLabel.AutoSize = true;
            NumDoneLabel.Font = new Font("Segoe UI", 20F);
            NumDoneLabel.Location = new Point(235, 307);
            NumDoneLabel.Name = "NumDoneLabel";
            NumDoneLabel.Size = new Size(61, 37);
            NumDoneLabel.TabIndex = 1;
            NumDoneLabel.Text = "null";
            // 
            // Next_Bttn
            // 
            Next_Bttn.Location = new Point(369, 321);
            Next_Bttn.Name = "Next_Bttn";
            Next_Bttn.Size = new Size(75, 23);
            Next_Bttn.TabIndex = 2;
            Next_Bttn.Text = "->";
            Next_Bttn.UseVisualStyleBackColor = true;
            Next_Bttn.Click += Next_Bttn_Click;
            // 
            // WriteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Next_Bttn);
            Controls.Add(NumDoneLabel);
            Controls.Add(tableLayoutPanel1);
            Name = "WriteForm";
            Text = "WriteForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label TermLabel;
        private TextBox userInputTextBox;
        private Label NumDoneLabel;
        private RichTextBox CorrectDefinitionTextBox;
        private Button Next_Bttn;
    }
}