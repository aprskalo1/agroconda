namespace AgrocondaAPI.Exceptions;

public class UserNotFoundException(string message) : AgrocondaCustomException(message);