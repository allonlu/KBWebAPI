using KB.Application.Categories.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Application.Categories.Service
{
    public interface ICategoryAppService
    {
        CategoryDto Add(CategoryCreateDto dto);

        void Delete(Guid id);
    }
}
