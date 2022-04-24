using FluentValidation;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Contracts;

public record StudentSubjectRegistrationCreateDto
{
	public int? SubjectId { get; set; }
	public int? SigningRuleId { get; set; }
	public StudentRegistrationType? RegistrationType { get; set; }

	public virtual void UpdateFrom(StudentSubjectRegistrationDto model)
	{
		this.SubjectId = model.SubjectId;
		this.SigningRuleId = model.SigningRuleId;
		this.RegistrationType = model.RegistrationType;
	}

	public class StudentSubjectRegistrationCreateDtoValidator : AbstractValidator<StudentSubjectRegistrationCreateDto>
	{
		public StudentSubjectRegistrationCreateDtoValidator()
		{
			RuleFor(x => x.SubjectId).NotNull();
			RuleFor(x => x.SigningRuleId).NotNull();
			RuleFor(x => x.RegistrationType).NotNull();
		}
	}

}
