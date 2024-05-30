namespace Tashgheel_Api.DATA.DTOs.GenericDataUpdate;

public class GenericDataUpdateDto <T>
{
    public string Event { get; set; } 
    public T Data { get; set; }
}

  
    
    