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
        public int Pulgadas { get; set; }
        public int Bateria { get; set; }
        public int Camara { get; set; }

        public Movil(string image, string companyBrand, string nameProduct, string category, decimal price, int pulgadas, int bateria, int camara)
            : base(image, companyBrand, nameProduct, category, price)
        {
            this.Pulgadas = pulgadas;
            this.Bateria = bateria;
            this.Camara = camara;
        }

        public Movil() { }
    }
}
