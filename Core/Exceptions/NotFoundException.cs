namespace Exceptions;

public class NotFoundException(string msg) : BaseBusinessException(msg);