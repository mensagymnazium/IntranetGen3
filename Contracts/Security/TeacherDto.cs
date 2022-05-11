using FluentValidation;
using MensaGymnazium.IntranetGen3.Contracts.ModelMetadata.Security;

namespace MensaGymnazium.IntranetGen3.Contracts.Security;
public record TeacherDto
{
	public int Id { get; set; }
	public int UserId { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public string FunFact { get; set; }

	public void UpdateFrom(TeacherDto other)
	{
		this.Id = other.Id;
		this.UserId = other.UserId;
		this.Name = other.Name;
		this.Email = other.Email;
		this.FunFact = other.FunFact;
	}

	public class TeacherValidator : AbstractValidator<TeacherDto>
	{
		public TeacherValidator()
		{
			RuleFor(t => t.Name).NotEmpty().MaximumLength(UserMetadata.NameMaxLength).WithName("Jméno");
			RuleFor(t => t.Email).NotEmpty().EmailAddress().MaximumLength(UserMetadata.EmailMaxLength).WithName("Email");
			RuleFor(t => t.FunFact).MaximumLength(TeacherMetadata.FunFactMaxLength).WithName("Fun Fact");
		}
	}
}
