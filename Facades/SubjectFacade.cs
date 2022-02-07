using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Havit.Data.Patterns.UnitOfWorks;
using Havit.Diagnostics.Contracts;
using Havit.Extensions.DependencyInjection.Abstractions;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.Queries;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;
using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Services;
using Microsoft.AspNetCore.Authorization;

namespace MensaGymnazium.IntranetGen3.Facades
{
	[Service]
	[Authorize]
	public class SubjectFacade : ISubjectFacade
	{
		private readonly ISubjectListQuery subjectListQuery;
		private readonly ISubjectRepository subjectRepository;
		private readonly IUnitOfWork unitOfWork;
		private readonly ISubjectMapper subjectMapper;

		public SubjectFacade(
			ISubjectListQuery subjectListQuery,
			ISubjectRepository subjectRepository,
			IUnitOfWork unitOfWork,
			ISubjectMapper subjectMapper)
		{
			this.subjectListQuery = subjectListQuery;
			this.subjectRepository = subjectRepository;
			this.unitOfWork = unitOfWork;
			this.subjectMapper = subjectMapper;
		}

		public async Task<DataFragmentResult<SubjectListItemDto>> GetSubjectListAsync(DataFragmentRequest<SubjectListQueryFilter> subjectListRequest, CancellationToken cancellationToken = default)
		{
			Contract.Requires<ArgumentNullException>(subjectListRequest is not null, nameof(subjectListRequest));

			subjectListQuery.Filter = subjectListRequest.Filter;
			//subjectListQuery.Sorting = subjectListRequest.Sorting;

			return await subjectListQuery.GetDataFragmentAsync(subjectListRequest.StartIndex, subjectListRequest.Count, cancellationToken);
		}

		public async Task<SubjectDto> GetSubjectDetailAsync(Dto<int> subjectIdDto, CancellationToken cancellationToken = default)
		{
			Contract.Requires<ArgumentException>(subjectIdDto.Value != default, nameof(subjectIdDto));

			var subject = await subjectRepository.GetObjectAsync(subjectIdDto.Value, cancellationToken);

			return subjectMapper.MapToSubjectDto(subject);
		}

		public async Task<Dto<int>> CreateSubjectAsync(SubjectDto subjectDto, CancellationToken cancellationToken = default)
		{
			Contract.Requires<ArgumentNullException>(subjectDto != null, nameof(SubjectDto));
			Contract.Requires<ArgumentException>(subjectDto.Id == null, nameof(SubjectDto.Id));

			var subject = new Subject();
			subjectMapper.MapFromSubjectDto(subjectDto, subject);

			unitOfWork.AddForInsert(subject);
			await unitOfWork.CommitAsync(cancellationToken);

			return Dto.FromValue(subject.Id);
		}

		public async Task UpdateSubjectAsync(SubjectDto subjectDto, CancellationToken cancellationToken = default)
		{
			Contract.Requires<ArgumentNullException>(subjectDto != null, nameof(SubjectDto));
			Contract.Requires<ArgumentException>(subjectDto.Id != null, nameof(SubjectDto.Id));

			var subject = await subjectRepository.GetObjectAsync(subjectDto.Id.Value, cancellationToken);

			subject.Name = subjectDto.Name;

			unitOfWork.AddForUpdate(subject);
			await unitOfWork.CommitAsync(cancellationToken);
		}

		public async Task DeleteSubjectAsync(Dto<int> subjectIdDto, CancellationToken cancellationToken = default)
		{
			var subject = subjectRepository.GetObjectAsync(subjectIdDto.Value, cancellationToken);
			unitOfWork.AddForDelete(subject);

			await unitOfWork.CommitAsync(cancellationToken);
		}
	}
}
