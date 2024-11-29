using BlazorApp.BL.Services;
using BlazorApp.Model.Entities;
using BlazorApp.Model.Models.Others;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ScoreController(IScoreService scoreService) : ControllerBase
{
    

    [HttpPost("addscore")]
    public async Task<ActionResult<BaseResponseModel>> AddScore(ScoresModel scoresModel)
    {
        try
        {
            var result = await scoreService.AddScoreAsync(scoresModel);
            return Ok(new BaseResponseModel { Success = true, Data = result });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateScore(int id, [FromBody] ScoresModel score)
    {
        if (id != score.ID)
            return BadRequest("ID mismatch");

        try
        {
            var result = await scoreService.UpdateScoreAsync(score);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetScores(int classId, int subjectId, int semesterId)
    {
        try
        {
            var result = await scoreService.GetScoresByClassAndSubjectAsync(classId, subjectId, semesterId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
