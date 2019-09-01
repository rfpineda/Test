using System;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class Base : IDisposable
    {
        private readonly string _cadenaDeConexion;
        private SqlConnection _conexion;
        private SqlTransaction _transaccion;

        public Base()
        {
            _cadenaDeConexion = System.Configuration.ConfigurationManager.ConnectionStrings["DBABC"].ConnectionString;
        }
        public bool ExisteTransaccion
        {
            get { return _transaccion != null; }
        }
        public void Dispose()
        {
            if (_transaccion != null)
                _transaccion.Dispose();

            if (_conexion != null)
                _conexion.Dispose();
        }
        
        public void IniciarTransaccion()
        {
            if (!ExisteTransaccion)
            {
                _conexion = new SqlConnection(_cadenaDeConexion);
                _conexion.Open();
                _transaccion = _conexion.BeginTransaction();
            }
        }

        public void ConfirmarTransaccion()
        {
            if (ExisteTransaccion)
                _transaccion.Commit();
        }

        public void RevertirTransaccion()
        {
            if (ExisteTransaccion)
                _transaccion.Rollback();
        }
    }
}
