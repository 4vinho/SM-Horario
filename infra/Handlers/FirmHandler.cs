using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace SM_Horarios;

public class FirmHandler : IFirmHandler
{
    private readonly AppDbContext context;
    private readonly IMapper _mapper;

    public async Task<Response<FirmDTO?>> CreateTDataAsync(FirmDTO tData)
    {
        try
        {
            if (tData == null)
                return new Response<FirmDTO?>(400, "Data is null", null);

            var firm = _mapper.Map<Firm>(tData);

            await context.Firm.AddAsync(firm);
            await context.SaveChangesAsync();

            var firmDTO = _mapper.Map<FirmDTO>(firm);

            return new Response<FirmDTO?>(201, "Firm create is success", firmDTO);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<FirmDTO?>(500, "Internal Error", null);
        }
    }

    public async Task<Response<FirmDTO?>> DeleteByIdAsync(int id)
    {
        try
        {
            var data = await context.Firm.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return new Response<FirmDTO?>(404, "Firm not found", null);

            context.Firm.Remove(data);
            await context.SaveChangesAsync();

            return new Response<FirmDTO?>(204, "Firm delete is success", null);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<FirmDTO?>(500, "Internal Error", null);
        }
    }

    public async Task<Response<FirmDTO?>> GetByIdAsync(int id)
    {
        try
        {
            var data = await context.Firm.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return new Response<FirmDTO?>(404, "Firm not found", null);

            var firm = _mapper.Map<FirmDTO>(data);

            return new Response<FirmDTO?>(200, "Firm get is success", firm);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<FirmDTO?>(500, "Internal Error", null);
        }
    }

    public async Task<PagedResponse<IEnumerable<FirmDTO>?>> GetByNameAsync(
        string name,
        PagedRequest pagedRequest
    )
    {
        try
        {
            var data = await context
                .Firm.Where(x => x.Name == name)
                .OrderBy(x => x.Name)
                .Skip((pagedRequest.PageCount - 1) * pagedRequest.PageSize)
                .Take(pagedRequest.PageSize)
                .ToListAsync();

            if (data is null)
                return new PagedResponse<IEnumerable<FirmDTO>?>(404, "Firm not found", null);

            var firmDTOCollection = _mapper.Map<IEnumerable<FirmDTO>>(data);

            return new PagedResponse<IEnumerable<FirmDTO>?>(
                200,
                "Firm get is success",
                firmDTOCollection
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new PagedResponse<IEnumerable<FirmDTO>?>(500, "Internal Error", null);
        }
    }

    public async Task<Response<FirmDTO?>> UpdateByIdAsync(int id, FirmDTO tData)
    {
        try
        {
            var data = await context.Firm.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return new Response<FirmDTO?>(404, "Firm not found", null);

            _mapper.Map(tData, data);

            context.Firm.Update(data);
            await context.SaveChangesAsync();

            var firm = _mapper.Map<FirmDTO>(data);
            return new Response<FirmDTO?>(200, "Firm update is success", firm);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<FirmDTO?>(500, "Internal Error", null);
        }
    }
}
