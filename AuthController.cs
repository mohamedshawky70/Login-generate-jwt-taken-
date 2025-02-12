[Route("[controller]")] 
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
	public AuthController(IAuthService authService)
	{
		_authService = authService;
	}
	
														/*public record LogiinRequest
														(
															string email,
															string password
    [HttpPost]													);*/
    public async Task<IActionResult> LoginAsync(LogiinRequest request,CancellationToken cancellationToken)
    {
        var authResult=await _authService.GetTakenAsync(request.email, request.password, cancellationToken);
        return authResult is null ?BadRequest("Ivalid email or password") : Ok(authResult);
	}
}
