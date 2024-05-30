using AutoMapper;
using Tashgheel_Api.DATA.DTOs;
using Tashgheel_Api.Entities;
using Tashgheel_Api.Interface;

namespace Tashgheel_Api.Services;

public interface ICategoryServices
{
    Task<(CategoryDto? category, string? error)> Create(CategoryForm categoryForm);
    Task<(List<CategoryDto> categorys, int? totalCount, string? error)> GetAll(CategoryFilter filter);
    Task<(CategoryDto? category, string? error)> Update(Guid id, CategoryUpdate categoryUpdate);
    Task<(Category? category, string? error)> Delete(Guid id);
}

public class CategoryServices : ICategoryServices
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public CategoryServices(
        IMapper mapper,
        IRepositoryWrapper repositoryWrapper
    )
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }


    public async Task<(CategoryDto? category, string? error)> Create(CategoryForm categoryForm)
    {
        var category = _mapper.Map<Category>(categoryForm);
        var response = await _repositoryWrapper.Category.Add(category);
        return response == null ? (null, "Error") : (_mapper.Map<CategoryDto>(response), null);
        
    }

    public async Task<(List<CategoryDto> categorys, int? totalCount, string? error)> GetAll(CategoryFilter filter)
    {
        var (categorys, totalCount) = await _repositoryWrapper.Category.GetAll<CategoryDto>(
            x =>
                (filter.Name == null || x.Name.Contains(filter.Name))
                && (filter.Type == null || x.Type == filter.Type)
                
            , filter.PageNumber, filter.PageSize);
        
        return (categorys, totalCount, null);
        
    }

    public async Task<(CategoryDto? category, string? error)> Update(Guid id, CategoryUpdate categoryUpdate)
    {
        var category = await _repositoryWrapper.Category.GetById(id);
        if (category == null) return  (null, "Category not found");
        _mapper.Map(categoryUpdate, category);
        var response = await _repositoryWrapper.Category.Update(category);
        return response == null ? (null, "Error") : (_mapper.Map<CategoryDto>(response), null);
    }

    public async Task<(Category? category, string? error)> Delete(Guid id)
    {
        var category = await _repositoryWrapper.Category.GetById(id);
        if (category == null) return  (null, "Category not found");
        var response = await _repositoryWrapper.Category.SoftDelete(id);
        return response == null ? (null, "Error") : (response, null);
    }
}