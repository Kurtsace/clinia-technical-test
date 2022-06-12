using System.Collections.Generic;

namespace TechnicalTest.Project.Pagination
{
    public class PaginationModel
    {

        // Max item count per page 
        const int MaxItemCountPerPage = 50;
        private int _pageSize;

        public int Page { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;

            // Limit items per page to the max 
            set => _pageSize = (value > MaxItemCountPerPage) ? MaxItemCountPerPage : value;
        }
    }
}
