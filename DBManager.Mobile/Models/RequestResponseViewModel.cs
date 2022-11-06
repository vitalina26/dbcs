using System.Collections.Generic;

namespace DBManager.Mobile.Models
{
    public class ErrorMessage
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class RequestResponseViewModel
    {
        public bool Succeeded { get; set; }
        public string StatusCode { get; set; }

        public List<ErrorMessage> Errors { get; set; } = new();
    }
}