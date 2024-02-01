try
{
    Console.Write("Enter the your entries way:1.Random  2.Console  3.File:");
    int choose = int.Parse(Console.ReadLine());
    if (choose < 1 || choose > 3)
        throw new Exception("Enter number between 1 to 3");
    List<int[]> tiles = new();
    Console.WriteLine("Enter the alogorithm you want:\n1.BFS\n2.IDS\n3.Uniform Cost\n4.AStar");
    int choosealgo = int.Parse(Console.ReadLine());
    if (choosealgo < 1 || choosealgo > 4)
        throw new Exception("Enter number between 1 to 4");
    switch (choose)
    {
        case 1:
            {
                switch (choosealgo)
                {
                    case 1:
                        {
                            Puzzle rndpuzz = new();
                            rndpuzz = RandomGen();
                            BFS(rndpuzz);
                        }
                        break;
                    case 2:
                        {
                            DFSPuzzle rndpuzz = new();
                            rndpuzz = RandomGen2();
                            IDS(rndpuzz);
                        }
                        break;
                    case 3:
                        {
                            UniPuzzle rndpuzz = new();
                            rndpuzz = RandomGen3();
                            UCS(rndpuzz);
                        }
                        break;
                    case 4:
                        {
                            UniPuzzle rndpuzz = new();
                            rndpuzz = RandomGen3();
                            AStar(rndpuzz);

                        }
                        break;
                }
                break;
            }
        case 2:
            {


                switch (choosealgo)
                {
                    case 1:
                        {
                            tiles = GetInput();
                            Puzzle puzzle = new(null, tiles);
                            BFS(puzzle);
                        }
                        break;
                    case 2:
                        {
                            tiles = GetInput();
                            DFSPuzzle puzzle = new(null, tiles);
                            IDS(puzzle);
                        }
                        break;
                    case 3:
                        {
                            tiles = GetInput();
                            UniPuzzle puzzle = new(null, tiles);
                            UCS(puzzle);
                        }
                        break;
                    case 4:
                        {
                            tiles = GetInput();
                            UniPuzzle puzzle = new(null, tiles);
                            AStar(puzzle);

                        }
                        break;
                }
                break;

            }

        case 3:
            {
                string path = @"D:\Programming\C#\AI_Projects\IDDFS\8Puzzle.txt";
                if (File.Exists(path))
                {
                    StreamReader textfile = new(path);
                    string? line;
                    for (int i = 0; i < 3; i++)
                    {
                        line = textfile.ReadLine();
                        tiles.Add(Array.ConvertAll(line.Split(' '), s => int.Parse(s)));
                    }
                }
                switch (choosealgo)
                {
                    case 1:
                        {
                            Puzzle puzzle = new(null, tiles);
                            BFS(puzzle);

                        }
                        break;
                    case 2:
                        {
                            DFSPuzzle puzzle = new(null, tiles);
                            IDS(puzzle);

                        }
                        break;
                    case 3:
                        {
                            UniPuzzle puzzle = new(null, tiles);
                            UCS(puzzle);

                        }
                        break;
                    case 4:
                        {
                            UniPuzzle puzzle = new(null, tiles);
                            AStar(puzzle);

                        }
                        break;
                }

            }
            break;
    }
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}