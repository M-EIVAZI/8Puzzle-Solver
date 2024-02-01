class UniPuzzle
{
    private UniPuzzle? _parent;
    private List<int[]> _tiles;
    private int _g;
    public UniPuzzle(UniPuzzle? parents, List<int[]> tiles)
    {
        this._parent = parents;
        this._tiles = tiles;
        if (parents == null)
            this._g = 0;
        else
            this._g = parents._g + 1;
    }
    public UniPuzzle(UniPuzzle? parents)
    {
        _tiles = this.GenArr();
        this._parent = parents;
        this._g = parents._g + 1;
    }
    public UniPuzzle()
    {   _tiles = this.GenArr(); }
    public List<int[]> GenArr()
    {
        List<int[]> ints = new List<int[]>();
        for (int i = 0; i < 3; i++)
            ints.Add(new int[3]);
        return ints;
    }
    public UniPuzzle? parent
    {
        get
        { return _parent; }
        set => _parent = value;
    }
    public List<int[]> tiles
    {
        get
        { return _tiles; }
        set => _tiles = value;
    }
    public int g
    {
        set { _g = value; }
        get { return _g; }
    }
    public override string ToString()
    {
        for (int i = 0; i < this.tiles.Count; i++)
        {
            for (int j = 0; j < this.tiles[i].Length; j++)
                Console.Write($"{this.tiles[i][j]} ");
            Console.WriteLine();
        }
        return "";
    }
    public UniPuzzle Move(int f_x, int f_y, int to_x, int to_y)
    {
        UniPuzzle puzzle = new(this);
        Copy(puzzle, this);
        (puzzle.tiles[f_x][f_y], puzzle.tiles[to_x][to_y]) = (puzzle.tiles[to_x][to_y], puzzle.tiles[f_x][f_y]);
        return puzzle;

    }
    public void Copy(UniPuzzle p1, UniPuzzle p2)
    {
        for (int i = 0; i < p2.tiles.Count; i++)
        {
            for (int j = 0; j < p2.tiles[i].Length; j++)
            { p1.tiles[i][j] = p2.tiles[i][j]; }
        }
    }
    public  void Copy(List<int[]> a1, List<int[]> a2)
    {
        for (int i = 0; i < a2.Count; i++)
        {
            for (int j = 0; j < a2[i].Length; j++)
                a1[i][j] = a2[i][j];
        }
    }


}