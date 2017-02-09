using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CrudMongoDB.Models
{
    public class Item
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string PaisCodigo { get; set; }

        [Required]
        [Display(Name = "País")]
        public String PaisNome { get; set; }

        [Required]
        [Display(Name = "População")]
        public string PaisPopulacao { get; set; }
        
        [Display(Name = "Data Cadastro")]
        public DateTime DataCadastro { get; set; }
    }
}