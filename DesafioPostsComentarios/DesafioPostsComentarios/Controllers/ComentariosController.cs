using DesafioPostsComentarios.Application.Comentarios;
using DesafioPostsComentarios.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DesafioPostsComentarios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComentariosController : ControllerBase
    {
        private readonly DesafioPostsComentariosContext _context;

        public ComentariosController(DesafioPostsComentariosContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult InserirComentarios([FromBody] ComentariosRequest request)
        {
            var comentariosService = new ComentariosService(_context);
            var comentarioAdicionado = comentariosService.AdicionarComentario(request);

            if(comentarioAdicionado.status)
            {
                return Ok(comentarioAdicionado);
            }

            else
            {
                return BadRequest(comentarioAdicionado);
            }     
        }

        [HttpGet]
        public IActionResult BuscarComentarios()
        {
            var comentariosService = new ComentariosService(_context);
            var comentarios = comentariosService.BuscarComentarios();

            if(comentarios != null)
            {
                return Ok(comentarios);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizarComentario([FromRoute]int id, [FromBody] ComentariosRequest request)
        {
            var comentariosService = new ComentariosService(_context);
            var comentarioAtualizado = comentariosService.AtualizarComentario(id, request);
            if (comentarioAtualizado == true)
            {
                return NoContent();
            }
            else 
            { 
                return BadRequest(); 
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletarComentario(int id)
        {
            var comentarioService = new ComentariosService(_context);
            var comentarioDeletado = comentarioService.DeletarComentario(id);
            if (comentarioDeletado == true)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
