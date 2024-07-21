namespace _20240701_HW_Inheritence;

public struct PicItem
{
    public int x;
    public int y;
    public char symdol;

    public PicItem(int x, int y, char symdol) : this()
    {
        this.x = x;
        this.y = y;
        this.symdol = symdol;
    }

    public PicItem(PicItem pic) : this(pic.x, pic.y, pic.symdol)
    {}

}
