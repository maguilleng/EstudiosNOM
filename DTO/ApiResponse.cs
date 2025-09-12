using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ApiResponse<T>
    {
        public bool IsSuccesfull { get; set; }
        public T ResponseData { get; set; }
        public string ErrorDetails { get; set; }
    }
}
