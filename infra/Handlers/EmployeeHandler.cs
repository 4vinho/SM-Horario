using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace SM_Horarios;

public class EmployeeHandler(AppDbContext context, IMapper _mapper) : IEmployeeHandler
{
    public async Task<Response<EmployeeDTO?>> CreateTDataAsync(EmployeeDTO tData)
    {
        try
        {
            if (tData == null)
                return new Response<EmployeeDTO?>(400, "Data is null", null);

            var employee = _mapper.Map<Employee>(tData);

            await context.Employee.AddAsync(employee);
            await context.SaveChangesAsync();

            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);

            return new Response<EmployeeDTO?>(201, "Employee create is success", employeeDTO);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<EmployeeDTO?>(500, "Internal Error", null);
        }
    }

    public async Task<Response<EmployeeDTO?>> DeleteByIdAsync(int id)
    {
        try
        {
            var data = await context.Employee.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return new Response<EmployeeDTO?>(404, "Employee not found", null);

            context.Employee.Remove(data);
            await context.SaveChangesAsync();

            return new Response<EmployeeDTO?>(204, "Employee delete is success", null);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<EmployeeDTO?>(500, "Internal Error", null);
        }
    }

    public async Task<Response<EmployeeDTO?>> GetByIdAsync(int id)
    {
        try
        {
            var data = await context.Employee.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return new Response<EmployeeDTO?>(404, "Employee not found", null);

            var employeeDTO = _mapper.Map<EmployeeDTO>(data);

            return new Response<EmployeeDTO?>(200, "Employee get is success", employeeDTO);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<EmployeeDTO?>(500, "Internal Error", null);
        }
    }

    public async Task<PagedResponse<IEnumerable<EmployeeDTO>?>> GetEmployeesByFirmIdAsync(
        int firmId,
        PagedRequest pagedRequest
    )
    {
        try
        {
            var data = await context
                .Employee.Where(x => x.FirmId == firmId)
                .OrderBy(x => x.Id)
                .Skip((pagedRequest.PageCount - 1) * pagedRequest.PageSize)
                .Take(pagedRequest.PageSize)
                .ToListAsync();

            if (!data.Any())
                return new PagedResponse<IEnumerable<EmployeeDTO>?>(
                    404,
                    "Employee not found",
                    null
                );

            var employeeDTOCollection = _mapper.Map<IEnumerable<EmployeeDTO>>(data);

            return new PagedResponse<IEnumerable<EmployeeDTO>?>(
                200,
                "Employee get is success",
                employeeDTOCollection,
                pagedRequest.PageSize,
                pagedRequest.PageCount
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new PagedResponse<IEnumerable<EmployeeDTO>?>(500, "Internal Error", null);
        }
    }

    public async Task<Response<EmployeeDTO?>> UpdateByIdAsync(int id, EmployeeDTO tData)
    {
        try
        {
            var data = await context.Employee.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return new Response<EmployeeDTO?>(404, "Employee not found", null);

            _mapper.Map(tData, data);

            context.Employee.Update(data);
            await context.SaveChangesAsync();

            var employee = _mapper.Map<EmployeeDTO>(data);
            return new Response<EmployeeDTO?>(200, "Employee update is success", employee);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<EmployeeDTO?>(500, "Internal Error", null);
        }
    }
}
