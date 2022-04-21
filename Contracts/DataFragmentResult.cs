using ProtoBuf;

namespace MensaGymnazium.IntranetGen3.Contracts;

[ProtoContract]
public class DataFragmentResult<TItem>
{
	[ProtoMember(1)]
	public List<TItem> Data { get; init; }

	[ProtoMember(2)]
	public int TotalCount { get; init; }
}
