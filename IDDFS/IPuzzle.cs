interface IPuzzle
{
    public UniPuzzle Move(int f_x, int f_y, int to_x, int to_y);
    public void Copy(UniPuzzle p1, UniPuzzle p2);
    public  void Copy(List<int[]> a1, List<int[]> a2);

}