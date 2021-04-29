using System;
using System.Collections.Generic;
using Npgsql;

namespace wsUser
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public Int64 countPersonas()
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

        public List<Persona> getPersonas()
        {
            string connectionString = "Server=127.0.0.1; Port=5432;Database=informatica;User Id=postgres;Password=admin;";
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            conn.Open();
            string sql = "SELECT * FROM persona";
            var cmd = new NpgsqlCommand(sql, conn);
            List <Persona> personas = new List<Persona>();
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Persona persona = new Persona();
                persona.TipoDocumento = dr[0].ToString();
                persona.NumeroDocumento = dr[1].ToString();
                persona.GrupoSanguineo = dr[2].ToString();
                persona.Sexo = dr[3].ToString();
                persona.PrimerNombre = dr[4].ToString();
                persona.SegundoNombre = dr[5].ToString();
                persona.PrimerApellido = dr[6].ToString();
                persona.SegundoApellido = dr[7].ToString();
                persona.Direccion = dr[8].ToString();
                persona.Celular = dr[9].ToString();
                personas.Add(persona);
            }
            conn.Close();
            return personas;
        }

        public String getApellidoPersona(String documento)
        {
            string connectionString = "Server=127.0.0.1; Port=5432;Database=informatica;User Id=postgres;Password=admin;";
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            conn.Open();
            string sql = "SELECT primer_apellido FROM persona where numero_documento=@numero_documento";
            var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("numero_documento", documento);
            String apellidoPersona = "";
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
                apellidoPersona=dr[0].ToString();
            conn.Close();
            return apellidoPersona;
        }

        public Persona getPersona(String documento)
        {
            string connectionString = "Server=127.0.0.1; Port=5432;Database=informatica;User Id=postgres;Password=admin;";
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            conn.Open();
            string sql = "SELECT * FROM persona where numero_documento=@numero_documento";
            var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("numero_documento", documento);
            Persona persona = new Persona();
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                persona.TipoDocumento = dr[0].ToString();
                persona.NumeroDocumento = dr[1].ToString();
                persona.GrupoSanguineo= dr[2].ToString();
                persona.Sexo= dr[3].ToString();
                persona.PrimerNombre= dr[4].ToString();
                persona.SegundoNombre = dr[5].ToString();
                persona.PrimerApellido = dr[6].ToString();
                persona.SegundoApellido = dr[7].ToString();
                persona.Direccion = dr[8].ToString();
                persona.Celular= dr[9].ToString();
            }
            conn.Close();
            return persona;
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
                cmd.Parameters.AddWithValue("grupo_sanguineo", ((Object)persona.GrupoSanguineo)??DBNull.Value);
                cmd.Parameters.AddWithValue("sexo", ((Object)persona.Sexo) ?? DBNull.Value);
                cmd.Parameters.AddWithValue("direccion", ((Object)persona.Direccion) ?? DBNull.Value);
                cmd.Parameters.AddWithValue("celular", ((Object)persona.Celular) ?? DBNull.Value);
                cmd.Parameters.AddWithValue("segundo_nombre", ((Object)persona.SegundoNombre) ?? DBNull.Value);
                cmd.Parameters.AddWithValue("segundo_apellido", ((Object)persona.SegundoApellido) ?? DBNull.Value);
                res =cmd.ExecuteNonQuery();
            }
            return res;
        }

        public Int64 deletePersona(String documento)
        {
            string connectionString = "Server=127.0.0.1; Port=5432;Database=informatica;User Id=postgres;Password=admin;";
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            conn.Open();
            Int64 res = 0;
            using (var cmd = new NpgsqlCommand("DELETE FROM persona where numero_documento=@numero_documento", conn))
            {
                cmd.Parameters.AddWithValue("numero_documento", documento);
                res = cmd.ExecuteNonQuery();
            }
            return res;
        }

        public Int64 updatePersona(Persona persona)
        {
            string connectionString = "Server=127.0.0.1; Port=5432;Database=informatica;User Id=postgres;Password=admin;";
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            conn.Open();
            Int64 res = 0;
            using (var cmd = new NpgsqlCommand("UPDATE persona SET (primer_nombre,primer_apellido,grupo_sanguineo,sexo,direccion,celular,segundo_nombre,segundo_apellido)=(@primer_nombre,@primer_apellido,@grupo_sanguineo,@sexo,@direccion,@celular,@segundo_nombre,@segundo_apellido) where numero_documento=@numero_documento", conn))
            {
                cmd.Parameters.AddWithValue("primer_nombre", persona.PrimerNombre);
                cmd.Parameters.AddWithValue("primer_apellido", persona.PrimerApellido);
                cmd.Parameters.AddWithValue("grupo_sanguineo", ((Object)persona.GrupoSanguineo) ?? DBNull.Value);
                cmd.Parameters.AddWithValue("sexo", ((Object)persona.Sexo) ?? DBNull.Value);
                cmd.Parameters.AddWithValue("direccion", ((Object)persona.Direccion) ?? DBNull.Value);
                cmd.Parameters.AddWithValue("celular", ((Object)persona.Celular) ?? DBNull.Value);
                cmd.Parameters.AddWithValue("segundo_nombre", ((Object)persona.SegundoNombre) ?? DBNull.Value);
                cmd.Parameters.AddWithValue("segundo_apellido", ((Object)persona.SegundoApellido) ?? DBNull.Value);
                cmd.Parameters.AddWithValue("numero_documento", persona.NumeroDocumento);
                res = cmd.ExecuteNonQuery();
            }
            return res;
        }
    }
}
