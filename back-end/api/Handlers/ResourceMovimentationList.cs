using System;

namespace api.Handlers
{
    public class ResourceMovimentationList
    {
        public string User { get; set; }
        public string Resource { get; set; }
        public int Quantity { get; set; }
        public string Date { get; set; }
    }
}