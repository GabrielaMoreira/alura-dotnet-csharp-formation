using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface IItemPedidoRepository
    {
        ItemPedido GetItemPedido(int itemPedidoId);
        void RemoveItemPedido(int itemPedidoId);
    }

    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext context) : base(context)
        {
            
        }

        public ItemPedido GetItemPedido(int itemPedidoId)
        {
            return
            dbSets
                .Where(ip => ip.Id == itemPedidoId)
                .SingleOrDefault();
        }

        public void RemoveItemPedido(int itemPedidoId)
        {
            dbSets.Remove(GetItemPedido(itemPedidoId));
            
        }
    }
}
