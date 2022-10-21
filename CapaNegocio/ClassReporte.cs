using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaNegocio
{
    public class ClassReporte
    {
        public object ConfigurationManager { get; private set; }


        public DataTable Mas_Vendidos()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Respaldo_PulperiaChinaConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("uspProductosMasVendidos", con);
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        public DataTable BuscaFActurasxFechas(DateTime FInicio, DateTime FFin)
        {
            DataTable dt = new DataTable();

            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Respaldo_PulperiaChinaConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("VentasxFecha", cn);
            cmd.CommandTimeout = 60;

            cmd.Parameters.Add("@Inicio", SqlDbType.DateTime).Value=FInicio;
            cmd.Parameters.Add("@Fin", SqlDbType.DateTime).Value = FFin;
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable IngresadosXFecha(DateTime fInicio, DateTime fFin)
        {
            DataTable dt = new DataTable();

            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Respaldo_PulperiaChinaConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("EntradasProductoXFechas", cn);
            cmd.CommandTimeout = 60;

            cmd.Parameters.Add("@Inicio", SqlDbType.DateTime).Value = fInicio;
            cmd.Parameters.Add("@Fin", SqlDbType.DateTime).Value = fFin;
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable ultimafactura(int idventa)
        {
            DataTable dt = new DataTable();


            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Respaldo_PulperiaChinaConnectionString"].ConnectionString);

            SqlCommand cmd = new SqlCommand("últimaFactura", cn);
            cmd.CommandTimeout = 60;
            cmd.Parameters.Add("@idventa", SqlDbType.Int).Value = idventa;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }

}
