using Microsoft.AspNetCore.SignalR;

namespace backend;

class BingoHub : Hub {
    public async Task RecvBoard(Board board, string id) {
        await Clients.Group(id).SendAsync("RecvBoard", board);
        Console.WriteLine("Send Data");
    }

    public async Task RecvClient(string id) {
        await Groups.AddToGroupAsync(Context.ConnectionId, id);
        Console.WriteLine("Added client: " + id);
    }

    public async Task SendBoard(Board board, string id) {
        BoardDatabase.SaveBoard(board, id);
        Console.WriteLine($"Board: {board}");
        await RecvBoard(board, id);
    }
}