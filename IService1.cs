using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace wsUser
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        Int64 getCountPersonas();

        [OperationContract]
        String getApellidoPersona(String documento);
    }

    [DataContract]
    public class Persona
    {
        private string tipoDocumento;
        private string numeroDocumento;
        private string grupoSanguineo;
        private string sexo;
        private string primerApellido;
        private string segundoApellido;
        private string primerNombre;
        private string segundoNombre;
        private string domicilio;
        private string telefono;
        private string fechaNacimiento;
        private string correoElectronico;
        private string correoElectronicoAlterno;
        private string celular;
        private string estadoCivil;

        [DataMember]
        public string TipoDocumento
        {
            get { return tipoDocumento; }
            set { tipoDocumento = value; }
        }
        [DataMember]
        public string NumeroDocumento
        {
            get { return numeroDocumento; }
            set { numeroDocumento = value; }
        }
        [DataMember]
        public string GrupoSanguineo
        {
            get { return grupoSanguineo; }
            set { grupoSanguineo = value; }
        }
        [DataMember]
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        [DataMember]
        public string PrimerApellido
        {
            get { return primerApellido; }
            set { primerApellido = value; }
        }
        [DataMember]
        public string SegundoApellido
        {
            get { return segundoApellido; }
            set { segundoApellido = value; }
        }
        [DataMember]
        public string PrimerNombre
        {
            get { return primerNombre; }
            set { primerNombre = value; }
        }
        [DataMember]
        public string SegundoNombre
        {
            get { return segundoNombre; }
            set { segundoNombre = value; }
        }
        [DataMember]
        public string Domicilio
        {
            get { return domicilio; }
            set { domicilio = value; }
        }
        [DataMember]
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        [DataMember]
        public string FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }
        [DataMember]
        public string CorreoElectronico
        {
            get { return correoElectronico; }
            set { correoElectronico = value; }
        }
        [DataMember]
        public string CorreoElectronicoAlterno
        {
            get { return correoElectronicoAlterno; }
            set { correoElectronicoAlterno = value; }
        }
        [DataMember]
        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }
        [DataMember]
        public string EstadoCivil
        {
            get { return estadoCivil; }
            set { estadoCivil = value; }
        }
    }
}
