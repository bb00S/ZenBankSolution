using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using ZenCoreService.Models;

namespace ZenCoreService.Filters
{
    public class CustomSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(ZenTransaction))
            {
                schema.Type = "object";
                schema.Properties = new Dictionary<string, OpenApiSchema>
                {
                    { "ID", new OpenApiSchema { Type = "integer" } },
                    { "UserID", new OpenApiSchema { Type = "integer" } },
                    { "Amount", new OpenApiSchema { Type = "number", Format = "decimal" } },
                    { "TransactionDate", new OpenApiSchema { Type = "string", Format = "date-time" } }
                    
                };
                schema.Reference = new OpenApiReference
                {
                    Type = ReferenceType.Schema,
                    Id = "ZenCoreService.Models.Transaction" 
                };
            }
        }
    }
}
