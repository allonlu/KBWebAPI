
using KB.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Application.Services
{
    public interface ICategoryAppService
    {
        CategoryDto Get(Guid id);

        IReadOnlyList<CategoryDto> GetList();

        CategoryDto Add(CategoryCreateDto dto);

        CategoryDto Update(CategoryUpdateDto dto);

        void Delete(Guid id);
    }
}
