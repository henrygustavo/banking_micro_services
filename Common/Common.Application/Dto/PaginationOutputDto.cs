namespace Common.Application.Dto
{
    using System.Collections;
    using System;

    public class PaginationOutputDto
    {
        public IList Content { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int TotalRecords { get; set; }

        public int TotalPages => (int)Math.Ceiling((decimal)TotalRecords / PageSize);

    }
}
