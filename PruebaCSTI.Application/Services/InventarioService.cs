using PruebaCSTI.Domain.Entities;
using PruebaCSTI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaCSTI.Application.Mappers;
using PruebaCSTI.Application.Dtos;
using System.CodeDom;
using System.Data;

namespace PruebaCSTI.Application.Services
{
    public class InventarioService
    {
        private readonly IInventarioRepository _repository;

        public InventarioService(IInventarioRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<InventarioDto> Listar(DateTime? fechaInicio,
                                                    DateTime? fechaFin,
                                                    string tipoMovimiento,
                                                    string nroDocumento)
        {
                    var data = _repository.GetAll(
                fechaInicio,
                fechaFin,
                tipoMovimiento,
                nroDocumento
            );

                    return data.Select(x => MaperInventario.ToDto(x));
        }

        public InventarioDto ObtenerPorId(
            string codCia,
            string companiaVenta3,
            string almacenVenta,
            string tipoMovimiento,
            string tipoDocumento,
            string nroDocumento,
            string codItem2)
        {
            var entity = _repository.GetById(
                codCia,
                companiaVenta3,
                almacenVenta,
                tipoMovimiento,
                tipoDocumento,
                nroDocumento,
                codItem2
            );

            return MaperInventario.ToDto(entity);
        }

        public ResultadoOperacion Crear(InventarioDto input)
        {

            var result = ValidateDataNew(input);

            if (!result.EsValido)
                return result;

            var obj = MaperInventario.ToEntity(input);
            _repository.Insert(obj);

            return ResultadoOperacion.Ok();
        }

        public ResultadoOperacion ValidateDataNew(InventarioDto input)
        {
            ResultadoOperacion data = new ResultadoOperacion();

            if (input == null)
            {
                data.EsValido = false;
                data.Mensaje = "No se tiene información para registrar, verifique";
                return data;
            }
            if (input.CodCia == null)
            {
                data.EsValido = false;
                data.Mensaje = "CodCia esta vacío, verifique";
                return data;
            }
            if (input.CompaniaVenta3 == null)
            {
                data.EsValido = false;
                data.Mensaje = "CompaniaVenta3 esta vacío, verifique";
                return data;
            }
            if (input.AlmacenVenta == null) 
            {
                data.EsValido = false;
                data.Mensaje = "AlmacenVenta esta vacío, verifique";
                return data;
            }

            if (input.TipoMovimiento == null)
            {
                data.EsValido = false;
                data.Mensaje = "TipoMovimiento esta vacío, verifique";
                return data;
            }
            if (input.TipoDocumento == null)
            {
                data.EsValido = false;
                data.Mensaje = "TipoDocumento esta vacío, verifique";
                return data;
            }
            if (input.NroDocumento == null) 
            {
                data.EsValido = false;
                data.Mensaje = "NroDocumento esta vacío, verifique";
                return data;
            }
            if (input.CodItem2 == null)
            {
                data.EsValido = false;
                data.Mensaje = "CodItem2 esta vacío, verifique";
                return data;
            }

            data.EsValido = true;
            data.Mensaje = "La información es válida";
            return data;
        }
        public void Actualizar(InventarioDto input)
        {
            var obj = MaperInventario.ToEntity(input);
            _repository.Update(obj);
        }
        
        public void Eliminar(
            string codCia,
            string companiaVenta3,
            string almacenVenta,
            string tipoMovimiento,
            string tipoDocumento,
            string nroDocumento,
            string codItem2)
        {
            _repository.Delete(
                codCia,
                companiaVenta3,
                almacenVenta,
                tipoMovimiento,
                tipoDocumento,
                nroDocumento,
                codItem2
            );
        }
    }
}
