//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OgrenciBilgiSistemi
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ogretmen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ogretmen()
        {
            this.Ogrenci = new HashSet<Ogrenci>();
            this.Ogretmen_Ogrenci_Ders = new HashSet<Ogretmen_Ogrenci_Ders>();
        }
    
        public int OgretmenId { get; set; }
        public string OgretmenAdi { get; set; }
        public string Email { get; set; }
        public Nullable<int> BolumId { get; set; }
    
        public virtual Bolum Bolum { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ogrenci> Ogrenci { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ogretmen_Ogrenci_Ders> Ogretmen_Ogrenci_Ders { get; set; }
    }
}