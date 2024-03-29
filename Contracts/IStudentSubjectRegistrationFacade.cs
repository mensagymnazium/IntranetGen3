﻿namespace MensaGymnazium.IntranetGen3.Contracts;

[ApiContract]
public interface IStudentSubjectRegistrationFacade
{
	Task<DataFragmentResult<StudentSubjectRegistrationDto>> GetStudentSubjectRegistrationListAsync(DataFragmentRequest<StudentSubjectRegistrationListQueryFilter> studentSubjectRegistrationListRequest, CancellationToken cancellationToken = default);
	Task<Dto<int>> CreateRegistrationAsync(StudentSubjectRegistrationDto registrationDto, CancellationToken cancellationToken = default);
	Task UpdateRegistrationAsync(StudentSubjectRegistrationDto registrationDto, CancellationToken cancellationToken = default);
	Task DeleteRegistrationAsync(Dto<int> registrationIdDto, CancellationToken cancellationToken = default);
}