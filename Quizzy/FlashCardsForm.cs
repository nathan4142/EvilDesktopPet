using Microsoft.VisualBasic;
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
using System.IO;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Quizzy
{
    public partial class FlashCardsForm : Form
    {
        private int termDefFlag = 0;
        private int currentCard = 0;

        public FlashCardsForm()
        {
            InitializeComponent();
            FlashCardLeft_Bttn.Enabled = false;
            LoadFlashCards();
        }

        private List<FlashCard> flashCards = new List<FlashCard>();

        private void AddFlashCard_Bttn_Click(object sender, EventArgs e)
        {
            string term = Interaction.InputBox("What is the term?");
            string definition = Interaction.InputBox("What is the definition?");
            var card = new FlashCard(term, definition);
            flashCards.Add(card);
            SaveFlashCards();
            TermDefLabel.Text = flashCards[currentCard].Term;
            CurrentCardLabel.Text = (currentCard + 1) + "/" + flashCards.Count.ToString();
            if (flashCards.Count <= 1)
            {
                FlashCardRight_Bttn.Enabled = false;
            }
            else
            {
                FlashCardRight_Bttn.Enabled = true;
            }
        }


        /// <summary>
        /// Logic on how to flip the card to show either the term or definition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Flip_Bttn_Click(object sender, EventArgs e)
        {
            if (termDefFlag == 0)
            {
                TermDefLabel.Text = flashCards[currentCard].Definition;
                TermOrDefLabel.Text = "Definition";
                termDefFlag = 1;
            }
            else
            {
                TermDefLabel.Text = flashCards[currentCard].Term;
                TermOrDefLabel.Text = "Term";
                termDefFlag = 0;
            }
        }
        /// <summary>
        /// Handles Left Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlashCardLeft_Bttn_Click(object sender, EventArgs e)
        {
            if (currentCard > 0)
            {
                currentCard--;
                TermDefLabel.Text = flashCards[currentCard].Term;
            }

            FlashCardLeft_Bttn.Enabled = currentCard > 0;
            FlashCardRight_Bttn.Enabled = currentCard < flashCards.Count - 1;

            CurrentCardLabel.Text = (currentCard + 1) + "/" + flashCards.Count.ToString();
        }
        /// <summary>
        /// Handles Right Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlashCardRight_Bttn_Click(object sender, EventArgs e)
        {
            if (currentCard < flashCards.Count - 1)
            {
                currentCard++;
                TermDefLabel.Text = flashCards[currentCard].Term;
            }

            FlashCardLeft_Bttn.Enabled = currentCard > 0;
            FlashCardRight_Bttn.Enabled = currentCard < flashCards.Count - 1;

            CurrentCardLabel.Text = (currentCard + 1) + "/" + flashCards.Count.ToString();
        }
        /// <summary>
        /// Saves the flashcards to a JSON file
        /// </summary>
        private void SaveFlashCards()
        {
            string json = JsonSerializer.Serialize(flashCards);
            File.WriteAllText("flashcards.json", json);
        }
        /// <summary>
        /// Loads the Flash cards from JSON
        /// </summary>
        private void LoadFlashCards()
        {
            if (File.Exists("flashcards.json"))
            {
                string json = File.ReadAllText("flashcards.json");
                flashCards = JsonSerializer.Deserialize<List<FlashCard>>(json);
                TermDefLabel.Text = flashCards[0].Term;
                CurrentCardLabel.Text = "1/" + flashCards.Count.ToString();
            }
            else
            {
                FlashCardRight_Bttn.Enabled = false;
                CurrentCardLabel.Text = currentCard + "/" + flashCards.Count.ToString();
            }
        }
        /// <summary>
        /// Resets and clears the JSON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reset_Bttn_Click(object sender, EventArgs e)
        {
            flashCards.Clear();
            if (File.Exists("flashcards.json"))
            {
                File.Delete("flashcards.json");
            }
        }


    }
}
