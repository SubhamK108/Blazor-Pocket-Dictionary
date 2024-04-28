namespace BlazorPocketDictionary.Models;

public class Phonetic
{
    public string Text { get; set; } = "";
    public string Audio { get; set; } = "";
    public string? SourceUrl { get; set; }
    public Dictionary<string, string>? License { get; set; }

}

public class Definitions
{
    public string Definition { get; set; } = "";
    public List<string> Synonyms { get; set; } = [];
    public List<string> Antonyms { get; set; } = [];
    public string? Example { get; set; }
}

public class Meaning
{
    public string PartOfSpeech { get; set; } = "";
    public List<Definitions> Definitions { get; set; } = [];
    public List<string> Synonyms { get; set; } = [];
    public List<string> Antonyms { get; set; } = [];
}

public class WordDefinition
{
    public string Word { get; set; } = "";
    public string Phonetic { get; set; } = "";
    public List<Phonetic> Phonetics { get; set; } = [];
    public List<Meaning> Meanings { get; set; } = [];
    public Dictionary<string, string> License { get; set; } = [];
    public List<string> SourceUrls { get; set; } = [];
}

