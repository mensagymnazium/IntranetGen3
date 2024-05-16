using FluentValidation;

namespace MensaGymnazium.IntranetGen3.Contracts;
public record GradeRegistrationCriteriaDto
{
	public int GradeId { get; set; }
	public int RequiredTotalAmountOfHoursPerWeekExcludingLanguage { get; set; }
	public bool RequiresCsOrCpValidation { get; set; }
	public int RequiredAmountOfHoursPerWeekInAreaCsOrCp { get; set; }
	public bool RequiresForeignLanguage { get; set; }
	public bool CanUseForeignLanguageInsteadOfHoursPerWeek { get; set; }

	public class GradeRegistrationCriteriaValidator : AbstractValidator<GradeRegistrationCriteriaDto>
	{
		public GradeRegistrationCriteriaValidator()
		{
			RuleFor(c => c.RequiredTotalAmountOfHoursPerWeekExcludingLanguage)
				.GreaterThanOrEqualTo(0)
				.WithName("Hodiny v rozvrhu (kromě jazyků)");

			RuleFor(c => c.RequiredAmountOfHoursPerWeekInAreaCsOrCp)
				.GreaterThanOrEqualTo(0)
				.WithName("Hodiny v oblasti ČS/ČP");

			RuleFor(c => c.CanUseForeignLanguageInsteadOfHoursPerWeek)
				.NotEqual(true)
				.When(c => c.RequiresForeignLanguage)
				.WithMessage("Ročník nemůže vyžadovat jazyk a zároveň ho využít namísto hodin v rozvrhu");
		}
	}
}