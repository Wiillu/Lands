using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.Infrastructure
{
    using ViewModels;
    class InstanceLocator
    {
        //Instanciador de las vistas
        #region Properties
        public MainViewModel Main
        {
            get;
            set;
        }
        #endregion
        //ctor=consturctor
        #region 
        //patron de diseño; instancia una las MainViewModel
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
        #endregion

    }
}
