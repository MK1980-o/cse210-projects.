//Creativity and enhancement:
//Progress Tracking: After each round of hiding words, the program displays the percentage
//of words currently hidden. This feature helps users visualize their memorization progress,
//motivating them and providing a clear sense of how much of the scripture remains visible.
//This progress feedback improves user experience and encourages continued practice.
//Scripture used: Helaman 5:12

using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    class Reference
    {
        public string Book { get; private set; }
        public int Chapter { get; private set; }
        public int StartVerse { get; private set; }
        public int? EndVerse { get; private set; }

        public Reference(string book, int chapter, int verse)
        {
            Book = book;
            Chapter = chapter;
            StartVerse = verse;
            EndVerse = null;
        }

        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            Book = book;
            Chapter = chapter;
            StartVerse = startVerse;
            EndVerse = endVerse;
        }

        public override string ToString()
        {
            if (EndVerse.HasValue)
                return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
            else
                return $"{Book} {Chapter}:{StartVerse}";
        }
    }

    class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public void Hide()
        {
            _isHidden = true;
        }

        public bool IsHidden()
        {
            return _isHidden;
        }

        public string GetDisplayText()
        {
            if (_isHidden)
                return new string('_', _text.Length);
            else
                return _text;
        }
    }

    class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random _random = new Random();

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();
            var splitWords = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var w in splitWords)
            {
                _words.Add(new Word(w));
            }
        }

        public void Display()
        {
            Console.WriteLine(_reference.ToString());
            foreach (var word in _words)
            {
                Console.Write(word.GetDisplayText() + " ");
            }
            Console.WriteLine();
        }

        public void HideRandomWords(int count)
        {
            int attempts = 0;
            int hiddenCount = 0;

            while (hiddenCount < count && attempts < _words.Count * 2)
            {
                int index = _random.Next(_words.Count);
                if (!_words[index].IsHidden())
                {
                    _words[index].Hide();
                    hiddenCount++;
                }
                attempts++;
            }
        }

        public double PercentHidden()
        {
            int hiddenCount = 0;
            foreach (var w in _words)
            {
            if (w.IsHidden()) hiddenCount++;
            }
            return (double)hiddenCount / _words.Count * 100;
        }


        public bool AllWordsHidden()
        {
            foreach (var word in _words)
            {
                if (!word.IsHidden())
                    return false;
            }
            return true;
        }
    }

    class Program
    {
        static void Main()
        {
            var reference = new Reference("Helaman", 5, 12);
            var text = "And now, my sons, remember, remember that it is upon the rock of our Redeemer, " +
                       "who is Christ, the Son of God, that ye must build your foundation; that when the devil " +
                       "shall send forth his mighty winds, yea, his shafts in the whirlwind, yea, when all his hail " +
                       "and his mighty storm shall beat upon you, it shall have no power over you to drag you down " +
                       "to the gulf of misery and endless wo, because of the rock upon which ye are built, which is a sure foundation, " +
                       "a foundation whereon if men build they cannot fall.";
            
            var scripture = new Scripture(reference, text);

            while (true)
            {
                Console.Clear();
                scripture.Display();

                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("\nAll words are hidden. Memorization complete!");
                    break;
                }

                Console.WriteLine($"Progress: {scripture.PercentHidden():F1}% of words hidden");
                Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "quit")
                    break;

                scripture.HideRandomWords(5); 
            }
        }
    }
}
