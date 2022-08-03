import { HubConnectionBuilder } from "@microsoft/signalr";

// const domain = "http://localhost:5233/bingoHub"; // Testing
const domain = "http://traijan.de:5000/bingoHub"; // Production

const BingoHub = new HubConnectionBuilder().withUrl(domain).build();

export { BingoHub };