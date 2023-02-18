namespace Architecture.Application;

public sealed record GetCustomerHandler : IHandler<GetCustomerRequest, CustomerModel>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IResultService _resultService;

    public GetCustomerHandler
    (
        ICustomerRepository customerRepository,
        IResultService resultService
    )
    {
        _customerRepository = customerRepository;
        _resultService = resultService;
    }

    public async Task<Result<CustomerModel>> HandleAsync(GetCustomerRequest request)
    {
        var customer = await _customerRepository.GetModelAsync(request.Id);

        return _resultService.Success(customer);
    }
}
