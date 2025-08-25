namespace Quizzy
{
    partial class FlashCardsForm
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
            AddFlashCard_Bttn = new Button();
            FlashCardLeft_Bttn = new Button();
            FlashCardRight_Bttn = new Button();
            Flip_Bttn = new Button();
            TermOrDefLabel = new Label();
            TermDefLabel = new Label();
            Reset_Bttn = new Button();
            CurrentCardLabel = new Label();
            FlashCardContainer = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            FlashCardContainer.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // AddFlashCard_Bttn
            // 
            AddFlashCard_Bttn.Location = new Point(686, 415);
            AddFlashCard_Bttn.Name = "AddFlashCard_Bttn";
            AddFlashCard_Bttn.Size = new Size(102, 23);
            AddFlashCard_Bttn.TabIndex = 0;
            AddFlashCard_Bttn.Text = "Add Flash Card";
            AddFlashCard_Bttn.UseVisualStyleBackColor = true;
            AddFlashCard_Bttn.Click += AddFlashCard_Bttn_Click;
            // 
            // FlashCardLeft_Bttn
            // 
            FlashCardLeft_Bttn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            FlashCardLeft_Bttn.Location = new Point(3, 3);
            FlashCardLeft_Bttn.Name = "FlashCardLeft_Bttn";
            FlashCardLeft_Bttn.Size = new Size(75, 25);
            FlashCardLeft_Bttn.TabIndex = 2;
            FlashCardLeft_Bttn.Text = "<-";
            FlashCardLeft_Bttn.UseVisualStyleBackColor = true;
            FlashCardLeft_Bttn.Click += FlashCardLeft_Bttn_Click;
            // 
            // FlashCardRight_Bttn
            // 
            FlashCardRight_Bttn.Location = new Point(190, 3);
            FlashCardRight_Bttn.Name = "FlashCardRight_Bttn";
            FlashCardRight_Bttn.Size = new Size(75, 25);
            FlashCardRight_Bttn.TabIndex = 3;
            FlashCardRight_Bttn.Text = "->";
            FlashCardRight_Bttn.UseVisualStyleBackColor = true;
            FlashCardRight_Bttn.Click += FlashCardRight_Bttn_Click;
            // 
            // Flip_Bttn
            // 
            Flip_Bttn.Anchor = AnchorStyles.None;
            Flip_Bttn.Location = new Point(84, 4);
            Flip_Bttn.Name = "Flip_Bttn";
            Flip_Bttn.Size = new Size(100, 23);
            Flip_Bttn.TabIndex = 4;
            Flip_Bttn.Text = "Flip";
            Flip_Bttn.UseVisualStyleBackColor = true;
            Flip_Bttn.Click += Flip_Bttn_Click;
            // 
            // TermOrDefLabel
            // 
            TermOrDefLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TermOrDefLabel.AutoSize = true;
            TermOrDefLabel.Font = new Font("Segoe UI", 27F);
            TermOrDefLabel.Location = new Point(3, 0);
            TermOrDefLabel.Name = "TermOrDefLabel";
            TermOrDefLabel.Size = new Size(281, 51);
            TermOrDefLabel.TabIndex = 1;
            TermOrDefLabel.Text = "Term";
            TermOrDefLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // TermDefLabel
            // 
            TermDefLabel.Anchor = AnchorStyles.None;
            TermDefLabel.AutoSize = true;
            TermDefLabel.Font = new Font("Segoe UI", 25F);
            TermDefLabel.Location = new Point(103, 117);
            TermDefLabel.Name = "TermDefLabel";
            TermDefLabel.Size = new Size(80, 46);
            TermDefLabel.TabIndex = 0;
            TermDefLabel.Text = "Null";
            TermDefLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // Reset_Bttn
            // 
            Reset_Bttn.Location = new Point(532, 415);
            Reset_Bttn.Name = "Reset_Bttn";
            Reset_Bttn.Size = new Size(111, 23);
            Reset_Bttn.TabIndex = 6;
            Reset_Bttn.Text = "Reset JSON file";
            Reset_Bttn.UseVisualStyleBackColor = true;
            Reset_Bttn.Click += Reset_Bttn_Click;
            // 
            // CurrentCardLabel
            // 
            CurrentCardLabel.AutoSize = true;
            CurrentCardLabel.Font = new Font("Segoe UI", 15F);
            CurrentCardLabel.Location = new Point(340, 305);
            CurrentCardLabel.Name = "CurrentCardLabel";
            CurrentCardLabel.Size = new Size(52, 28);
            CurrentCardLabel.TabIndex = 7;
            CurrentCardLabel.Text = "0 / 0";
            // 
            // FlashCardContainer
            // 
            FlashCardContainer.Anchor = AnchorStyles.None;
            FlashCardContainer.ColumnCount = 1;
            FlashCardContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            FlashCardContainer.Controls.Add(flowLayoutPanel1, 0, 2);
            FlashCardContainer.Controls.Add(TermDefLabel, 0, 1);
            FlashCardContainer.Controls.Add(TermOrDefLabel, 0, 0);
            FlashCardContainer.Location = new Point(212, 30);
            FlashCardContainer.Name = "FlashCardContainer";
            FlashCardContainer.RowCount = 3;
            FlashCardContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 22.2707424F));
            FlashCardContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 77.7292557F));
            FlashCardContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            FlashCardContainer.Size = new Size(287, 272);
            FlashCardContainer.TabIndex = 8;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.None;
            flowLayoutPanel1.Controls.Add(FlashCardLeft_Bttn);
            flowLayoutPanel1.Controls.Add(Flip_Bttn);
            flowLayoutPanel1.Controls.Add(FlashCardRight_Bttn);
            flowLayoutPanel1.Location = new Point(8, 232);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(270, 37);
            flowLayoutPanel1.TabIndex = 9;
            // 
            // QuizzyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(FlashCardContainer);
            Controls.Add(CurrentCardLabel);
            Controls.Add(Reset_Bttn);
            Controls.Add(AddFlashCard_Bttn);
            Name = "QuizzyForm";
            Text = "QuizzyForm";
            FlashCardContainer.ResumeLayout(false);
            FlashCardContainer.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddFlashCard_Bttn;
        private Button FlashCardLeft_Bttn;
        private Button FlashCardRight_Bttn;
        private Button Flip_Bttn;
        private Label TermDefLabel;
        private Button Reset_Bttn;
        private Label CurrentCardLabel;
        private Label TermOrDefLabel;
        private TableLayoutPanel FlashCardContainer;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}