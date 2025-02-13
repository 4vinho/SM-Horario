using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace SM_Horarios;

public class ClientHandler(AppDbContext context, IMapper _mapper) : IClientHandler
{
    public async Task<Response<ClientDTO?>> CreateTDataAsync(ClientDTO tData)
    {
        try
        {
            if (tData == null)
                return new Response<ClientDTO?>(400, "Data is null", null);

            var client = _mapper.Map<Client>(tData);

            await context.Client.AddAsync(client);
            await context.SaveChangesAsync();

            var clientDTO = _mapper.Map<ClientDTO>(tData);

            return new Response<ClientDTO?>(201, "Client create is success", clientDTO);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<ClientDTO?>(500, "Internal Error", null);
        }
    }

    public async Task<Response<ClientDTO?>> DeleteByIdAsync(int id)
    {
        try
        {
            var data = await context.Client.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return new Response<ClientDTO?>(404, "Client not found", null);

            context.Client.Remove(data);
            await context.SaveChangesAsync();

            return new Response<ClientDTO?>(204, "Client delete is success", null);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<ClientDTO?>(500, "Internal Error", null);
        }
    }

    public async Task<Response<ClientDTO?>> GetByIdAsync(int id)
    {
        try
        {
            var data = await context.Client.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return new Response<ClientDTO?>(404, "Client not found", null);

            var clientDTO = _mapper.Map<ClientDTO>(data);

            return new Response<ClientDTO?>(200, "Client get is success", clientDTO);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<ClientDTO?>(500, "Internal Error", null);
        }
    }

    public async Task<PagedResponse<IEnumerable<ClientDTO>?>> GetClientByNameAsync(
        string clientName,
        PagedRequest pagedRequest
    )
    {
        try
        {
            var data = await context
                .Client.Where(x => x.Name == clientName)
                .OrderBy(x => x.Name)
                .Skip((pagedRequest.PageCount - 1) * pagedRequest.PageSize)
                .Take(pagedRequest.PageSize)
                .ToListAsync();

            if (!data.Any())
                return new PagedResponse<IEnumerable<ClientDTO>?>(404, "Client not found", null);

            var clientDTOCollection = _mapper.Map<IEnumerable<ClientDTO>>(data);

            return new PagedResponse<IEnumerable<ClientDTO>?>(
                200,
                "Client get is success",
                clientDTOCollection,
                pagedRequest.PageSize,
                pagedRequest.PageCount
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new PagedResponse<IEnumerable<ClientDTO>?>(500, "Internal Error", null);
        }
    }

    public async Task<Response<ClientDTO?>> UpdateByIdAsync(int id, ClientDTO tData)
    {
        try
        {
            var data = await context.Client.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return new Response<ClientDTO?>(404, "Client not found", null);

            _mapper.Map(tData, data);

            context.Client.Update(data);
            await context.SaveChangesAsync();

            var clientDTO = _mapper.Map<ClientDTO>(data);
            return new Response<ClientDTO?>(200, "Client update is success", clientDTO);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<ClientDTO?>(500, "Internal Error", null);
        }
    }
}
