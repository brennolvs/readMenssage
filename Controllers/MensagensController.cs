using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ReadMessage.Controllers
{
    [Route("api/mensagens")]
    [ApiController]
    public class MensagensController : ControllerBase
    {
        private List<Mensagem> _mensagens = new List<Mensagem>
        {
            new Mensagem { Id = 1, Texto = "Teste!", IsRead = true },
            new Mensagem { Id = 2, Texto = "Teste Api de print para Daniel.", IsRead = false }
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

            mensagem.IsRead = true;
            return Ok(); // Operação bem-sucedida
        }
    }
}
