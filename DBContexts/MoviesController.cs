using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieHubClientMockChallenge.DBContexts;

[ApiController]
[Authorize]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion(1)]
[Produces("application/json")]
public class MoviesController
{
    
}