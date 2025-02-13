using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace SM_Horarios;

public class MarkedTimeHandler : IMarkedTimeHandler
{
    private readonly AppDbContext context;
    private readonly IMapper _mapper;

    public async Task<Response<MarkedTimeDTO?>> CreateTDataAsync(MarkedTimeDTO tData)
    {
        try
        {
            if (tData == null)
                return new Response<MarkedTimeDTO?>(400, "Data is null", null);

            var markedTime = _mapper.Map<MarkedTime>(tData);

            await context.MarkedTime.AddAsync(markedTime);
            await context.SaveChangesAsync();

            var markedTimeDTO = _mapper.Map<MarkedTimeDTO>(tData);

            return new Response<MarkedTimeDTO?>(201, "MarkedTime create is success", markedTimeDTO);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<MarkedTimeDTO?>(500, "Internal Error", null);
        }
    }

    public async Task<Response<MarkedTimeDTO?>> DeleteByIdAsync(int id)
    {
        try
        {
            var data = await context.MarkedTime.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return new Response<MarkedTimeDTO?>(404, "MarkedTime not found", null);

            context.MarkedTime.Remove(data);
            await context.SaveChangesAsync();

            return new Response<MarkedTimeDTO?>(204, "MarkedTime delete is success", null);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<MarkedTimeDTO?>(500, "Internal Error", null);
        }
    }

    public async Task<PagedResponse<IEnumerable<MarkedTimeDTO>?>> GetByClientIdAsync(
        int clientId,
        PagedRequest pagedRequest
    )
    {
        try
        {
            var data = await context
                .MarkedTime.Where(x => x.ClientId == clientId)
                .OrderBy(x => x.ClientId)
                .Skip((pagedRequest.PageCount - 1) * pagedRequest.PageSize)
                .Take(pagedRequest.PageSize)
                .ToListAsync();

            if (data is null)
                return new PagedResponse<IEnumerable<MarkedTimeDTO>?>(
                    404,
                    "Client MarkedTime not found",
                    null
                );

            var markedTimeCollection = _mapper.Map<IEnumerable<MarkedTimeDTO>>(data);

            return new PagedResponse<IEnumerable<MarkedTimeDTO>?>(
                200,
                "MarkedTime get is success",
                markedTimeCollection
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new PagedResponse<IEnumerable<MarkedTimeDTO>?>(500, "Internal Error", null);
        }
    }

    public async Task<PagedResponse<IEnumerable<MarkedTimeDTO>?>> GetByEmployeeIdAsync(
        int employeeId,
        PagedRequest pagedRequest
    )
    {
        try
        {
            var data = await context
                .MarkedTime.Where(x => x.EmployeeId == employeeId)
                .OrderBy(x => x.ClientId)
                .Skip((pagedRequest.PageCount - 1) * pagedRequest.PageSize)
                .Take(pagedRequest.PageSize)
                .ToListAsync();

            if (data is null)
                return new PagedResponse<IEnumerable<MarkedTimeDTO>?>(
                    404,
                    "Employee MarkedTime not found",
                    null
                );

            var markedTimeCollection = _mapper.Map<IEnumerable<MarkedTimeDTO>>(data);

            return new PagedResponse<IEnumerable<MarkedTimeDTO>?>(
                200,
                "MarkedTime get is success",
                markedTimeCollection
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new PagedResponse<IEnumerable<MarkedTimeDTO>?>(500, "Internal Error", null);
        }
    }

    public async Task<PagedResponse<IEnumerable<MarkedTimeDTO>?>> GetByFirmIdAsync(
        int firmId,
        PagedRequest pagedRequest
    )
    {
        try
        {
            var data = await context
                .MarkedTime.Where(x => x.FirmId == firmId)
                .OrderBy(x => x.ClientId)
                .Skip((pagedRequest.PageCount - 1) * pagedRequest.PageSize)
                .Take(pagedRequest.PageSize)
                .ToListAsync();

            if (data is null)
                return new PagedResponse<IEnumerable<MarkedTimeDTO>?>(
                    404,
                    "Firm MarkedTime not found",
                    null
                );

            var markedTimeDTOCollection = _mapper.Map<IEnumerable<MarkedTimeDTO>>(data);

            return new PagedResponse<IEnumerable<MarkedTimeDTO>?>(
                200,
                "MarkedTime get is success",
                markedTimeDTOCollection
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new PagedResponse<IEnumerable<MarkedTimeDTO>?>(500, "Internal Error", null);
        }
    }

    public async Task<Response<MarkedTimeDTO?>> GetByIdAsync(int id)
    {
        try
        {
            var data = await context.MarkedTime.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return new Response<MarkedTimeDTO?>(404, "MarkedTime not found", null);

            var markedTimeDTO = _mapper.Map<MarkedTimeDTO>(data);

            return new Response<MarkedTimeDTO?>(200, "MarkedTime get is success", markedTimeDTO);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<MarkedTimeDTO?>(500, "Internal Error", null);
        }
    }

    public async Task<Response<MarkedTimeDTO?>> UpdateByIdAsync(int id, MarkedTimeDTO tData)
    {
        try
        {
            var data = await context.MarkedTime.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return new Response<MarkedTimeDTO?>(404, "MarkedTime not found", null);

            _mapper.Map(tData, data);

            context.MarkedTime.Update(data);
            await context.SaveChangesAsync();

            var markedTime = _mapper.Map<MarkedTimeDTO>(data);
            return new Response<MarkedTimeDTO?>(200, "MarkedTime update is success", markedTime);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<MarkedTimeDTO?>(500, "Internal Error", null);
        }
    }
}
