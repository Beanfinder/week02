class ttc
{  
    static void Main(string[] args)
    {
        List<string> board = Createnewboard();
        string current = "x";
        while (!Gameover(board))
        {
            displayboard(board);
            int choice = getmove(current);
            makemove(board, choice, current);
            current = nextplayer(current);
        }
        displayboard(board);
        Console.WriteLine("GG's nerd");
    }
    static List<string> Createnewboard()
    {
        List<string> board = new List<string>();
        for (int i = 1; i <= 9; i++)
        {
            board.Add(i.ToString());
        }
        return board;
    }
    static void displayboard(List<string> board)
    {
        Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
        Console.WriteLine("-+-+-");
        Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
        Console.WriteLine("-+-+-");
        Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
    }
    static bool Gameover(List<string> board)
    {
        bool Gameover = false;
        if (winner(board, "x") || winner(board, "o") || tie(board))
        {
            Gameover = true;
        }
        return Gameover;
    }
    static bool winner(List<string> board, string player)
    {
        bool winner = false;
        if ((board[0] == player && board[1] == player && board[2] == player)
            || (board[3] == player && board[4] == player && board[5] == player)
            || (board[6] == player && board[7] == player && board[8] == player)
            || (board[0] == player && board[3] == player && board[6] == player)
            || (board[1] == player && board[4] == player && board[7] == player)
            || (board[2] == player && board[5] == player && board[8] == player)
            || (board[0] == player && board[4] == player && board[8] == player)
            || (board[2] == player && board[4] == player && board[6] == player)
            )
        {
            winner = true;
        }
        return winner;
    }
    static bool tie(List<string> board)
    {
        bool digit = false;
        foreach (string value in board)
        {
            if (char.IsDigit(value[0]))
            {
                digit = true;
                break;
            }
        }
        return !digit;
    }
    static string nextplayer(string current)
        {
            string nextplayer = "x";
            if (current == "x")
            {
                nextplayer = "o";
            }
            return nextplayer;
        }
    static int getmove(string current)
    {
        Console.Write($"{current}'s turn pick (1-9): ");
        string move_string = Console.ReadLine();
        int choice = int.Parse(move_string);
        return choice;
    }
    static void makemove(List<string> board, int choice, string current)
    {
        int index = choice - 1;
        board[index] = current;
    }

}