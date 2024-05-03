using FluentValidation;

namespace MensaGymnazium.IntranetGen3.Contracts;
public record GradeRegistrationCriteriaDto
{
	public int GradeId { get; set; }
	public int RequiredTotalAmountOfDonatedHoursExcludingLanguage { get; set; }
	public bool RequiresCspOrCpValidation { get; set; }
	public int RequiredAmountOfDonatedHoursInAreaCspOrCp { get; set; }
	public bool RequiresForeignLanguage { get; set; }
	public bool CanUseForeignLanguageInsteadOfDonatedHours { get; set; }

	public class GradeRegistrationCriteriaValidator : AbstractValidator<GradeRegistrationCriteriaDto>
	{
		public GradeRegistrationCriteriaValidator()
		{
			RuleFor(c => c.RequiredTotalAmountOfDonatedHoursExcludingLanguage)
				.GreaterThanOrEqualTo(0)
				.WithName("Hodiny v rozvrhu (kromě jazyků)");

			RuleFor(c => c.RequiredAmountOfDonatedHoursInAreaCspOrCp)
				.GreaterThanOrEqualTo(0)
				.WithName("Hodiny v oblasti ČSP/ČP");

			RuleFor(c => c.CanUseForeignLanguageInsteadOfDonatedHours)
				.NotEqual(true)
				.When(c => c.RequiresForeignLanguage)
				.WithMessage("Ročník nemůže vyžadovat jazyk a zároveň ho využít namísto hodin v rozvrhu");
		}
	}
}