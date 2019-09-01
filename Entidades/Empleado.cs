namespace Entidades
{
    public class Empleado
    {
        public string IdUsuario { get; set; }
        public int Identificacion { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasena { get; set; }
        
        public string NombreCompleto
        {
            get { return $"{Nombre} {PrimerApellido} {SegundoApellido}"; }
        }
    }
}
