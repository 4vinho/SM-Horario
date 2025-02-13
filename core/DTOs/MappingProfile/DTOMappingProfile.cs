using AutoMapper;

namespace SM_Horarios;

public class DTOMappingProfile : Profile
{
    public DTOMappingProfile()
    {
        CreateMap<Client, ClientDTO>().ReverseMap();
        CreateMap<Employee, EmployeeDTO>().ReverseMap();
        CreateMap<Firm, FirmDTO>().ReverseMap();
        CreateMap<MarkedTime, MarkedTimeDTO>().ReverseMap();
    }
}
