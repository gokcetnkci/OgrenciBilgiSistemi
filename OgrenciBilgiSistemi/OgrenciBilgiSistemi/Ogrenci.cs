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
    
    public partial class Ogrenci
    {
        public int OgrId { get; set; }
        public Nullable<int> OgrNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Tc { get; set; }
        public Nullable<int> BolumId { get; set; }
        public Nullable<int> KayityapanID { get; set; }
        public Nullable<System.DateTime> KayitYapilantarih { get; set; }
        public Nullable<System.DateTime> DogumTarih { get; set; }
        public Nullable<short> Cinsiyet { get; set; }
        public Nullable<short> AktifPasif { get; set; }
        public string Email { get; set; }
    
        public virtual Bolum Bolum { get; set; }
        public virtual Ogretmen Ogretmen { get; set; }
    }
}
