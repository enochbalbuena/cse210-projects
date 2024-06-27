public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] words = text.Split(' ');
        foreach (var word in words)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int wordsHidden = 0;

        while (wordsHidden < numberToHide && !IsCompletelyHidden())
        {
            int index = random.Next(_words.Count);
            if (!_words[index].IsHidden)
            {
                _words[index].Hide();
                wordsHidden++;
            }
        }

        if (IsCompletelyHidden())
        {
            foreach (var word in _words)
            {
                word.Hide();
            }
        }
    }

    public string GetDisplayText()
    {
        List<string> displayedWords = new List<string>();
        foreach (var word in _words)
        {
            displayedWords.Add(word.GetDisplayText());
        }
        return $"{_reference.GetDisplayText()}\n\n{string.Join(" ", displayedWords)}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (var word in _words)
        {
            if (!word.IsHidden)
            {
                return false;
            }
        }
        return true;
    }
}