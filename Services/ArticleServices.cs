using AutoMapper;
using Tashgheel_Api.DATA.DTOs;
using Tashgheel_Api.Entities;
using Tashgheel_Api.Interface;

public interface IArticleServices
{
    Task<(Article? article, string? error)> Create(ArticleForm articleForm);
    Task<(Article? article, string? error)> GetById(Guid id);
    Task<(List<ArticleDto> articles, int? totalCount, string? error)> GetAll(ArticleFilter filter);
    Task<(Article? article, string? error)> Update(Guid id, ArticleUpdate articleUpdate);
    Task<(Article? article, string? error)> Delete(Guid id);
}

public class ArticleServices : IArticleServices
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public ArticleServices(
        IMapper mapper,
        IRepositoryWrapper repositoryWrapper
    )
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<(Article? article, string? error)> Create(ArticleForm articleForm)
    {
        var article = _mapper.Map<Article>(articleForm);
        var response = await _repositoryWrapper.Article.Add(article);
        return response == null ? (null, "Article Couldn't add") : (response, null);
    }

    public async Task<(Article? article, string? error)> GetById(Guid id)
    {
        var article = await _repositoryWrapper.Article.GetById(id);
        if (article == null) return (null, "Article not found");
        return (article, null);
    }

    public async Task<(List<ArticleDto> articles, int? totalCount, string? error)> GetAll(ArticleFilter filter)
    {
        var (articles, totalCount) = await _repositoryWrapper.Article.GetAll<ArticleDto>(
            x => (x.Title.Contains(filter.Title) || filter.Title==null) //&& (x.isMain == filter.isMain || filter.isMain == null)
            ,
            filter.PageNumber, filter.PageSize);        
        return (articles, totalCount, null);
    }

    public async Task<(Article? article, string? error)> Update(Guid id, ArticleUpdate articleUpdate)
    {
        var article = await _repositoryWrapper.Article.GetById(id);
        if (article == null) return (null, "Article not found");
        article = _mapper.Map(articleUpdate, article);
        article = await _repositoryWrapper.Article.Update(article, id);
        return (article, null);
    }

    public async Task<(Article? article, string? error)> Delete(Guid id)
    {
        var article = await _repositoryWrapper.Article.GetById(id);
        if (article == null) return (null, "Article not found");
        await _repositoryWrapper.Article.SoftDelete(id);
        return (article, null);
    }
}