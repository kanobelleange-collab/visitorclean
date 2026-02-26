using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.Visite.Dtos;
using visitorclean.Application.Feature.Visite.Dtos.ServiceDto;
namespace visitorclean.Application.Feature.Visite.Interfaces;
public interface IVisitRepository{

Task<List<VisitDto?>>GetAllAsync();
Task<VisitDto?>GetByDateAsync(DateTime Date);
    Task<VisitDto?> GetByIdAsync(int Id);
    Task<VisitDto> AddAsync(Visit visit);
    Task<VisitDto?> UpdateAsync(Visit visit);
    Task<Visit?> DeleteAsync(int Id);
    Task<List<ServiceDto>> GetVisitCountByServiceStatutAsync();
    }