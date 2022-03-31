using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MensaGymnazium.IntranetGen3.Contracts.ModelMetadata;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Contracts;

public record SubjectDto : SubjectListItemDto
{
	public string Description { get; set; }

	public class SubjectValidator : AbstractValidator<SubjectDto>
	{
		public SubjectValidator()
		{
			RuleFor(x => x.Name).NotEmpty().MaximumLength(SubjectMetadata.NameMaxLength).WithName("Název");
			RuleFor(x => x.Description).NotEmpty().MaximumLength(SubjectMetadata.DescriptionMaxLength).WithName("Popis");
			RuleFor(x => x.CategoryId).NotEmpty().WithName("Kategorie");
			RuleFor(x => x.ScheduleDayOfWeek).NotEmpty().WithName("Den");
			RuleFor(x => x.ScheduleSlotInDay).NotEmpty().WithName("Čas");
		}
	}
}
