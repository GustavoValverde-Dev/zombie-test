namespace api.Handlers
{
    public class ResourceAdd
    {
        public int ResourceTypeId { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int MinQuantity { get; set; }
        public int MaxQuantity { get; set; }
        public string Observation { get; set; }
    }
}