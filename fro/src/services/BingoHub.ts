import { HubConnectionBuilder } from "@microsoft/signalr";

const BingoHub = new HubConnectionBuilder().withUrl("http://localhost:5233/bingoHub").build();

export { BingoHub };