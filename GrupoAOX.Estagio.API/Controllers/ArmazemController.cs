using GrupoAOX.Estagio.API.DAL;
using System.Web.Http;

namespace GrupoAOX.Estagio.API.Controllers
{
    public class ArmazemController : ApiController
    {
        private readonly ArmazemDAL armazemDAL = new ArmazemDAL();

        [HttpGet]
        public IHttpActionResult GetArmazens(string filial)
        {
            return Ok(armazemDAL.ObterTodos(filial));
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
