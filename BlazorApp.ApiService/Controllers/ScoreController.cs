using BlazorApp.BL.Services;
using BlazorApp.Model.Entities;
using BlazorApp.Model.Models.Others;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly IScoresService _scoresService;

        // Constructor nhận vào IScoresService qua dependency injection
        public ScoresController(IScoresService scoresService)
        {
            _scoresService = scoresService;
        }

        // GET: api/Scores
        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetScores()
        {
            var scores = await _scoresService.GetScores();
            return Ok(new BaseResponseModel { Success = true, Data = scores });
        }

        // GET: api/Scores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel>> GetScore(int id)
        {
            var score = await _scoresService.GetScore(id);

            if (score == null)
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy điểm số" });
            }

            return Ok(new BaseResponseModel { Success = true, Data = score });
        }

        // GET: api/Scores/getbystudentandsubject/1/2/1
        [HttpGet("getbystudentandsubject/{studentId}/{subjectId}/{semester}")]
        public async Task<ActionResult<BaseResponseModel>> GetScoreByStudentAndSubject(int studentId, int subjectId, int semester)
        {
            var score = await _scoresService.GetScoreByStudentAndSubject(studentId, subjectId, semester);

            if (score == null)
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy điểm số cho học sinh và môn học này trong học kỳ" });
            }

            return Ok(new BaseResponseModel { Success = true, Data = score });
        }

        // POST: api/Scores
        [HttpPost]
        public async Task<ActionResult<BaseResponseModel>> CreateScore(ScoresModel scoresModel)
        {
            var createdScore = await _scoresService.CreateScore(scoresModel);
            return Ok(new BaseResponseModel { Success = true, Data = createdScore });
        }

        // PUT: api/Scores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateScore(int id, ScoresModel scoresModel)
        {
            if (id != scoresModel.ID || !await _scoresService.ScoreExists(id))
            {
                return BadRequest(new BaseResponseModel { Success = false, ErrorMessage = "Yêu cầu không hợp lệ" });
            }

            await _scoresService.UpdateScore(scoresModel);
            return Ok(new BaseResponseModel { Success = true });
        }

        // DELETE: api/Scores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScore(int id)
        {
            if (!await _scoresService.ScoreExists(id))
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy điểm số" });
            }

            await _scoresService.DeleteScore(id);
            return Ok(new BaseResponseModel { Success = true });
        }
    }
}

