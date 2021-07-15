using System;
using System.Data.SqlClient;

namespace WebApplication2.BD
{
    public class DALTarifa
    {
        DbConnect cnx;

        // CRUD
        public DALTarifa()
        {
            cnx = new DbConnect();
            Console.WriteLine("te has connectado");
        }

        public void InsertTarifa(Tarifa ta)
        {
            try
            {
                string sql = @"INSERT INTO TARIFA 
                    (Nombre, Tipo, Horario)
                    VALUES (@pNombre,
                        @pTipo,
                        @pHorario)";

                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);

                SqlParameter pNombre = new SqlParameter("@pNombre", System.Data.SqlDbType.NVarChar, 50);
                pNombre.Value = ta.Nombre;
                SqlParameter pTipo = new SqlParameter("@pTipo", System.Data.SqlDbType.NVarChar, 50);
                pTipo.Value = ta.Tipo;
                SqlParameter pHorario = new SqlParameter("@pHorario", System.Data.SqlDbType.NVarChar, 50);
                pHorario.Value = ta.Horario;

                cmd.Parameters.Add(pNombre);
                cmd.Parameters.Add(pTipo);
                cmd.Parameters.Add(pHorario);


                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eror Insert");
            }
        }

        public Tarifa SelectTarifaById(int id)
        {
            Tarifa ta = null;

            try
            {
                string sql = "SELECT * FROM TARIFA WHERE IdTarifa=@pId";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);
                SqlParameter pId = new SqlParameter("@pId", id);
                cmd.Parameters.Add(pId);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ta = new Tarifa();
                    ta.Nombre = (string)dr["Nombre"];
                    ta.Tipo = (string)dr["Tipo"];
                    ta.Horario = (string)dr["Horario"];                   
                    ta.IdTarifa = (int)dr["IdTarifa"];
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error en Insert: " + ex.Message);
            }

            return ta;
        }

        public void UpdateTarifa(Tarifa ta)
        {
            try
            {
                string sql = @"UPDATE USUARIO
                SET Nombre = @pNombre,                                   
                    Tipo = @pTipo,
                    Horario = @pHorario
                    WHERE IdTarifa = @pId";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);

                SqlParameter pId = new SqlParameter("@pId", ta.IdTarifa);
                SqlParameter pNombre = new SqlParameter("@pNombre", System.Data.SqlDbType.NVarChar, 50);
                SqlParameter pTipo = new SqlParameter("@pTipo", System.Data.SqlDbType.NVarChar, 50);
                SqlParameter pHorario = new SqlParameter("@pHorario", System.Data.SqlDbType.NVarChar, 50);


                cmd.Parameters.Add(pId);
                cmd.Parameters.Add(pNombre);
                cmd.Parameters.Add(pTipo);
                cmd.Parameters.Add(pHorario);


                pNombre.Value = ta.Nombre;
                pTipo.Value = ta.Tipo;
                pHorario.Value = ta.Horario;


                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error en Insert: " + ex.Message);
            }
        }

        public void DeleteTarifa(int id)
        {
            try
            {
                string sql = "DELETE FROM TARIFA WHERE IdTarifa = @pId";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);

                SqlParameter pId = new SqlParameter("@pId", id);
                cmd.Parameters.Add(pId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error en Insert: " + ex.Message);
            }

        }
    }
}