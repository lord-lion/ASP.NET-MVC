//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP.NET_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AUTEUR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AUTEUR()
        {
            this.LIVRES = new HashSet<LIVRE>();
        }
    
        public int ID_AUTEUR { get; set; }
        public string NOM_AUTEUR { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LIVRE> LIVRES { get; set; }
    }
}
