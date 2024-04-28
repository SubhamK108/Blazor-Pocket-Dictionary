namespace BlazorPocketDictionary.Components.Api;

public static class WordDefinitionFetcher
{
    public static async Task<WordDefinition> FetchWordDefinitionAsync(string word)
    {
        await Task.Delay(1000);
        try
        {
            using HttpClient httpClient = new();
            var response = await httpClient.GetAsync(@$"https://api.dictionaryapi.dev/api/v2/entries/en/{word}");
            response.EnsureSuccessStatusCode();
            List<WordDefinition>? wordDefinitions = await response.Content.ReadFromJsonAsync<List<WordDefinition>>();
            return wordDefinitions is not null ? wordDefinitions[0] : throw new Exception();
        }
        catch (Exception)
        {
            return new();
        }
    }
}