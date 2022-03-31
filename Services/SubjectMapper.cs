using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.Services;

[Service]
public class SubjectMapper : ISubjectMapper
{
	private readonly IDataLoader dataLoader;
	private readonly IUnitOfWork unitOfWork;

	public SubjectMapper(
		IDataLoader dataLoader,
		IUnitOfWork unitOfWork)
	{
		this.dataLoader = dataLoader;
		this.unitOfWork = unitOfWork;
	}

	public async Task MapFromSubjectDtoAsync(SubjectDto subjectDto, Subject subject, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(subjectDto is not null);
		Contract.Requires<ArgumentNullException>(subject is not null);

		if (subject.Id != default)
		{
			await dataLoader.LoadAsync(subject, s => s.TeacherRelations, cancellationToken);
			await dataLoader.LoadAsync(subject, s => s.TypeRelations, cancellationToken);
			await dataLoader.LoadAsync(subject, s => s.GradeRelations, cancellationToken);
		}

		subject.Name = subjectDto.Name;
		subject.Description = subjectDto.Description;
		subject.CategoryId = subjectDto.CategoryId.Value;
		subject.Capacity = subjectDto.Capacity;
		subject.ScheduleDayOfWeek = subjectDto.ScheduleDayOfWeek.Value;
		subject.ScheduleSlotInDay = subjectDto.ScheduleSlotInDay.Value;

		var teacherRelationsUpdateFromResult = subject.TeacherRelations.UpdateFrom(subjectDto.TeacherIds,
			targetKeySelector: t => t.TeacherId,
			sourceKeySelector: s => s,
			newItemCreateFunc: s => new SubjectTeacherRelation { SubjectId = subject.Id, TeacherId = s },
			updateItemAction: (s, t) => t.TeacherId = s,
			removeItemAction: t => { });
		unitOfWork.AddUpdateFromResult(teacherRelationsUpdateFromResult);

		var typeRelationsUpdateFromResult = subject.TypeRelations.UpdateFrom(subjectDto.SubjectTypeIds,
			targetKeySelector: t => t.SubjectTypeId,
			sourceKeySelector: s => s,
			newItemCreateFunc: s => new SubjectTypeRelation { SubjectId = subject.Id, SubjectTypeId = s },
			updateItemAction: (s, t) => t.SubjectTypeId = s,
			removeItemAction: t => { });
		unitOfWork.AddUpdateFromResult(typeRelationsUpdateFromResult);

		var gradeRelationsUpdateFromResult = subject.GradeRelations.UpdateFrom(subjectDto.GradeIds,
			targetKeySelector: t => t.GradeId,
			sourceKeySelector: s => s,
			newItemCreateFunc: s => new SubjectGradeRelation { SubjectId = subject.Id, GradeId = s },
			updateItemAction: (s, t) => t.GradeId = s,
			removeItemAction: t => { });
		unitOfWork.AddUpdateFromResult(gradeRelationsUpdateFromResult);

	}

	public async Task<SubjectDto> MapToSubjectDtoAsync(Subject subject, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(subject is not null);

		await dataLoader.LoadAsync(subject, s => s.TeacherRelations, cancellationToken);
		await dataLoader.LoadAsync(subject, s => s.GradeRelations, cancellationToken);
		await dataLoader.LoadAsync(subject, s => s.TypeRelations, cancellationToken);

		return new SubjectDto
		{
			SubjectId = subject.Id,
			Name = subject.Name,
			Description = subject.Description,
			CategoryId = subject.CategoryId,
			SubjectTypeIds = subject.TypeRelations.Select(tr => tr.SubjectTypeId).ToList(),
			Capacity = subject.Capacity,
			GradeIds = subject.GradeRelations.Select(tr => tr.GradeId).ToList(),
			TeacherIds = subject.TeacherRelations.Select(tr => tr.TeacherId).ToList(),
			ScheduleSlotInDay = subject.ScheduleSlotInDay,
			ScheduleDayOfWeek = subject.ScheduleDayOfWeek,
		};
	}
}
