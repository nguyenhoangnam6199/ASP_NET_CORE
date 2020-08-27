using System;

namespace Buoi17_18_19_EFCore_CRUD_AJAX.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
