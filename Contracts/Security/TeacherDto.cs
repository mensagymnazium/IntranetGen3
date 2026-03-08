using FluentValidation;
using MensaGymnazium.IntranetGen3.Contracts.ModelMetadata.Security;

namespace MensaGymnazium.IntranetGen3.Contracts.Security;

public record TeacherDto
{
	public int TeacherId { get; set; }

	public string Name { get; set; }

	public string Email { get; set; }

	/// <summary>
	/// Free-text bio shown on the teacher's profile.
	/// </summary>
	public string FunFact { get; set; }

	/// <summary>
	/// When <c>true</c> the teacher record is soft-deleted; <c>false</c> means active.
	/// </summary>
	public bool IsDeleted { get; set; }

	public class TeacherValidator : AbstractValidator<TeacherDto>
	{
		public TeacherValidator()
		{
			RuleFor(x => x.Name).NotEmpty().MaximumLength(UserMetadata.NameMaxLength).WithName("Jméno");
			RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(UserMetadata.EmailMaxLength).WithName("E-mail");
		}
	}
}
