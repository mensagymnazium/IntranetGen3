using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.Queries;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Facades;

[Service]
[Authorize]
public class StudentSubjectRegistrationFacade : IStudentSubjectRegistrationFacade
{
	private readonly IStudentSubjectRegistrationListQuery studentSubjectRegistrationListQuery;

	public StudentSubjectRegistrationFacade(
		IStudentSubjectRegistrationListQuery studentSubjectRegistrationListQuery)
	{
		this.studentSubjectRegistrationListQuery = studentSubjectRegistrationListQuery;
	}

	[Authorize(Roles = $"{nameof(Role.Teacher)}, {nameof(Role.Administrator)}")]
	public async Task<DataFragmentResult<StudentSubjectRegistrationDto>> GetStudentSubjectRegistrationListAsync(DataFragmentRequest<StudentSubjectRegistrationListQueryFilter> studentSubjectRegistrationListRequest, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(studentSubjectRegistrationListRequest is not null);

		studentSubjectRegistrationListQuery.Filter = studentSubjectRegistrationListRequest.Filter;
		//studentSubjectRegistrationListQuery.Sorting = studentSubjectRegistrationListRequest.Sorting;

		return await studentSubjectRegistrationListQuery.GetDataFragmentAsync(studentSubjectRegistrationListRequest.StartIndex, studentSubjectRegistrationListRequest.Count, cancellationToken);
	}
}
