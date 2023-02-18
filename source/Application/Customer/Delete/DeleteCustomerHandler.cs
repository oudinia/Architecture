namespace Architecture.Application;

public sealed record DeleteCustomerHandler : IHandler<DeleteCustomerRequest>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IResultService _resultService;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCustomerHandler
    (
        ICustomerRepository customerRepository,
        IResultService resultService,
        IUnitOfWork unitOfWork
    )
    {
        _customerRepository = customerRepository;
        _resultService = resultService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(DeleteCustomerRequest request)
    {
        await _customerRepository.DeleteAsync(request.Id);

        await _unitOfWork.SaveChangesAsync();

        return _resultService.Success();
    }
}
