using PruebaCSTI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCSTI.Domain.Interfaces
{
    public interface IInventarioRepository
    {
        IEnumerable<Inventario> GetAll(DateTime? fechaInicio,
                                        DateTime? fechaFin,
                                        string tipoMovimiento,
                                        string nroDocumento);

        Inventario GetById(
            string codCia,
            string companiaVenta3,
            string almacenVenta,
            string tipoMovimiento,
            string tipoDocumento,
            string nroDocumento,
            string codItem2
        );

        void Insert(Inventario entity);

        void Update(Inventario entity);

        void Delete(
            string codCia,
            string companiaVenta3,
            string almacenVenta,
            string tipoMovimiento,
            string tipoDocumento,
            string nroDocumento,
            string codItem2
        );
    }
}
