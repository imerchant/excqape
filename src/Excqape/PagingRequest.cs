using System;

namespace Excqape
{
	public class PagingRequest
	{
		public int PageIndex { get; set; }
		public int PageSize { get; set; }

		public PagingRequest() : this(1, 12)
		{
		}

		public PagingRequest(int pageIndex, int pageSize)
		{
			if (pageIndex < 0) throw new ArgumentOutOfRangeException(nameof(pageIndex), "Page Index must be greater than 0.");
			if (pageSize <= 0) throw new ArgumentOutOfRangeException(nameof(pageSize), "Page Size must be greater than 0.");

			PageIndex = pageIndex;
			PageSize = pageSize;
		}
	}
}