using Domain.Constants;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class PandaDocDocument
    {
        public void Share()
        {
            Process |= PandaDocProcess.Shared;
        }

        public void Send(DateTime expiresAt)
        {
            ExpiresAt = expiresAt;
            Process |= PandaDocProcess.Sent;
            Status = PandaDocStatus.DOCUMENT_SENT;
        }

        public void SaveToDisk()
        {
            Process |= PandaDocProcess.Saved;
        }
    }
}
