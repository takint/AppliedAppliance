namespace Application.Common.Models
{
    public class DropDownModel<TValue>
    {
        public TValue Value { get; set; }

        public string Label { get; set; }

        public string Description { get; set; }
    }

    public class DropDownModel : DropDownModel<int>
    {
    }
}
