using System.Security;
using System.Security.Claims;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories.Security;
using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.Services.Security;

[Service]
public class UserOnboarder : IUserOnboarder
{
	private const string EmailClaimType = "unique_name";

	/// <summary>
	/// Claim type string used to extract display name from ClaimsPrincipal
	/// </summary>
	private const string NameClaimType = "name";

	private readonly IUserRepository userRepository;
	private readonly IUnitOfWork unitOfWork;

	public UserOnboarder(
		IUserRepository userRepository,
		IUnitOfWork unitOfWork)
	{
		this.userRepository = userRepository;
		this.unitOfWork = unitOfWork;
	}

	/// <inheritdoc />
	public async Task<User> TryOnboardUserAsync(Guid oid, ClaimsPrincipal principal, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentException>(principal != null, nameof(principal));

		string email = principal.FindFirst(x => x.Type == EmailClaimType)?.Value;

		if (email == null)
		{
			throw new SecurityException("Email uživatele se nepodařilo vyhodnotit.");
		}

		var user = await userRepository.GetByEmailAsync(email, cancellationToken);
		if (user != null)
		{
			unitOfWork.AddForUpdate(user);
		}
		else
		{
			user = new User();
			unitOfWork.AddForInsert(user);
		}

		user = SetUserFromClaimsPrincipal(user, oid, principal);

		unitOfWork.AddForUpdate(user);

		await unitOfWork.CommitAsync(cancellationToken);

		return user;
	}

	private User SetUserFromClaimsPrincipal(User user, Guid oid, ClaimsPrincipal principal)
	{
		Contract.Requires<ArgumentException>(user != null, nameof(user));

		user.Oid = oid;
		user.Email = principal.FindFirst(x => x.Type == EmailClaimType)?.Value;
		user.Name = principal.FindFirst(x => x.Type == NameClaimType)?.Value;
		return user;
	}

}
