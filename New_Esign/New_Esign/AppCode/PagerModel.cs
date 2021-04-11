public class PagerModel
{
    public const int PageSize = 20;
    public string GetAction { get; set; }
    public string GetControler { get; set; }
    public string GetArea { get; set; }
    public int curentPage { get; set; }
    public int totalPage { get; set; }
    public PagerModel()
    {

    }
    public PagerModel(string _action, string _controler, string _area, int _curent, int _totalPage)
    {
        this.GetAction = _action;
        this.GetControler = _controler;
        this.GetArea = _area;
        this.curentPage = _curent;
        this.totalPage = _totalPage;
    }

    public PagerModel(string _action, string _controler, string _area, int _curent, int _pageSize, int _totalRecord)
    {
        this.GetAction = _action;
        this.GetControler = _controler;
        this.GetArea = _area;
        this.curentPage = _curent;
        int total = _totalRecord / _pageSize;
        this.totalPage = (_totalRecord % _pageSize) != 0 ? (total + 1) : total;
    }
}
