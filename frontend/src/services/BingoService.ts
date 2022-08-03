import { Board } from "@/models/board";

class BingoService {
    // domain = "http://localhost:5233"; // Testing
    domain = "http://traijan.de:5000"; // Production

    public async getBoard(id: string): Promise<Board> {
        const response = await fetch(`${this.domain}/board?id=${id}`);
        const json = await response.json();

        return json as Board;
    }
}

export default new BingoService();