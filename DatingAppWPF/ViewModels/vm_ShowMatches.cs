using DatingAppWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppWPF.ViewModels
{
    public class vm_ShowMatches
    {
        Person PM { get; set; }

        public vm_ShowMatches()
        {
            PM = new Person();
        }
    }
}
