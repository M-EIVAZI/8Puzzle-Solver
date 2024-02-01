using System.Runtime.CompilerServices;

partial class Program
{   static List<Puzzle> GenMoves(Puzzle puzzle)
    {   int zero_x=0,zero_y=0;
        for(int i = 0; i <puzzle.tiles.Count; i++)
        {   for(int j = 0; j < puzzle.tiles[i].Length; j++)
            {
                if (puzzle.tiles[i][j]==0)
                {
                    zero_x = i;
                    zero_y = j;
                }

            }
        }
        List<Puzzle> arr = new(); 
        if(zero_x<2)
            arr.Add(puzzle.Move(zero_x,zero_y,zero_x+1,zero_y));
        if (zero_x > 0)
            arr.Add(puzzle.Move(zero_x, zero_y, zero_x - 1, zero_y));
        if (zero_y < 2)
            arr.Add(puzzle.Move(zero_x, zero_y, zero_x, zero_y + 1));
        if(zero_y > 0)
            arr.Add(puzzle.Move(zero_x,zero_y,zero_x,zero_y -1));
        return arr;
    }
    //BFS Algorithm
    static void BFS(Puzzle puzzle)
    {   Queue<Puzzle> queue = new();
        List<Puzzle> arr = new();
        queue.Enqueue(puzzle);
        HashSet<List<int[]>> visited=new();
        while(!IsGoal(queue.First().tiles))
        {
            Step_Counter++;
            var first=queue.Dequeue();
            arr = GenMoves(first);
            //Console.WriteLine(Step_Counter);
            visited.Add(first.tiles);
            foreach(var move in arr)
            {
                if (!visited.Contains(move.tiles))
                {   
                    queue.Enqueue(move);
                }
            }

        }
        Print(queue.First());
    }
    static Puzzle RandomGen()
    {   Random rnd = new Random();
        List<int[]> arr = new List<int[]>
        {
            new int[]{1,2,3},
            new int[]{4,5,6},
            new int[]{7,8,0}

        };
        Puzzle puzzle = new(null,arr);
        Console.WriteLine("Enter the random step");
        int n =int.Parse(Console.ReadLine());
        int zero_x=2, zero_y=2,myrnd,i=1;
        int? premove=null;
        bool[] moves= new bool[4];
        rnd.Next(0,4);
        while(i<=n)
        {   
            moves = NextMove(zero_x, zero_y, arr);
            myrnd=rnd.Next(0,4);
            while(!moves[myrnd])
                myrnd=rnd.Next(0,4) ;
            switch(myrnd)
            {
                case 0 :
                    if (moves[myrnd] == true && premove != 1)
                    {
                        puzzle = puzzle.Move(zero_x, zero_y, zero_x, zero_y + 1);
                        zero_y++;
                        premove = 0;
                        i++;
                        //Console.WriteLine(puzzle);
                    }
                    break;
                case 1:
                    if (moves[myrnd] == true && premove != 0)
                    {
                        puzzle = puzzle.Move(zero_x, zero_y, zero_x, zero_y - 1);
                        zero_y--;
                        premove = 1;
                        i++;
                        //Console.WriteLine(puzzle);
                    }
                    break;
                case 2:
                    if (moves[myrnd] == true && premove != 3)
                    {
                        puzzle = puzzle.Move(zero_x, zero_y, zero_x + 1, zero_y);
                        zero_x++;
                        premove = 2;
                        i++;
                        //Console.WriteLine(puzzle);
                    }
                    break;
                case 3:
                    if (moves[myrnd] == true && premove != 2)
                    {
                        puzzle = puzzle.Move(zero_x, zero_y, zero_x - 1, zero_y);
                        premove = 3;
                        zero_x--;
                        i++;
                        //Console.WriteLine(puzzle);
                    }
                    break;
            }


        }
        puzzle.parent= null;
        Console.WriteLine(puzzle);
        return puzzle;
    }
    static DFSPuzzle RandomGen2()
    {
        Random rnd = new Random();
        List<int[]> arr = new List<int[]>
        {
            new int[]{1,2,3},
            new int[]{4,5,6},
            new int[]{7,8,0}

        };
        DFSPuzzle dfspuzzle = new(null, arr);
        Console.WriteLine("Enter the random step");
        int n = int.Parse(Console.ReadLine());
        int zero_x = 2, zero_y = 2, myrnd, i = 1;
        int? premove = null;
        bool[] moves = new bool[4];
        rnd.Next(0, 4);
        while (i <= n)
        {
            moves = NextMove(zero_x, zero_y, arr);
            myrnd = rnd.Next(0, 4);
            while (!moves[myrnd])
                myrnd = rnd.Next(0, 4);
            switch (myrnd)
            {
                case 0:
                    if (moves[myrnd] == true && premove != 1)
                    {
                        dfspuzzle = dfspuzzle.Move(zero_x, zero_y, zero_x, zero_y + 1);
                        zero_y++;
                        premove = 0;
                        i++;
                        //Console.WriteLine(puzzle);
                    }
                    break;
                case 1:
                    if (moves[myrnd] == true && premove != 0)
                    {
                        dfspuzzle = dfspuzzle.Move(zero_x, zero_y, zero_x, zero_y - 1);
                        zero_y--;
                        premove = 1;
                        i++;
                        //Console.WriteLine(puzzle);
                    }
                    break;
                case 2:
                    if (moves[myrnd] == true && premove != 3)
                    {
                        dfspuzzle = dfspuzzle.Move(zero_x, zero_y, zero_x + 1, zero_y);
                        zero_x++;
                        premove = 2;
                        i++;
                        //Console.WriteLine(puzzle);
                    }
                    break;
                case 3:
                    if (moves[myrnd] == true && premove != 2)
                    {
                        dfspuzzle = dfspuzzle.Move(zero_x, zero_y, zero_x - 1, zero_y);
                        premove = 3;
                        zero_x--;
                        i++;
                        //Console.WriteLine(puzzle);
                    }
                    break;
            }


        }
        dfspuzzle.parent = null;
        dfspuzzle.height = 0;
        Console.WriteLine(dfspuzzle);
        return dfspuzzle;
    }
    static UniPuzzle RandomGen3()
    {
        Random rnd = new Random();
        List<int[]> arr = new List<int[]>
        {
            new int[]{1,2,3},
            new int[]{4,5,6},
            new int[]{7,8,0}

        };
        UniPuzzle puzzle = new(null, arr);
        Console.WriteLine("Enter the random step");
        int n = int.Parse(Console.ReadLine());
        int zero_x = 2, zero_y = 2, myrnd, i = 1;
        int? premove = null;
        bool[] moves = new bool[4];
        rnd.Next(0, 4);
        while (i <= n)
        {
            moves = NextMove(zero_x, zero_y, arr);
            myrnd = rnd.Next(0, 4);
            while (!moves[myrnd])
                myrnd = rnd.Next(0, 4);
            switch (myrnd)
            {
                case 0:
                    if (moves[myrnd] == true && premove != 1)
                    {
                        puzzle = puzzle.Move(zero_x, zero_y, zero_x, zero_y + 1);
                        zero_y++;
                        premove = 0;
                        i++;
                        //Console.WriteLine(puzzle);
                    }
                    break;
                case 1:
                    if (moves[myrnd] == true && premove != 0)
                    {
                        puzzle = puzzle.Move(zero_x, zero_y, zero_x, zero_y - 1);
                        zero_y--;
                        premove = 1;
                        i++;
                        //Console.WriteLine(puzzle);
                    }
                    break;
                case 2:
                    if (moves[myrnd] == true && premove != 3)
                    {
                        puzzle = puzzle.Move(zero_x, zero_y, zero_x + 1, zero_y);
                        zero_x++;
                        premove = 2;
                        i++;
                        //Console.WriteLine(puzzle);
                    }
                    break;
                case 3:
                    if (moves[myrnd] == true && premove != 2)
                    {
                        puzzle = puzzle.Move(zero_x, zero_y, zero_x - 1, zero_y);
                        premove = 3;
                        zero_x--;
                        i++;
                        //Console.WriteLine(puzzle);
                    }
                    break;
            }


        }
        puzzle.parent = null;
        Console.WriteLine(puzzle);
        return puzzle;
    }
    static bool[] NextMove(int zx,int zy, List<int[]> arr)
    {
        //right-left-down-up
        bool[] moves = new bool[4];
        if(zy<2)
            moves[0] = true;
        if(zy>0)
            moves[1]=true;
        if(zx<2)
            moves[2]=true;
        if (zx>0)
            moves[3]=true;
        return moves;

    }
    static bool IsGoal(List<int[]> tiles)
    {
        List<int[]> arr = new List<int[]>
        {
            new int[]{1,2,3},
            new int[]{4,5,6},
            new int[]{7,8,0}

        };
        for(int i=0; i<tiles.Count; i++)
        {   for(int j=0; j < tiles[i].Length;j++)
            {
                if (tiles[i][j] !=arr[i][j])
                    return false;

            }

        }
        return true;

    }
    static List<int[]> GetInput()
    {
        List<int[]> elems = new();
        try
        {
            Console.WriteLine("You should Write elements in this format:");
            Console.WriteLine("1 2 3");
            Console.WriteLine("4 5 6");
            Console.WriteLine("7 8 0");
            Console.WriteLine("Enter the elements of the puzzle:");
            for (int i = 0; i < 3; i++)
            {
                elems.Add(new int[3]);
                elems[i] = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
                if (elems[i].Length > 3)
                {
                    Console.WriteLine("You can not enter more than 3 items in a row,Enter again");
                    elems[i] = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));

                }
            }
            if (!CheckBounderies(elems))
                throw new Exception("numbers must be in 0 to 8 bound");
            if (!IsSolveable(elems))
                throw new Exception("Puzzle is not solvable");

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            GetInput();
        }
        return elems;

    }
    static bool IsSolveable(List<int[]> elems)
    {
        List<int> arr = new List<int>();
        for (int i = 0; i < elems.Count; i++)
        {
            for (int j = 0; j < elems[i].Length; j++)
            {
                arr.Add(elems[i][j]);

            }
        }
        int inversions = 0;
        foreach (int a in arr)
        {
            foreach (int b in arr)
                if (a > b)
                    inversions++;
        }
        return (inversions % 2 == 0);

    }
    static bool CheckBounderies(List<int[]> elems)
    {
        foreach (int[] elems2 in elems)
            foreach (int item in elems2)
                if (item < 0 || item > 8)
                    return false;
        return true;

    }
    static void Print(Puzzle puzzle)
    {
        ConsoleColor previouscolor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Blue;
        Puzzle iterator= puzzle;
        Console.WriteLine();
        Stack <Puzzle> stack= new Stack<Puzzle>();
        while (iterator.parent!=null)
        {   stack.Push(iterator);
            iterator= iterator.parent;
        }
        int count = 0;
        while(stack.Any())
        {
            Console.WriteLine($"Step:{++count}");
            Console.WriteLine(stack.Pop());

        }
        Console.ForegroundColor = previouscolor;
    }
    static void Print(DFSPuzzle puzzle)
    {
        ConsoleColor previouscolor = Console.ForegroundColor;
        Console.ForegroundColor= ConsoleColor.Blue;
        DFSPuzzle iterator = puzzle;

        Console.WriteLine();
        Stack<DFSPuzzle> stack = new Stack<DFSPuzzle>();
        while (iterator.parent != null)
        {
            stack.Push(iterator);
            iterator = iterator.parent;
        }
        int counter = 0;
        while (stack.Any())
        {
            Console.WriteLine($"Step:{++counter}");
            Console.WriteLine(stack.Pop());

        }
        Console.ForegroundColor = previouscolor;
    }
    static void Print(UniPuzzle puzzle)
    {
        ConsoleColor previouscolor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Blue;
        UniPuzzle iterator = puzzle;
        Console.WriteLine();
        Stack<UniPuzzle> stack = new Stack<UniPuzzle>();
        while (iterator.parent != null)
        {
            stack.Push(iterator);
            iterator = iterator.parent;
        }
        int counter = 0;
        while (stack.Any())
        {
            Console.WriteLine($"Step:{++counter}");
            Console.WriteLine(stack.Pop());

        }
        Console.ForegroundColor = previouscolor;
    }
    static List<DFSPuzzle> GenMoves(DFSPuzzle dfspuzzle)
    {
        int zero_x = 0, zero_y = 0;
        for (int i = 0; i < dfspuzzle.tiles.Count; i++)
        {
            for (int j = 0; j < dfspuzzle.tiles[i].Length; j++)
            {
                if (dfspuzzle.tiles[i][j] == 0)
                {
                    zero_x = i;
                    zero_y = j;
                }

            }
        }
        List<DFSPuzzle> arr = new();
        if (zero_x < 2)
            arr.Add(dfspuzzle.Move(zero_x, zero_y, zero_x + 1, zero_y));
        if (zero_x > 0)
            arr.Add(dfspuzzle.Move(zero_x, zero_y, zero_x - 1, zero_y));
        if (zero_y < 2)
            arr.Add(dfspuzzle.Move(zero_x, zero_y, zero_x, zero_y + 1));
        if (zero_y > 0)
            arr.Add(dfspuzzle.Move(zero_x, zero_y, zero_x, zero_y - 1));
        return arr;

    }
    static int Step_Counter = 0;
    static int Step_Counter1 = 0;
    static int Step_Counter2= 0;
    //Iterative deepeing search
    static DFSPuzzle DFS(DFSPuzzle dfspuzzle,int maxheight)
    {   
        Stack<DFSPuzzle> stack = new();
        List<DFSPuzzle> arr=new();
        stack.Push(dfspuzzle);
        HashSet<List<int[]>> visited= new();
        DFSPuzzle tmp=new();
        while(stack.Any() &&stack.First().height<=maxheight)
        {   var last=stack.Pop();
            if(IsGoal(last.tiles))
            {
                Console.WriteLine("<<<Found>>>");
                tmp = last;
                break;

            }
            Step_Counter1++;
            //Console.WriteLine(Step_Counter1);
            visited.Add(last.tiles);
            if (last.height +1<= maxheight)
            {
                arr =GenMoves(last);
                foreach(var move in arr)
                {
                    if (!visited.Contains(move.tiles))
                        stack.Push(move);
                }
            }
            if (stack.Any())
                tmp = stack.First() ;
        }
        if(maxheight > 1)
            return tmp;
        return tmp;
    }
    static void IDS(DFSPuzzle dfspuzzle)
    {   DFSPuzzle tmp = new();
        tmp.Copy(tmp, dfspuzzle);
        int maxheight = 0;
        while(!IsGoal(tmp.tiles))
        {
            tmp=DFS(dfspuzzle,maxheight);
            if (IsGoal(tmp.tiles))
            {
                Print(tmp);
                return;
            }
            maxheight++;
        }

    }
    static List<UniPuzzle> GenMoves(UniPuzzle unipuzzle)
    {
        {
            int zero_x = 0, zero_y = 0;
            for (int i = 0; i < unipuzzle.tiles.Count; i++)
            {
                for (int j = 0; j < unipuzzle.tiles[i].Length; j++)
                {
                    if (unipuzzle.tiles[i][j] == 0)
                    {
                        zero_x = i;
                        zero_y = j;
                    }

                }
            }
            List<UniPuzzle> arr = new();
            if (zero_x < 2)
                arr.Add(unipuzzle.Move(zero_x, zero_y, zero_x + 1, zero_y));
            if (zero_x > 0)
                arr.Add(unipuzzle.Move(zero_x, zero_y, zero_x - 1, zero_y));
            if (zero_y < 2)
                arr.Add(unipuzzle.Move(zero_x, zero_y, zero_x, zero_y + 1));
            if (zero_y > 0)
                arr.Add(unipuzzle.Move(zero_x, zero_y, zero_x, zero_y - 1));
            return arr;
        }

    }
    //Unifomal search
    static void UCS(UniPuzzle unipuzzle)
    {
        PriorityQueue<UniPuzzle, int> pq = new();
        List<UniPuzzle> arr=new();
        pq.Enqueue(unipuzzle, unipuzzle.g);
        HashSet<List<int[]>> visited = new();
        while(!IsGoal(pq.Peek().tiles))
        {   var first=pq.Dequeue();
            Step_Counter2++;
            arr = GenMoves(first);
            visited.Add(first.tiles);
            //Console.WriteLine(Step_Counter2);
            foreach(var move in arr)
            {
                if (!visited.Contains(move.tiles))
                    pq.Enqueue(move, move.g);
                
            }
        }
        Print(pq.Peek());
    }
    static int Step_Counter3 = 0;
    //AStar
    static void AStar(UniPuzzle unipuzzle)
    {
        PriorityQueue<UniPuzzle, int> pq = new();
        List<UniPuzzle> arr = new();
        HashSet<List<int[]>> visited = new();
        pq.Enqueue(unipuzzle, unipuzzle.g + HDCal(unipuzzle));
        while (!IsGoal(pq.Peek().tiles))
        {
            Step_Counter3++;
            var first = pq.Dequeue();
            arr = GenMoves(first);
            visited.Add(first.tiles);
            if(Step_Counter3 % 500 == 0)
                Console.WriteLine(Step_Counter3);
            foreach(var move in arr)
            {
                if (!visited.Contains(move.tiles))
                    pq.Enqueue(move, move.g + HDCal(move));
            }


        }
        Print(pq.Peek());

    }
    public static int HDCal(UniPuzzle unipuzzle)
    {
        int [][] arr = new int[3][] 
        {
            new int[]{1,2,3},
            new int[]{4,5,6},
            new int[]{7,8,0}

        };
        int sum = 0 ;
        for(int i=0;i<unipuzzle.tiles.Count;i++)
        {   for(int j = 0; j < unipuzzle.tiles[i].Length;j++)
            {   
                sum += Math.Abs(i-FindIdx(arr, unipuzzle.tiles[i][j], true)) + Math.Abs(j - FindIdx(arr, unipuzzle.tiles[i][j],false));

            }
        }
        return sum;
    }
    public static int FindIdx(int[][] tiles,int goal,bool mybool)
    {
        int idx = 0, idy = 0;
        for(int i=0;i<tiles.Length;i++)
        {   for (int j = 0; j < tiles[i].Length; j++)
            {
                if (tiles[i][j] == goal)
                {
                    idx = i;
                    idy = j;

                }

            }
        }
        if(mybool==true)
            return idx;
        else
        return idy;

    }
}