using ProduccionBack.Data.Utils;
using ProduccionBack.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduccionBack.Data
{
    public class ComponenteRepository : IComponenteRepository
    {
        public bool Create(Componente oComponente)
        {
            var lst = new List<ParameterSQL>();
            lst.Add(new ParameterSQL("@nombre", oComponente.Nombre));
            var helper = DataHelper.GetInstance();
            return helper.ExecuteSPDML("SP_INSERTAR_COMPONENTE", lst) > 0;
        }

        public bool Delete(int id, string? motivo)
        {
            var lst = new List<ParameterSQL>();
            lst.Add(new ParameterSQL("@codigo", id));
            lst.Add(new ParameterSQL("@motivo", motivo));

            var helper = DataHelper.GetInstance();
            return helper.ExecuteSPDML("SP_REGISTRAR_BAJA_COMPONENTE", lst) > 0;
        }

        public List<Componente> GetAll()
        {
            var lst = new List<Componente>();
            var helper = DataHelper.GetInstance();
            var table = helper.ExecuteSPQuery("SP_CONSULTAR_COMPONENTES", null);

            foreach (DataRow item in table.Rows)
            {
                var componente = new Componente();
                componente.Codigo = int.Parse(item["codigo"].ToString());
                componente.Nombre = item["nombre"].ToString();
                if (item["fecha_baja"] != DBNull.Value)
                    componente.FechaBaja = DateTime.Parse(item["fecha_baja"].ToString());
                if(item["motivo_baja"] != DBNull.Value)
                    componente.MotivoBaja = item["motivo_baja"].ToString();
                lst.Add(componente);
            }
            return lst;
        }

        public Componente? GetById(int id)
        {
            var lst = new List<ParameterSQL>();
            lst.Add(new ParameterSQL("@codigo", id));
            var helper = DataHelper.GetInstance();
            var table = helper.ExecuteSPQuery("SP_CONSULTAR_COMPONENTE_CODIGO", lst);
            Componente componente = null;

            if (table.Rows.Count > 0)
            {
                var item = table.Rows[0];
                componente = new Componente();
                componente.Codigo = int.Parse(item["codigo"].ToString());
                componente.Nombre = item["nombre"].ToString();
                if (item["fecha_baja"] != DBNull.Value)
                    componente.FechaBaja = DateTime.Parse(item["fecha_baja"].ToString());
                if (item["motivo_baja"] != DBNull.Value)
                    componente.MotivoBaja = item["motivo_baja"].ToString();
            }

            return componente;
        }

        public bool Update(Componente oComponente)
        {
            var lst = new List<ParameterSQL>();
            lst.Add(new ParameterSQL("@nombre", oComponente.Nombre));
            lst.Add(new ParameterSQL("@codigo", oComponente.Codigo));
            var helper = DataHelper.GetInstance();
            return helper.ExecuteSPDML("SP_ACTUALIZAR_COMPONENTE", lst) > 0;
        }
    }
}
