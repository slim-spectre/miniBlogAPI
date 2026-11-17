using System.ComponentModel.DataAnnotations;

public class ValidationFilter<T> : IEndpointFilter where T : class
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var argument = context.Arguments.OfType<T>().FirstOrDefault();
        if (argument is null)
        {
            return Results.BadRequest(new { Message = "Invalid request body." });
        }

        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(argument);
        bool isValid = Validator.TryValidateObject(argument, validationContext, validationResults, validateAllProperties: true);

        if (!isValid)
        {
            var errors = validationResults
                .SelectMany(r => r.MemberNames.DefaultIfEmpty(string.Empty), (r, member) => new { member, r.ErrorMessage })
                .GroupBy(x => x.member)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(x => x.ErrorMessage ?? "Validation error").ToArray()
                );

            return Results.ValidationProblem(errors);
        }

        return await next(context);
    }
}