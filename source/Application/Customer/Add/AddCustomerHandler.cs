namespace Architecture.Application;

public sealed record AddCustomerHandler : IHandler<AddCustomerRequest, long>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IResultService _resultService;
    private readonly IUnitOfWork _unitOfWork;

    public AddCustomerHandler
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

    public async Task<Result<long>> HandleAsync(AddCustomerRequest request)
    {
        var customer = new Customer(request.Name);

        await _customerRepository.AddAsync(customer);

        await _unitOfWork.SaveChangesAsync();

        return _resultService.Success(customer.Id);
    }
}
