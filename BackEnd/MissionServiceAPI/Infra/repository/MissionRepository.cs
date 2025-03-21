using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace MissionServiceAPI;

public class MissionRepository(AppDbContext _context, IMapper _mapper) : IMissionRepository
{
    public async Task<bool?> DeleteAsync(int id)
    {
        try
        {
            var data = await _context.Mission.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return false;

            _context.Mission.Remove(data);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<MissionDTO?> GetByIdAsync(int Id)
    {
        try
        {
            var data = await _context.Mission.FirstOrDefaultAsync(x => x.Id == Id);
            if (data == null)
                return null;

            var response = _mapper.Map<MissionDTO>(data);
            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<IEnumerable<MissionDTO>?> GetByStatusAsync(StatusEnum statusEnum)
    {
        try
        {
            var data = await _context.Mission.Where(x => x.Status == statusEnum).ToListAsync();

            if (data == null)
                return null;

            var response = _mapper.Map<IEnumerable<MissionDTO>>(data);
            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<IEnumerable<MissionDTO>?> GetWorkItemsByEmployeeId(int employeeId)
    {
        try
        {
            var data = await _context
                .Mission.Where(x => x.EmployeeIds.Contains(employeeId))
                .ToListAsync();

            if (data == null)
                return null;

            var response = _mapper.Map<IEnumerable<MissionDTO>>(data);
            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<bool?> PostAsync(MissionDTO missionDTO)
    {
        try
        {
            var data = _mapper.Map<Mission>(missionDTO);

            await _context.Mission.AddAsync(data);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<MissionDTO>(data);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<bool?> PutAsync(MissionDTO missionDTO)
    {
        try
        {
            var data = await _context.Mission.FirstOrDefaultAsync(x => x.Id == missionDTO.Id);
            if (data == null)
                return null;

            _mapper.Map(missionDTO, data);

            _context.Mission.Update(data);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<MissionDTO>(data);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}
