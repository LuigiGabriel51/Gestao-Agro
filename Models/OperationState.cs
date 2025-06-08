using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAgro.Models
{
    public class OperationState : ObservableObject

    {
        #region generic properties
        public bool IsGoBack { get; set; }
        public DataRepository DataRepository { get; set; }

        #endregion generic properties

        #region observable properties


        #endregion observable properties
    }
}
