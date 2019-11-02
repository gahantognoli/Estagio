using GrupoAox.Estagio.Domain.Interfaces.Servicos;
using GrupoAOX.Estagio.Application.Interfaces;
using GrupoAOX.Estagio.Application.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GrupoAOX.Estagio.MVC.Controllers
{
    [Authorize]
    public class LoteController : Controller
    {
        private readonly ILoteAppServices _loteAppServices;
        private readonly IEntitySerializationServices<IEnumerable<int_exp_Etiqueta_ProducaoViewModel>> _entitySerializationServices;

        public LoteController(ILoteAppServices loteAppServices,
            IEntitySerializationServices<IEnumerable<int_exp_Etiqueta_ProducaoViewModel>> entitySerializationServices)
        {
            _loteAppServices = loteAppServices;
            _entitySerializationServices = entitySerializationServices;
        }

        public ActionResult Descartar()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Descartar(string requisicao)
        {
            var lotes = _entitySerializationServices.Deserialize(requisicao);
            foreach (var lote in lotes)
            {
                var retornoLotes = _loteAppServices.AtualizarStatus(lote.ApontamentoProducaoId, 9);
            }
            return Json(new { retorno = lotes }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObterLote(string numLote)
        {
            var lote = _loteAppServices.ObterPorLote(numLote);
            return Json(new { retorno = lote }, JsonRequestBehavior.AllowGet);
        }
    }
}