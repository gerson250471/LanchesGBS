using LanchesGBS.Models;
using LanchesGBS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchesGBS.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Pedido pedido)
        {
            int totalItensPedido = 0;
            decimal precoTotalPedido = 0.0m;

            //Obtem os itens do carrinho de compra do cliente
            List<CarrinhoCompraItem> items = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = items;

            //Verifica se existe intens no pedido
            if (_carrinhoCompra.CarrinhoCompraItems.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho está vazio, que tal incluir um lanche ...");
            }

            // Calcula o total de itens e o total do Pedido
            foreach(var item in items)
            {
                totalItensPedido += item.Quantidade;
                precoTotalPedido += (item.Lanche.Preco * item.Quantidade);
            }

            // Atribuir os valores obtidos ao  pedio
            pedido.TotalItensPedido = totalItensPedido;
            pedido.PedidoTotal=precoTotalPedido;

            // Validar os dados do pedido
            if (ModelState.IsValid)
            {
                // Criar o pedido e os detalhes do pedido
                _pedidoRepository.CriarPedido(pedido);

                // Definir mensagens ao cliente
                ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido :)";
                ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();

                // Limpar o carrinho do cliente
                _carrinhoCompra.LimparCarrinho();

                // Exibe a View com os dados do cliente e do pedido
                return View("~/Views/Pedido/CheckoutCompleto.cshtml",pedido);
            }
            return View(pedido);
        }
    }
}
