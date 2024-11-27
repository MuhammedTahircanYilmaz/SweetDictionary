namespace Core.Exceptions.NotFound;

public class NotFoundException(string? message) : Exception(message);
