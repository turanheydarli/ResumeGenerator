namespace Application.Models;

public class ResumeResult
{
    public ResumeResult(bool success, string message, string pdfPath)
    {
        Success = success;
        Message = message;
        PdfPath = pdfPath;
    }
    public ResumeResult(bool success, string message)
    {
        Success = success;
        Message = message;
    }
    public bool Success { get; set; }
    public string Message { get; set; }
    public string PdfPath { get; set; }
}