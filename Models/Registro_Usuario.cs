namespace Compras.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Registro_Usuario
    {
        [Key]
        public int idUsuario { get; set; }

        public int? idCarrito { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(100)]
        public string Correo { get; set; }

        [Required]
        [StringLength(10)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(50)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(50)]
        public string Contraseña { get; set; }

        public DateTime fecha { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] foto { get; set; }

        [StringLength(100)]
        public string Tipo_User { get; set; }
    }
}
