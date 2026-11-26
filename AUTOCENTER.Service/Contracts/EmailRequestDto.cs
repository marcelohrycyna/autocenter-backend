using Microsoft.AspNetCore.Http;

namespace autocenterEmailService.Contracts;

public record EmailRequestDto(
    string Subject,
    string Body,
    List<string>? To,
    List<string>? Cc,
    IFormFileCollection? Attachments
);