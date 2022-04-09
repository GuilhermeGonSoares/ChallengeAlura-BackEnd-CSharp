using ChallengeAluraBackEnd.Data;
using ChallengeAluraBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAluraBackEnd.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class VideosController : ControllerBase
    {
        private readonly VideoContext _context;

        public VideosController(VideoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Video>>> RecuperarVideos()
        {
            return Ok(await _context.Videos.ToListAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> RecuperarVideoPorId(int id)
        {
            var video = await _context.Videos.FindAsync(id); 
            if(video is null)
                return NotFound();
            return video;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarVideo(Video novoVideo)
        {
            _context.Videos.Add(novoVideo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(RecuperarVideoPorId), new {id = novoVideo.Id}, novoVideo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarVideo(int id, Video novoVideo)
        {
            var video = await _context.Videos.SingleOrDefaultAsync(v => v.Id == id);
            if(video is null)
                return NotFound();
                
            video.Titulo = novoVideo.Titulo;
            video.Descricao = novoVideo.Descricao;
            video.Url = novoVideo.Url;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarVideo(int id)
        {
            var video = await _context.Videos.SingleOrDefaultAsync(v => v.Id == id);
            if (video is null)
                return NotFound();
            _context.Remove(video);
            await _context.SaveChangesAsync();
            return Ok();

        }

    }
}