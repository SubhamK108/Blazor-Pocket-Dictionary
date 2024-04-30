namespace BlazorPocketDictionary.Components.Api;

public static class WordDefinitionFetcher
{
    public static async Task<(WordDefinition, ResponseResult)> FetchWordDefinitionAsync(string word)
    {
        await Task.Delay(1000);
        try
        {
            using HttpClient httpClient = new();
            var response = await httpClient.GetAsync(@$"https://api.dictionaryapi.dev/api/v2/entries/en/{word.Trim().ToLower()}");
            response.EnsureSuccessStatusCode();
            List<WordDefinition>? wordDefinitions = await response.Content.ReadFromJsonAsync<List<WordDefinition>>();
            return (wordDefinitions is not null) switch
            {
                true => (wordDefinitions[0], ResponseResult.SUCCESS),
                false => throw new Exception(nameof(ResponseResult.NOT_FOUND))
            };
        }
        catch (Exception exception)
        {
            return exception.Message.Contains("404") switch
            {
                true => (new(), ResponseResult.NOT_FOUND),
                false => (new(), ResponseResult.SERVER_ERROR)
            };
        }
    }

    public enum ResponseResult
    {
        SUCCESS,
        NOT_FOUND,
        SERVER_ERROR,
        BAD_DATA
    }
}