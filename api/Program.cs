using backend;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(policy => 
    policy.AddDefaultPolicy(cors => cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
);

builder.Services.AddSignalR();

var app = builder.Build();
app.UseCors();

BoardDatabase.Load();

app.MapGet("/info", () => "Connection is working!");
app.MapGet("/board", (string id) => { 
    if(!BoardDatabase.Boards.ContainsKey(id))
        return Results.NotFound(id);
        
    Console.WriteLine(BoardDatabase.Boards[id]);

    return Results.Ok(BoardDatabase.Boards[id]);
});

app.MapPost("/board", ([FromBody] Board board) => {
    var currentBoard = BoardDatabase.GetBoardById(board.Id);

    BoardDatabase.SaveBoard(board, board.Id);

    return Results.Ok(board);
});

app.MapGet("/initBoard", () => {
    var board = new Board();
    
    for(int i = 0; i < 9; i++)
        board.Fields.Add(new Field(""));

    BoardDatabase.SaveBoard(board, board.Id);

    return Results.Ok(board);
});

app.MapHub<BingoHub>("/bingoHub").RequireCors(policy => policy
        .WithOrigins("http://localhost:8081", "http://traijan.de")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());

app.Run();