class Puzzle
{
    private int _num;
    private List<List<int>> _pieces;
    private dynamic parent;
    private int _h;
    private int _g;
    private int _f;
    public int num 
    {   get => _num;
        set {  _num = value;}       
    }
    public int h 
    {   get => _h;
        set { _h = value;}
    }
    public int g 
    {   get => _g;
        set { _g = value;}
    }
    Puzzle(int n,dynamic  parent,List<List<int>> pieces,int g)
    {   if(n < 0)
            throw new ArgumentOutOfRangeException("N Can not be negative");
         _num = n;
        _pieces = pieces;
        this.parent=parent;
        this.g = g;

    }



}