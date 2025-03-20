using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace EmployeeServiceAPI;

public class EmployeeRepository(AppDbContext _context, IMapper _mapper) : IEmployeeRepository
{
    public async Task<bool?> DeleteAsync(int id)
    {
        try
        {
            var data = await _context.Employee.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return false;

            _context.Employee.Remove(data);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<IEnumerable<EmployeeDTO>?> GetAllByStatusAsync(StatusEnum statusEnum)
    {
        try
        {
            var data = await _context.Employee.Where(x => x.Status == statusEnum).ToListAsync();

            if (data == null)
                return null;

            var response = _mapper.Map<IEnumerable<EmployeeDTO>>(data);
            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<EmployeeDTO?> GetByCPFAsync(string CPF)
    {
        try
        {
            var data = await _context.Employee.FirstOrDefaultAsync(x => x.Cpf == CPF);
            if (data == null)
                return null;

            var response = _mapper.Map<EmployeeDTO>(data);
            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<EmployeeDTO?> GetByIdAsync(int id)
    {
        try
        {
            var data = await _context.Employee.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return null;

            var response = _mapper.Map<EmployeeDTO>(data);
            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<bool?> PostAsync(EmployeeDTO employeeDTO)
    {
        try
        {
            var data = _mapper.Map<Employee>(employeeDTO);

            await _context.Employee.AddAsync(data);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<EmployeeDTO>(data);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<bool?> PutAsync(EmployeeDTO employeeDTO)
    {
        try
        {
            var data = await _context.Employee.FirstOrDefaultAsync(x => x.Id == employeeDTO.Id);
            if (data == null)
                return null;

            _mapper.Map(employeeDTO, data);

            _context.Employee.Update(data);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<EmployeeDTO>(data);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}
