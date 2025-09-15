

using ProduccionBack.Data.Utils;
using ProduccionBack.Entities;
using System.Data;
using System.Data.SqlClient;

namespace ProduccionBack.Data
{
    public class OrdenRepository : IOrdenRepository
    {
        public bool CancelarOrden(int nro)
        {
            bool aux = true;
            SqlConnection conexion = DataHelper.GetInstance().GetConnection();
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_CANCELAR_ORDEN", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nro", nro);
                aux = cmd.ExecuteNonQuery() == 1;
                conexion.Close();
            }
            catch (Exception)
            {
                aux = false;
            }
            return aux;
        }

        public bool CrearOrden(OrdenProduccion orden)
        {
            bool aux = true;
            SqlConnection conexion = DataHelper.GetInstance().GetConnection();
            SqlTransaction t = null;
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                SqlCommand cmd = new SqlCommand("SP_INSERTAR_MAESTRO", conexion, t);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@nro_orden", SqlDbType.Int);
                p.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(p);
                cmd.Parameters.AddWithValue("@fecha", orden.Fecha);
                cmd.Parameters.AddWithValue("@modelo", orden.Modelo);
                cmd.Parameters.AddWithValue("@estado", orden.Estado);
                cmd.Parameters.AddWithValue("@cantidad", orden.Cantidad);
                cmd.ExecuteNonQuery();

                int nroOrden = (int)p.Value;

                foreach (DetalleOrden det in orden.ListaDetalles)
                {
                    SqlCommand cmd2 = new SqlCommand("SP_INSERTAR_DETALLE", conexion, t);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@nro_orden", nroOrden);
                    cmd2.Parameters.AddWithValue("@id", det.Id);
                    cmd2.Parameters.AddWithValue("@componente", det.Componente.Codigo);
                    cmd2.Parameters.AddWithValue("@cantidad", det.Cantidad);
                    cmd2.ExecuteNonQuery();

                }
                t.Commit();
            }
            catch (Exception ex)
            {
                if (t != null)
                {
                    aux = false;
                    t.Rollback();
                }
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }


            return aux;
        }

        public List<OrdenProduccion> ObtenerOrdenes(DateTime? fecha, string estado)
        {
            var parameters = new List<ParameterSQL>();
            if (fecha != null && !fecha.HasValue)
                parameters.Add(new ParameterSQL("@fecha", DBNull.Value));
            else
                parameters.Add(new ParameterSQL("@fecha", fecha));

            if (string.IsNullOrEmpty(estado))
                parameters.Add(new ParameterSQL("@estado", DBNull.Value));
            else
                parameters.Add(new ParameterSQL("@estado", estado));

            DataTable tabla = DataHelper.GetInstance().ExecuteSPQuery("SP_CONSULTAR_ORDENES", parameters);
            var lst = new List<OrdenProduccion>();


            foreach (DataRow row in tabla.Rows)
            {
                var c = new OrdenProduccion()
                {
                    Nro = int.Parse(row["nro_orden"].ToString()),
                    Fecha = DateTime.Parse(row["fecha"].ToString()),
                    Modelo = row["modelo"].ToString(),
                    Estado = row["estado"].ToString(),
                    Cantidad = int.Parse(row["cantidad"].ToString())
                };
                lst.Add(c);
            }

            return lst;

        }
    }
}
