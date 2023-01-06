using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Paging
{
    public class BasePageableModel
    {
        public int Index { get; set; }//Kaçıncı sayfadayım.
        public int Size { get; set; }//Bir sayfada kaç data var.
        public int Count { get; set; }//Toplamda kaçtane data var.
        public int Pages { get; set; }//Toplamda kaçtane sayfa var.
        public bool HasPrevious { get; set; }//Önceki dayfa var mı.
        public bool HasNext { get; set; }//Sonraki sayfa var mı.

    }
}
