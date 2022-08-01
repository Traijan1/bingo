using Microsoft.AspNetCore.SignalR;

namespace backend;

class BingoHub : Hub {
    public async Task RecvBoard(Board board, string id) {
        await Clients.Group(id).SendAsync("RecvBoard", board);
    }

    public async Task RecvClient(string id) {
        await Groups.AddToGroupAsync(Context.ConnectionId, id);
    }

    public async Task SendBoard(Board board, string id) {
        BoardDatabase.SaveBoard(board, id);
        await RecvBoard(board, id);
    }
}