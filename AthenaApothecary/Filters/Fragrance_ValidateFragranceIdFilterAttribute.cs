using AthenaApothecary.Models.Respositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AthenaApothecary.Filters.ActionFilters
{
    public class Fragrance_ValidateFragranceIdFilterAttribute : ActionFilterAttribute
    {
        
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var fragranceId = context.ActionArguments["id"] as int?;
            if (fragranceId.HasValue)
            {
                if (fragranceId.Value <= 0)
                {
                    context.ModelState.AddModelError("FragranceId", "FragranceId is invalid.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else if (!FragranceRepository.FragranceExists(fragranceId.Value))
                {
                    context.ModelState.AddModelError("FragranceId", "FragranceId does not exist.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(context.ModelState);
                }
            }
        }
    }
}
