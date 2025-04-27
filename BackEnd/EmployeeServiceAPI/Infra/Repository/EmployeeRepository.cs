using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace EmployeeServiceAPI;

public class EmployeeRepository(AppDbContext _context, IMapper _mapper) : IEmployeeRepository
{
    public async Task<Response<bool?>> DeleteAsync(int id)
    {
        try
        {
            var data = await _context.Employee.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return new Response<bool?>(404, "Not found!", false);

            _context.Employee.Remove(data);
            await _context.SaveChangesAsync();

            return new Response<bool?>(200, $"{id} Deleted successfully", true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<bool?>(500, "Erro interno", false);
        }
    }

    public async Task<PagedResponse<IEnumerable<EmployeeDTO>?>> GetAllByStatusAsync(StatusEnum statusEnum, PagedRequest pagedRequest)
    {
        try
        {
            var query = _context.Employee
                .Where(x => x.Status == statusEnum)
                .OrderBy(x => x.Id);

            var totalItems = await query.CountAsync();

            var data = await query
                .Skip((pagedRequest.PageCount - 1) * pagedRequest.PageSize)
                .Take(pagedRequest.PageSize)
                .ToListAsync();

            if (!data.Any())
                return new PagedResponse<IEnumerable<EmployeeDTO>?>(404, "Not found!", null, pagedRequest.PageSize, 0);

            var response = _mapper.Map<IEnumerable<EmployeeDTO>>(data);
            return new PagedResponse<IEnumerable<EmployeeDTO>?>(200, "Search completed successfully.", response, pagedRequest.PageSize, totalItems);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new PagedResponse<IEnumerable<EmployeeDTO>?>(500, "Internal server error", null, pagedRequest.PageSize, 0);
        }
    }

    public async Task<Response<EmployeeDTO?>> GetByCPFAsync(string CPF)
    {
        try
        {
            var data = await _context.Employee.FirstOrDefaultAsync(x => x.Cpf == CPF);
            if (data == null)
                return new Response<EmployeeDTO?>(404, "Not found!", null);

            var response = _mapper.Map<EmployeeDTO>(data);
            return new Response<EmployeeDTO?>(200, "Search completed successfully", response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<EmployeeDTO?>(500, "Erro interno", null);
        }
    }

    public async Task<Response<EmployeeDTO?>> GetByIdAsync(int id)
    {
        try
        {
            var data = await _context.Employee.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return new Response<EmployeeDTO?>(404, "Not found", null);

            var response = _mapper.Map<EmployeeDTO>(data);
            return new Response<EmployeeDTO?>(200, "Search completed successfully", response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<EmployeeDTO?>(500, "Erro interno", null);
        }
    }

    public async Task<Response<EmployeeDTO?>> PostAsync(EmployeeDTO employeeDTO)
    {
        try
        {
            var data = _mapper.Map<Employee>(employeeDTO);

            await _context.Employee.AddAsync(data);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<EmployeeDTO>(data);
            return new Response<EmployeeDTO?>(200, "Post completed successfully", response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<EmployeeDTO?>(500, "Erro interno", null);
        }
    }

    public async Task<Response<EmployeeDTO?>> PutAsync(EmployeeDTO employeeDTO)
    {
        try
        {
            var data = await _context.Employee.FirstOrDefaultAsync(x => x.Id == employeeDTO.Id);
            if (data == null)
                return new Response<EmployeeDTO?>(404, "Not found", null);

            _mapper.Map(employeeDTO, data);

            _context.Employee.Update(data);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<EmployeeDTO>(data);
            return new Response<EmployeeDTO?>(200, "Put completed successfully", response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<EmployeeDTO?>(500, "Erro interno", null);
        }
    }
}
