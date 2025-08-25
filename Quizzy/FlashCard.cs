using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzy
{
    public class FlashCard
    {
        /// <summary>
        /// The term of the card
        /// </summary>
        public string Term { get; set; }
        /// <summary>
        /// The description of the term
        /// </summary>
        public string Definition { get; set; }

        public FlashCard(string term, string definition)
        {
            Term = term;
            Definition = definition;
        }

        public override string ToString()
        {
            return Term + ": " + Definition;
        }
    }
}
