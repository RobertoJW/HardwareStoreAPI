using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStoreAPI.Modelo
{
    public class Producto
    {
        [Key] // Key tratará a id_producto como clave primaria y autoincremental
        public int id_producto { get; set; }
        public string imageUrl { get; set; }
        public string companyBrand { get; set; }
        public string nameProduct { get; set; }
        public string category { get; set; }
        public double price { get; set; }


        // relacion uno a muchos
        public virtual ICollection<Movil> Moviles { get; set; }
        public virtual ICollection<Sobremesa> Sobremesas { get; set; }
        public virtual ICollection<Portatil> Portatiles { get; set; }

        // relacion uno a uno
        public virtual DescripcionPortatilMovil DescripcionPortatilMovil { get; set; }
        public virtual DescripcionSobremesa DescripcionSobremesa { get; set; }


        public Producto(string imageUrl, string companyBrand, string nameProduct, string category, double price)
        {
            this.imageUrl = imageUrl;
            this.companyBrand = companyBrand;
            this.nameProduct = nameProduct;
            this.category = category;
            this.price = price;
            this.Moviles = new List<Movil>();
            this.Sobremesas = new List<Sobremesa>();
            this.Portatiles = new List<Portatil>();
        }

        public Producto(){}
    }
}
