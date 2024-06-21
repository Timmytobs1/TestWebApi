using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestWebApi.Models
{
    [Index("StateName", IsUnique = true)]
    [Index("CapitalName", IsUnique = true)]
    public class StateAndCapital
    {

        public Guid Id { get; set; }
        public string StateName { get; set; } = string.Empty;
        public string CapitalName { get; set; } = string.Empty ;
     
    }
}
