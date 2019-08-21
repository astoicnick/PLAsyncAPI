using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace plApi.Filters {
    public class BookResultFilterAttribute : ResultFilterAttribute {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context,
        ResultExecutionDelegate next) {
            var resFromAction = context.Result as ObjectResult;
            await next();
        }
    }
}