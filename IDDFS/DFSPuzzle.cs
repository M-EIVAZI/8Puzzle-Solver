class DFSPuzzle
{
    private DFSPuzzle? _parent;
    private List<int[]> _tiles;
    private int _height;
    public DFSPuzzle(DFSPuzzle? parents, List<int[]> tiles)
    {
        this._parent = parents;
        this._tiles = tiles;
        if(parents == null)
            _height = 0;
        else
        this._height =parents._height+1;
    }
    public DFSPuzzle(DFSPuzzle? parents)
    {
        _tiles = this.GenArr();
        this._parent = parents;
        if(parents == null)
            _height = 0;
        else
            this._height =parents._height+1;
    }
    public DFSPuzzle()
    { this._tiles = this.GenArr(); }
    public List<int[]> GenArr()
    {
        List<int[]> ints = new List<int[]>();
        for (int i = 0; i < 3; i++)
            ints.Add(new int[3]);
        return ints;
    }
    public DFSPuzzle? parent
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
    public int height
    {
        set { _height = value; }
        get { return _height; }
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
    public DFSPuzzle Move(int f_x, int f_y, int to_x, int to_y)
    {
        DFSPuzzle puzzle = new(this);
        Copy(puzzle, this);
        (puzzle.tiles[f_x][f_y], puzzle.tiles[to_x][to_y]) = (puzzle.tiles[to_x][to_y], puzzle.tiles[f_x][f_y]);
        return puzzle;

    }
    public void Copy(DFSPuzzle p1, DFSPuzzle p2)
    {
        for (int i = 0; i < p2.tiles.Count; i++)
        {
            for (int j = 0; j < p2.tiles[i].Length; j++)
            { p1.tiles[i][j] = p2.tiles[i][j]; }
        }
    }
    public void Copy(List<int[]> a1, List<int[]> a2)
    {
        for (int i = 0; i < a2.Count; i++)
        {
            for (int j = 0; j < a2[i].Length; j++)
                a1[i][j] = a2[i][j];
        }
    }

}