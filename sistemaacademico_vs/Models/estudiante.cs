//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sistemaacademico_vs.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class estudiante
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public estudiante()
        {
            this.matricula = new HashSet<matricula>();
        }
    
        public int id_estudiante { get; set; }
        public string nombre { get; set; }
        public string carrera { get; set; }
        public int semestre { get; set; }
        public int telefono { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<matricula> matricula { get; set; }
    }
}