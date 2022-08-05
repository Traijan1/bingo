import { HubConnectionBuilder } from "@microsoft/signalr";
import url from "@/assets/domain.json";

const domain = `${url.url}/bingoHub`;

const BingoHub = new HubConnectionBuilder().withUrl(domain).build();

export { BingoHub };