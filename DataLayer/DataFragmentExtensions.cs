using MensaGymnazium.IntranetGen3.Contracts;

namespace MensaGymnazium.IntranetGen3.DataLayer;

public static class DataFragmentExtensions
{
	public static DataFragmentResult<TItem> ToDataFragmentResult<TItem>(this DataFragment<TItem> source)
	{
		return new DataFragmentResult<TItem>
		{
			Data = source.Data,
			TotalCount = source.TotalCount
		};
	}
}