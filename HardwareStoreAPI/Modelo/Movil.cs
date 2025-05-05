using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HardwareStoreAdmin.Enumerado;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStoreAPI.Modelo
{
    public class Movil : Producto
    {
        public virtual DescripcionPortatilMovil DescripcionPortatilMovil { get; set; }
        public Movil(string imageUrl, string companyBrand, string nameProduct, string category, double price)
            : base(imageUrl, companyBrand, nameProduct, category, price) {}

        public Movil() { }
    }
}
