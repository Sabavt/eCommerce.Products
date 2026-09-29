using AutoMapper; 

namespace eCommerce.Core.Services;

public abstract class BaseService
{ 
    protected readonly IMapper _mapper;

    public BaseService(IMapper mapper)
    { 
        _mapper = mapper;
    } 
}
