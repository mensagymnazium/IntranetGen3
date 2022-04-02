using MensaGymnazium.IntranetGen3.Contracts;

namespace MensaGymnazium.IntranetGen3.DataLayer.Queries;

public interface IStudentSubjectRegistrationListQuery
{
	StudentSubjectRegistrationListQueryFilter Filter { get; set; }
	//SortItem[] Sorting { get; set; }

	Task<DataFragmentResult<StudentSubjectRegistrationDto>> GetDataFragmentAsync(int startIndex, int? count, CancellationToken cancellationToken = default);
}