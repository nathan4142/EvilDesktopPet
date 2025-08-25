using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizzy
{
    public partial class WriteForm : Form
    {
        private int currentCard = 0;
        private int cardSelected;
        private List<int> alreadySelected = new List<int>();
        public WriteForm()
        {
            InitializeComponent();
            LoadFlashCards();
            //Test
            //CorrectDefinitionTextBox.Text = "This is a test";
            //TestColor();

        }
        private List<FlashCard> flashCards = new List<FlashCard>();
        private void LoadFlashCards()
        {
            if (File.Exists("flashcards.json"))
            {
                string json = File.ReadAllText("flashcards.json");
                flashCards = JsonSerializer.Deserialize<List<FlashCard>>(json);
                //picks random card from flash cards
                cardSelected = GetNewNumber();
                currentCard = cardSelected;
                TermLabel.Text = flashCards[cardSelected].Term;
                NumDoneLabel.Text = "1/" + flashCards.Count.ToString();
                Debug.WriteLine(string.Join(", ", alreadySelected));
                Next_Bttn.Enabled = true;
            }
        }

        private int GetNewNumber()
        {
            int done = 0;
            Random rand = new Random();
            int num = rand.Next(0, flashCards.Count);
            while (done == 0)
            {
                if (alreadySelected.Contains(num))
                {
                    num = rand.Next(0, flashCards.Count);
                }
                else
                {
                    done = 1;
                    alreadySelected.Add(num);
                }
            }
            return num;
        }

        private void CheckAnswer(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                Debug.WriteLine("Enter Pressed");
                this.ActiveControl = null;

                Color incorrectColor = Color.Red;

                string correctDefinition = flashCards[currentCard].Definition;
                Debug.WriteLine(correctDefinition);

                CorrectDefinitionTextBox.Text = correctDefinition;
                for (int i = 0; i < userInputTextBox.Text.Length; i++)
                {
                    if (userInputTextBox.Text[i] != correctDefinition[i])
                    {
                        CorrectDefinitionTextBox.SelectionStart = i;
                        CorrectDefinitionTextBox.SelectionLength = 1;
                        CorrectDefinitionTextBox.SelectionColor = incorrectColor;

                    }
                }

            }
        }

        private void Next_Bttn_Click(object sender, EventArgs e)
        {
            cardSelected = GetNewNumber();
            currentCard = cardSelected;
            TermLabel.Text = flashCards[cardSelected].Term;
            NumDoneLabel.Text = alreadySelected.Count + "/" + flashCards.Count.ToString();
            if (alreadySelected.Count == flashCards.Count)
            {
                Next_Bttn.Enabled = false;
            }

            userInputTextBox.Text = "";
            CorrectDefinitionTextBox.Text = "";
        }
    }
}
