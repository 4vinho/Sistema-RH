using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace MissionServiceAPI;

public class MissionRepository(AppDbContext _context, IMapper _mapper) : IMissionRepository
{
    public async Task<Response<bool?>> DeleteAsync(int id)
    {
        try
        {
            var data = await _context.Mission.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return new Response<bool?>(404, "Not found!", false);

            _context.Mission.Remove(data);
            await _context.SaveChangesAsync();

            return new Response<bool?>(200, $"{id} Deleted successfully", true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<bool?>(500, "Erro interno", false);
        }
    }

    public async Task<Response<MissionDTO?>> GetByIdAsync(int Id)
    {
        try
        {
            var data = await _context.Mission.FirstOrDefaultAsync(x => x.Id == Id);
            if (data == null)
                return new Response<MissionDTO?>(404, "Not found", null);

            var response = _mapper.Map<MissionDTO>(data);
            return new Response<MissionDTO?>(200, "Search completed successfully", response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<MissionDTO?>(500, "Erro interno", null);
        }
    }

    public async Task<PagedResponse<IEnumerable<MissionDTO>?>> GetByStatusAsync(StatusEnum statusEnum, PagedRequest pagedRequest)
    {
        try
        {
            var query = _context.Mission
                .Where(x => x.Status == statusEnum)
                .OrderBy(x => x.Id);

            var totalItems = await query.CountAsync();

            var data = await query
                .Skip((pagedRequest.PageCount - 1) * pagedRequest.PageSize)
                .Take(pagedRequest.PageSize)
                .ToListAsync();

            if (!data.Any())
                return new PagedResponse<IEnumerable<MissionDTO>?>(404, "Not found!", null, pagedRequest.PageSize, 0);

            var response = _mapper.Map<IEnumerable<MissionDTO>>(data);
            return new PagedResponse<IEnumerable<MissionDTO>?>(200, "Search completed successfully.", response, pagedRequest.PageSize, totalItems);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new PagedResponse<IEnumerable<MissionDTO>?>(500, "Internal server error", null, pagedRequest.PageSize, 0);
        }
    }

    public async Task<PagedResponse<IEnumerable<MissionDTO>?>> GetWorkItemsByEmployeeId(int employeeId, PagedRequest pagedRequest)
    {
        try
        {
            var totalItems = await _context.Mission
                .Where(x => x.EmployeeIds.Contains(employeeId))
                .CountAsync();

            var data = await _context.Mission
                .Where(x => x.EmployeeIds.Contains(employeeId))
                .OrderBy(x => x.StartDate)
                .Skip((pagedRequest.PageCount - 1) * pagedRequest.PageSize)
                .Take(pagedRequest.PageSize)
                .ToListAsync();

            if (!data.Any())
                return new PagedResponse<IEnumerable<MissionDTO>?>(404, "Not found!", null, pagedRequest.PageSize, 0);


            var response = _mapper.Map<IEnumerable<MissionDTO>>(data);
            return new PagedResponse<IEnumerable<MissionDTO>?>(200, "Search completed successfully.", response, pagedRequest.PageSize, totalItems);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new PagedResponse<IEnumerable<MissionDTO>?>(500, "Internal server error", null, pagedRequest.PageSize, 0);
        }
    }

    public async Task<Response<MissionDTO?>> PostAsync(MissionDTO missionDTO)
    {
        try
        {
            var data = _mapper.Map<Mission>(missionDTO);

            await _context.Mission.AddAsync(data);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<MissionDTO>(data);
            return new Response<MissionDTO?>(200, "Post completed successfully", response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<MissionDTO?>(500, "Erro interno", null);
        }
    }

    public async Task<Response<MissionDTO?>> PutAsync(MissionDTO missionDTO)
    {
        try
        {
            var data = await _context.Mission.FirstOrDefaultAsync(x => x.Id == missionDTO.Id);
            if (data == null)
                return new Response<MissionDTO?>(404, "Not found!", null);

            _mapper.Map(missionDTO, data);

            _context.Mission.Update(data);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<MissionDTO>(data);
            return new Response<MissionDTO?>(200, "Put completed successfully", response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<MissionDTO?>(500, "Erro interno", null);
        }
    }
}
