using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Editor_WPF
{
    public interface ILoader<T> where T : class
    {
        List<T> GetWeaponsFromFile(string filePath);
    }
}
