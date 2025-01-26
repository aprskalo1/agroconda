namespace AgrocondaAPI.Exceptions;

public class TokenNotFoundException(string message) : AgrocondaCustomException(message);

public class UnauthorizedException(string message) : AgrocondaCustomException(message);