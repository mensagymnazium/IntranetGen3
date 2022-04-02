using MensaGymnazium.IntranetGen3.Contracts.Security;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security;
using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.Facades.Security;

[Service]
[Authorize]
public class StudentFacade : IStudentFacade
{
	private readonly IStudentRepository studentRepository;

	public StudentFacade(IStudentRepository studentRepository)
	{
		this.studentRepository = studentRepository;
	}

	public async Task<List<StudentReferenceDto>> GetAllStudentReferencesAsync(CancellationToken cancellationToken = default)
	{
		var data = await studentRepository.GetAllIncludingDeletedAsync(cancellationToken);
		return data.Select(s => new StudentReferenceDto()
		{
			Id = s.Id,
			UserId = s.User.Id,
			Name = s.User.Name,
			GradeId = s.GradeId,
			IsDeleted = (s.Deleted != null)
		}).ToList();
	}
}
