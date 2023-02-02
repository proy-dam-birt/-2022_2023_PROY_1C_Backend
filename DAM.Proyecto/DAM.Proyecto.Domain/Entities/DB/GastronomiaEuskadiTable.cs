using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using static System.Formats.Asn1.AsnWriter;

namespace DAM.Proyecto.Domain.Entities.DB
{
    public class GastronomiaEuskadiTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentDescription { get; set; }
        public string? TemplateType { get; set; }
        public string? Locality { get; set; }
        public string? QualityQ { get; set; }
        public string? QualityIconDescription { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Marks { get; set; }
        public string? Physical { get; set; }
        public string? Visual { get; set; }
        public string? Auditive { get; set; }
        public string? Intellectual { get; set; }
        public string? Organic { get; set; }
        public string? QualityAssurance { get; set; }
        public string? TourismEmail { get; set; }
        public string? Web { get; set; }
        public string? Room { get; set; }
        public string? ProductClub { get; set; }
        public string? Visit { get; set; }
        public string? Capacity { get; set; }
        public string? Store { get; set; }
        public string? PostalCode { get; set; }
        public string? RestorationType { get; set; }
        public string? Recomended { get; set; }
        public string? RecomendedURLIcon { get; set; }
        public string? RecomendedIconDescription { get; set; }
        public string? Restaurant { get; set; }
        public string? Bodega { get; set; }
        public string? MichelinStar { get; set; }
        public string? RepsolSun { get; set; }
        public string? Latitudelongitude { get; set; }
        public string? Latwgs84 { get; set; }
        public string? Lonwgs84 { get; set; }
        public string? Municipality { get; set; }
        public string? Municipalitycode { get; set; }
        public string? Territory { get; set; }
        public string? Territorycode { get; set; }
        public string? Country { get; set; }
        public string? Countrycode { get; set; }
        public string? FriendlyUrl { get; set; }
        public string? PhysicalUrl { get; set; }
        public string? DataXML { get; set; }
        public string? MetadataXML { get; set; }
        public string? ZipFile { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public void Update(GastronomiaEuskadiTable src)
        {
            if (src == null)
                throw new ArgumentNullException("Source orderline is null");

            this.DocumentName = DocumentName;
            this.DocumentDescription = DocumentDescription;
            this.TemplateType = TemplateType;
            this.Locality = Locality;
            this.QualityQ = QualityQ;
            this.QualityIconDescription = QualityIconDescription;
            this.Phone = Phone;
            this.Address = Address;
            this.Marks = Marks;
            this.Physical = Physical;
            this.Visual = Visual;
            this.Auditive = Auditive;
            this.Intellectual = Intellectual;
            this.Organic = Organic;
            this.QualityAssurance = QualityAssurance;
            this.TourismEmail = TourismEmail;
            this.Web = Web;
            this.Room = Room;
            this.ProductClub = ProductClub;
            this.Visit = Visit;
            this.Capacity = Capacity;
            this.Store = Store;
            this.PostalCode = PostalCode;
            this.RestorationType = RestorationType;
            this.Recomended = Recomended;
            this.RecomendedURLIcon = RecomendedURLIcon;
            this.RecomendedIconDescription = RecomendedIconDescription;
            this.Restaurant = Restaurant;
            this.MichelinStar = MichelinStar;
            this.RepsolSun = RepsolSun;
            this.Latitudelongitude = Latitudelongitude;
            this.Latwgs84 = Latwgs84;
            this.Lonwgs84 = Lonwgs84;
            this.Municipality = Municipality;
            this.Municipalitycode = Municipalitycode;
            this.Territory = Territory;
            this.Territorycode = Territorycode;
            this.Country = Country;
            this.Countrycode = Countrycode;
            this.FriendlyUrl = FriendlyUrl;
            this.PhysicalUrl = PhysicalUrl;
            this.DataXML = DataXML;
            this.MetadataXML = MetadataXML;
            this.ZipFile = ZipFile;
            this.UpdatedDateTime = DateTime.Now;
        }
    }
}
