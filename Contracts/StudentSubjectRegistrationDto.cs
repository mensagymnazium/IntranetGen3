using FluentValidation;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Contracts;

public record StudentSubjectRegistrationDto : StudentSubjectRegistrationCreateDto
{
	public int Id { get; set; }
	public int? StudentId { get; set; }
	public DateTime Created { get; set; }

	public override void UpdateFrom(StudentSubjectRegistrationDto model)
	{
		base.UpdateFrom(model);

		this.StudentId = model.StudentId;
		this.Created = model.Created;
	}

	public class StudentSubjectRegistrationDtoValidator : AbstractValidator<StudentSubjectRegistrationDto>
	{
		public StudentSubjectRegistrationDtoValidator()
		{
			RuleFor(x => x.SubjectId).NotNull().WithName("Předmět");
			RuleFor(x => x.RegistrationType).NotNull().WithName("Typ zápisu");
			RuleFor(x => x.StudentId).NotNull().WithName("Student");
		}
	}
}
