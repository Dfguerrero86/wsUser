using System;
using System.Collections.Generic;
using Npgsql;

namespace wsUser
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public Int64 getCountPersonas()
        {
            string connectionString = "Server=127.0.0.1; Port=5432;Database=informatica;User Id=postgres;Password=admin;";
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            conn.Open();
            string sql = "SELECT count(*) FROM persona";
            var cmd = new NpgsqlCommand(sql, conn);
            Int64 countPersonas=(Int64)cmd.ExecuteScalar();
            conn.Close();
            return countPersonas;
        }

        public String getApellidoPersona(String documento)
        {
            string connectionString = "Server=127.0.0.1; Port=5432;Database=informatica;User Id=postgres;Password=admin;";
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            conn.Open();
            string sql = "SELECT primer_apellido FROM persona where numero_documento='"+documento+"'";
            var cmd = new NpgsqlCommand(sql, conn);
            String apellidoPersona = "";
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
                apellidoPersona=dr[0].ToString();
            conn.Close();
            return apellidoPersona;
        }

        public Int64 addPersona(Persona persona)
        {
            string connectionString = "Server=127.0.0.1; Port=5432;Database=informatica;User Id=postgres;Password=admin;";
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            conn.Open();
            Int64 res = 0;
            using (var cmd = new NpgsqlCommand("INSERT INTO persona(tipo_documento,numero_documento,primer_nombre,primer_apellido,grupo_sanguineo,sexo,direccion,celular,segundo_nombre,segundo_apellido) VALUES (@tipo_documento,@numero_documento, @primer_nombre, @primer_apellido,@grupo_sanguineo,@sexo,@direccion,@celular,@segundo_nombre,@segundo_apellido)", conn))
            {
                cmd.Parameters.AddWithValue("tipo_documento", persona.TipoDocumento);
                cmd.Parameters.AddWithValue("numero_documento", persona.NumeroDocumento);
                cmd.Parameters.AddWithValue("primer_nombre", persona.PrimerNombre);
                cmd.Parameters.AddWithValue("primer_apellido", persona.PrimerApellido);
                cmd.Parameters.AddWithValue("grupo_sanguineo", persona.GrupoSanguineo);
                cmd.Parameters.AddWithValue("sexo", persona.Sexo);
                cmd.Parameters.AddWithValue("direccion", persona.Direccion);
                cmd.Parameters.AddWithValue("celular", persona.Celular);
                cmd.Parameters.AddWithValue("segundo_nombre", persona.SegundoNombre);
                cmd.Parameters.AddWithValue("segundo_apellido", persona.SegundoApellido);
                res=cmd.ExecuteNonQuery();
            }
            return res;
        }
    }
}
