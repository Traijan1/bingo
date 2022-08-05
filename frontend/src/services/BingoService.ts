import { Board } from "@/models/board";
import domain from "@/assets/domain.json";

class BingoService {
    public async getBoard(id: string): Promise<Board> {
        const response = await fetch(`${domain.url}/board?id=${id}`);
        const json = await response.json();

        return json as Board;
    }
}

export default new BingoService();