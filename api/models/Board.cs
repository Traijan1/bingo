using System.Text.Json.Serialization;

namespace backend;

class Board {
    [JsonPropertyName("fields")] public List<Field> Fields { get; set; }
    [JsonPropertyName("id")] public string Id { get; set; }


    public Board() {
        Fields = new();
        Id = Guid.NewGuid().ToString();
    }

    public void AddField(string text) => Fields.Add(new Field(text));

    public override string ToString() {
        string cache = "Fields: ";

        foreach(var field in Fields) 
            cache += $"{field}\n";

        return cache;
    }
}

class Field {
    [JsonPropertyName("title")] public string Title { get; set; }
    [JsonPropertyName("isDone")] public bool IsDone { get; set; }

    public Field(string title) {
        Title = title;
        IsDone = false;
    }

    public override string ToString() {
        return $"'{Title}' => {IsDone}";
    }
}