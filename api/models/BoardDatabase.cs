using System.Text.Json;

namespace backend;

static class BoardDatabase {
    public static Dictionary<string, Board> Boards { get; set; } = new();
    const string FILE = "boards.json"; 

    public static void SaveBoard(Board board, string id) {
        Boards[id] = board;
        Save();
    } 

    static bool CheckIfFileExists() {
        if(!File.Exists(FILE)) {
            File.Create(FILE).Close();
            return true;
        }

        return false;
    }

    public async static void Save() {
        CheckIfFileExists();

        string json = JsonSerializer.Serialize(Boards);

        StreamWriter writer = new(FILE);
        await writer.WriteLineAsync(json);
        writer.Flush();
        writer.Close();
    }

    public static void Load() {
        if(CheckIfFileExists())
            return;
        
        var file = new FileStream(FILE, FileMode.Open, FileAccess.Read);
        Boards = JsonSerializer.Deserialize<Dictionary<string, Board>>(file) ?? throw new JsonException($"{FILE} has not valid json");

        Console.WriteLine("All Boards:");

        foreach(var key in Boards.Keys)
            Console.Write(key + " ");

        Console.WriteLine();

        file.Close();
    }

    public static Board? GetBoardById(string id) {
        if(Boards.ContainsKey(id))
            return Boards[id];

        return null;
    }
}