namespace Api.Responces.Global;

public class SuccessResponce<TData> : BaseResponce
{
    public string Operation { get; set; }
    public List<TData> Datas { get; set; } = new List<TData>();
}