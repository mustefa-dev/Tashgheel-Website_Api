using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using TextExtensions;

namespace Tashgheel_Api.Helpers;

public class PascalCaseQueryParameterFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // set all query parameters to be pascal case
        foreach (var parameter in operation.Parameters)
            if (parameter.In == ParameterLocation.Query)
                parameter.Name = parameter.Name.ToCamelCase();
    }
}