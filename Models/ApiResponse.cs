using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management_api.Models;
public class ApiResponse<T>
{
    public bool Status { get; set; }
    public string Message { get; set; }
    public string Timestamp { get; set; }
    public T Data { get; set; }

    public ApiResponse(bool status, string message, T data)
    {
        Status = status;
        Message = message;
        Timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
        Data = data;
    }
}