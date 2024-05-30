using System.Text.Json;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Tweetinvi.Models;

namespace Tashgheel.Core.Helpers;

public class ErrorResponseException : Exception
{
    private string? MessageEnglish { get; set; }
    private string? MessageArabic { get; set; }

    public ErrorResponseException(string? messageEnglish, string? messageArabic) : base(messageEnglish)
    {
        MessageEnglish = messageEnglish;
        MessageArabic = messageArabic;
    }

    public static string GenerateErrorResponse(string englishMessage, string arabicMessage, string language)
    {
        var message = language == "ar" ? arabicMessage : englishMessage;
        return message;
    }

    private object ToObject(string language)
    {
        var message = language == "ar" ? MessageArabic : MessageEnglish;

        return new
        {
            Message = message
        };
    }
}