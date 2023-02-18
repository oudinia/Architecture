namespace Architecture.Application;

public sealed record UpdateCustomerHandler : IHandler<UpdateCustomerRequest>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IResultService _resultService;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCustomerHandler
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

    public async Task<Result> HandleAsync(UpdateCustomerRequest request)
    {
        var customer = new Customer(request.Id, request.Name);

        await _customerRepository.UpdateAsync(customer);

        await _unitOfWork.SaveChangesAsync();

        return _resultService.Success();
    }
}
