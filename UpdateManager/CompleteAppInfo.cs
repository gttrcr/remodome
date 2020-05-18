using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateManager
{
    class CompleteAppInfo
    {
        string name = String.Empty;
        string url = String.Empty;
        string number = String.Empty;
        string mess = String.Empty;

        public string AppName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
            }
        }

        public string FileVersion
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        public string Message
        {
            get
            {
                return mess;
            }
            set
            {
                mess = value;
            }
        }
    }
}