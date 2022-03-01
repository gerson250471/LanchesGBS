using LanchesGBS.Context;
using LanchesGBS.Models;
using LanchesGBS.Repositories.Interfaces;

namespace LanchesGBS.Repositories
{
    public class PedidoRepository :IPedidoRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext appDbContext, CarrinhoCompra carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
            _appDbContext = appDbContext;
        }

        public void CriarPedido(Pedido pedido)
        {
            // Criar Id do pedido para poder persistir os detalhes do pedido de compra
            pedido.PedidoEnviado = DateTime.Now;
            _appDbContext.Pedidos.Add(pedido);
            _appDbContext.SaveChanges();

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItems;

            foreach(var carrinhoItem in carrinhoCompraItens)
            {
                var pedidoDetail = new PedidoDetalhe()
                {
                    Quantidade=carrinhoItem.Quantidade,
                    LancheId=carrinhoItem.Lanche.LancheId,
                    PedidoDetalheId=pedido.PedidoId,  // Neste ponto que era necessário o Id do Pedido
                    Preco=carrinhoItem.Lanche.Preco
                };

                _appDbContext.PedidoDetalhes.Add(pedidoDetail);
            }
            _appDbContext.SaveChanges();
        }
    }
}
