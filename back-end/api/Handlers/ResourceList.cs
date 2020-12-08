using System;


namespace api.Handlers
{
    public class ResourceList
    {
        public string ResourceTypeName { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int MinQuantity { get; set; }
        public int MaxQuantity { get; set; }
        public int Quantity { get; set; }
        public string Observation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
    }
}