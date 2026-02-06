using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaCSTI.Domain.Entities;
using PruebaCSTI.Application.Dtos;

namespace PruebaCSTI.Application.Mappers
{
    public static class MaperInventario
    {
        public static InventarioDto ToDto(Inventario entity)
        {
            return new InventarioDto
            {
                CodCia = entity.CodCia,
                CompaniaVenta3 = entity.CompaniaVenta3,
                AlmacenVenta = entity.AlmacenVenta,
                TipoMovimiento = entity.TipoMovimiento,
                TipoDocumento = entity.TipoDocumento,
                NroDocumento = entity.NroDocumento,
                CodItem2 = entity.CodItem2,
                Proveedor = entity.Proveedor,
                AlmacenDestino = entity.AlmacenDestino,
                Cantidad = entity.Cantidad ?? 0,
                DocRef1 = entity.DocRef1,
                DocRef2 = entity.DocRef2,
                DocRef3 = entity.DocRef3,
                DocRef4 = entity.DocRef4,
                DocRef5 = entity.DocRef5,
                FechaTransaccion = entity.FechaTransaccion
            };
        }

        public static Inventario ToEntity(InventarioDto dto)
        {
            return new Inventario
            {
                CodCia = dto.CodCia,
                CompaniaVenta3 = dto.CompaniaVenta3,
                AlmacenVenta = dto.AlmacenVenta,
                TipoMovimiento = dto.TipoMovimiento,
                TipoDocumento = dto.TipoDocumento,
                NroDocumento = dto.NroDocumento,
                CodItem2 = dto.CodItem2,
                Proveedor = dto.Proveedor,
                AlmacenDestino = dto.AlmacenDestino,
                Cantidad = dto.Cantidad ?? 0,
                DocRef1 = dto.DocRef1,
                DocRef2 = dto.DocRef2,
                DocRef3 = dto.DocRef3,
                DocRef4 = dto.DocRef4,
                DocRef5 = dto.DocRef5,
                FechaTransaccion = dto.FechaTransaccion
            };
        }
    }
}
