namespace Common.Application.Service
{
    using Common.Application.Dto;
    using System.Collections.Generic;

    public interface IBaseApplicationService<TEntityInput, TEntityOutPut>
    {
        TEntityOutPut Get(int id);
        IList<TEntityOutPut> GetAll();
        PaginationOutputDto GetAll(int page, int pageSize, string sortBy, string sortDirection);

        int Add(TEntityInput entity);

        int Update(int id, TEntityInput entity);

        int Remove(int id);

    }
}
