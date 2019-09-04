﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class EmpleadoPerfilAD : Base
    {
        public EmpleadoPerfilAD() : base()
        {

        }
        public List<EmpleadoPerfil> ListarEmpleadoPerfiles()
        {
            List<EmpleadoPerfil> empleadoPerfiles = new List<EmpleadoPerfil>();
            using (var bd = this)
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlDataReader reader;
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = bd.Conexion;
                    comando.Transaction = bd.Transaccion;
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "administracion.ListarEmpleadoPerfil";
                    reader = comando.ExecuteReader();
                    try
                    {
                        EmpleadoPerfil empleadoPerfil;
                        while (reader.Read())
                        {
                            empleadoPerfil = new EmpleadoPerfil()
                            {
                                Empleado = new Empleado() { IdUsuario = Convert.ToString(reader["IdUsuario"]) },
                                Perfil = new Perfil() { IdPerfil = Convert.ToByte(reader["IdPerfil"]) }
                            };
                            empleadoPerfiles.Add(empleadoPerfil);
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
            return empleadoPerfiles;
        }
        public void InsertarEmpleadoPerfil(EmpleadoPerfil empleadoPerfil)
        {
            using (var bd = this)
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlCommand comando = new SqlCommand();
                    comando.Connection = bd.Conexion;
                    comando.Transaction = bd.Transaccion;
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "administracion.InsertarEmpleadoPerfil";
                    comando.Parameters.Add(new SqlParameter("@idUsuario", empleadoPerfil.Empleado.IdUsuario));
                    comando.Parameters.Add(new SqlParameter("@idPerfil", empleadoPerfil.Perfil.IdPerfil));
                    comando.ExecuteNonQuery();

                    bd.ConfirmarTransaccion();
                }
                catch (Exception)
                {
                    bd.RevertirTransaccion();
                    throw;
                }
            }
        }
        public void EliminarEmpleadoPerfilPorEmpleado(string idUsuario)
        {
            using (var bd = this)
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlCommand comando = new SqlCommand();
                    comando.Connection = bd.Conexion;
                    comando.Transaction = bd.Transaccion;
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "administracion.EliminarEmpleadoPerfilPorEmpleado";
                    comando.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
                    comando.ExecuteNonQuery();

                    bd.ConfirmarTransaccion();
                }
                catch (Exception)
                {
                    bd.RevertirTransaccion();
                    throw;
                }
            }
        }
    }
}
