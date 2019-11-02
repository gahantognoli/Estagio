using GrupoAOX.Estagio.API.DAL;
using System.Web.Http;

namespace GrupoAOX.Estagio.API.Controllers
{
    public class ArmazemController : ApiController
    {
        private readonly ArmazemDAL armazemDAL = new ArmazemDAL();

        [HttpGet]
        public IHttpActionResult GetArmazens(string filial, string parametro, string pesquisa)
        {
            if (string.IsNullOrEmpty(parametro))
                return Ok(armazemDAL.ObterTodos(filial));
            else if(parametro == "codigo")
                return Ok(armazemDAL.ObterPorCodigo(filial, pesquisa));
            else if (parametro == "descricao")
                return Ok(armazemDAL.ObterPorDescricao(filial, pesquisa));

            return NotFound();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                armazemDAL.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
