using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAM.Proyecto.Domain.Entities.API;

namespace DAM.Proyecto.Domain.Entities.DB
{
    public class ImagesTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ImageTitle { get; set; }
        public byte[]? ImageData { get; set; }

        [Required]
        public long EventoEuskadiId { get; set; }

        [ForeignKey("EventoEuskadiId")]
        public EventoEuskadiTable EventoEuskadiTable { get; set; }


        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public void Update(ImagesTable src)
        {
            if (src == null)
                throw new ArgumentNullException("Source orderline is null");

            this.ImageTitle = ImageTitle;
            this.ImageData = ImageData;
            this.UpdatedDateTime = DateTime.Now;
        }
    }
}
