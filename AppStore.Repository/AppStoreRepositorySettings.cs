using AppStore.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Repository
{
    public class AppStoreRepositorySettings : IAppStoreRepositorySettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
