using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cur_21_MVVM.Models;
using Xamarin.Forms;

namespace Cur_21_MVVM.UI
{
    public class CustomDataTemplateSelector : DataTemplateSelector
    {

        DataTemplate _logTemplate = new DataTemplate(typeof(LogTemplate));
        DataTemplate _tecTemplate = new DataTemplate(typeof(TecTemplate));

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            
            var empleado = item as Empleado;
            if (empleado?.Department == "Logs")
            {
                return _logTemplate;
            }

                return _tecTemplate;
        
            }
    }
}
