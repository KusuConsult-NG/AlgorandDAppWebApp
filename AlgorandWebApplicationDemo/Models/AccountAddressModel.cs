using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorandWebApplicationDemo.Models
{
    public class AccountAddressModel
    {
        [Key]
        public int Id { get; set; }
        public string AccountAddress { get; set; }
        public string MnemonicKey { get; set; }

    }
}
