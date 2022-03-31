using MensaGymnazium.IntranetGen3.Contracts.Security;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security;

namespace MensaGymnazium.IntranetGen3.Facades.Security;

[Service]
[Authorize]
public class TeacherFacade : ITeacherFacade
{
	private readonly ITeacherRepository teacherRepository;

	public TeacherFacade(
		ITeacherRepository teacherRepository)
	{
		this.teacherRepository = teacherRepository;
	}

	public async Task<List<TeacherReferenceDto>> GetAllTeacherReferencesAsync(CancellationToken cancellationToken = default)
	{
		var data = await teacherRepository.GetAllIncludingDeletedAsync(cancellationToken);
		return data.Select(t => new TeacherReferenceDto()
		{
			TeacherId = t.Id,
			UserId = t.User.Id,
			Name = t.User.Name,
			IsDeleted = (t.Deleted != null)
		}).ToList();
	}
}
