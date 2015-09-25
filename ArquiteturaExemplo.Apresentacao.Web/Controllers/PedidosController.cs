using ArquiteturaExemplo.Aplicacao.Interfaces;
using ArquiteturaExemplo.Dominio.Entidades;
using ArquiteturaExemplo.Apresentacao.Web.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArquiteturaExemplo.Apresentacao.Web.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IPedidoAppService _pedidoAppService;

        public PedidosController(IPedidoAppService pedidoAppService)
        {
            _pedidoAppService = pedidoAppService;
        }

        // GET: Pedidos
        public ActionResult Index()
        {
            // Controller tão enxuto que não precisa de muitos comentários
            var pedidos = _pedidoAppService.Listar();
            var model = Mapper.Map<IEnumerable<Pedido>, IEnumerable<PedidoViewModel>>(pedidos);
            return View(model);
        }

        // GET: Pedidos/Details/5
        public ActionResult Details(int id)
        {
            var pedido = _pedidoAppService.Consultar(id);
            var model = Mapper.Map<Pedido, PedidoViewModel>(pedido);
            return View(model);
        }

        // GET: Pedidos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pedidos/Create
        [HttpPost]
        public ActionResult Create(PedidoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var pedido = Mapper.Map<PedidoViewModel, Pedido>(viewModel);
                _pedidoAppService.Incluir(pedido);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Pedidos/Edit/5
        public ActionResult Edit(int id)
        {
            var pedido = _pedidoAppService.Consultar(id);
            var viewModel = Mapper.Map<Pedido, PedidoViewModel>(pedido);
            return View(viewModel);
        }

        // POST: Pedidos/Edit/5
        [HttpPost]
        public ActionResult Edit(PedidoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var pedido = Mapper.Map<PedidoViewModel, Pedido>(viewModel);
                _pedidoAppService.Alterar(pedido);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int id)
        {
            var viewModel = Mapper.Map<Pedido, PedidoViewModel>(_pedidoAppService.Consultar(id));
            return View(viewModel);
        }

        // POST: Pedidos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PedidoViewModel viewModel)
        {
            if (id > 0)
            {
                var pedido = _pedidoAppService.Consultar(id);
                _pedidoAppService.Excluir(pedido);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Pedidos/Cancelar/5
        public ActionResult Cancelar(int id)
        {
            if (id > 0)
            {
                var pedido = _pedidoAppService.Consultar(id);
                _pedidoAppService.CancelarPedido(pedido);
            }
            return RedirectToAction("Index");
        }

    }
}
