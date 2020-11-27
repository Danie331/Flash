﻿
namespace Flash.Api1.DtoModels.Request
{
    public class PaginationQuery
    {
        public PaginationQuery() { }
        public PaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 100;
    }
}
