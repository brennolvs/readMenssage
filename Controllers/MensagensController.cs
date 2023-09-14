using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SuaAppMensagens.Enums;

namespace ReadMessage.Controllers
{
    [Route("api/mensagens")]
    [ApiController]
    public class MensagensController : ControllerBase
    {
        private List<Mensagem> _mensagens = new List<Mensagem>
        {
            new Mensagem { Id = 1, Texto = "Teste!", Status = Status.NOREAD },
            new Mensagem { Id = 2, Texto = "Teste Api de print para Daniel.", Status = Status.NOREAD }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Mensagem>> GetMensagens()
        {
            return Ok(_mensagens);
        }


        [HttpPut("{id}/mark-as-read")]
        public IActionResult MarcarMensagemComoLida(int id)
        {
            var mensagem = _mensagens.Find(m => m.Id == id);

            if (mensagem == null)
            {
                return NotFound(); // Mensagem não encontrada
            }

            mensagem.Status = Status.READ;
            
            // Idealmente para o verbo put quando tudo da certo,
            // o status retornado deveria ser 0 204 No Content,
            // mas para fins ditáticos, está retornando o 200
            return Ok(mensagem);
        }
        
        
        [HttpPut("{id}/mark-no-read")]
        public IActionResult MarcarMensagemComoNaoLida(int id)
        {
            var mensagem = _mensagens.Find(m => m.Id == id);

            if (mensagem == null)
            {
                return NotFound(); // Mensagem não encontrada
            }

            mensagem.Status = Status.NOREAD;
            // Idealmente para o verbo put quando tudo da certo,
            // o status retornado deveria ser 0 204 No Content,
            // mas para fins ditáticos, está retornando o 200
            return Ok(mensagem); 
        }
    }
}