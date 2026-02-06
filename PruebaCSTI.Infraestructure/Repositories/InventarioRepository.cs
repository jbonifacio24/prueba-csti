using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using PruebaCSTI.Domain.Entities;
using PruebaCSTI.Domain.Interfaces;
using PruebaCSTI.Infraestructure.Data;

namespace PruebaCSTI.Infraestructure.Repositories
{
    public class InventarioRepository : IInventarioRepository
    {
        public IEnumerable<Inventario> GetAll(  DateTime? fechaInicio,
                                                DateTime? fechaFin,
                                                string tipoMovimiento,
                                                string nroDocumento  )
        {
            using (SqlConnection cn = DbConnectionFactory.CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_MOV_INVENTARIO_LISTAR", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros
                cmd.Parameters.AddWithValue("@FECHA_INICIO",
                    (object)fechaInicio ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@FECHA_FIN",
                    (object)fechaFin ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO",
                    string.IsNullOrEmpty(tipoMovimiento) ? (object)DBNull.Value : tipoMovimiento);

                cmd.Parameters.AddWithValue("@NRO_DOCUMENTO",
                    string.IsNullOrEmpty(nroDocumento) ? (object)DBNull.Value : nroDocumento);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    yield return Map(dr);
                }
            }
        }

        public Inventario GetById(
            string codCia,
            string companiaVenta3,
            string almacenVenta,
            string tipoMovimiento,
            string tipoDocumento,
            string nroDocumento,
            string codItem2)
        {
            using (SqlConnection cn = DbConnectionFactory.CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_MOV_INVENTARIO_OBTENER", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@COD_CIA", codCia);
                cmd.Parameters.AddWithValue("@COMPANIA_VENTA_3", companiaVenta3);
                cmd.Parameters.AddWithValue("@ALMACEN_VENTA", almacenVenta);
                cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", tipoMovimiento);
                cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", tipoDocumento);
                cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", nroDocumento);
                cmd.Parameters.AddWithValue("@COD_ITEM_2", codItem2);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                    return Map(dr);

                return null;
            }
        }

        public void Insert(Inventario entity)
        {
            using (SqlConnection cn = DbConnectionFactory.CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_MOV_INVENTARIO_INSERTAR", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                AddParameters(cmd, entity);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Inventario entity)
        {
            using (SqlConnection cn = DbConnectionFactory.CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_MOV_INVENTARIO_ACTUALIZAR", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                AddParameters(cmd, entity);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(
            string codCia,
            string companiaVenta3,
            string almacenVenta,
            string tipoMovimiento,
            string tipoDocumento,
            string nroDocumento,
            string codItem2)
        {
            using (SqlConnection cn = DbConnectionFactory.CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_MOV_INVENTARIO_ELIMINAR", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@COD_CIA", codCia);
                cmd.Parameters.AddWithValue("@COMPANIA_VENTA_3", companiaVenta3);
                cmd.Parameters.AddWithValue("@ALMACEN_VENTA", almacenVenta);
                cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", tipoMovimiento);
                cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", tipoDocumento);
                cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", nroDocumento);
                cmd.Parameters.AddWithValue("@COD_ITEM_2", codItem2);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // 🔹 Métodos privados

        private Inventario Map(SqlDataReader dr)
        {
            return new Inventario
            {
                CodCia = dr["COD_CIA"].ToString(),
                CompaniaVenta3 = dr["COMPANIA_VENTA_3"].ToString(),
                AlmacenVenta = dr["ALMACEN_VENTA"].ToString(),
                TipoMovimiento = dr["TIPO_MOVIMIENTO"].ToString(),
                TipoDocumento = dr["TIPO_DOCUMENTO"].ToString(),
                NroDocumento = dr["NRO_DOCUMENTO"].ToString(),
                CodItem2 = dr["COD_ITEM_2"].ToString(),
                Proveedor = dr["PROVEEDOR"]?.ToString(),
                AlmacenDestino = dr["ALMACEN_DESTINO"]?.ToString(),
                Cantidad = dr["CANTIDAD"] == DBNull.Value ? (int?)null : (int)dr["CANTIDAD"],
                DocRef1 = dr["DOC_REF_1"]?.ToString(),
                DocRef2 = dr["DOC_REF_2"]?.ToString(),
                DocRef3 = dr["DOC_REF_3"]?.ToString(),
                DocRef4 = dr["DOC_REF_4"]?.ToString(),
                DocRef5 = dr["DOC_REF_5"]?.ToString(),
                FechaTransaccion = dr["FECHA_TRANSACCION"] == DBNull.Value
                                    ? (DateTime?)null
                                    : (DateTime)dr["FECHA_TRANSACCION"]
            };
        }

        private void AddParameters(SqlCommand cmd, Inventario e)
        {
            cmd.Parameters.AddWithValue("@COD_CIA", e.CodCia.Trim().ToUpper());
            cmd.Parameters.AddWithValue("@COMPANIA_VENTA_3", e.CompaniaVenta3.Trim().ToUpper());
            cmd.Parameters.AddWithValue("@ALMACEN_VENTA", e.AlmacenVenta.Trim().ToUpper());
            cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", e.TipoMovimiento.Trim().ToUpper());
            cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", e.TipoDocumento.Trim().ToUpper());
            cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", e.NroDocumento.Trim().ToUpper());
            cmd.Parameters.AddWithValue("@COD_ITEM_2", e.CodItem2.Trim().ToUpper());
            cmd.Parameters.AddWithValue("@PROVEEDOR", (object)e.Proveedor ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ALMACEN_DESTINO", (object)e.AlmacenDestino ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CANTIDAD", (object)e.Cantidad ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DOC_REF_1", (object)e.DocRef1 ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DOC_REF_2", (object)e.DocRef2 ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DOC_REF_3", (object)e.DocRef3 ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DOC_REF_4", (object)e.DocRef4 ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DOC_REF_5", (object)e.DocRef5 ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@FECHA_TRANSACCION", (object)e.FechaTransaccion ?? DBNull.Value);
        }
    }
}
