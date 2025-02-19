[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly AuthDbContext _authContext;
    private readonly AcademicDbContext _academicContext;

    public TestController(AuthDbContext authContext, AcademicDbContext academicContext)
    {
        _authContext = authContext;
        _academicContext = academicContext;
    }

    [HttpGet("CheckAuthUsers")]
    public IActionResult CheckAuthUsers()
    {
        var users = _authContext.Users.ToList();
        return Ok(users);
    }

    [HttpGet("CheckAcademicStudents")]
    public IActionResult CheckAcademicStudents()
    {
        var students = _academicContext.Students.ToList();
        return Ok(students);
    }
}
