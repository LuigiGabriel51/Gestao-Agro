using GestaoAgro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAgro.ViewModels.Forms
{
    public partial class FormNewVaccineViewModel : BaseViewModel
    {
        public FormNewVaccineViewModel
            (
                OperationStateService operationStateService,
                DBService dBService
            )
            :
            base 
            (
                dBService: dBService,
                operationStateService: operationStateService
            )
        {

        }
    }
}
