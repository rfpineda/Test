using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class PerfilAD : Base
    {
        public PerfilAD() : base()
        {

        }
        public Perfil ObtenerPerfil(int idPerfil)
        {
            Perfil perfil = new Perfil();
            using (var bd = new Base())
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlDataReader reader;
                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "ObtenerPerfil";
                    comando.Parameters.Add(new SqlParameter("@idPerfil", idPerfil));
                    reader = comando.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            perfil.IdPerfil = Convert.ToByte(reader["IdPerfil"]);
                            perfil.Descripcion = Convert.ToString(reader["Descripcion"]);
                            perfil.Codigo = Convert.ToString(reader["Codigo"]);
                        }
                    }
                    finally
                    {
                        reader.Close();
                    }

                    bd.ConfirmarTransaccion();
                }
                catch (Exception)
                {
                    bd.RevertirTransaccion();
                    throw;
                }
            }
            return perfil;
        }
        public List<Perfil> ListarPerfiles()
        {
            List<Perfil> perfiles = new List<Perfil>();
            using (var bd = new Base())
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlDataReader reader;
                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "ListarPerfil";
                    reader = comando.ExecuteReader();
                    try
                    {
                        Perfil perfil;
                        while (reader.Read())
                        {
                            perfil = new Perfil()
                            {
                                IdPerfil = Convert.ToByte(reader["IdProducto"]),
                                Descripcion = Convert.ToString(reader["Descripcion"]),
                                Codigo = Convert.ToString(reader["Codigo"])
                            };
                            perfiles.Add(perfil);
                        };
                    }
                    finally
                    {
                        try
                        {
                            reader.Close();
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }
                    bd.ConfirmarTransaccion();
                }
                catch (Exception)
                {
                    bd.RevertirTransaccion();
                    throw;
                }
            }
            return perfiles;
        }
    }
}
